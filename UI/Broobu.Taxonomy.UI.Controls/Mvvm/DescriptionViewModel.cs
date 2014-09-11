// ***********************************************************************
// Assembly         : Broobu.Taxonomy.UI.Controls
// Author           : Rafael Lefever
// Created          : 04-22-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 04-30-2014
// ***********************************************************************
// <copyright file="DescriptionViewModel.cs" company="Insoft Pvt.Ltd.">
//     Copyright (c) Insoft Pvt.Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Fx.UI.MVVM;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Broobu.Taxonomy.UI.Controls.Mvvm
{
    /// <summary>
    /// Class DescriptionViewModel.
    /// </summary>
    [POCOViewModel]
    public class DescriptionViewModel : FxViewModelBase, IDocumentViewModel
    {


        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            TaxonomyPortal
                .Descriptions
                .DeleteDescription(Description);
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            TaxonomyPortal
                .Descriptions
                .SaveDescription(Description);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionViewModel"/> class.
        /// </summary>
        public DescriptionViewModel()
        {
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DescriptionViewModel.</returns>
        public static DescriptionViewModel Create()
        {
            return ViewModelSource.Create(() => new DescriptionViewModel());
        }

        /// <summary>
        /// [To be supplied]
        /// </summary>
        /// <returns>[To be supplied]</returns>
        public bool Close()
        {
            return !Description.IsDirty;
        }

        /// <summary>
        /// [To be supplied]
        /// </summary>
        /// <value>[To be supplied]</value>
        public object Title
        {
            get { return "Edit Description"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public Description Description { get; set; }

        protected override void InitializeInternal(object[] parameters)
        {
            
        }
    }
}