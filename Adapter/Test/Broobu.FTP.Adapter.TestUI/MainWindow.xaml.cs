using System;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using Pms.FTP.Adapter.Contract.Agent;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();


            _cbxAgentType.Items.Clear();
            foreach (object agentType in Enum.GetValues(typeof(FTPAgentFactory.AgentType)))            
                _cbxAgentType.Items.Add(agentType);

            _cbxAgentType.SelectedItem = FTPAgentFactory.AgentType.Default;


            _tbxUser.Text = "FtpUsr";
            _tbxPassword.Text = "Ftp#546;";
            _tbxAddress.Text = "ftp://localhost";
            _tbxPath.IsEnabled = false;
            _tbxFileToSend.Text = @"C:\Temp\_DSC4122.jpg";
            _tbxServerFileNameForUpload.Text = "MineField.jpg";
            _tbxServerFileNameForDownload.Text = "MineField.jpg";
            _tbxSaveTo.Text = @"C:\Temp\MineFieldReceived.jpg";

            _lstFiles.Items.Clear();
        }

        private void BtnBrowseClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            _tbxFileToSend.Text = openFileDialog.FileName;
        }

        private void BtnSendClick(object sender, RoutedEventArgs e)
        {
            Uploader uploader = new Uploader((FTPAgentFactory.AgentType) _cbxAgentType.SelectedItem);
            string messageString;
            uploader.UploadFile(_tbxFileToSend.Text, _tbxServerFileNameForUpload.Text, GetFtpParameters(), out messageString);
            MessageBox.Show(messageString);
        }


        private FtpParameters GetFtpParameters()
        {
            FtpParameters ftpParameters = new FtpParameters();
            ftpParameters.Address = _tbxAddress.Text;
            ftpParameters.User = _tbxUser.Text;
            ftpParameters.Password = _tbxPassword.Text;
            ftpParameters.Port = 21;
           
            return ftpParameters;
        }

        private void BtnSaveToBrowseClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            _tbxSaveTo.Text = saveFileDialog.FileName;
        }

        private void BtnReceiveClick(object sender, RoutedEventArgs e)
        {
            Downloader downloader = new Downloader((FTPAgentFactory.AgentType)_cbxAgentType.SelectedItem);
            string messageString;

            downloader.DownloadFile(_tbxSaveTo.Text, _tbxServerFileNameForDownload.Text, GetFtpParameters(), out messageString);
            MessageBox.Show(messageString);
        }

        private void BtnFileListClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IFTPAgent ftpAgent = FTPAgentFactory.CreateAgent(FTPAgentFactory.AgentType.Default);
                string[] list;

                FtpResponseStatus responseStatus = ftpAgent.NameListOfRemoteDirectory(GetFtpParameters(), String.Empty, out list);


                if (responseStatus.StatusType == StatusType.Succeeded && list != null)
                {
                    _lstFiles.Items.Clear();
                    Array.ForEach(list, fileNameItem => _lstFiles.Items.Add(fileNameItem));
                }else
                {
                    MessageBox.Show(ResponseFormatter.Format(responseStatus));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void _btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IFTPAgent ftpAgent = FTPAgentFactory.CreateAgent(FTPAgentFactory.AgentType.Default);


                bool existing;
                FtpResponseStatus responseStatus = ftpAgent.DeleteIfExists(GetFtpParameters(), _tbxFileToDelete.Text, out existing);

                StringBuilder result = new StringBuilder();
                result.AppendLine(ResponseFormatter.Format(responseStatus));
                result.AppendLine(String.Format("File was existing : '{0}'", existing));

                MessageBox.Show(result.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }
    }
}
