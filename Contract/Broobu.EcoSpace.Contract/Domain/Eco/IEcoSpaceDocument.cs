using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Eco
{
    public interface IEcoSpaceDocument : IComposedObject
    {
        /// <summary>
        /// Gets or sets the applets.
        /// </summary>
        /// <value>The applets.</value>
        [DataMember]
        AppletContainer Applets { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [DataMember]
        RoleContainer Roles { get; set; }

        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>The menu.</value>
        [DataMember]
        MenuContainer Menu { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>The links.</value>
        [DataMember]
        MenuAppletLinkContainer MenuAppletLinks { get; set; }

        [DataMember]
        RoleMenuLinkContainer RoleMenuLinks { get; set; }

       


        MenuContainer GetMenuForUser(string userName, string cultureId=null);

        
        IRole SelectedRole { get; set; }




    }
}