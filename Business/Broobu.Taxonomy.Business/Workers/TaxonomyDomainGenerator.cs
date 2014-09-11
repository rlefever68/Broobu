// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-06-2014
// ***********************************************************************
// <copyright file="TaxonomyDomainGenerator.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using NLog;


namespace Broobu.Taxonomy.Business.Workers
{
/// <summary>
/// Class TaxonomyDomainGenerator.
/// </summary>
    public class TaxonomyDomainGenerator
    {

/// <summary>
/// The _logger
/// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

/// <summary>
/// Gets the description types.
/// </summary>
/// <value>The description types.</value>
        public static IEnumerable<Hook> DescriptionTypes 
        { 
            get
            {
                return new[] 
                { 
                    new Hook()
                    {
                        Id = HookConst.DescriptionTypeDefault,
                        Title = "Default",
                        DisplayName = "Default",
                        TypeId = HookConst.DescriptionTypeEnum,
                        ParentId = HookConst.DescriptionTypeEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DescriptionTypeAlternative,
                        Title = "Alternative",
                        DisplayName = "Alternative",
                        TypeId = HookConst.DescriptionTypeEnum,
                        ParentId = HookConst.DescriptionTypeEnum
                    }
                };

            }
        }


        /// <summary>
        /// Gets the default hooks.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Hook[].</returns>
        public static Hook[] GetDefaultHooks(string path)
        {
            var res = new List<Hook>();
            res.AddRange(DescriptionTypes);
            res.AddRange(DefaultDataCultures);
            res.AddRange( new[]
            {
                new Hook()
                {
                    Id = HookConst.Root,
                    Title = "Hooks",
                    DisplayName = "Hooks",
                    TypeId = SysConst.NullGuid,
                    ParentId = SysConst.NullGuid,
                    ObjectId = SysConst.NullGuid
                },
                new Hook()
                {
                    Id = HookConst.EcoSpaceRoot,
                    Title = "Roles",
                    DisplayName = "Roles",
                    TypeId = HookConst.Root,
                    ParentId = HookConst.Root
                },
                new Hook()
                {
                    Id = HookConst.EcoSpaceRoot,
                    Title = "EcoSpace",
                    DisplayName = "EcoSpace",
                    TypeId = HookConst.Root,
                    ParentId = HookConst.Root
                },
                new Hook() 
                {
                    Id = HookConst.PublicEcoSpace,
                    ParentId = HookConst.EcoSpaceRoot,
                    TypeId = HookConst.EcoSpaceRoot,
                    DisplayName = "Public EcoSpace",
                    Title = "Public EcoSpace"
                },
                new Hook() 
                {
                    Id = HookConst.PrivateEcoSpaces,
                    ParentId = HookConst.EcoSpaceRoot,
                    TypeId = HookConst.EcoSpaceRoot,
                    DisplayName = "Private EcoSpaces",
                    Title = "Private EcoSpaces"
                },
                new Hook()
                {
                    Id = HookConst.EnumRoot,
                    Title = "Enumerations",
                    DisplayName = "Enumerations",
                    TypeId = HookConst.Root,
                    ParentId = HookConst.Root
                },
                new Hook()
                {
                    Id = HookConst.DataCultureEnum,
                    Title = "Supported Data Cultures",
                    DisplayName = "Supported Data Cultures",
                    TypeId = HookConst.EnumRoot,
                    ParentId = HookConst.EnumRoot
                },
                new Hook()
                {
                    Id = HookConst.DescriptionTypeEnum,
                    Title = "Description Types",
                    DisplayName = "Description Types",
                    TypeId = HookConst.EnumRoot,
                    ParentId = HookConst.EnumRoot
                },
                new Hook()
                {
                    Id = HookConst.GenderEnum,
                    Title = "Genders",
                    DisplayName = "Genders",
                    TypeId = HookConst.EnumRoot,
                    ParentId = HookConst.EnumRoot
                },
                new Hook()
                {
                    Id = HookConst.GenderMaleEnum,
                    Title = "Male",
                    DisplayName = "Male",
                    TypeId = HookConst.GenderEnum,
                    ParentId = HookConst.GenderEnum
                },
                new Hook()
                {
                    Id = HookConst.GenderFemaleEnum,
                    Title = "Female",
                    DisplayName = "Female",
                    TypeId = HookConst.GenderEnum,
                    ParentId = HookConst.GenderEnum
                },
                new Hook()
                {
                    Id = HookConst.GenderUnknownEnum,
                    Title = "Unknown",
                    DisplayName = "Unknown",
                    TypeId = HookConst.GenderEnum,
                    ParentId = HookConst.GenderEnum
                }
            });
            return res.ToArray();
            //Logger.DebugFormat("Reading default taxonomy from {0}", path);
            //DomainSerializer<Hook[]>.Serialize(res,path);
            //return DomainSerializer<Hook[]>.Deserialize(path);     
        }

        /// <summary>
        /// Gets the default data languages.
        /// </summary>
        /// <value>The default data languages.</value>
        public static IEnumerable<Hook> DefaultDataCultures 
        {
            get
            {
                return new[]
                {
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumDutch,
                        Title = "Dutch (NL)",
                        DisplayName = "Dutch - The Netherlands",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumEnglish,
                        Title = "English (US)",
                        DisplayName = "English - USA",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumFrench,
                        Title = "French (FR)",
                        DisplayName = "French - France",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumGerman,
                        Title = "German (DE)",
                        DisplayName = "German - Germany",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumItalian,
                        Title = "Italian (IT)",
                        DisplayName = "Italian - Italy",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    },
                    new Hook()
                    {
                        Id = HookConst.DataCultureEnumSpanish,
                        Title = "Spanish (ES)",
                        DisplayName = "Spanish - Spain",
                        TypeId = HookConst.DataCultureEnum,
                        ParentId = HookConst.DataCultureEnum
                    }
                };
            }
        }



        /// <summary>
        /// Creates the default setting.
        /// </summary>
        /// <returns>Setting.</returns>
        public static Setting CreateDefaultSetting()
        {
            return new Setting()
            {
                Id = SysConst.NullGuid,
                RoleId = SysConst.NullGuid,
                ApplicationFunctionId = SysConst.NullGuid,
                AccountId = SysConst.NullGuid,
                ObjectId = SysConst.NullGuid,
            };
        }


        /// <summary>
        /// Creates the description.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>Description.</returns>
        public static Description CreateDescription(string objectId, string typeId, string cultureId, string displayName)
        {
            return new Description()
            {
                CultureId = cultureId,
                TypeId = typeId,
                ObjectId = objectId,
                DisplayName = String.Format("{0} ({1})", displayName, cultureId),
                Title = String.Format("{0} ({1})", displayName, cultureId)
            };
        }


    /// <summary>
    /// Inflates the default descriptions.
    /// </summary>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="displayName"></param>
    /// <returns>Description[].</returns>
    public static Description[] InflateDefaultDescriptions(string objectId, string displayName = "Unknown")
    {
        var lst = new List<Description>();
        //var dataCultures = TaxonomyProvider.DataCultures;
        //foreach (var dataCulture in dataCultures)
        //{
        //    lst.AddRange(descrTypes
        //        .Select(descrType => CreateDescription(objectId, descrType.Id, dataCulture.Id, displayName)));
        //}
        return lst.ToArray();
    }
    }
}
