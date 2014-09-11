// ***********************************************************************
// Assembly         : Broobu.Authentication.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-15-2014
// ***********************************************************************
// <copyright file="SelectAccountFragment.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections;
using System.Windows;
using System.Windows.Input;

namespace Broobu.Authentication.UI.Controls.Fragments
{
    /// <summary>
    ///     Interaction logic for AccountsFragment.xaml
    /// </summary>
    public partial class SelectAccountFragment
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SelectAccountFragment" /> class.
        /// </summary>
        public SelectAccountFragment()
        {
            InitializeComponent();
        }


        /// <summary>
        ///     Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseMove" /> attached event reaches an element
        ///     in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton != MouseButtonState.Pressed) return;
            // Package the data.
            var data = new DataObject();
            data.SetData(typeof (IList), GridControl.SelectedItems);
            // Inititate the drag-and-drop operation.
            DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
        }


        /// <summary>
        ///     Invoked when an unhandled <see cref="E:System.Windows.DragDrop.GiveFeedback" /> attached event reaches an element
        ///     in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.GiveFeedbackEventArgs" /> that contains the event data.</param>
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's 
            // DragOver event handler. 
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
    }
}