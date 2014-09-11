using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Fx.Test.Domain
{
    public static class DomainGenerator
    {

        public static DiningRoom GetDiningRoom()
        {

            return new DiningRoom() {Id = "DiningRoomSimple1"};

        }

        public static DiningRoom GetComplexDiningRoom()
        {
         
            return new DiningRoom()
            {
                Id = "DiningRoom1",
                Sideboards = new[]
                {
                    new Sideboard() {Id = "SideBoard1", Material = "Oak", CoverMaterial = "Marble"},
                    new Sideboard() {Id = "SideBoard2", Material = "Pine", CoverMaterial = "Stone"},
                    new Sideboard() {Id = "SideBoard3", Material = "Oak", CoverMaterial = "Pine"}
                },
                Tables = new[]
                {
                    new Table()
                    {
                        Id = "Table1",
                        Material = "Oak",
                        Color = "Red",
                        Chairs = new[]
                        {
                            new Chair()
                            {
                                Id = "Chair1",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry1", Material = "Leather", Color = "Red"}
                            },
                            new Chair()
                            {
                                Id = "Chair2",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry2", Material = "Leather", Color = "Red"}
                            },
                            new Chair()
                            {
                                Id = "Chair3",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry3", Material = "Leather", Color = "Red"}
                            },
                            new Chair()
                            {
                                Id = "Chair4",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry4", Material = "Leather", Color = "Red"}
                            }
                        }
                    },
                    new Table()
                    {
                        Id = "Table2",
                        Material = "Pine",
                        Color = "Yellow",
                        Chairs = new[]
                        {
                            new Chair()
                            {
                                Id = "Chair5",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry5", Material = "Leather", Color = "Blue"}
                            },
                            new Chair()
                            {
                                Id = "Chair6",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry6", Material = "Leather", Color = "Red"}
                            },
                            new Chair()
                            {
                                Id = "Chair7",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry7", Material = "Leather", Color = "Blue"}
                            },
                            new Chair()
                            {
                                Id = "Chair8",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry8", Material = "Leather", Color = "Red"}
                            }
                        }
                    },
                    new Table()
                    {
                        Id = "Table3",
                        Material = "Aluminium",
                        Color = "Silver",
                        Chairs = new[]
                        {
                            new Chair()
                            {
                                Id = "Chair9",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry9", Material = "Inox", Color = "Silver"}
                            },
                            new Chair()
                            {
                                Id = "Chair10",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry10", Material = "Leather", Color = "Red"}
                            },
                            new Chair()
                            {
                                Id = "Chair11",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry11", Material = "Inox", Color = "Silver"}
                            },
                            new Chair()
                            {
                                Id = "Chair12",
                                Material = "Oak",
                                NumberOfLegs = 4,
                                Upholstry = new Upholstry() {Id = "Upholstry12", Material = "Leather", Color = "Red"}
                            }
                        }
                    }
                }

            };

        }

    }
}
