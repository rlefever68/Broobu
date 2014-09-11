// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-06-2014
// ***********************************************************************
// <copyright file="ManageTaxoAgent.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using Broobu.Fx.UI.MVVM;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Networking.Wcf;


namespace Broobu.ManageTaxo.Contract.Agent
{
    /// <summary>
    /// Class ManageTaxoAgent.
    /// </summary>
    class ManageTaxoAgent : DiscoProxy<IManageTaxo>,  IManageTaxoAgent
    {





        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return ManageTaxoServiceConst.Namespace;
        }


        /// <summary>
        /// Gets the translations for object.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetTranslationsForObject(HookItem filter)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetTranslationsForObject(filter);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionTypes()
        {
            var clt = CreateClient();
            try
            {
                return clt.GetDescriptionTypes();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Saves the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        public Description SaveDescription(Description document)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveDescription(document);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the enumerations asynchronous.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="act">The act.</param>
        public void GetEnumerationsAsync(HookItem root, Action<HookItem[]> act)
        {
            HookItem[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetHookItems(root);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };
           
        }

        /// <summary>
        /// Gets the translations for object asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="act">The act.</param>
        public void GetTranslationsForObjectAsync(HookItem filter, Action<DescriptionItem[]> act)
        {
            DescriptionItem[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetTranslationsForObject(filter);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };

        }

        /// <summary>
        /// Gets the description types asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        public void GetDescriptionTypesAsync(Action<DescriptionItem[]> act)
        {
            DescriptionItem[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetDescriptionTypes();
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };
        }

        /// <summary>
        /// Gets the enumeration items asynchronous.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="act">The act.</param>
        public void GetHookItemsAsync(HookItem root, Action<HookItem[]> act)
        {
            HookItem[] result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetHookItems(root);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };
        }

        /// <summary>
        /// Gets the hook asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="act">The act.</param>
        public void GetHookAsync(string id, Action<Hook> act)
        {
            Hook result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetHook(id);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };
           
        }

        /// <summary>
        /// Gets the description asynchronous.
        /// </summary>
        /// <param name="documentMessage">The document message.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void GetDescriptionAsync(DescriptionItem item, Action<Description> act)
        {
            Description result = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, d) =>
                {
                    result = GetDescription(item);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (act != null)
                        act(result);
                };
                wrk.RunWorkerAsync();
            };

        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        public Description DeleteDescription(Description document)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteDescription(document);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the enumeration items.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>EnumerationItem[].</returns>
        public HookItem[] GetHookItems(HookItem root)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetHookItems(root);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Saves the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        public Hook SaveHook(Hook document)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveHook(document);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Deletes the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        public Hook DeleteHook(Hook document)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteHook(document);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        public Hook GetHook(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetHook(id);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Description.</returns>
        public Description GetDescription(DescriptionItem item)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetDescription(item);
            }
            finally
            {
                CloseClient(clt);
            }
           
        }
    }
}
