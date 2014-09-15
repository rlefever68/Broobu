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


using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class ManageRolesViewModel.
    /// </summary>
    public class ManageRolesViewModel : EcoSpaceChildViewModel
    {
        /// <summary>
        /// The _roles
        /// </summary>
        private RoleContainer _roles;
        
        /// <summary>
        /// The _selected role
        /// </summary>
        private IComposedObject _selectedRole;


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




     

        protected override void OnEcoSpaceChanged()
        {
            Roles = EcoSpace.Roles;            
        }


        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        /// <value>The selected role.</value>
        public IComposedObject SelectedRole
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



       
        
            
    }
}
