// ***********************************************************************
// Assembly         : Broubu.Boutique.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-12-2014
// ***********************************************************************
// <copyright file="BoutiqueDomainGenerator.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
//using Broobu.Taxonomy.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Utils;

namespace Broobu.Boutique.Contract.Domain
{
    /// <summary>
    /// Class BoutiqueDomainGenerator.
    /// </summary>
    public class BoutiqueDomainGenerator
    {


        /// <summary>
        /// Class BoutiqueInfoDefaults.
        /// </summary>
        public class BoutiqueInfoDefaults
        {
            /// <summary>
            /// The tool tip
            /// </summary>
            public const string ToolTip = "<Your Tooltip comes here>";

            /// <summary>
            /// Gets the default icon.
            /// </summary>
            /// <value>The default icon.</value>
            public static byte[] DefaultIcon
            {
                get 
                {
                    return
                        ResourceImageAsByteArray(
                            "pack://application:,,,/Wulka.Resources;component/button-icons/prodata-logo.png");
                }
            }

            /// <summary>
            /// The plugin URL
            /// </summary>
            public const string PluginUrl = "http://<your host name>/clickonce/<your applet>";
            /// <summary>
            /// The ribbon type
            /// </summary>
            public const string RibbonType = "AF_RIBBON_";

        }

        /// <summary>
        /// Creates the mock boutique user information.
        /// </summary>
        /// <returns>UserEnvironmentInfo.</returns>
        public static UserEnvironmentInfo CreateMockUserEnvironmentInfo()
        {
            return new UserEnvironmentInfo()
                       {
                           UserId = WulkaContextDefault.UserId,
                           Menu = EcoSpaceFactory.MasterEcoSpace.Menu
                       };
        }

        /// <summary>
        /// Gets the resource image as byte array.
        /// </summary>
        /// <param name="imageNameUri">The image name URI.</param>
        /// <returns>System.Byte[][].</returns>
        private static byte[] ResourceImageAsByteArray(string imageNameUri)
        {
            //var img = new BitmapImage();
            //img.BeginInit();
            //img.UriSource = new Uri(imageNameUri);
            //img.EndInit();
            //return BufferFromImage(img);
            return new byte[] { };
        }


        /// <summary>
        /// Buffers from image.
        /// </summary>
        /// <param name="imageSource">The image source.</param>
        /// <returns>Byte[][].</returns>
        public static Byte[] BufferFromImage(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (var br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }
            return buffer;
        }


        /// <summary>
        /// Creates the mock boutique menu information.
        /// </summary>
        /// <returns>IEnumerable{BoutiqueMenuInfo}.</returns>
    


        ///// <summary>
        ///// Creates the description type enumeration.
        ///// </summary>
        ///// <returns>Hook[][].</returns>
        //public static Hook[] CreateDescriptionTypeEnumeration()
        //{ 
        //    return new Hook[] {};
        //    //return new TaxonomyHook[] 
        //    //{
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Root,
        //    //        Title = "Media Types Enumeration",
        //    //        TypeId = EnumerationType.TypeIdBaseTypeEnum,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    },
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Text,
        //    //        Title = "Text Description",
        //    //        TypeId = EnumerationType.TypeIdMedia,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    },
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Picture,
        //    //        Title = "Picture",
        //    //        TypeId = EnumerationType.TypeIdMedia,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    },
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Video,
        //    //        Title = "Video",
        //    //        TypeId = EnumerationType.TypeIdMedia,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    },
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Audio,
        //    //        Title = "Audio",
        //    //        TypeId = EnumerationType.TypeIdMedia,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    },
        //    //    new TaxonomyHook
        //    //    {
        //    //        Id = MediaType.Link,
        //    //        Title = "Link",
        //    //        TypeId = EnumerationType.TypeIdMedia,
        //    //        SortOrder = 0,
        //    //        Image = new byte[] { },
        //    //        AdditionalInfoUri = String.Empty
        //    //    }
        //    //};

        //    // Register the DescriptionType items
        //}



        /// <summary>
        /// Creates the default boutique user information.
        /// </summary>
        /// <returns>UserEnvironmentInfo.</returns>
        public static UserEnvironmentInfo CreateDefaultUserEnvironmentInfo()
        {
            return new UserEnvironmentInfo() 
            {
                Menu = EcoSpaceFactory.MasterEcoSpace.Menu,
                Applets = EcoSpaceFactory.MasterEcoSpace.Applets
            };  
        }


        public static UserEnvironmentInfo CreateDefaultGuestUserInfo()
        {
            return new UserEnvironmentInfo()
            {
                Menu = EcoSpaceFactory.GuestEcoSpace.Menu,
                Applets = EcoSpaceFactory.GuestEcoSpace.Applets
            };  
        }
    }
}
