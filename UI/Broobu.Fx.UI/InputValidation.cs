using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     This code comes from the interweb:
    ///     http://weblogs.asp.net/marianor/archive/2009/04/17/wpf-validation-with-attributes-and-idataerrorinfo-interface-in-mvvm.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class InputValidation<T> where T : IDataErrorInfo
    {
        private static readonly Dictionary<string, KeyValuePair<Func<T, object>, ValidationAttribute[]>> AllValidators;

        static InputValidation()
        {
            AllValidators = new Dictionary<string, KeyValuePair<Func<T, object>, ValidationAttribute[]>>();
            foreach (PropertyInfo property in typeof (T).GetProperties())
            {
                ValidationAttribute[] validations = GetValidations(property);
                if (validations.Length > 0)
                    AllValidators.Add(property.Name,
                        new KeyValuePair<Func<T, object>, ValidationAttribute[]>(
                            CreateValueGetter(property), validations));
            }
        }

        /// <summary>
        ///     Validate a single column in the source
        /// </summary>
        /// <remarks>
        ///     Usually called from IErrorDataInfo.this[]
        /// </remarks>
        /// <param name="source">Instance to validate</param>
        /// <param name="columnName">Name of column to validate</param>
        /// <returns>Error messages separated by newline or string.Empty if no errors</returns>
        public static string Validate(T source, string columnName)
        {
            KeyValuePair<Func<T, object>, ValidationAttribute[]> validators;
            if (AllValidators.TryGetValue(columnName, out validators))
            {
                object value = validators.Key(source);
                string[] errors =
                    validators.Value.Where(v => !v.IsValid(value)).Select(v => v.ErrorMessage ?? "").ToArray();
                return string.Join(Environment.NewLine, errors);
            }
            return string.Empty;
        }

        /// <summary>
        ///     Validate all columns in the source
        /// </summary>
        /// <param name="source">Instance to validate</param>
        /// <returns>List of all error messages. Empty list if no errors</returns>
        public static ICollection<string> Validate(T source)
        {
            var messages = new List<string>();
            foreach (var validators in AllValidators.Values)
            {
                object value = validators.Key(source);
                messages.AddRange(validators.Value.Where(v => !v.IsValid(value)).Select(v => v.ErrorMessage ?? ""));
            }
            return messages;
        }

        /// <summary>
        ///     Get all validation attributes on a property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static ValidationAttribute[] GetValidations(PropertyInfo property)
        {
            return (ValidationAttribute[]) property.GetCustomAttributes(typeof (ValidationAttribute), true);
        }

        /// <summary>
        ///     Create a lambda to receive a property value
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static Func<T, object> CreateValueGetter(PropertyInfo property)
        {
            ParameterExpression instance = Expression.Parameter(typeof (T), "i");
            UnaryExpression cast = Expression.TypeAs(Expression.Property(instance, property), typeof (object));
            return (Func<T, object>) Expression.Lambda(cast, instance).Compile();
        }
    }
}