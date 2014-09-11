using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Transactions;
using log4net;
using Pms.Explorer.Contract.Agent;
using Pms.Explorer.Contract.Domain;
using Pms.Explorer.Contract.Interfaces;
using Pms.Media.Contract.Agent;
using Pms.Media.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Constants;
using EnumBaseType = Pms.Explorer.Contract.Domain.ExplorerDomainGenerator.EnumBaseType;
using Pms.Framework.Domain;

namespace Pms.ManageWorkspaces.Business
{
    public class WorkspaceBrowserBusinessGenerator
    {
        private static readonly ILog Logger;
        private static IExplorerAgent _explorerAgent;
        private static IMediaAgent _mediaAgent;

        private const string DebugWriteLinePrefix = "Pms.ManageWorkspaces.Business.WorkspaceBrowserBusinessGenerator";

        static WorkspaceBrowserBusinessGenerator()
        {
            Logger = LogManager.GetLogger("Pms.ManageWorkspaces.Service");
        }

        /// <summary>
        /// 
        /// </summary> 
        public static bool Generate()
        {
            LogInfo("Generate");

            LogInfo("Creating agents");
            _explorerAgent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            _mediaAgent = MediaAgentFactory.CreateMediaAgent();

            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                LogInfo("Transaction begin");
                try
                {
                    LogInfo("Creating objects; perspectiveItemRoot, enumerationItemRoot and descriptionItems");
                    PerspectiveItem perspectiveItemRoot = GetPerspectiveItemRoot();
                    EnumerationItem enumerationItemRoot = GetEnumerationItemRoot();
                    IEnumerable<DescriptionItem> descriptionItems = GetDescriptionItems();

                    LogInfo("Saving enumerationItemRoot and perspectiveItemRoot");
                    if (SaveEnumerationItem(enumerationItemRoot) && SavePerspectiveItem(perspectiveItemRoot))
                    {
                        var language = CultureInfo.CurrentCulture.Name;
                        var items = from i in descriptionItems
                                    where i.CultureId.Equals(language)
                                    select i;

                        LogInfo("Saving descriptionItems for culture {0}", language);
                        if (SaveDescriptionItems(items))
                        {
                            scope.Complete();
                            return LogInfo("Transaction complete");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return LogError("Method Generate throws exception;\n" + ex);
                }
            }
            return LogError("Generate = false");
        }

        private static PerspectiveItem GetPerspectiveItemRoot()
        {
            return new PerspectiveItem { Id = WorkspaceRoot.Id, ParentId = WorkspaceRoot.Parent, EnumerationId = WorkspaceRootItem.Id };
        }

        private static EnumerationItem GetEnumerationItemRoot()
        {
            string typeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewFolder);
            return new EnumerationItem
                       {
                           Id = WorkspaceRootItem.Id,
                           SortOrder = 0,
                           Title = WorkspaceRootItem.Title,
                           TypeId = typeId,
                           Image = new byte[] { },
                           AdditionalInfoUri = String.Empty
                       };
        }

        private static IEnumerable<DescriptionItem> GetDescriptionItems()
        {
            var items = new[]
                       {
                           new DescriptionItem
                               {
                                   Id = "D79AB2CE-4235-4536-99B9-00BB1D379CAE",
                                   CultureId = "nl-BE",
                                   Title = "Hoofd"
                               },
                           new DescriptionItem
                               {
                                   Id = "9A09B5B0-EE68-4076-A4F4-EBCB21790DE1", 
                                   CultureId = "fr-BE",
                                   Title = "Depart"
                               },
                            new DescriptionItem
                               {
                                   Id = "03847B14-C3F3-49B5-9128-85F17CE866DD",
                                   CultureId = "en",
                                   Title = "Root"
                               }
                       };
            string typeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.WorkspaceItemDescription);
            foreach (DescriptionItem item in items)
            {
                item.ObjectId = WorkspaceRootItem.Id;
                item.TypeId = typeId;
                item.Url = String.Empty;
                item.Blob = new byte[] { };
                item.AdditionalInfoUri = String.Empty;
            }

            return items;
        }

        /// <summary>
        /// Saves the perspective item.
        /// </summary>
        /// <param name="perspectiveItem">The hierarchy.</param>
        private static bool SavePerspectiveItem(PerspectiveItem perspectiveItem)
        {
            if (PerspectiveItemExists(perspectiveItem.Id)) return true;

            LogInfo("Saving perspectiveItem");
            PerspectiveItem perspectiveItemSaved = _explorerAgent.SavePerspectiveItem(perspectiveItem);
            if (perspectiveItemSaved != null)
            {
                if (perspectiveItemSaved.HasErrors)
                {
                    LogInfo("PerspectiveItem      ( " + perspectiveItem + ")");
                    LogInfo("PerspectiveItemSaved ( " + perspectiveItemSaved + ")");
                    return LogError("AllErrors = " + perspectiveItemSaved.AllErrors);
                }
                return LogInfo("SavePerspectiveItem = true");
            }
            return LogError("Method _explorerAgent.SavePerspectiveItem returned null");
        }

        /// <summary>
        /// Saves the enumeration item.
        /// </summary>
        /// <param name="enumerationItem">The hierarchy item.</param>
        private static bool SaveEnumerationItem(EnumerationItem enumerationItem)
        {
            if (EnumerationItemExists(enumerationItem.Id)) return true;

            LogInfo("Saving enumerationItem");
            EnumerationItem enumerationItemSaved = _explorerAgent.SaveEnumerationItem(enumerationItem);
            if (enumerationItemSaved != null)
            {
                if (enumerationItemSaved.HasErrors)
                {
                    LogInfo("EnumerationItem      ( " + enumerationItem + ")");
                    LogInfo("EnumerationItemSaved ( " + enumerationItemSaved + ")");
                    return LogError("AllErrors = " + enumerationItemSaved.AllErrors);
                }
                return LogInfo("SaveEnumerationItem = true");
            }
            return LogError("_explorerAgent.SaveEnumerationItem returned null");
        }

        /// <summary>
        /// Saves the description item.
        /// </summary>
        /// <param name="descriptionItem">The description item.</param>
        private static bool SaveDescriptionItem(DescriptionItem descriptionItem)
        {
            if (DescriptionItemExists(descriptionItem.Id)) return true;

            LogInfo("Saving descriptionItem");
            DescriptionItem descriptionItemSaved = _mediaAgent.SaveDescription(descriptionItem);
            if (descriptionItemSaved != null)
            {
                if (descriptionItemSaved.HasErrors)
                {
                    LogInfo("DescriptionItem      ( " + descriptionItem + ")");
                    LogInfo("DescriptionItemSaved ( " + descriptionItemSaved + ")");
                    return LogError("AllErrors = " + descriptionItemSaved.AllErrors);
                }
                return LogInfo("SaveDescriptionItem = true");
            }
            return LogError("Method SaveDescriptionItem returned null");
        }

        private static bool SaveDescriptionItems(IEnumerable<DescriptionItem> descriptionItems)
        {
            return descriptionItems.Select(SaveDescriptionItem).All(result => result);
        }

        #region Exists methods

        /// <summary>
        /// Exists the perspective item ?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private static bool PerspectiveItemExists(string id)
        {
            if (String.IsNullOrEmpty(id)) return false;
            var exists = _explorerAgent.GetPerspectiveItem(id) != null;
            LogInfo("PerspectiveItemExists(Id = '{0}') = {1}", id, exists);
            return exists;
        }

        /// <summary>
        /// Exists the enumeration item ?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static bool EnumerationItemExists(string id)
        {
            if (String.IsNullOrEmpty(id)) return false;
            var exists = _explorerAgent.GetEnumerationItem(id) != null;
            LogInfo("EnumerationItemExists(Id = '{0}') = {1}", id, exists);
            return exists;
        }

        /// <summary>
        /// Exists the description item ?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private static bool DescriptionItemExists(string id)
        {
            if (String.IsNullOrEmpty(id)) return false;
            var exists = _mediaAgent.GetDescriptionItem(id) != null;
            LogInfo("DescriptionItemExists(Id = '{0}') = {1}", id, exists);
            return exists;
        }

        #endregion // Exists methods

        private static bool LogInfo(string message)
        {
            Debug.WriteLine(DebugWriteLinePrefix + message);
            Logger.Info(message);
            return true;
        }

        private static bool LogInfo(string format, params object[] args)
        {
            Debug.WriteLine(DebugWriteLinePrefix + String.Format(format, args));
            Logger.InfoFormat(format, args);
            return true;
        }

        private static bool LogError(string message)
        {
            Debug.WriteLine(DebugWriteLinePrefix + message);
            Logger.Error(message);
            return false;
        }

        private static bool LogError(string format, params object[] args)
        {
            Debug.WriteLine(DebugWriteLinePrefix + String.Format(format, args));
            Logger.ErrorFormat(format, args);
            return false;
        }
    }
}
