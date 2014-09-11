using System;

namespace Broobu.Fx.UI.Attributes
{
    /// <summary>
    ///     Attribute to ignore a Class or Property by the IsDirtyObserver.
    ///     When a class or property must not be observed on its changes
    ///     this attribute must be set.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class IgnoreIsDirtyAttribute : Attribute
    {
    }
}