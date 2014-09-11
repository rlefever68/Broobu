using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Iris.Explorer.Contract.Domain;
using log4net;

namespace Iris.Explorer.Business
{
    public class ExplorerBusinessGenerator
    {

        private IEnumerable<Enumeration> _enumerationTypes;
        private IEnumerable<Enumeration> _enumerationLanguages;
        private ILog _logger;
        private IEnumerable<Enumeration> _existingEnumerations;
        private IEnumerable<Perspective> _existingPerspectives;

        public ExplorerBusinessGenerator()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Generate()
        {
            
            _enumerationTypes = GetEnumerationTypes();
            _enumerationLanguages = GetEnumerationLanguages();
            _existingEnumerations = ExplorerRepositoryAgentFactory.CreateEnumerationRepositoryAgent().SelectAll();
            _existingPerspectives = ExplorerRepositoryAgentFactory.CreatePerspectiveRepositoryAgent().SelectAll();
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    if (GenerateTypes() && GenerateLanguages() && GenerateEnumerationItemRoot() && GeneratePerspective())
                    {
                        scope.Complete();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
            }
            return false;
        }

        private bool GeneratePerspective()
        {
            //Create Perspective
            var perspective = new PerspectiveItem() { Id = WorkspaceRoot.Id, ParentId = WorkspaceRoot.Parent, EnumerationId = WorkspaceRootItem.Id };

            //if (PerspectiveItemExists(perspective.Id)) return true;
            if (_existingPerspectives.Select(pers => pers.Id).Contains(perspective.Id)) return true;


            PerspectiveItem perspectiveItemSaved = ExplorerProviderFactory.CreateProvider(ExplorerProviderFactory.Key.Instance).SavePerspectiveItem(perspective);
            if (perspectiveItemSaved != null)
            {
                if (perspectiveItemSaved.HasErrors)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private bool GenerateEnumerationItemRoot()
        {
            if (_existingEnumerations.Select(en => en.Id).Contains(WorkspaceRoot.Id)) return true;

            string typeId = ExplorerDomainGenerator.GetEnumerationTypeId(ExplorerDomainGenerator.EnumBaseType.TreeViewFolder);
            var enumRoot = new Enumeration
            {
                Id = WorkspaceRootItem.Id,
                SortOrder = 0,
                Title = WorkspaceRootItem.Title,
                TypeId = typeId,
                Image = new byte[] { },
                DateModified = DateTime.Now
            };


            var result = ExplorerRepositoryAgentFactory
                .CreateEnumerationRepositoryAgent()
                .Insert(enumRoot);

            return !result.HasErrors;
        }
        /// <summary>
        /// Exists the perspective item ?
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private static bool PerspectiveItemExists(string id)
        {
            if (String.IsNullOrEmpty(id)) return false;
            var exists = ExplorerProviderFactory.CreateProvider(ExplorerProviderFactory.Key.Instance).GetPerspectiveItem(id) != null;
            return exists;
        }

        /// <summary>
        /// Generates the types.
        /// </summary>
        /// <returns></returns>
        private bool GenerateTypes()
        {
            bool result = true;
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (var en in _enumerationTypes)
                {
                    result = SaveEnumeration(en);
                }
                if (result) scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// Gets the enumeration types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Enumeration> GetEnumerationTypes()
        {
            var enumerationTypes = ExplorerDomainGenerator.GetEnumerationItemsTypes();
            return enumerationTypes.Select(enumerationType => new Enumeration
                                                                  {
                                                                      Id = enumerationType.Id,
                                                                      SortOrder = enumerationType.SortOrder,
                                                                      Title = enumerationType.Title,
                                                                      TypeId = enumerationType.TypeId,
                                                                      Image = enumerationType.Image,
                                                                      DateModified = enumerationType.DateModified
                                                                  });
        }

        /// <summary>
        /// Generates the languages.
        /// </summary>
        /// <returns></returns>
        private bool GenerateLanguages()
        {
            if (_enumerationLanguages == null) return true;

            int i = _enumerationLanguages.Count(SaveEnumeration);
            var result = i == _enumerationLanguages.Count();
            return result;
        }

        /// <summary>
        /// Gets the enumeration languages.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Enumeration> GetEnumerationLanguages()
        {
            var enumerationItemsLanguages = ExplorerDomainGenerator.GetEnumerationItemsLanguages();
            return enumerationItemsLanguages.Select(enumerationItemLanguage => new Enumeration
                                                                                   {
                                                                                       Id = enumerationItemLanguage.Id,
                                                                                       SortOrder = enumerationItemLanguage.SortOrder,
                                                                                       Title = enumerationItemLanguage.Title,
                                                                                       TypeId = enumerationItemLanguage.TypeId,
                                                                                       Image = enumerationItemLanguage.Image,
                                                                                       DateModified = enumerationItemLanguage.DateModified
                                                                                   });

        }

        /// <summary>
        /// Gets the enumeration items languages for descriptions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Enumeration> GetEnumerationItemsLanguagesForDescriptions()
        {
            var enumerationItemsLanguages = ExplorerDomainGenerator.GetEnumerationItemsLanguagesForDescriptions();
            return enumerationItemsLanguages.Select(enumerationItemLanguage => new Enumeration
            {
                Id = enumerationItemLanguage.Id,
                SortOrder = enumerationItemLanguage.SortOrder,
                Title = enumerationItemLanguage.Title,
                TypeId = enumerationItemLanguage.TypeId,
                Image = enumerationItemLanguage.Image,
                DateModified = enumerationItemLanguage.DateModified
            });
        }

        /// <summary>
        /// Saves the enumeration.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns></returns>
        private bool SaveEnumeration(Enumeration enumeration)
        {
            //if (EnumerationExists(enumeration.Id)) return true;
            if (_existingEnumerations.Select(en => en.Id).Contains(enumeration.Id)) return true;
            IEnumerationRepositoryAgent agent = ExplorerRepositoryAgentFactory.CreateEnumerationRepositoryAgent();
            try
            {
                agent.Insert(enumeration);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("agent.Insert throws exception\n" + ex);
                return false;
            }
        }

        /// <summary>
        /// Saves the enumeration.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns></returns>
        private bool SaveEnumeration(IEnumerationRepositoryAgent agent, Enumeration enumeration)
        {
            if (EnumerationExists(agent, enumeration.Id)) return true;
            try
            {
                agent.Insert(enumeration);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("agent.Insert throws exception\n" + ex);
                return false;
            }
        }

        /// <summary>
        /// Enumerations the exists.
        /// </summary>
        /// <param name="agent">The agent.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private bool EnumerationExists(IEnumerationRepositoryAgent agent, string id)
        {
            if (String.IsNullOrEmpty(id)) return false;
            return agent.SelectById(id) != null;
        }

        /// <summary>
        /// Enumerations the exists.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private bool EnumerationExists(string id)
        {
        }

        ///// <summary>
        ///// Descriptions the item exists.
        ///// </summary>
        ///// <param name="agent">The agent.</param>
        ///// <param name="descriptionItem">The description item.</param>
        ///// <returns></returns>
        //private  bool DescriptionItemExists(IMediaAgent agent, DescriptionItem descriptionItem)
        //{
        //    return agent.GetDescriptionItem(descriptionItem.Id) != null;
        //}

        ///// <summary>
        ///// Saves the description item.
        ///// </summary>
        ///// <param name="agent">The agent.</param>
        ///// <param name="descriptionItem">The description item.</param>
        ///// <returns></returns>
        //private  bool SaveDescriptionItem(IMediaAgent agent, DescriptionItem descriptionItem)
        //{
        //    if (!DescriptionItemExists(agent, descriptionItem)) return true;
        //    try
        //    {
        //        agent.SaveDescription(descriptionItem);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("agent.SaveDescriptionItem throws exception\n" + ex);
        //        return false;
        //    }
        //}


    }
}
