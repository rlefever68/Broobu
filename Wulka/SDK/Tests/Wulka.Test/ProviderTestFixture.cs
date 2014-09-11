// ***********************************************************************
// Assembly         : Iris.Fx.Test
// Author           : Rafael Lefever
// Created          : 12-31-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-24-2014
// ***********************************************************************
// <copyright file="ProviderTestFixture.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using Iris.Fx.Test.Domain;
using Iris.Fx.Test.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Iris.Fx.Test
{
    /// <summary>
    /// Class ProviderTestFixture.
    /// </summary>
    [TestClass]
    public class ProviderTestFixture : IProviderTest
    {


        /// <summary>
        /// Try_s the generate test domain.
        /// </summary>
        [TestMethod]
        public void Try_GenerateSimpleDiningRoom()
        {
            try
            {
                RegisterSimpleDingingRoom();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetCombinedMessages());
            }
        }


        /// <summary>
        /// Try_s the generate complex dining room.
        /// </summary>
        [TestMethod]
        public void Try_GenerateComplexDiningRoom()
        {
            try
            {
                RegisterComplexDingingRoom();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetCombinedMessages());
            }
        }

        /// <summary>
        /// Registers the complex dinging room.
        /// </summary>
        private void RegisterComplexDingingRoom()
        {
            Provider<DiningRoom>.Save(DomainGenerator.GetComplexDiningRoom());
        }


        /// <summary>
        /// Try_s the get domain objects.
        /// </summary>
        [TestMethod]
        public void Try_GetDomainObjects()
        {
            try
            {
                RegisterComplexDingingRoom();
                
                var res = Provider<DiningRoom>.GetAll();
                foreach (var diningRoom in res)
                {
                    Console.WriteLine(diningRoom.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.GetCombinedMessages());
            }
            
        }


        /// <summary>
        /// Registers the domain objects.
        /// </summary>
        public void RegisterSimpleDingingRoom()
        {
            Provider<DiningRoom>.Save(DomainGenerator.GetDiningRoom());
        }



        public void RegisterUpholstry()
        {
            foreach (var upholstry in _things)
            {
                Provider<Upholstry>.Save(upholstry);
            }
        }


        public void DeleteUpholstry()
        {
            foreach (var upholstry in _things)
            {
                Provider<Upholstry>.Delete(upholstry);
            }
        }


        private readonly Upholstry[] _things = new Upholstry[] {
                new Upholstry() {Id          = "Upholstry01", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry02", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry03", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry04", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry05", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry06", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry07", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry08", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry09", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry10", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry11", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry12", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry13", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry14", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry15", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry16", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry17", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry18", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry19", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry20", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry21", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry22", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry23", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry24", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry25", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry26", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry27", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry28", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry29", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry30", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry31", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry32", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry33", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry34", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry35", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry36", DisplayName = "New"}, 
                new Upholstry() {Id          = "Upholstry37", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry38", DisplayName = "Old"}, 
                new Upholstry() {Id          = "Upholstry39", DisplayName = "Medium"}, 
                new Upholstry() {Id          = "Upholstry40", DisplayName = "Old"} 
            };

        
        
        [TestMethod]
        public void Try_GetUpholstryPages()
        {
            const bool save = false;
            const bool delete = false;
            try
            {

                if (save)
                    RegisterUpholstry();

                var req = new WhereRequest() { 
                    Descending = false,
                    DocName = "OldDoc",
                    ViewName = "OldView",
                    Value = "Old",
                    KeepView = false,
                    EndId = null,
                    EndKey = null,
                    KeyField = "Id",
                    Field = "DisplayName",
                    IncludeDocs = true,
                    Limit = 4,
                    Reduce = false,
                    Skip = 0,
                    Stale = false,
                    StartId = null,
                    StartKey = "Upholstry04"
                };
                var res = Provider<Upholstry>.Where(req);
                Console.WriteLine("Found {0} items", res.Length);
                foreach (var upholstry in res)
                {
                    Console.WriteLine(upholstry.ToString());
                }
            }
            finally
            {
                if(delete)
                    DeleteUpholstry();
            }
            
        }








    }
}
