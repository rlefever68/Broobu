// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-21-2014
// ***********************************************************************
// <copyright file="MenuButton.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;
using Wulka.Utils;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{

    /// <summary>
    /// Class MenuButton.
    /// </summary>
    [DataContract]
    public class MenuButton : MenuItem, IMenuButton
    {


        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
        /// <summary>
        /// The _applet identifier
        /// </summary>
        private string _appletId;

        private bool _isAllowed = false;

        /// <summary>
        /// Gets the applet.
        /// </summary>
        /// <value>The applet.</value>
        public ICloudApplet Applet
        { 
            get 
            {
                return Find<ICloudApplet>(AppletId);
            } 
        }

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption 
        {
            get
            {
                return Applet == null ? "Not Found" : Applet.DisplayName;
            }
        }


        



        protected override IDisplayInfo GetDisplayInfo()
        {
            return new DisplayInfo()
            {
                DisplayName = Caption,
                Icon = Glyph
            };

        }

        public ImageSource Glyph {
            get {
                return Image.ToImageSource();
            }
        }

        /// <summary>
        /// Gets the launch URL.
        /// </summary>
        /// <value>The launch URL.</value>
        public string LaunchUrl
        {
            get
            {
                return Applet == null ? "Not Found" : Applet.PublishUrl;
            }
        }

        public bool IsAllowed
        {
            get { return _isAllowed; }
            set { _isAllowed = value; }
        }


        /// <summary>
        /// Gets or sets the applet identifier.
        /// </summary>
        /// <value>The applet identifier.</value>
        [DataMember]
        public string AppletId
        {
            get { return _appletId; }
            set { _appletId = value; }
        }
     

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [DataMember]
        public String Order { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MenuButton>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MenuButton>.Validate(this);
        }

        protected override ImageSource GetGlyph()
        {
            return Applet != null
                ? Applet.Icon.ToImageSource()
                : Resources.unknown.ToImageSource();
        }
    }
}