// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="ManageRolesViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class ManageRolesViewModel.
    /// </summary>
    public class ManageRolesViewModel : FxViewModelBase
    {
        /// <summary>
        /// The _roles
        /// </summary>
        private RoleContainer _roles;
        /// <summary>
        /// The _eco space document
        /// </summary>
        private IEcoSpaceDocument _ecoSpaceDocument;
        /// <summary>
        /// The _selected role
        /// </summary>
        private IRole _selectedRole;


        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public RoleContainer Roles
        {
            get { return _roles; }
            set 
            { 
                _roles = value; 
                RaisePropertyChanged("Roles"); 
            }
        }




        /// <summary>
        /// Initializes a new instance of the <see cref="ManageRolesViewModel"/> class.
        /// </summary>
        public ManageRolesViewModel()
        {
            Messenger.Default.Register<EcoSpaceMvvmMessage>(this, m => 
            { 
                EcoSpace = m.EcoSpaceDocument; 
            });
        }

        /// <summary>
        /// Gets or sets the eco space document.
        /// </summary>
        /// <value>The eco space document.</value>
        public IEcoSpaceDocument EcoSpace
        {
            get 
            { 
                return _ecoSpaceDocument; 
            }
            set 
            {
                if (value == null) return;
                _ecoSpaceDocument = value;
                RaisePropertyChanged("EcoSpace");
                Roles = _ecoSpaceDocument.Roles;
            }
        }


        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        /// <value>The selected role.</value>
        public IRole SelectedRole
        {
            get 
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
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
            
        }



        [Command(Name="NewRoot", UseCommandManager=true)]
        public void NewRoot()
        {

        }


        [Command(Name="AddChild", UseCommandManager=true)]
        public void AddChild()
        {

        }
        
            
    }
}
