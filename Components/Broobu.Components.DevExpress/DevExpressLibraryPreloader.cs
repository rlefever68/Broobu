// ***********************************************************************
// Assembly         : Broobu.Components.DevExpress
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="DevExpressLibraryPreloader.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpf.Carousel;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Map;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.PivotGrid;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Ribbon;



namespace Broobu.Components.DevExpress
{
    /// <summary>
    /// Class DevExpressLibraryPreloader.
    /// </summary>
    public class DevExpressLibraryPreloader
    {

        /// <summary>
        /// Pres the load.
        /// </summary>
        public static void PreLoad()
        {
            var a = new GridControl();
            var b = new CarouselPanel();
            var c = new ChartControl();
            var d = new FlowLayoutControl();
            var e = new NavBarControl();
            var f = new PivotGridControl();
            var g = new DocumentPreview();
            var h = new RibbonControl();
            var i = new MapControl();
        }


        /// <summary>
        /// Pres the load grid.
        /// </summary>
        public static void PreLoadGrid()
        {
            var a = new GridControl();
        }

        /// <summary>
        /// Pres the load carousel.
        /// </summary>
        public static void PreLoadCarousel()
        {
            var b = new CarouselPanel();
        }

        /// <summary>
        /// Pres the load chart.
        /// </summary>
        public static void PreLoadChart()
        {
            var c = new ChartControl();
        }

        /// <summary>
        /// Pres the load flow layout.
        /// </summary>
        public static void PreLoadFlowLayout()
        {
            var d = new FlowLayoutControl();
        }

        /// <summary>
        /// Pres the load nav bar.
        /// </summary>
        public static void PreLoadNavBar()
        {
            var e = new NavBarControl();
        }

        /// <summary>
        /// Pres the load pivot.
        /// </summary>
        public static void PreLoadPivot()
        {
            var f = new PivotGridControl();
        }


        /// <summary>
        /// Pres the load printing.
        /// </summary>
        public static void PreLoadPrinting()
        {
            var g = new DocumentPreview();
        }


        /// <summary>
        /// Pres the load ribbon.
        /// </summary>
        public static void PreLoadRibbon()
        {
            var h = new RibbonControl();
        }

        /// <summary>
        /// Preloads the map.
        /// </summary>
        public static void PreloadMap()
        {
            var h = new MapControl();
        }




    }
}
