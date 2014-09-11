// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Business
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-10-2014
// ***********************************************************************
// <copyright file="ManageTaxoProvider.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
using System.Linq;
using Broobu.ManageTaxo.Business.Workers;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;




namespace Broobu.ManageTaxo.Business
{
    /// <summary>
    /// Class ManageTaxoProvider.
    /// </summary>
    public static class ManageTaxoProvider
    {
        /// <summary>
        /// Gets the worker.
        /// </summary>
        /// <value>The worker.</value>
        public static IManageTaxo Worker
        {
            get { return new ManageTaxoWorker(); }
        }


        /// <summary>
        /// To the description item.
        /// </summary>
        /// <param name="hooks">The hooks.</param>
        /// <returns>DescriptionItem[].</returns>
        public static HookItem[] ToEnumerationItem(this Hook[] hooks)
        {
            return hooks
                .Select(hook => new HookItem() 
                {
                    Id = hook.Id, 
                    TypeId = hook.TypeId,
                    DisplayName = hook.DisplayName
                })
                .ToArray();
        }

        /// <summary>
        /// To the description item.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[].</returns>
        public static DescriptionItem[] ToDescriptionItem(this Description[] descriptions)
        {
            return descriptions
                .Select(descr => descr.ToDescriptionItem())
                .ToArray();
        }


        /// <summary>
        /// To the description item.
        /// </summary>
        /// <param name="descr">The description.</param>
        /// <returns>DescriptionItem.</returns>
        public static DescriptionItem ToDescriptionItem(this Description descr)
        {
            return new DescriptionItem() 
            {
                Id = descr.Id,
                DisplayName = descr.DisplayName,
                TypeId = descr.TypeId,
                CultureId = descr.CultureId
            };
        }



        /// <summary>
        /// To the hook item.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <returns>HookItem.</returns>
        public static HookItem ToHookItem(this Hook hook)
        {
            return new HookItem()
            {
                Id = hook.Id,
                DisplayName = hook.DisplayName,
                AdditionalInfoUri = hook.AdditionalInfoUri,
                ObjectId = hook.ObjectId,
                ParentId = hook.ParentId,
                TypeId = hook.TypeId
            };
        }



        /// <summary>
        /// To the hook item.
        /// </summary>
        /// <param name="hooks">The hooks.</param>
        /// <returns>HookItem[].</returns>
        public static HookItem[] ToHookItem(this Hook[] hooks)
        {
            return hooks
                .Select(x => x.ToHookItem())
                .ToArray();
        }

        /// <summary>
        /// To the hook.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Hook.</returns>
        public static Hook ToHook(this HookItem item)
        {
            return new Hook()
            {
                Id = item.Id,
                DisplayName = item.DisplayName,
                AdditionalInfoUri = item.AdditionalInfoUri,
                ObjectId = item.ObjectId,
                ParentId = item.ParentId,
                TypeId = item.TypeId
            };
        }


        /// <summary>
        /// To the description item.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <returns>DescriptionItem.</returns>
        public static DescriptionItem ToDescriptionItem(this Hook hook)
        { 
            return new DescriptionItem() { 
                Id = hook.Descriptions[0].Id,
                DisplayName = hook.Descriptions[0].DisplayName,
                ObjectId    = hook.Id
            };
        }


        /// <summary>
        /// To the description item.
        /// </summary>
        /// <param name="hooks">The hooks.</param>
        /// <returns>DescriptionItem[].</returns>
        public static DescriptionItem[] ToDescriptionItem(this Hook[] hooks)
        {
            return hooks
                .Select(x => x.ToDescriptionItem())
                .ToArray();
        }








    }
}
