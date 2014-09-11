// ***********************************************************************
// Assembly         : AddIn
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="MyAddIn.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Addin.Interfaces;

namespace Broobu.BrowseWeb.UI
{

    /// <summary>
    /// Class MyAddIn.
    /// </summary>
    [Export(typeof(IXProcAddIn))]
    public class BrowseAddIn : AddInBase
    {
       
    }

}