using System;
using System.Linq;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Interfaces;
using Iris.Fx.Extensions;
using Iris.Fx.Test.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.Fx.Test
{
    [TestClass]
    public class DomainTestFixture
    {

        
        

        [TestMethod]
        public void Try_CompressDomainObject()
        {
            IDomainObject chair = new Chair() { DisplayName = "My Chair" };
            var compressedJson = chair.Zip();
            Console.WriteLine(compressedJson);
        }


        [TestMethod]
        public void Try_DecompressObject()
        {
            IDomainObject chair = new Chair() { DisplayName = "My Chair" };
            var i = chair.ToFlatJson();
            var compressedJson = chair.Zip();
            Console.WriteLine("\n\n**********************************************************************");
            Console.WriteLine(compressedJson);
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("Length: {0} chars",compressedJson.Length); 

            chair = compressedJson.Unzip<Chair>();
            var i2 = chair.ToFlatJson();
            Console.WriteLine("\n\n**********************************************************************");
            Console.WriteLine(chair.ToFlatJson());
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("Length: {0} chars", chair.ToFlatJson().Length); 
            Assert.AreEqual(i,i2);
        }
        
        
        
        
        
        
        
        
        
        
        
        [TestMethod]
        public void Try_CreateTable()
        {
            var res = new Table() {AdditionalInfoUri = "Some Aditional Info", Color = "Yellow", DisplayName = "A Yellow Table", Id="YellowTable1", Material = "Wood"};
            Console.WriteLine(res.ToString());
        }


        [TestMethod]
        public void Try_AddItemsToMasterIndex()
        {
            var master = ObjectIndex.Instance;
            IDomainObject chair = new Chair() {DisplayName="My Chair"};
            IComposedObject diningRoom = new DiningRoom() {DisplayName="My DiningRoom"};
            diningRoom.AddPart(chair);
            
            //Master.Reg(diningRoom);
            Console.WriteLine("AFTER ADDING THE DININGROOM:{0} items", master.Count());
            Console.WriteLine("Found DiningRooms:");
            foreach(var i in master.GetAll())
            {
                Console.WriteLine(String.Format("\t{0}",i.DisplayName));
            }
            diningRoom.AddPart(new Table { DisplayName = "Some Table" , Id="SPECIAL_TABLE"});
            diningRoom.AddPart(new Table { DisplayName = "Some other Table" });
            var res = master.GetAll<Table>();
            if (!res.Any())
                Console.WriteLine("Found no Tables");
            else
            {
                Console.WriteLine("Found Tables:");
                foreach (var i in res)
                {
                    Console.WriteLine("\t{0}", i.DisplayName);
                }
            }

            //REMOVING
            master.Unregister(chair);
            Console.WriteLine("AFTER REMOVING THE CHAIR:{0} items", master.Count());
            foreach (var i in master.GetAll())
            {

                Console.WriteLine("\t{0}", i.DisplayName);
            }


            master.Unregister(diningRoom);
            Console.WriteLine("AFTER REMOVING THE DININGROOM:{0} items", master.Count());
            foreach (var i in master.GetAll())
            {

                Console.WriteLine("\t{0}", i.DisplayName);
            }

        }


        [TestMethod]
        public void Try_GetHook()
        {
            //var x = new Chair {SourceType = typeof (Hook)};
            //var h = x.Hook;
        }

    }
}
