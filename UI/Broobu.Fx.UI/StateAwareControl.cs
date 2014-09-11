using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Broobu.Fx.UI.MVVM;
using Wulka.Core;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     A base UserControl that automatically binds its ModelState property to a ViewModelBase's State property.
    ///     In orde to unlock this feature, any derived StateAware Control should have a ViewModelBase DataContext.
    /// </summary>
    public class StateAwareControl : UserControl
    {
        private bool _firstTimeRender = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StateAwareControl" /> class.
        /// </summary>
        public StateAwareControl()
        {
            //Loaded += (s, e) => InitializeViewModel();

            // We bind 
            // the Modelstate Property to State IN CODE 
            // if the DataContext is a ViewModelBase
            DataContextChanged += (s, e) => InitializeViewState();
        }

        /// <summary>
        ///     Gets the view model.
        /// </summary>
        /// <value>The view model.</value>
        private FxViewModelBase ViewModel
        {
            get { return DataContext as FxViewModelBase; }
        }

        private void InitializeViewState()
        {
            var stateBinding = new Binding(FxViewModelBase.Property.State)
            {
                Source = ViewModel,
                Mode = BindingMode.TwoWay
            };
            SetBinding(ModelStateProperty, stateBinding);
            IsStateBound = true;
            InitializeViewModel();
        }


        /// <summary>
        ///     When overridden in a derived class, participates in rendering operations that are directed by the layout system.
        ///     The rendering instructions for this element are not used directly when this method is invoked, and are instead
        ///     preserved for later asynchronous use by layout and drawing.
        /// </summary>
        /// <param name="drawingContext">
        ///     The drawing instructions for a specific element. This context is provided to the layout
        ///     system.
        /// </param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (_firstTimeRender)
            {
                _firstTimeRender = false;
                OnFirstTimeRender();
            }
        }

        /// <summary>
        ///     Called when [first time show].
        /// </summary>
        protected virtual void OnFirstTimeRender()
        {
            InitializeViewModel();
        }


        /// <summary>
        ///     Initializes the view model.
        /// </summary>
        private void InitializeViewModel()
        {
            if (Misc.DesignMode) return;
            //if (IsStateBound) return; 
            // disabled this check as we want to re-set the binding in case the 
            //datacontext changes. Raf might know more about why this check was here originally.            
            if (ViewModel == null) return;
            ViewModel.Initialize();
        }

        #region ModelStateProperty Plumbing

        /// <summary>
        ///     Dependency Property for the ModelState
        /// </summary>
        public static readonly DependencyProperty ModelStateProperty =
            DependencyProperty.Register(Property.ModelState,
                typeof (TransitionState),
                typeof (StateAwareControl),
                new PropertyMetadata(null, ModelStateChanged));

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is state bound.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is state bound; otherwise, <c>false</c>.
        /// </value>
        public bool IsStateBound { get; private set; }

        /// <summary>
        /// </summary>
        public TransitionState ModelState
        {
            get { return (TransitionState) GetValue(ModelStateProperty); }
            set
            {
                SetValue(ModelStateProperty, value);
                if (Misc.DesignMode) return;

                if (value != null)
                {
                    VisualStateManager.GoToState(this, value.State, value.UseTransitions);
                }
            }
        }

        private static void ModelStateChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            ((StateAwareControl) d).ModelState = (TransitionState) e.NewValue;
        }

        #endregion

        #region VisualStateCompletedProperty Plumbing

        /// <summary>
        ///     Dependency Property for the ModelState
        /// </summary>
        public static readonly DependencyProperty VisualStateCompletedProperty =
            DependencyProperty.Register(Property.VisualStateCompleted,
                typeof (bool),
                typeof (StateAwareControl),
                new PropertyMetadata(false, VisualStateCompletedChanged));


        /// <summary>
        ///     Gets or sets a value indicating whether visual state completed.
        ///     Set this property to <c>true</c> in a StoryBoard to trigger the VisualStateChanged event.
        /// </summary>
        /// <remarks>
        ///     This property must be changed at the end of the StoryBoard.
        /// </remarks>
        /// <value>
        ///     <c>true</c> if the visual state is completed; otherwise, <c>false</c>.
        /// </value>
        public bool VisualStateCompleted
        {
            get { return (bool) GetValue(VisualStateCompletedProperty); }
            set
            {
                SetValue(VisualStateCompletedProperty, value);

                if (value)
                {
                    RaiseVisualStateChanged();
                    SetValue(VisualStateCompletedProperty, false);
                }
            }
        }

        private static void VisualStateCompletedChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            ((StateAwareControl) d).VisualStateCompleted = (bool) e.NewValue;
        }

        /// <summary>
        ///     Occurs when the visual model state changed.
        ///     To trigger the event set the VisualStateCompleted flag to <c>true</c>
        /// </summary>
        public event EventHandler VisualStateChanged;

        /// <summary>
        ///     Raises the visual state changed.
        /// </summary>
        private void RaiseVisualStateChanged()
        {
            if (VisualStateChanged != null) VisualStateChanged(this, EventArgs.Empty);
        }

        #endregion

        /// <summary>
        /// </summary>
        public class Property
        {
            /// <summary>
            /// </summary>
            public const string ModelState = "ModelState";

            /// <summary>
            /// </summary>
            public const string VisualStateCompleted = "VisualStateCompleted";
        }
    }
}