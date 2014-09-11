using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Broobu.Contact.Business.Data;
using Broobu.Contact.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;
using log4net;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class ContactBusinessGenerator.
    /// </summary>
    public class ContactBusinessGenerator
    {
        /// <summary>
        /// The _logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ContactBusinessGenerator));


        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem[].</returns>
        public static Country[] GetCountryItems()
        {
            return ContactDomainGenerator.GetCountries().ToArray();
        }

        /// <summary>
        /// Gets the country description items.
        /// </summary>
        /// <returns>Iris.Fx.Domain.Description[].</returns>
        public static Description[] GetCountryDescriptions()
        {
            const string file = "RequiredObjects.xml";

            Logger.Info("Start generating data for Media");

            var cultures = new List<CultureInfo> { new CultureInfo("nl"), new CultureInfo("fr"), new CultureInfo("en"), new CultureInfo("de") };
            var result = new Result();
            var h = new RequiredObjectsHelper(file);
            result.AddFeedback(h);
            var lst = new List<Description>();
            foreach (var cultureInfo in cultures)
            {
                string cultureName = cultureInfo.Name.Substring(0, 2).ToLower();
                List<Country> deserializedCountries = h.GetDeserializedDomainObjects<Country>("Items", e => (string)e.Attribute("Culture") == cultureName).ToList();
                var count = deserializedCountries.Count;
                if (count > 0)
                {
                    lst.AddRange(deserializedCountries
                        .Select(deserializedCountry => new Description() 
                    {
                        ObjectId = deserializedCountry.Id, 
                        CultureId = cultureName, 
                        Title = deserializedCountry.DefaultName
                    }));
                }
                else
                {
                    Logger.DebugFormat("Found no XElements in XDocument for culture = '{0}'", cultureName);
                }
            }

            Logger.Info("Finished generating data for Media");
            return lst.ToArray();
        }
    }
}
