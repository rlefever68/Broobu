using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Validation;

namespace Broobu.Contact.Contract.Domain
{
    /// <summary>
    /// Class CountryItem.
    /// </summary>
	public class Country: TaxonomyObject<Country>
	{
		#region Fields
        /// <summary>
        /// The _two letter iso region name
        /// </summary>
		private string _twoLetterIsoRegionName;
        /// <summary>
        /// The _three letter iso region name
        /// </summary>
		private string _threeLetterIsoRegionName;
        /// <summary>
        /// The _default name
        /// </summary>
		private string _defaultName;
		#endregion
		#region Properties
        /// <summary>
        /// Gets or sets the name of the two letter iso region.
        /// </summary>
        /// <value>The name of the two letter iso region.</value>
		[DataMember]
		public string TwoLetterIsoRegionName
		{
			get
			{
				return _twoLetterIsoRegionName;
				
			}
			set
			{
				if(ReferenceEquals(_twoLetterIsoRegionName, value) != true)
				{
					_twoLetterIsoRegionName = value;
					RaisePropertyChanged("TwoLetterIsoRegionName");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the name of the three letter iso region.
        /// </summary>
        /// <value>The name of the three letter iso region.</value>
		[DataMember]
		public string ThreeLetterIsoRegionName
		{
			get
			{
				return _threeLetterIsoRegionName;
				
			}
			set
			{
				if(ReferenceEquals(_threeLetterIsoRegionName, value) != true)
				{
					_threeLetterIsoRegionName = value;
					RaisePropertyChanged("ThreeLetterIsoRegionName");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the default name.
        /// </summary>
        /// <value>The default name.</value>
		[DataMember]
		public string DefaultName
		{
			get
			{
				return _defaultName;
				
			}
			set
			{
				if(ReferenceEquals(_defaultName, value) != true)
				{
					_defaultName = value;
					RaisePropertyChanged("DefaultName");
				}
				
			}
		}
		#endregion
		#region Methods
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
		protected override string Validate(string columnName)
		{
			return DataErrorInfoValidator<Country>.Validate(this, columnName);
		}
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>System.Collections.Generic.ICollection{System.String}.</returns>
		protected override ICollection<string> Validate()
		{
			return DataErrorInfoValidator<Country>.Validate(this);
		}

		#endregion		
	}
}