using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using Broobu.Fx.UI.Attributes;
using Broobu.Fx.UI.Interfaces;
using Wulka.Configuration;
using Wulka.Core;
using Expression = System.Linq.Expressions.Expression;

namespace Broobu.Fx.UI.MVVM
{
    /// <summary>
    ///     Abstract base class for ViewModel Classes. This base class implements the INotifyPropertyChanged interface
    ///     and inherited classes MUST implement the method InitializeInternal.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo, IViewModel
    {
        private static bool? _isInDesignMode;

        protected readonly IsDirtyObserver<INotifyPropertyChanged> IsDirtyObserver =
            new IsDirtyObserver<INotifyPropertyChanged>();

        private readonly Dictionary<string, KeyValuePair<Delegate, ValidationAttribute[]>> _allValidators =
            new Dictionary<string, KeyValuePair<Delegate, ValidationAttribute[]>>();

        private readonly Dictionary<string, string> _errors = new Dictionary<string, string>();
        protected object[] InitializationParams;
        private bool _ignoreIsDirty;
        private bool _isAuthenticated;
        private bool _isBusy;
        private bool _isDirty;
        private bool _isEmpty;

        private bool _isInitialized;
        private TransitionState _state;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Broobu.Fx.UI.MVVM.FxViewModelBase" /> class.
        /// </summary>
        protected ViewModelBase()
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                CreateValidators(property);
            }
            //Initialize();
        }

        /// <summary>
        ///     Gets a value indicating whether the control is in design mode (running in Blend
        ///     or Visual Studio).
        /// </summary>
        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
#if SILVERLIGHT
            _isInDesignMode = DesignerProperties.IsInDesignTool;
#else
                    DependencyProperty prop = DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode
                        = (bool) DependencyPropertyDescriptor
                            .FromProperty(prop, typeof (FrameworkElement))
                            .Metadata.DefaultValue;
#endif
                }

                return _isInDesignMode.Value;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the control is in design mode (running under Blend
        ///     or Visual Studio).
        /// </summary>
        [SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "Non static member needed for data binding")]
        public bool IsInDesignMode
        {
            get { return IsInDesignModeStatic; }
        }


        [IgnoreIsDirty]
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                if (value == _isEmpty) return;
                _isEmpty = value;
                RaisePropertyChanged(Property.IsEmpty);
            }
        }


        /// <summary>
        ///     Gets a value indicating whether this instance has error.
        ///     This can be very usefull to disable/enable certain commands
        ///     when an error has occurred.
        /// </summary>
        /// <value><c>true</c> if this instance has error; otherwise, <c>false</c>.</value>
        [IgnoreIsDirty]
        public bool HasError
        {
            get { return _errors.Any(); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is dirty.
        ///     A dirty instance is an instance of which one of its properties that is NOT
        ///     flagged as IsDirty has changed.
        /// </summary>
        /// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;

                _ignoreIsDirty = true;
                RaisePropertyChanged(Property.IsDirty);
                _ignoreIsDirty = false;
            }
        }

        [IgnoreIsDirty]
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                _isAuthenticated = value;
                RaisePropertyChanged(Property.IsAuthenticated);
            }
        }

        /// <summary>
        ///     Gets the Error string from the specified Property
        /// </summary>
        /// <value>Error value</value>
        public string this[string columnName]
        {
            get
            {
                KeyValuePair<Delegate, ValidationAttribute[]> validators;
                if (_allValidators.TryGetValue(columnName, out validators))
                {
                    object value = validators.Key.DynamicInvoke(this);
                    string[] errors =
                        validators.Value.Where(v => !v.IsValid(value)).Select(v => v.ErrorMessage ?? "").ToArray();
                    string text = string.Join(Environment.NewLine, errors);

                    if (string.IsNullOrEmpty(text))
                    {
                        if (_errors.ContainsKey(columnName))
                        {
                            _errors.Remove(columnName);
                        }
                    }
                    else
                    {
                        _errors[columnName] = text;
                    }

                    RaisePropertyChanged(Property.HasError);
                    RaisePropertyChanged(Property.Error);
                    OnValidation(columnName, text);

                    return text;
                }

                return string.Empty;
            }
        }

        /// <summary>
        ///     Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        [IgnoreIsDirty]
        public string Error
        {
            get
            {
                var messages = new List<string>();
                foreach (var validators in _allValidators.Values)
                {
                    object value = validators.Key.DynamicInvoke(this);
                    messages.AddRange(validators.Value.Where(v => !v.IsValid(value)).Select(v => v.ErrorMessage ?? ""));
                }

                return messages.Count == 0 ? null : string.Join(Environment.NewLine, messages.ToArray());
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        [IgnoreIsDirty]
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(Property.IsBusy);
            }
        }

        /// <summary>
        ///     Gets or sets the state of this instance.
        /// </summary>
        /// <value>The state.</value>
        [IgnoreIsDirty]
        public TransitionState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged(Property.State);
            }
        }

        /// <summary>
        ///     Initializes this instance.
        ///     This method will make sure the initialization is only done
        ///     once and is not run at DesignTime, this to make sure
        ///     that the development environment does not crash when initializing
        ///     certain certain database or service connections.
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel.</param>
        public void Initialize(params object[] parameters)
        {
            InitializationParams = parameters;
            if (_isInitialized) return;
            _isInitialized = true;
            if (Misc.DesignMode) return;
            IsDirtyObserver.Register(this);
            IsDirtyObserver.IsDirty += (sender, e) => { if (!_ignoreIsDirty) IsDirty = true; };
            if (ConfigurationHelper.AuthenticateApplet)
                StartAuthenticatedSession();
            else
                InitializeInternal(parameters);
        }

        /// <summary>
        ///     Creates the validators.
        /// </summary>
        /// <param name="property">The property.</param>
        private void CreateValidators(PropertyInfo property)
        {
            var validations = (ValidationAttribute[]) property.GetCustomAttributes(typeof (ValidationAttribute), true);
            if (validations.Length > 0)
            {
                _allValidators.Add(property.Name,
                    new KeyValuePair<Delegate, ValidationAttribute[]>(CreateValueGetter(property),
                        validations));
            }
        }

        /// <summary>
        ///     Create a lambda to receive a property value
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private Delegate CreateValueGetter(PropertyInfo property)
        {
            ParameterExpression parameter = Expression.Parameter(GetType(), "i");
            UnaryExpression cast = Expression.TypeAs(Expression.Property(parameter, property), typeof (object));

            return Expression.Lambda(cast, parameter).Compile();
        }

        /// <summary>
        ///     Sets the State property. This property is bound to
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="useTransitions">if set to <c>true</c> [use transitions].</param>
        protected void GotoState(string state, bool useTransitions)
        {
            State = new TransitionState {State = state, UseTransitions = useTransitions};
        }


        /// <summary>
        ///     Starts the authenticated session.
        /// </summary>
        /// <param name="initializationParams"></param>
        protected abstract void StartAuthenticatedSession();


        /// <summary>
        ///     Terminates the authenticated session.
        /// </summary>
        /// <param name="onSessionTerminated">The on session terminated.</param>
        public abstract void TerminateAuthenticatedSession(Action onSessionTerminated = null);


        /// <summary>
        ///     Initializes the ViewModel the first time it is called.
        ///     This method will be called from the View that implements the
        ///     ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected abstract void InitializeInternal(object[] parameters);

        /// <summary>
        ///     Called when a property has been validated.
        ///     This can be used to update a status field on the ViewModel
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="error">The error.</param>
        protected virtual void OnValidation(string columnName, string error)
        {
        }

        #region INotifyPropertyChanged Plumbing

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        /// <summary>
        /// </summary>
        public class Property
        {
            public const string IsEmpty = "IsEmpty";

            /// <summary>
            /// </summary>
            public const string State = "State";

            /// <summary>
            /// </summary>
            public const string IsBusy = "IsBusy";

            /// <summary>
            /// </summary>
            public const string HasError = "HasError";

            /// <summary>
            /// </summary>
            public const string Error = "Error";

            /// <summary>
            /// </summary>
            public const string IsDirty = "IsDirty";

            public const string IsAuthenticated = "IsAuthenticated";
        }
    }
}