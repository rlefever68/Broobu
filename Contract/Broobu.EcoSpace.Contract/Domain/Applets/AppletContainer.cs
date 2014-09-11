// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="AppletContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
/// <summary>
/// Class AppletContainer.
/// </summary>

    [DataContract]
    public class AppletContainer : Folder
    {



/// <summary>
/// Gets the applets.
/// </summary>
/// <value>The applets.</value>
        public IEnumerable<CloudApplet> Applets { get {return Parts.OfType<CloudApplet>();}}
        
/// <summary>
/// Validates the specified column name.
/// </summary>
/// <param name="columnName">Name of the column.</param>
/// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AppletContainer>.Validate(this,columnName);
        }

/// <summary>
/// Validates this instance.
/// </summary>
/// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AppletContainer>.Validate(this);
        }


        private BusinessAppletsFolder BusinessAppletFolder
        {
            get
            {
                return !Parts.OfType<BusinessAppletsFolder>().Any() 
                    ? null 
                    : Parts.OfType<BusinessAppletsFolder>().First();
            }
        }

        public void AddToBusinessApplets(IDomainObject item)
        {
            if(BusinessAppletFolder!=null)
            {
                BusinessAppletFolder.AddPart(item);
            }
        }
        
        public const string ID = "APPLET_CONTAINER";
        
        public AppletContainer()
        {
            Id = ID;
            DisplayName = "Applets";
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


    }
}
