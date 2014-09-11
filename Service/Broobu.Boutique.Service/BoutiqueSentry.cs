using System.Linq;
using System.ServiceModel;
using Broobu.Boutique.Business;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Contract.Interfaces;
using Wulka.Extensions;
using Wulka.Networking.Wcf;
using Wulka.Utils;
using NLog;

namespace Broobu.Boutique.Service
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    [ContextServiceBehavior]
    public class BoutiqueSentry : SentryBase, IBoutiqueSentry
    {
        readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        /// <remarks></remarks>
        protected override void RegisterRequiredDomainObjects()
        {
            _logger.Info("Inflating Boutiques Domain");
            BoutiqueProvider
                .Boutiques
                .InflateDomain();
        }


        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetUserEnvironmentInfo()
        {
            _logger.Info("Boutique UserInfo requested for user {0}",UserName);
            return BoutiqueProvider
                .Boutiques
                .GetUserEnvironmentInfo(UserName)
                .Zip();
        }


        /// <summary>
        /// Gets the applet menu.
        /// </summary>
        /// <param name="appletId">The applet id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public BoutiqueMenuInfo GetAppletMenu(string appletId)
        {
            return BoutiqueProvider
                .Boutiques
                .GetAppletMenu(UserName, appletId);
        }

       

       


        ///// <summary>
        ///// Saves the settings.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting SaveSettings(Setting item)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveSettings(item);
        //}

        ///// <summary>
        ///// Gets the settings.
        ///// </summary>
        ///// <param name="req">The req.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting GetSettings(Setting req)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetSettings(req);
        //}

       


        ///// <summary>
        ///// Gets the descriptions for object.
        ///// </summary>
        ///// <param name="typeId">The type id.</param>
        ///// <param name="objectId">The object id.</param>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetDescriptionsForObject(typeId, objectId, cultureId);
        //}

        ///// <summary>
        ///// Saves the description.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Description SaveDescription(Description item)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveDescription(item);
        //}

        ///// <summary>
        ///// Gets the description types.
        ///// </summary>
        ///// <param name="cultureId">The culture id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook[] GetDescriptionTypes(string cultureId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetDescriptionTypes(cultureId);
        //}

      

        ///// <summary>
        ///// Gets the personal settings.
        ///// </summary>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Setting GetPersonalSettings()
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetPersonalSettings(UserName);
        //}



        ///// <summary>
        ///// Gets the tag object.
        ///// </summary>
        ///// <param name="objectId">The object id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook GetTagObject(string objectId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetObject(objectId);
        //}

        ///// <summary>
        ///// Saves the tag object.
        ///// </summary>
        ///// <param name="it">It.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public Hook SaveTagObject(Hook it)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .SaveObject(it);
        //}

       


        ///// <summary>
        ///// Registers the applet.
        ///// </summary>
        ///// <param name="applet">The applet.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .RegisterApplet(applet);
        //}

        ///// <summary>
        ///// Gets the applet info.
        ///// </summary>
        ///// <param name="appletId">The applet id.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    return BoutiqueProvider
        //        .Boutiques
        //        .GetAppletInfo(appletId);
        //}

    }
}
