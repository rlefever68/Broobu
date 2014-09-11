// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="EcoSpaceViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class EcoSpaceViewModel.
    /// </summary>
    [POCOViewModel]
    public class EcoSpaceViewModel : FxViewModelBase
    {
        /// <summary>
        /// The _eco space
        /// </summary>
        private IEcoSpaceDocument _ecoSpace;


        /// <summary>
        /// Gets or sets the eco space.
        /// </summary>
        /// <value>The eco space.</value>
        public IEcoSpaceDocument EcoSpace
        {
            get { return _ecoSpace; }
            set
            {
                if (value == null) return;
                _ecoSpace = value;
                Messenger.Default.Send(new EcoSpaceMvvmMessage() { EcoSpaceDocument = _ecoSpace});
                RaisePropertyChanged("EcoSpace");
            }
        }


        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            EcoSpacePortal
                .EcoSpace
                .GetEcoSpaceAsync(MasterEcoSpace.ID, e => 
                { 
                    EcoSpace = e; 
                });
        }
    }
}