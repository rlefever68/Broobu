// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract.Test
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-26-2014
// ***********************************************************************
// <copyright file="AccountTestFixture.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Test;
using Wulka.Utils;

namespace Broobu.EcoSpace.Contract.Test
{
    /// <summary>
    /// Class AccountTestFixture.
    /// </summary>
    [TestClass]
    public class EcoSpaceTestFixture : ServiceTestFixtureBase
    {

        [TestMethod]
        public override void Try_GetServiceEndpoints()
        {
            base.Try_GetServiceEndpoints();
        }




        /// <summary>
        /// Try_s the save default eco space.
        /// </summary>
        [TestMethod]
        public void Try_SaveDefaultEcoSpace()
        {
            ObjectIndex.Clear();
            var res = EcoSpaceFactory.MasterEcoSpace;
            DomainSerializer<IEcoSpaceDocument>.SaveToJsonFile(@"c:\temp\ecospace\broobu.json", res);
            WriteEcoSpace(res, true);
        }



        /// <summary>
        /// Try_s the load default eco space.
        /// </summary>
        [TestMethod]
        public void Try_LoadDefaultEcoSpace()
        {
            ObjectIndex.Clear();
            var res = DomainSerializer<EcoSpaceDocument>.LoadFromJsonFile(@"c:\temp\ecospace\broobu.json");
            WriteEcoSpace(res, true);
        }



        /// <summary>
        /// Try_s the save default eco space to big d.
        /// </summary>
        [TestMethod]
        public void Try_SaveDefaultEcoSpaceToBigD()
        {
            ObjectIndex.Clear();
            var res = EcoSpaceFactory.MasterEcoSpace;
            res = Provider<EcoSpaceDocument>
                .Save(res);
            WriteEcoSpace(res);

        }

        /// <summary>
        /// Writes the eco space.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="showIndex">if set to <c>true</c> [show index].</param>
        private void WriteEcoSpace(IEcoSpaceDocument doc, bool showIndex=true)
        {
            WriteResultInfo(doc);
            WriteResultInfo(doc.Applets,"  ");
            WriteResultInfo(doc.Menu,"  ");
            WriteResultInfo(doc.MenuAppletLinks,"  ");
            WriteResultInfo(doc.RoleMenuLinks, "  ");
            WriteResultInfo(doc.Roles, "  ");
            if(showIndex)
                WriteIndexInfo();
        }

        /// <summary>
        /// Writes the result information.
        /// </summary>
        /// <param name="res">The resource.</param>
        /// <param name="header">The header.</param>
        private void WriteResultInfo(IDomainObject res, string header=null)
        {
            header = String.Format("  {0}", header);
            Console.WriteLine("{0}[{1}]{2}  -  {3}",header, res.TreeDepth,res.DisplayName,res.Id);
            var o = res as IComposedObject;
            if(o==null)return;
            foreach (var part in o.Parts)
            {
                WriteResultInfo(part, header); 
            }
        }

        /// <summary>
        /// Try_s the read default eco space from big d.
        /// </summary>
        [TestMethod]
        public void Try_ReadDefaultEcoSpaceFromBigD()
        {
            var id = EcoSpaceFactory.MasterEcoSpace.Id;
            var res = Provider<EcoSpaceDocument>.GetById(id);
            WriteEcoSpace(res);
        }


        /// <summary>
        /// Writes the index information.
        /// </summary>
        private void WriteIndexInfo()
        {
            Console.WriteLine("\n-----------");
            Console.WriteLine("INDEX INFO");
            Console.WriteLine("-----------");
            Console.WriteLine("  Master Index has {0} items", ObjectIndex.Instance.Count());
            Console.WriteLine("  containing:");
            Console.WriteLine("     {0} Cloud Applets", ObjectIndex.Instance.Count<CloudApplet>());
            Console.WriteLine("     {0} Applet Features", ObjectIndex.Instance.Count<AppletFeature>());
            Console.WriteLine("--------------------------------------------\nDump:\n");
            foreach (var item in ObjectIndex.Instance.GetAll())
            {
                Console.WriteLine("[{0}]\t\t{1}", item.Id, item.DisplayName);
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\n\n");
        }


        protected override string GetContractType()
        {
            return String.Format("{0}:IEcoSpaceSentry", EcoSpaceConst.Namespace );
        }
    }
}
