using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Messaging;
using System.ServiceProcess;
using System.Transactions;
using log4net;
using Pms.FileWatcher.WinService.TransactionRouterServiceRef;
using System.Threading;
using Pms.Framework.Domain;

namespace Pms.FileWatcher.WinService
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class FileWatcherService : ServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        private ILog _logger = LogManager.GetLogger(typeof (FileWatcherService));

        /// <summary>
        /// Creates a new instance of the <see cref="T:System.ServiceProcess.ServiceBase"/> class.
        /// </summary>
        /// <remarks></remarks>
        public FileWatcherService()
        {
            InitializeComponent();
            _logger.InfoFormat("Created File Watcher.");
        }


        /// <summary>
        /// 
        /// </summary>
        private static List<string> _backlog = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private FileSystemWatcher _inboxWatcher;


        /// <summary>
        /// Start of the Windows Service
        /// </summary>
        /// <param name="args">Startup Arguments</param>
        /// <remarks></remarks>
        protected override void OnStart(string[] args)
        {
            _logger.InfoFormat("**** Started File Watcher");
            InitiateQueue();
            UpdateBackLog();
            StartWatching();
            StartProcessing();
        }

        /// <summary>
        /// Starts the processing.
        /// </summary>
        /// <remarks></remarks>
        private void StartProcessing()
        {
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                                  {
                                      try
                                      {
                                          while (!wrk.CancellationPending)
                                          {
                                              if (_backlog.Count <= 0)
                                              {
                                                  Thread.Sleep(1000);
                                                  continue;
                                              }
                                              MoveFileToQueue(_backlog[0]);
                                          }
                                      }
                                      catch (Exception ex)
                                      {
                                          string st = (ex.InnerException == null) ? ex.Message : ex.InnerException.Message;
                                          _logger.ErrorFormat(st);
                                      }

                                  };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Initiates the queue.
        /// </summary>
        /// <remarks></remarks>
        private void InitiateQueue()
        {
            _logger.InfoFormat("Initiating Queue");
            // Get MSMQ queue name from app settings in configuration
            string queueName = FileWatcherConfigurationHelper.QueueName;
            // Create the transacted MSMQ queue if necessary.
            if (MessageQueue.Exists(queueName)) return;
            MessageQueue queue= MessageQueue.Create(queueName, true);
            queue.Authenticate = false;
            queue.SetPermissions("EveryOne", MessageQueueAccessRights.FullControl);
        }

        /// <summary>
        /// Starts the watching.
        /// </summary>
        /// <remarks></remarks>
        private void StartWatching()
        {
            _logger.InfoFormat("Watching...");
            _inboxWatcher = new FileSystemWatcher
                                {
                                    Path = FileWatcherConfigurationHelper.InboxPath,
                                    InternalBufferSize = 1024*64-1,
                                    EnableRaisingEvents = true,
                                    IncludeSubdirectories = false,
                                    NotifyFilter =
                                        NotifyFilters.FileName | NotifyFilters.Attributes | NotifyFilters.CreationTime |
                                        NotifyFilters.DirectoryName | NotifyFilters.Security | NotifyFilters.LastWrite |
                                        NotifyFilters.Size
                                };
            _inboxWatcher.Created += OnNewFileCreated;
            _inboxWatcher.Deleted += OnFileDeleted; 
            _inboxWatcher.Renamed += OnFileRenamed;
            _inboxWatcher.Error += OnWatcherError;
        }

        /// <summary>
        /// Called when [file deleted].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            _logger.DebugFormat("Deleted File {0}", e.FullPath);
            _backlog.Remove(e.FullPath);
        }


        /// <summary>
        /// Called when [file renamed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.IO.RenamedEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            _logger.DebugFormat("Renamed File {0} to {1}", e.OldFullPath, e.FullPath);
        }

        /// <summary>
        /// Called when [watcher error].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.IO.ErrorEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void OnWatcherError(object sender, ErrorEventArgs e)
        {
            _logger.ErrorFormat(e.GetException().Message);
            UpdateBackLog();
        }

        /// <summary>
        /// Updates the back log.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateBackLog()
        {
            _logger.InfoFormat("... Updating Backlog ...");
            _backlog.Clear();
            _backlog.AddRange(Directory.EnumerateFiles(FileWatcherConfigurationHelper.InboxPath).Where(f=>!f.EndsWith(".part")));
        }


        /// <summary>
        /// Called when [new file created].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void OnNewFileCreated(object sender, FileSystemEventArgs e)
        {
            _logger.DebugFormat("New File Created {0}", e.FullPath);
            _backlog.Add(e.FullPath);
        }


        /// <summary>
        /// Moves the file to queue.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <remarks></remarks>
        private void MoveFileToQueue(string fullPath)
        {
            _logger.InfoFormat("Moving File {0} to queue", fullPath);

            if (fullPath.Trim().EndsWith(".part"))
            {
                Thread.Sleep(50);
                UpdateBackLog();
                return;
            }

            var clt = new TransactionRouterClient();
            try
            {
                if (CheckFileRestrictions(fullPath))
                {
                    var newFile = new TransactionFileItem
                    {
                        IsZip = CheckFileHelper.IsFileAZip(fullPath),
                        File = File.ReadAllBytes(fullPath),
                        FileName = Path.GetFileName(fullPath)
                    };
                    using (var scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        clt.SubmitTransactionFile(newFile);
                        scope.Complete();

                        File.Move(fullPath,
                                  File.Exists(Path.Combine(FileWatcherConfigurationHelper.ReceivedPath,
                                                           Path.GetFileName(fullPath)))
                                      ? Path.Combine(FileWatcherConfigurationHelper.ReceivedPath, Path.GetFileName(fullPath))
                                      : Path.Combine(FileWatcherConfigurationHelper.ReceivedPath,
                                                     Path.GetFileName(fullPath) + "_" + DateTime.Now.ToFileTimeUtc()));

                        UpdateBackLog();
                    }
                }
                else
                {
                    File.Move(fullPath,
                                  File.Exists(Path.Combine(FileWatcherConfigurationHelper.ErrorPath,
                                                           Path.GetFileName(fullPath)))
                                      ? Path.Combine(FileWatcherConfigurationHelper.ErrorPath, Path.GetFileName(fullPath))
                                      : Path.Combine(FileWatcherConfigurationHelper.ErrorPath,
                                                     Path.GetFileName(fullPath) + "_" + DateTime.Now.ToFileTimeUtc())); 

                    UpdateBackLog();
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex.Message);
            }
            finally
            {
                clt.Close();
            }
        }

        /// <summary>
        /// Checks the file restrictions.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool CheckFileRestrictions(string fullPath)
        {
            //Check FileSize
            var info = new FileInfo(fullPath);
            if (info.Length >= Constants.MaxFileSize)
                return false;
            return true;
        }

        /// <summary>
        /// Stopping of the Windows Service
        /// </summary>
        /// <remarks></remarks>
        protected override void OnStop()
        {
            _inboxWatcher.EnableRaisingEvents = false;
            _inboxWatcher.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public class Constants
        {
            /// <summary>
            /// 
            /// </summary>
            public const long MaxFileSize = 4194304;
        }
        
    }
}
