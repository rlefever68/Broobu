using System;
using System.Collections;
using System.Reflection;

namespace Pms.ManageWorkspaces.UI.Controls.UIInputValidations
{

	#region Class StringEnumeration

	/// <summary>
	/// Helper class for working with 'extended' enums using <see cref="StringValueAttribute"/> attributes.
	/// </summary>
	public class StringEnumeration
	{
		#region Instance implementation

		private readonly Type _enumType;
		//private static Hashtable _stringValues = new Hashtable();

		/// <summary>
		/// Creates a new <see cref="System.String"/> enumeration instance.
		/// </summary>
		/// <param name="enumType">Enum type.</param>
        public StringEnumeration(Type enumType)
		{
			if (!enumType.IsEnum)
				throw new ArgumentException(String.Format("Supplied type must be an Enum.  Type was {0}", enumType));

			_enumType = enumType;
		}

		/// <summary>
		/// Gets the string value associated with the given enum value.
		/// </summary>
		/// <param name="valueName">Name of the enum value.</param>
		/// <returns>String Value</returns>
		public string GetStringValue(string valueName)
		{
		    string stringValue = null;
			try
			{
			    var enumType = (Enum) Enum.Parse(_enumType, valueName);
			    stringValue = GetStringValue(enumType);
			}
			catch 
			{ }//Swallow!

			return stringValue;
		}

      
		/// <summary>
		/// Gets the values as a 'bindable' list datasource.
		/// </summary>
		/// <returns>IList for data binding</returns>
        public IList GetListValues()
		{
		    var underlyingType = Enum.GetUnderlyingType(_enumType);
		    var values = new ArrayList();
		    //Look for our string value associated with fields in this enum
		    foreach (FieldInfo fi in _enumType.GetFields())
		    {
		        //Check for our custom attribute
		        var attrs = fi.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];
		        if (attrs != null && attrs.Length > 0)
		            values.Add(new DictionaryEntry(Convert.ChangeType(Enum.Parse(_enumType, fi.Name), underlyingType),
		                                           attrs[0].Value));
		    }
		    return values;
		}

	    #endregion

		#region Static implementation

		/// <summary>
		/// Gets a string value for a particular enum value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>String Value associated via a <see cref="StringValueAttribute"/> attribute, or null if not found.</returns>
        public static string GetStringValue(Enum value)
		{
		    var type = value.GetType();
		    var fi = type.GetField(value.ToString());
		    var attrs =
		        fi.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];
            if (attrs != null && attrs.Length > 0)
                return attrs[0].Value;
		    return string.Empty;

		}

	    #endregion
	}

	#endregion
}