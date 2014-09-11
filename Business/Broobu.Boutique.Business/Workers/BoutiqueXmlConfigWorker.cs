using System;
//using Broobu.Authorization.Contract.Domain;
using System.Collections.Generic;
using Broobu.Boutique.Business.Interfaces;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Contract.Interfaces;
//using Broobu.Taxonomy.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Wulka.Domain;
using Wulka.Utils;

namespace Broobu.Boutique.Business.Workers
{
    class BoutiqueXmlConfigWorker : IBoutiques
    {
        /// <summary>
        /// Gets the Boutique user info.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns></returns>
        public UserEnvironmentInfo GetUserEnvironmentInfo(string userName)
        {
            var res = new UserEnvironmentInfo
            {
                Menu = EcoSpaceFactory.MasterEcoSpace.Menu,
                Greeting = String.Format("User '{0}' validated.",userName)
            };
            return res;
        }




        //#region IBoutiqueProvider Members


        //public Setting SaveSettings(Setting item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Setting GetSettings(Setting req)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        //#region IBoutiqueProvider Members


        public UserEnvironmentInfo GetUserEnvironmentInfo(string userName, string ecoSpaceId = null)
        {
            throw new NotImplementedException();
        }

        public void InflateDomain()
        {

        }

        public BoutiqueMenuInfo GetAppletMenu(string userName, string appletId)
        {
            throw new NotImplementedException();
        }


        public UserEnvironmentInfo GetUserEnvironmentInfo()
        {
            throw new NotImplementedException();
        }

        //public WulkaSession TerminateSession()
        //{
        //    throw new NotImplementedException();
        //}

        //public Description[] GetDescriptionsForObject(string typeId, string objectId, string cultureId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Description SaveDescription(Description item)
        //{
        //    throw new NotImplementedException();
        //}

        //Hook[] IBoutique.GetDescriptionTypes(string cultrureId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Setting GetPersonalSettings()
        //{
        //    throw new NotImplementedException();
        //}

        //public Hook GetTagObject(string objectId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Hook SaveTagObject(Hook it)
        //{
        //    throw new NotImplementedException();
        //}

        

        //public Hook GetDescriptionTypes(string cultrureId)
        //{
        //    throw new NotImplementedException();
        //}



        //public Setting GetPersonalSettings(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion



        //public Hook GetObject(string objectId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Hook SaveObject(Hook it)
        //{
        //    throw new NotImplementedException();
        //}

        //public BoutiqueMenuInfo GetAppletMenu(string UserName, string appletId)
        //{
        //    throw new NotImplementedException();
        //}

        //public ApplicationFunction RegisterApplet(ApplicationFunction applet)
        //{
        //    throw new NotImplementedException();
        //}

        //public ApplicationFunction GetAppletInfo(string appletId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IdResult<bool> UserNameExists(string userName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
