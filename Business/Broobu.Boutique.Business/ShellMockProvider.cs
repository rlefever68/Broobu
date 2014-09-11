using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;
using Pms.Framework.Domain;
using Pms.Framework.Extensions.Utils;
using Pms.Shell.Business.Interfaces;
using Pms.Shell.Domain;

namespace Pms.Shell.Business
{
    class ShellMockProvider : IShellProvider
    {
        /// <summary>
        /// Gets the shell user info.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns></returns>
        public ShellUserInfo GetShellUserInfo(string userName, string passWord)
        {
            var r = ShellDomainGenerator
                .CreateMockShellUserInfo();
            var path = HostingEnvironment.MapPath(ShellConst.ShellUserInfoXmlPath);
            DomainSerializer<ShellUserInfo>.Serialize(r,  path);
            return r;
        }

        /// <summary>
        /// Gets the shell user info.
        /// </summary>
        /// <param name="pmsSession">The PMS session.</param>
        /// <returns></returns>
        public ShellUserInfo GetShellUserInfo(PMSSession pmsSession)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="authRequest">The auth request.</param>
        /// <returns></returns>
        public PMSSession LoginUser(PMSAuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates the session.
        /// </summary>
        /// <param name="pmsSession">The PMS session.</param>
        /// <returns></returns>
        public PMSSession ValidateSession(PMSSession pmsSession)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the application functions.
        /// </summary>
        /// <returns></returns>
        public ShellMenuInfo[] GetAllMenuInfo()
        {
            throw new NotImplementedException();
        }

        public ShellMenuInfo[] GetMenuInfoByFolderId(string folderId)
        {
            throw new NotImplementedException();
        }

        public Result SaveMenuInfo(ShellMenuInfo appFunc)
        {
            throw new NotImplementedException();
        }

        #region IShellProvider Members


        public Result RegisterException(ExceptionInfo info)
        {
            throw new NotImplementedException();
        }

        #endregion
    }




}





