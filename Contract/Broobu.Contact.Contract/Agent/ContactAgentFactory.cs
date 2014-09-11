using Broobu.Contact.Contract.Interfaces;

namespace Broobu.Contact.Contract.Agent
{
    
	public class ContactAgentFactory
	{
		#region Methods
        /// <summary>
        /// Creates the address agent.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Interfaces.IAddressAgent.</returns>
		public static IAddressAgent CreateAddressAgent()
		{
			return new AddressAgent();
		}
        /// <summary>
        /// Creates the country agent.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Interfaces.ICountryAgent.</returns>
		public static ICountryAgent CreateCountryAgent()
		{
			return new CountryAgent();
		}
        /// <summary>
        /// Creates the document agent.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Interfaces.IDocumentAgent.</returns>
		public static IDocumentAgent CreateDocumentAgent()
		{
			return new DocumentAgent();
		}
        /// <summary>
        /// Creates the relation agent.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Interfaces.IRelationAgent.</returns>
		public static IRelationAgent CreateRelationAgent()
		{
			return new RelationAgent();
		}
        /// <summary>
        /// Creates the contact agent.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Interfaces.IContactAgent.</returns>
		public static IContactAgent CreateContactAgent()
		{
			return new ContactAgent();
		}
			
		#endregion		
	}
}