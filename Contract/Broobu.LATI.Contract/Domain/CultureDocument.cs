// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 08-13-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="CultureDocument.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    /// <summary>
    /// Class CultureDocument.
    /// </summary>
    public class CultureDocument : Folder, ICultureDocument
    {




        public CultureDocument()
        {
            Id = ID;
        }



        public const string ID = "CULTURES_AND_REGIONS";

        /// <summary>
        /// Gets the regions.
        /// </summary>
        /// <value>The regions.</value>
        public IEnumerable<IRegion> Regions
        {
            get { return Parts.OfType<IRegion>(); }
        }



        /// <summary>
        /// Gets the cultures.
        /// </summary>
        /// <value>The cultures.</value>
        public IEnumerable<ICulture> Cultures
        {
            get { return Parts.OfType<ICulture>(); }
        }





        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<CultureDocument>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<CultureDocument>.Validate(this);
        }

        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


        /// <summary>
        /// Gets the region cultures.
        /// </summary>
        /// <value>The region cultures.</value>
        public IEnumerable<IRegionCulture>  RegionCultures
        {
            get { return Parts.OfType<IRegionCulture>(); }
        }


        /// <summary>
        /// Links the culture to region.
        /// </summary>
        /// <param name="cult">The cult.</param>
        /// <param name="region">The region.</param>
        public void LinkCultureToRegion(ICulture cult, IRegion region)
        {
            AddRegionCulture(new RegionCulture(cult, region));
        }

        /// <summary>
        /// Adds the region culture.
        /// </summary>
        /// <param name="regionCultureLink">The region culture link.</param>
        private void AddRegionCulture(IRegionCulture regionCultureLink)
        {
            if(RegionCultures.Any(x=> (x.SourceId==regionCultureLink.SourceId) && (x.TargetId==regionCultureLink.TargetId))) return;
            AddPart(regionCultureLink);

        }
    }
}
