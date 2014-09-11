// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-15-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="MembershipFragment.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections;
using System.Linq;
using System.Windows;
using Broobu.EcoSpace.UI.Controls.Mvvm;
using DevExpress.Mvvm;

namespace Broobu.EcoSpace.UI.Controls.Fragments
{
    /// <summary>
    /// Interaction logic for MembershipFragment.xaml
    /// </summary>
    public partial class MembershipFragment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipFragment"/> class.
        /// </summary>
        public MembershipFragment()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        private MembershipViewModel Vm
        {
            get { return DataContext as MembershipViewModel; }
        }




        public static DependencyProperty DroppedItemsProperty =
            DependencyProperty.Register("DroppedItems", typeof(IList), typeof(MembershipFragment));


        public IList DroppedItems 
        {
            get 
            { 
                return GetValue(DroppedItemsProperty) as IList;
            }
            set 
            {
                SetValue(DroppedItemsProperty, value);
               
            } 
        }



        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.DragDrop.DragEnter" /> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            // If the DataObject contains string data, extract it. 
            if (e.Data.GetDataPresent(typeof (IList)))
            {
                e.Effects = e.KeyStates.HasFlag(DragDropKeyStates.ControlKey)
                    ? DragDropEffects.Copy
                    : DragDropEffects.Move;
                if (Vm != null)
                {
                    Vm.DroppedItems = (IList) e.Data.GetData(typeof (IList));
                }
            }
            e.Handled = true;
        }
    }
}