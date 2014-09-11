using System;
using System.Collections.Generic;
using System.Globalization;
using Pms.Framework.Domain;
using Pms.Framework.Validation;
using Pms.ManageWorkspaces.Resources;

namespace Pms.ManageWorkspaces.Contract.Domain
{
    public class WorkspaceBrowserDomainGenerator : DomainObject<WorkspaceBrowserDomainGenerator>
    {
        #region Public Methods

        #region Mock methods

        /// <summary>
        /// Gets the Workspace Items based on the workspaceid
        /// </summary>
        /// <param name="workspaceId">string name</param>
        /// <returns>IEnumerable</returns>
        public static WorkspaceItem[] CreateMockWorkspaceItems(string workspaceId)
        {
            switch (workspaceId)
            {
                case "00000001-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                                      new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000002-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                          ItemId = "00000002-0000-0000-0000-000000000000",
                                                                                         TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Title => Business applications - 22/10/2010 15:13:11",
                                                                                         SortOrder = 0,
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000003-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000003-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000004-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000004-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000005-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000005-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 3 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                   
                                                                                                 }.ToArray()
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000006-0000-0000-0000-000000000000",
                                                                                          ItemId = "00000006-0000-0000-0000-000000000000",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                                                         TypeTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                                                       
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                                       Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000006-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                             "Title => My applications type 1- 22/10/2010 15:13:11",
                                                                                                              ItemId = "00000007-0000-0000-0000-000000000000",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                                 ItemId = "00000009-0000-0000-0000-000000000000",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 1.1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                   Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000a-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000a-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000b-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000b-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                  "00000006-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000008-0000-0000-0000-000000000000",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                                 
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000c-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000c-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 3  - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000d-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000d-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 4 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000e-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000e-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000f-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000f-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }
                                                                                                   
                                                                                                   
                                                                                                 }.ToArray()
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000010-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                          ItemId = "00000010-0000-0000-0000-000000000000",
                                                                                         ItemTitle = "Title => App item 1 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000011-0000-0000-0000-000000000000",
                                                                                          ItemId = "00000011-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                         ItemTitle = "Title => App item 2 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "000000012-0000-0000-0000-000000000000",
                                                                                          ItemId = "00000012-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                        
                                                                                         ItemTitle = "Title => App item 3 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                        
                                                                                     }
                               }.ToArray();
                case "ROOT":
                    return new List<WorkspaceItem>
                               {
                                              new WorkspaceItem
                                                          {
                                                              Id = "00000001-0000-0000-0000-000000000000",
                                                               ItemId = "00000001-0000-0000-0000-000000000000",
                                                             
                                                              ParentId = "ROOT",
                                                              ItemTitle = "Title => Applications - 22/10/2010 15:13:11",
                                                              TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                              TypeTitle = "Base Type",
                                                              SortOrder = 0,
                                                              ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"CloseFolder.png"),
                                                              Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000002-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                           ItemId = "00000002-0000-0000-0000-000000000000",
                                                                                         TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Title => Business applications - 22/10/2010 15:13:11",
                                                                                         SortOrder = 0,
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000003-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000003-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000004-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000004-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000005-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000005-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 3 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                   
                                                                                                 }.ToArray()
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000006-0000-0000-0000-000000000000",
                                                                                           ItemId = "00000006-0000-0000-0000-000000000000",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                                                         TypeTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                                                       
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                                       Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000006-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000007-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                             "Title => My applications type 1- 22/10/2010 15:13:11",
                                                                                                            
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                                
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 1.1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                   Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000a-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000a-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000b-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000b-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "00000008-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                  "00000006-0000-0000-0000-000000000000",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                               
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000c-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000c-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 3  - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000d-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000d-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 4 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000e-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000e-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000f-0000-0000-0000-000000000000",
                                                                                                                   ItemId = "0000000f-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }
                                                                                                   
                                                                                                   
                                                                                                 }.ToArray()
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000010-0000-0000-0000-000000000000",
                                                                                           ItemId = "00000010-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                         ItemTitle = "Title => App item 1 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "00000011-0000-0000-0000-000000000000",
                                                                                         ItemId = "00000011-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                         ItemTitle = "Title => App item 2 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "000000012-0000-0000-0000-000000000000",
                                                                                         ItemId = "000000012-0000-0000-0000-000000000000",
                                                                                         ParentId = "00000001-0000-0000-0000-000000000000",
                                                                                       
                                                                                         ItemTitle = "Title => App item 3 - 22/10/2010 15:13:11",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                        
                                                                                     }
                                                                             }.ToArray()
                                                          }       
                               }.ToArray();
                case "00000002-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                             new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000003-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000003-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000004-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000004-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000005-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000005-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Title => Business application 3 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                   
                               }.ToArray();
                case "00000006-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                                    new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000007-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000006-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                             "Title => My applications type 1- 22/10/2010 15:13:11",
                                                                                                           
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                              
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 1.1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                   Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000a-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000a-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000b-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000b-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "00000008-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                  "00000006-0000-0000-0000-000000000000",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 2 - 22/10/2010 15:13:11",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                               
                                                                                                             TypeTitle =
                                                                                                                 "Title => Business application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                  Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000c-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000c-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 3  - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000d-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000d-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 4 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000e-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000e-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000f-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000f-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }
                                                                                                   
                                                                                                   
                               }.ToArray();
                case "00000007-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000007-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_FOLDER",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                                 ItemId =  "00000009-0000-0000-0000-000000000000",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications type 1.1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "CloseFolder.png"),
                                                                                                                   Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000a-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000a-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000b-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000b-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }}.ToArray()
                                                                                                                 
                                                                                                         }
                               }.ToArray();
                case "00000009-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                                    new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000a-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000a-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000b-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000b-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000009-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }
                               }.ToArray();
                case "00000008-0000-0000-0000-000000000000":
                    return new List<WorkspaceItem>
                               {
                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000c-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000c-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 3  - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                  new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000d-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000d-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My application 4 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000e-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000e-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 1 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         },
                                                                                                 new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "0000000f-0000-0000-0000-000000000000",
                                                                                                                  ItemId = "0000000f-0000-0000-0000-000000000000",
                                                                                                             ParentId =
                                                                                                                 "00000008-0000-0000-0000-000000000000",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Title => My specific application 2 - 22/10/2010 15:13:11",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png"),
                                                                                                                 
                                                                                                         }
                               }.ToArray();


            }
            return new List<WorkspaceItem>
            {
                new WorkspaceItem{
                Id = "ROOT",
                ParentId = "",
                TypeId = "ROOT",
                TypeTitle = "Root",
                ItemId = "ROOT",
                ItemTitle = "WorkspaceItem1"}
            }.ToArray();
        }

        /// <summary>
        /// Gets the Full Workspace Item based on the itemid
        /// </summary>
        /// <param name="itemId">string name</param>
        /// <returns>WorkspaceItem</returns>
        public static WorkspaceItem GetFullMockWorkspaceItem(string itemId)
        {
            switch (itemId)
            {
                case "ROOTitem1":
                    return new WorkspaceItem
                    {

                        Id = "ROOT",
                        ParentId = "",
                        TypeId = "ROOTitem1",
                        TypeTitle = "Root",
                        ItemId = "ROOTitem1",
                        ItemTitle = "WorkspaceItem1",
                        ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                  {
                                                      new WorkspaceItem
                                                          {
                                                              Id = "ROOTW1",
                                                              ParentId = "ROOT",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemTitle = "Root",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Descriptioninfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Descriptioninfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Descriptioninfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Descriptioninfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Descriptioninfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "Root1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue = "ROOT_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "Root2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue = "ROOT_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "Root3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue = "ROOT_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "Root4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue = "ROOT_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "Root5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue = "ROOT_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "BASE_TYPEW1",
                                                              ParentId = "ROOT",
                                                              ItemTitle = "Base Type",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.WorkspaceDescription.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.WorkspaceDescription.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.WorkspaceDescription.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.WorkspaceDescription.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.WorkspaceDescription.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "BASE_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "BASE_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "BASE_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "BASE_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "BASE_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_STRINGW1",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "String",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Description.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Description.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Description.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Description.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.Description.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "STRING_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "STRING_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "STRING_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "STRING_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "STRING_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_INTEGERW1",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "Integer",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "INTEGER_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "INTEGER_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "INTEGER_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "INTEGER_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "INTEGER_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_DATEW1",
                                                              ParentId = "BASE_TYPE",
                                                              ItemId = "Date",
                                                              ItemTitle = "Date",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "CloseFolder.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "DATE_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "DATE_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "DATE_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "DATE_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATEC1",
                                                                                           PropertyName = "DATE_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray(),
                                                              Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTC1",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPE",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRING",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGER",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemId = "Date_Date",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                         Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id = "ROOTC2",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "BASE_TYPE",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Base Type",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_STRING",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_String",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_INTEGER",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Integer",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_DATE",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Date",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                 }.ToArray()
                                                                                     }
                                                                             }.ToArray()
                                                          }
                                                  }.ToArray(),
                        Descriptions = new List<WorkspaceItemDescription>
                                                      {
                                                          new WorkspaceItemDescription
                                                              {
                                                                  Id = "ROOT",
                                                                  ItemId = "ROOT",
                                                                  AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                  CultureId = "LANGUAGE_ID1",
                                                                  Title = "DESCRIPTION_TEXT1",
                                                                  TypeId = "ROOT",
                                                                  Image =
                                                                      GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                      "Description.png")
                                                              },
                                                          new WorkspaceItemDescription
                                                              {
                                                                  Id = "BASE_TYPE",
                                                                  ItemId = "ROOT",
                                                                  AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                  CultureId = "LANGUAGE_ID2",
                                                                  Title = "DESCRIPTION_TEXT2",
                                                                  TypeId = "ROOT",
                                                                  Image =
                                                                      GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                      "Description.png")
                                                              },
                                                          new WorkspaceItemDescription
                                                              {
                                                                  Id = "TYPE_STRING",
                                                                  ItemId = "ROOT",
                                                                  AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                  CultureId = "LANGUAGE_ID3",
                                                                  Title = "DESCRIPTION_TEXT3",
                                                                  TypeId = "Base Type",
                                                                  Image =
                                                                      GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                      "Description.png")
                                                              },
                                                          new WorkspaceItemDescription
                                                              {
                                                                  Id = "TYPE_INTEGER",
                                                                  ItemId = "ROOT",
                                                                  AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                  CultureId = "LANGUAGE_ID4",
                                                                  Title = "DESCRIPTION_TEXT4",
                                                                  TypeId = "Base Type",
                                                                  Image =
                                                                      GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                      "Description.png")
                                                              },
                                                          new WorkspaceItemDescription
                                                              {
                                                                  Id = "TYPE_DATE",
                                                                  ItemId = "ROOT",
                                                                  AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                  CultureId = "LANGUAGE_ID5",
                                                                  Title = "DESCRIPTION_TEXT5",
                                                                  TypeId = "Base Type",
                                                                  Image =
                                                                      GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                      "Description.png")
                                                              },
                                                      }.ToArray(),
                        Properties = new List<WorkspaceItemProperty>
                                                    {
                                                        new WorkspaceItemProperty
                                                            {
                                                                Id = "ROOTC3",
                                                                PropertyName = "PROPERTY_NAME1",
                                                                PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                                                PropertyTypeId = "BASE_TYPE",
                                                                PropertyValue = "PROPERTY_VALUE1",
                                                                ItemId = "ROOT"
                                                            },
                                                        new WorkspaceItemProperty
                                                            {
                                                                Id = "BASE_TYPE",
                                                                PropertyName = "PROPERTY_NAME2",
                                                                PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                                                PropertyTypeId = "BASE_TYPE",
                                                                PropertyValue = "PROPERTY_VALUE2",
                                                                ItemId = "BASE_TYPE"
                                                            },
                                                        new WorkspaceItemProperty
                                                            {
                                                                Id = "TYPE_STRING",
                                                                PropertyName = "PROPERTY_NAME3",
                                                                PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                                                PropertyTypeId = "BASE_TYPE",
                                                                PropertyValue = "PROPERTY_VALUE3",
                                                                ItemId = "TYPE_STRING"
                                                            },
                                                        new WorkspaceItemProperty
                                                            {
                                                                Id = "TYPE_INTEGER",
                                                                PropertyName = "PROPERTY_NAME4",
                                                                PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                                                PropertyTypeId = "BASE_TYPE",
                                                                PropertyValue = "PROPERTY_VALUE4",
                                                                ItemId = "TYPE_INTEGER"
                                                            },
                                                        new WorkspaceItemProperty
                                                            {
                                                                Id = "TYPE_DATE",
                                                                PropertyName = "PROPERTY_NAME5",
                                                                PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                                                PropertyTypeId = "BASE_TYPE",
                                                                PropertyValue = "PROPERTY_VALUE5",
                                                                ItemId = "TYPE_DATE"
                                                            }
                                                    }.ToArray()



                    };
                case "ROOTitem2":
                    return new WorkspaceItem
                    {
                        Id = "BASE_TYPE",
                        ParentId = "ROOT",
                        ItemId = "ROOTitem2",
                        TypeId = "ROOT",
                        TypeTitle = "Root",
                        ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                        ItemTitle = "WorkspaceItem2",
                        Children = new List<WorkspaceItem>
                                           {
                                               new WorkspaceItem
                                                   {
                                                       Id = "ROOTw22",
                                                       ParentId = "ROOT",
                                                       ItemId = "ROOTitem6",
                                                       TypeId = "ROOT",
                                                       TypeTitle = "Root",
                                                       ItemTitle = "Root2",
                                                       ItemImage =
                                                           GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                           "CloseFolder.png"),
                                                       Children = new List<WorkspaceItem>
                                                                      {
                                                                          new WorkspaceItem
                                                                              {
                                                                                  Id = "ROOTw11",
                                                                                  ParentId = "ROOT",
                                                                                 
                                                                                  TypeId = "ROOT",
                                                                                  TypeTitle = "Root",
                                                                                  ItemTitle = "Date_Root",
                                                                                  ItemImage =
                                                                                      GetEmbeddedFile(
                                                                                          Const.ResourceAssemblyName,
                                                                                          "leafnode1.png")
                                                                              },
                                                                          new WorkspaceItem
                                                                              {
                                                                                  Id = "BASE_TYPEw2",
                                                                                  ParentId = "ROOT",
                                                                                  ItemTitle = "Base Type",
                                                                                  TypeId = "ROOT",
                                                                                  TypeTitle = "Root",
                                                                                  ItemImage =
                                                                                      GetEmbeddedFile(
                                                                                          Const.ResourceAssemblyName,
                                                                                          "leafnode1.png")
                                                                              },
                                                                          new WorkspaceItem
                                                                              {
                                                                                  Id = "TYPE_STRINGw2",
                                                                                  ParentId = "BASE_TYPE",
                                                                                  ItemTitle = "Date_String",
                                                                                  TypeId = "BASE_TYPE",
                                                                                  TypeTitle = "Base Type",
                                                                                  ItemImage =
                                                                                      GetEmbeddedFile(
                                                                                          Const.ResourceAssemblyName,
                                                                                          "leafnode1.png")
                                                                              },
                                                                          new WorkspaceItem
                                                                              {
                                                                                  Id = "TYPE_INTEGERw2",
                                                                                  ParentId = "BASE_TYPE",
                                                                                  ItemTitle = "Date_Integer",
                                                                                  TypeId = "BASE_TYPE",
                                                                                  TypeTitle = "Base Type",
                                                                                  ItemImage =
                                                                                      GetEmbeddedFile(
                                                                                          Const.ResourceAssemblyName,
                                                                                          "leafnode1.png")
                                                                              },
                                                                          new WorkspaceItem
                                                                              {
                                                                                  Id = "TYPE_DATEC2w2",
                                                                                  ParentId = "BASE_TYPE",
                                                                                  ItemId = "ROOTitem7",
                                                                                  ItemTitle = "Date_Date",
                                                                                  TypeId = "BASE_TYPE",
                                                                                  TypeTitle = "Base Type",
                                                                                  ItemImage =
                                                                                      GetEmbeddedFile(
                                                                                          Const.ResourceAssemblyName,
                                                                                          "CloseFolder.png"),
                                                                                  Children = new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "ROOTw12",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Root",
                                                                                                             ItemTitle =
                                                                                                                 "Date_Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (
                                                                                                                     Const
                                                                                                                         .
                                                                                                                         ResourceAssemblyName,
                                                                                                                     "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "BASE_TYPEw22",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Base Type",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (
                                                                                                                     Const
                                                                                                                         .
                                                                                                                         ResourceAssemblyName,
                                                                                                                     "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_STRINGw23",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date_String",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (
                                                                                                                     Const
                                                                                                                         .
                                                                                                                         ResourceAssemblyName,
                                                                                                                     "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_INTEGERw24",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date_Integer",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (
                                                                                                                     Const
                                                                                                                         .
                                                                                                                         ResourceAssemblyName,
                                                                                                                     "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_DATEC2w25",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date_Date",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (
                                                                                                                     Const
                                                                                                                         .
                                                                                                                         ResourceAssemblyName,
                                                                                                                     "leafnode1.png"),

                                                                                                         }
                                                                                                 }.ToArray(),

                                                                              }
                                                                      }.ToArray(),


                                                       Descriptions = new List<WorkspaceItemDescription>
                                                                          {
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "ROOT",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID1",
                                                                                      Title = "DESCRIPTION_TEXT1",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "BASE_TYPE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID2",
                                                                                      Title = "DESCRIPTION_TEXT2",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_STRING",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID3",
                                                                                      Title = "DESCRIPTION_TEXT3",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_INTEGER",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID4",
                                                                                      Title = "DESCRIPTION_TEXT4",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_DATE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID5",
                                                                                      Title = "DESCRIPTION_TEXT5",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                          }.ToArray(),
                                                       Properties = new List<WorkspaceItemProperty>
                                                                        {
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "ROOT",
                                                                                    PropertyName = "ROOT2_NAME1",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE1",
                                                                                    ItemId = "ROOT"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "BASE_TYPE",
                                                                                    PropertyName = "PROPERTY_NAME2",
                                                                                    PropertyTypeDescription =
                                                                                        "ROOT2_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE2",
                                                                                    ItemId = "BASE_TYPE"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_STRING",
                                                                                    PropertyName = "PROPERTY_NAME3",
                                                                                    PropertyTypeDescription =
                                                                                        "ROOT2_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE3",
                                                                                    ItemId = "TYPE_STRING"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_INTEGER",
                                                                                    PropertyName = "PROPERTY_NAME4",
                                                                                    PropertyTypeDescription =
                                                                                        "ROOT2_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE4",
                                                                                    ItemId = "TYPE_INTEGER"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_DATE",
                                                                                    PropertyName = "PROPERTY_NAME5",
                                                                                    PropertyTypeDescription =
                                                                                        "ROOT2_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE5",
                                                                                    ItemId = "TYPE_DATE"
                                                                                }
                                                                        }.ToArray()
                                                   },
                                               new WorkspaceItem
                                                   {
                                                       Id = "BASE_TYPE",
                                                       ParentId = "ROOT",
                                                       ItemTitle = "Base Type2",
                                                       TypeId = "ROOT",
                                                       TypeTitle = "Root",
                                                       ItemImage =
                                                           GetEmbeddedFile(Const.ResourceAssemblyName, "leafnode1.png"),
                                                       Descriptions = new List<WorkspaceItemDescription>
                                                                          {
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "ROOT",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID1",
                                                                                      Title = "DESCRIPTION_TEXT1",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "BASE_TYPE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID2",
                                                                                      Title = "DESCRIPTION_TEXT2",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_STRING",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID3",
                                                                                      Title = "DESCRIPTION_TEXT3",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_INTEGER",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID4",
                                                                                      Title = "DESCRIPTION_TEXT4",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_DATE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID5",
                                                                                      Title = "DESCRIPTION_TEXT5",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                          }.ToArray(),
                                                       Properties = new List<WorkspaceItemProperty>
                                                                        {
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "ROOT",
                                                                                    PropertyName = "BASE2_NAME1",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE1",
                                                                                    ItemId = "ROOT"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "BASE_TYPE",
                                                                                    PropertyName = "BASE2_NAME2",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE2",
                                                                                    ItemId = "BASE_TYPE"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_STRING",
                                                                                    PropertyName = "BASE2_NAME3",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE3",
                                                                                    ItemId = "TYPE_STRING"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_INTEGER",
                                                                                    PropertyName = "BASE2_NAME4",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE4",
                                                                                    ItemId = "TYPE_INTEGER"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_DATE",
                                                                                    PropertyName = "BASE2_NAME5",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE5",
                                                                                    ItemId = "TYPE_DATE"
                                                                                }
                                                                        }.ToArray()
                                                   },
                                               new WorkspaceItem
                                                   {
                                                       Id = "TYPE_STRING",
                                                       ParentId = "BASE_TYPE",
                                                       ItemTitle = "String2",
                                                       TypeId = "BASE_TYPE",
                                                       TypeTitle = "Base Type",
                                                       ItemImage =
                                                           GetEmbeddedFile(Const.ResourceAssemblyName, "leafnode1.png"),
                                                       Descriptions = new List<WorkspaceItemDescription>
                                                                          {
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "ROOT",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID1",
                                                                                      Title = "DESCRIPTION_TEXT1",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "BASE_TYPE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID2",
                                                                                      Title = "DESCRIPTION_TEXT2",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_STRING",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID3",
                                                                                      Title = "DESCRIPTION_TEXT3",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_INTEGER",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID4",
                                                                                      Title = "DESCRIPTION_TEXT4",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_DATE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID5",
                                                                                      Title = "DESCRIPTION_TEXT5",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                          }.ToArray(),
                                                       Properties = new List<WorkspaceItemProperty>
                                                                        {
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "ROOT",
                                                                                    PropertyName = "STRING2_NAME1",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE1",
                                                                                    ItemId = "ROOT"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "BASE_TYPE",
                                                                                    PropertyName = "STRING2_NAME2",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE2",
                                                                                    ItemId = "BASE_TYPE"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_STRING",
                                                                                    PropertyName = "STRING2_NAME3",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE3",
                                                                                    ItemId = "TYPE_STRING"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_INTEGER",
                                                                                    PropertyName = "STRING2_NAME4",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE4",
                                                                                    ItemId = "TYPE_INTEGER"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_DATE",
                                                                                    PropertyName = "STRING2_NAME5",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE5",
                                                                                    ItemId = "TYPE_DATE"
                                                                                }
                                                                        }.ToArray()
                                                   },
                                               new WorkspaceItem
                                                   {
                                                       Id = "TYPE_INTEGER",
                                                       ParentId = "BASE_TYPE",
                                                       ItemTitle = "Integer2",
                                                       TypeId = "BASE_TYPE",
                                                       TypeTitle = "Base Type",
                                                       ItemImage =
                                                           GetEmbeddedFile(Const.ResourceAssemblyName, "leafnode1.png"),
                                                       Descriptions = new List<WorkspaceItemDescription>
                                                                          {
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "ROOT",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri = "",
                                                                                      CultureId = "LANGUAGE_ID1",
                                                                                      Title = "DESCRIPTION_TEXT1",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "BASE_TYPE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID2",
                                                                                      Title = "DESCRIPTION_TEXT2",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_STRING",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID3",
                                                                                      Title = "DESCRIPTION_TEXT3",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_INTEGER",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID4",
                                                                                      Title = "DESCRIPTION_TEXT4",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_DATE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID5",
                                                                                      Title = "DESCRIPTION_TEXT5",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                          }.ToArray(),
                                                       Properties = new List<WorkspaceItemProperty>
                                                                        {
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "ROOT",
                                                                                    PropertyName = "INTEGER2_NAME1",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE1",
                                                                                    ItemId = "ROOT"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "BASE_TYPE",
                                                                                    PropertyName = "INTEGER2_NAME2",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE2",
                                                                                    ItemId = "BASE_TYPE"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_STRING",
                                                                                    PropertyName = "INTEGER2_NAME3",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE3",
                                                                                    ItemId = "TYPE_STRING"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_INTEGER",
                                                                                    PropertyName = "INTEGER2_NAME4",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE4",
                                                                                    ItemId = "TYPE_INTEGER"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_DATE",
                                                                                    PropertyName = "INTEGER2_NAME5",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE5",
                                                                                    ItemId = "TYPE_DATE"
                                                                                }
                                                                        }.ToArray()
                                                   },
                                               new WorkspaceItem
                                                   {
                                                       Id = "TYPE_DATEW1",
                                                       ParentId = "BASE_TYPE",
                                                       ItemTitle = "Date2",
                                                       TypeId = "BASE_TYPE",
                                                       TypeTitle = "Base Type",
                                                       ItemImage =
                                                           GetEmbeddedFile(Const.ResourceAssemblyName, "leafnode1.png"),
                                                       Descriptions = new List<WorkspaceItemDescription>
                                                                          {
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "ROOT",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri = "",
                                                                                      CultureId = "LANGUAGE_ID1",
                                                                                      Title = "DESCRIPTION_TEXT1",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "BASE_TYPE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID2",
                                                                                      Title = "DESCRIPTION_TEXT2",
                                                                                      TypeId = "ROOT",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_STRING",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID3",
                                                                                      Title = "DESCRIPTION_TEXT3",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_INTEGER",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID4",
                                                                                      Title = "DESCRIPTION_TEXT4",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                              new WorkspaceItemDescription
                                                                                  {
                                                                                      Id = "TYPE_DATE",
                                                                                      ItemId = "ROOT",
                                                                                      AdditionalInfoUri =
                                                                                          "http://wwww.DescriptionInfo.com",
                                                                                      CultureId = "LANGUAGE_ID5",
                                                                                      Title = "DESCRIPTION_TEXT5",
                                                                                      TypeId = "Base Type",
                                                                                      Image =
                                                                                          GetEmbeddedFile(
                                                                                              Const.ResourceAssemblyName,
                                                                                              "Description.png")
                                                                                  },
                                                                          }.ToArray(),
                                                       Properties = new List<WorkspaceItemProperty>
                                                                        {
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "ROOT",
                                                                                    PropertyName = "DATE2_NAME1",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE1",
                                                                                    ItemId = "ROOT"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "BASE_TYPE",
                                                                                    PropertyName = "DATE2_NAME2",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE2",
                                                                                    ItemId = "BASE_TYPE"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_STRING",
                                                                                    PropertyName = "DATE2_NAME3",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE3",
                                                                                    ItemId = "TYPE_STRING"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_INTEGER",
                                                                                    PropertyName = "DATE2_NAME4",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE4",
                                                                                    ItemId = "TYPE_INTEGER"
                                                                                },
                                                                            new WorkspaceItemProperty
                                                                                {
                                                                                    Id = "TYPE_DATE",
                                                                                    PropertyName = "DATE2_NAME5",
                                                                                    PropertyTypeDescription =
                                                                                        "NAME_PROPERTYTYPE",
                                                                                    PropertyTypeId = "BASE_TYPE",
                                                                                    PropertyValue = "PROPERTY_VALUE5",
                                                                                    ItemId = "TYPE_DATE"
                                                                                }
                                                                        }.ToArray()
                                                   }
                                           }.ToArray(),
                    };
                case "ROOTitem3":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_STRING",
                        ParentId = "BASE_TYPE",
                        ItemId = "TYPE_STRING",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                        ItemTitle = "WorkspaceItem3",
                        Children = new List<WorkspaceItem>
                                                  {
                                                      new WorkspaceItem
                                                          {
                                                              Id = "ROOT",
                                                              ParentId = "ROOT",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemTitle = "Root3",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "ROOT3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "ROOT3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "ROOT3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "ROOT3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "ROOT3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "BASE_TYPE",
                                                              ParentId = "ROOT",
                                                              ItemTitle = "Base Type3",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "BASE3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "BASE3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "BASE3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "BASE3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "BASE3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_STRING",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "String3",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "STRING3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "STRING3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "STRING3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "STRING3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "STRING3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_INTEGER",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "Integer3",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png"),
                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "INTEGER3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "INTEGER3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "INTEGER3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "INTEGER3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "INTEGER3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_DATEw3",
                                                              ParentId = "BASE_TYPE",
                                                              ItemId = "ROOTitem8",
                                                              ItemTitle = "Date3",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "CloseFolder.png"),
                                                              Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw3",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw3",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png"),

                                                                                     }
                                                                             }.ToArray(),

                                                              Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                                                              Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "DATE3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "DATE3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "DATE3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "DATE3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "DATE3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                                                          }
                                                  }.ToArray()
                    };
                case "ROOTitem4":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_INTEGER",
                        ParentId = "BASE_TYPE",
                        ItemId = "TYPE_INTEGER",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                        ItemTitle = "WorkspaceItem4",
                        Children = new List<WorkspaceItem>
                                                  {
                                                      new WorkspaceItem
                                                          {
                                                              Id = "ROOT",
                                                              ParentId = "ROOT",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemTitle = "Root4",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png")
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "BASE_TYPE",
                                                              ParentId = "ROOT",
                                                              ItemTitle = "Base Type4",
                                                              TypeId = "ROOT",
                                                              TypeTitle = "Root",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png")
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_STRING",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "String4",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png")
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_INTEGER",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "Integer4",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "leafnode1.png")
                                                          },
                                                      new WorkspaceItem
                                                          {
                                                              Id = "TYPE_DATE45",
                                                              ParentId = "BASE_TYPE",
                                                              ItemTitle = "Date4",
                                                              ItemId = "ROOTitem9",
                                                              TypeId = "BASE_TYPE",
                                                              TypeTitle = "Base Type",
                                                              ItemImage =
                                                                  GetEmbeddedFile(Const.ResourceAssemblyName,
                                                                                  "CloseFolder.png"),
                                                              Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOT45",
                                                                                         ParentId = "TYPE_DATE",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Root4",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPE",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type4",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRING",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "String4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGER",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Integer4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATE",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     }
                                                                             }.ToArray()
                                                          }
                                                  }.ToArray()
                    };
                case "ROOTitem5":
                    return new WorkspaceItem
                    {

                        Children = new List<WorkspaceItem> { new WorkspaceItem { Id = "ROOT", ParentId = "ROOT", TypeId = "ROOT", TypeTitle = "Root",ItemTitle = "Root5",ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"leafnode1.png")},
                                                                 new WorkspaceItem { Id = "BASE_TYPE", ParentId = "ROOT", ItemTitle = "Base Type5",TypeId = "ROOT", TypeTitle = "Root",ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"leafnode1.png")} ,
                                                                 new WorkspaceItem { Id = "TYPE_STRING", ParentId = "BASE_TYPE",ItemTitle = "String5", TypeId = "BASE_TYPE", TypeTitle = "Base Type",ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"leafnode1.png")} ,
                                                                 new WorkspaceItem { Id = "TYPE_INTEGER", ParentId = "BASE_TYPE",ItemTitle = "Integer5", TypeId = "BASE_TYPE", TypeTitle = "Base Type",ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"leafnode1.png")} ,
                                                                 new WorkspaceItem { Id = "TYPE_DATEw5",ItemId = "ROOTitem10", ParentId = "BASE_TYPE",  ItemTitle = "Date5", TypeId = "BASE_TYPE", TypeTitle = "Base Type",ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"CloseFolder.png"),
                                                                  Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw11w5",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw5",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png"),
                                                                                                 
                                                                                     }
                                                                             }.ToArray(),
                                                           
                                                                 }}.ToArray()
                    };
                case "Date":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATEW1",
                        ParentId = "BASE_TYPE",
                        ItemTitle = "Date",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage =
                            GetEmbeddedFile(Const.ResourceAssemblyName,
                                            "CloseFolder.png"),
                        Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                        Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "DATE_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "DATE_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "DATE_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "DATE_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATEC1",
                                                                                           PropertyName = "DATE_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray(),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTC1",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPE",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRING",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGER",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemId = "Date_Date",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                         Children =
                                                                                             new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id = "ROOTC2",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "BASE_TYPE",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Base Type",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_STRING",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_String",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_INTEGER",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Integer",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_DATE",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Date",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                 }.ToArray()
                                                                                     }
                                                                             }.ToArray()
                    };
                case "Date_Date":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATEC2",
                        ParentId = "BASE_TYPE",
                        ItemTitle = "Date_Date",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage =
                            GetEmbeddedFile(
                                Const.
                                    ResourceAssemblyName,
                                "CloseFolder.png"),
                        Children =
                            new List<WorkspaceItem>
                                                                                                 {
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id = "ROOTC2",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Date1_Root",
                                                                                                             ItemTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "BASE_TYPE",
                                                                                                             ParentId =
                                                                                                                 "ROOT",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Base Type",
                                                                                                             TypeId =
                                                                                                                 "ROOT",
                                                                                                             TypeTitle =
                                                                                                                 "Root",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_STRING",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_String",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_INTEGER",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Integer",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         },
                                                                                                     new WorkspaceItem
                                                                                                         {
                                                                                                             Id =
                                                                                                                 "TYPE_DATE",
                                                                                                             ParentId =
                                                                                                                 "BASE_TYPE",
                                                                                                             ItemTitle =
                                                                                                                 "Date1_Date",
                                                                                                             TypeId =
                                                                                                                 "BASE_TYPE",
                                                                                                             TypeTitle =
                                                                                                                 "Base Type",
                                                                                                             ItemImage =
                                                                                                                 GetEmbeddedFile
                                                                                                                 (Const.
                                                                                                                      ResourceAssemblyName,
                                                                                                                  "leafnode1.png")
                                                                                                         }
                                                                                                 }.ToArray()
                    };
                case "ROOTitem6":
                    return new WorkspaceItem
                    {
                        Id = "ROOTw22",
                        ParentId = "ROOT",
                        TypeId = "ROOT",
                        TypeTitle = "Root",
                        ItemTitle = "Root2",
                        ItemImage =
                            GetEmbeddedFile(Const.ResourceAssemblyName,
                                            "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw11",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw2",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw2",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw2",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w2",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemId = "ROOTitem7",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "CloseFolder.png"),
                                                                                                  Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw12",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw22",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw23",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw24",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w25",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png"),
                                                                                                 
                                                                                     }
                                                                             }.ToArray(),
                                                           
                                                                                     }
                                                                             }.ToArray(),


                        Descriptions = new List<WorkspaceItemDescription>{ new WorkspaceItemDescription{Id ="ROOT", ItemId="ROOT",AdditionalInfoUri ="http://wwww.DescriptionInfo.com",CultureId = "LANGUAGE_ID1",Title = "DESCRIPTION_TEXT1",TypeId = "ROOT",Image = GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png")},
                                                                           new WorkspaceItemDescription{Id ="BASE_TYPE", ItemId="ROOT",AdditionalInfoUri ="http://wwww.DescriptionInfo.com",CultureId = "LANGUAGE_ID2",Title = "DESCRIPTION_TEXT2",TypeId = "ROOT",Image = GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png")},
                                                                           new WorkspaceItemDescription{Id ="TYPE_STRING", ItemId="ROOT",AdditionalInfoUri ="http://wwww.DescriptionInfo.com",CultureId = "LANGUAGE_ID3",Title = "DESCRIPTION_TEXT3",TypeId = "Base Type",Image = GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png")},
                                                                           new WorkspaceItemDescription{Id ="TYPE_INTEGER", ItemId="ROOT",AdditionalInfoUri ="http://wwww.DescriptionInfo.com",CultureId = "LANGUAGE_ID4",Title = "DESCRIPTION_TEXT4",TypeId = "Base Type",Image = GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png")},
                                                                           new WorkspaceItemDescription{Id ="TYPE_DATE", ItemId="ROOT",AdditionalInfoUri ="http://wwww.DescriptionInfo.com",CultureId = "LANGUAGE_ID5",Title = "DESCRIPTION_TEXT5",TypeId = "Base Type",Image = GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png")},}.ToArray(),
                        Properties = new List<WorkspaceItemProperty>{ new WorkspaceItemProperty{Id = "ROOT",PropertyName ="ROOT2_NAME1",PropertyTypeDescription = "NAME_PROPERTYTYPE",PropertyTypeId = "BASE_TYPE",PropertyValue = "PROPERTY_VALUE1",ItemId = "ROOT"},
                                                                         new WorkspaceItemProperty{Id = "BASE_TYPE",PropertyName ="PROPERTY_NAME2",PropertyTypeDescription = "ROOT2_PROPERTYTYPE",PropertyTypeId = "BASE_TYPE",PropertyValue = "PROPERTY_VALUE2",ItemId = "BASE_TYPE"},
                                                                         new WorkspaceItemProperty{Id = "TYPE_STRING",PropertyName ="PROPERTY_NAME3",PropertyTypeDescription = "ROOT2_PROPERTYTYPE",PropertyTypeId = "BASE_TYPE",PropertyValue = "PROPERTY_VALUE3",ItemId = "TYPE_STRING"},
                                                                         new WorkspaceItemProperty{Id = "TYPE_INTEGER",PropertyName ="PROPERTY_NAME4",PropertyTypeDescription = "ROOT2_PROPERTYTYPE",PropertyTypeId = "BASE_TYPE",PropertyValue = "PROPERTY_VALUE4",ItemId = "TYPE_INTEGER"},
                                                                         new WorkspaceItemProperty{Id = "TYPE_DATE",PropertyName ="PROPERTY_NAME5",PropertyTypeDescription = "ROOT2_PROPERTYTYPE",PropertyTypeId = "BASE_TYPE",PropertyValue = "PROPERTY_VALUE5",ItemId = "TYPE_DATE"}}.ToArray()
                    };
                case "ROOTitem7":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATEC2w2",
                        ParentId = "BASE_TYPE",
                        ItemId = "ROOTitem7",
                        ItemTitle = "Date_Date",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage =
                            GetEmbeddedFile(
                                Const.ResourceAssemblyName,
                                "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw12",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw22",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw23",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw24",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w25",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png"),
                                                                                                 
                                                                                     }
                                                                             }.ToArray()
                    };
                case "ROOTitem8":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATEw3",
                        ParentId = "BASE_TYPE",
                        ItemTitle = "Date3",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage =
                            GetEmbeddedFile(Const.ResourceAssemblyName,
                                            "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw3",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw3",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w3",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.
                                                                                                     ResourceAssemblyName,
                                                                                                 "leafnode1.png"),

                                                                                     }
                                                                             }.ToArray(),

                        Descriptions = new List<WorkspaceItemDescription>
                                                                                 {
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "ROOT",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri = "",
                                                                                             CultureId = "LANGUAGE_ID1",
                                                                                             Title = "DESCRIPTION_TEXT1",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "BASE_TYPE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID2",
                                                                                             Title = "DESCRIPTION_TEXT2",
                                                                                             TypeId = "ROOT",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_STRING",
                                                                                             ItemId = "ROOT",
                                                                                            
                                                                                             CultureId = "LANGUAGE_ID3",
                                                                                             Title = "DESCRIPTION_TEXT3",
                                                                                             TypeId = "Base Type",
                                                                                              AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_INTEGER",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID4",
                                                                                             Title = "DESCRIPTION_TEXT4",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                     new WorkspaceItemDescription
                                                                                         {
                                                                                             Id = "TYPE_DATE",
                                                                                             ItemId = "ROOT",
                                                                                             AdditionalInfoUri =
                                                                                                 "http://wwww.DescriptionInfo.com",
                                                                                             CultureId = "LANGUAGE_ID5",
                                                                                             Title = "DESCRIPTION_TEXT5",
                                                                                             TypeId = "Base Type",
                                                                                             Image =
                                                                                                 GetEmbeddedFile(
                                                                                                     Const.
                                                                                                         ResourceAssemblyName,
                                                                                                     "Description.png")
                                                                                         },
                                                                                 }.ToArray(),
                        Properties = new List<WorkspaceItemProperty>
                                                                               {
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "ROOT",
                                                                                           PropertyName = "DATE3_NAME1",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE1",
                                                                                           ItemId = "ROOT"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "BASE_TYPE",
                                                                                           PropertyName = "DATE3_NAME2",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE2",
                                                                                           ItemId = "BASE_TYPE"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_STRING",
                                                                                           PropertyName = "DATE3_NAME3",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE3",
                                                                                           ItemId = "TYPE_STRING"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_INTEGER",
                                                                                           PropertyName = "DATE3_NAME4",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE4",
                                                                                           ItemId = "TYPE_INTEGER"
                                                                                       },
                                                                                   new WorkspaceItemProperty
                                                                                       {
                                                                                           Id = "TYPE_DATE",
                                                                                           PropertyName = "DATE3_NAME5",
                                                                                           PropertyTypeDescription =
                                                                                               "NAME_PROPERTYTYPE",
                                                                                           PropertyTypeId = "BASE_TYPE",
                                                                                           PropertyValue =
                                                                                               "PROPERTY_VALUE5",
                                                                                           ItemId = "TYPE_DATE"
                                                                                       }
                                                                               }.ToArray()
                    };
                case "ROOTitem9":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATE45",
                        ParentId = "BASE_TYPE",
                        ItemTitle = "Date4",
                        ItemId = "ROOTitem9",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage =
                            GetEmbeddedFile(Const.ResourceAssemblyName,
                                            "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOT45",
                                                                                         ParentId = "TYPE_DATE",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Root4",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPE",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type4",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRING",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "String4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGER",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Integer4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATE",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date4",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     }
                                                                             }.ToArray()
                    };
                case "ROOTitem10":
                    return new WorkspaceItem
                    {
                        Id = "TYPE_DATEw5",
                        ItemId = "ROOTitem10",
                        ParentId = "BASE_TYPE",
                        ItemTitle = "Date5",
                        TypeId = "BASE_TYPE",
                        TypeTitle = "Base Type",
                        ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                        Children = new List<WorkspaceItem>
                                                                             {
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "ROOTw11w5",
                                                                                         ParentId = "ROOT",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemTitle = "Date_Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "BASE_TYPEw5",
                                                                                         ParentId = "ROOT",
                                                                                         ItemTitle = "Base Type",
                                                                                         TypeId = "ROOT",
                                                                                         TypeTitle = "Root",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_STRINGw5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_String",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_INTEGERw5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Integer",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png")
                                                                                     },
                                                                                 new WorkspaceItem
                                                                                     {
                                                                                         Id = "TYPE_DATEC2w5",
                                                                                         ParentId = "BASE_TYPE",
                                                                                         ItemTitle = "Date_Date",
                                                                                         TypeId = "BASE_TYPE",
                                                                                         TypeTitle = "Base Type",
                                                                                         ItemImage =
                                                                                             GetEmbeddedFile(
                                                                                                 Const.ResourceAssemblyName,
                                                                                                 "leafnode1.png"),
                                                                                                 
                                                                                     }
                                                                             }.ToArray()
                    };
            }
            return new WorkspaceItem
            {

                Id = "ROOT",
                ParentId = "",
                TypeId = "ROOT",
                TypeTitle = "Root",
                ItemId = "ROOT",
                ItemTitle = "WorkspaceItem1"
            };
        }

        /// <summary>
        /// Gets the Workspace properties based on the itemid
        /// </summary>
        /// <param name="itemId">string name</param>
        /// <returns>IEnumerable WorkspaceItemProperty</returns>
        public static WorkspaceItemProperty[] GetMockProperties(string itemId)
        {
            switch (itemId)
            {
                case "00000001-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000001-0000-0000-0000-000000000000",
                                           PropertyName = "Property(01) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(01) - 1 of 3",
                                           ItemId = "00000001-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000002-0000-0000-0000-000000000000",
                                           PropertyName = "Property(01) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(02) - 2 of 3",
                                           ItemId = "00000001-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000003-0000-0000-0000-000000000000",
                                           PropertyName = "Property(01) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(03) - 3 of 3",
                                           ItemId = "00000001-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000002-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000000b-0000-0000-0000-000000000000",
                                           PropertyName = "Property(0b) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(0b) - 1 of 3",
                                           ItemId = "00000002-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000000c-0000-0000-0000-000000000000",
                                           PropertyName = "Property(0c) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(0c) - 2 of 3",
                                           ItemId = "00000002-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000000d-0000-0000-0000-000000000000",
                                           PropertyName = "Property(0d) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(0d) - 3 of 3",
                                           ItemId = "00000002-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000003-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000015-0000-0000-0000-000000000000",
                                           PropertyName = "Property(15) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(15) - 1 of 3",
                                           ItemId = "00000003-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000016-0000-0000-0000-000000000000",
                                           PropertyName = "Property(16) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(16) - 2 of 3",
                                           ItemId = "00000003-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000017-0000-0000-0000-000000000000",
                                           PropertyName = "Property(17) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(17) - 3 of 3",
                                           ItemId = "00000003-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000004-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000001f-0000-0000-0000-000000000000",
                                           PropertyName = "Property(1f) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(1f) - 1 of 3",
                                           ItemId = "00000004-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000020-0000-0000-0000-000000000000",
                                           PropertyName = "Property(20) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(20) - 2 of 3",
                                           ItemId = "00000004-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000021-0000-0000-0000-000000000000",
                                           PropertyName = "Property(21) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(21) - 3 of 3",
                                           ItemId = "00000004-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000005-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000029-0000-0000-0000-000000000000",
                                           PropertyName = "Property(29) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(29) - 1 of 3",
                                           ItemId = "00000005-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000002a-0000-0000-0000-000000000000",
                                           PropertyName = "Property(2a) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(2a) - 2 of 3",
                                           ItemId = "00000005-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000002b-0000-0000-0000-000000000000",
                                           PropertyName = "Property(2b) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(2b) - 3 of 3",
                                           ItemId = "00000005-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000006-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000033-0000-0000-0000-000000000000",
                                           PropertyName = "Property(33) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(33) - 1 of 3",
                                           ItemId = "00000006-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000034-0000-0000-0000-000000000000",
                                           PropertyName = "Property(34) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(34) - 2 of 3",
                                           ItemId = "00000006-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000035-0000-0000-0000-000000000000",
                                           PropertyName = "Property(35) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(35) - 3 of 3",
                                           ItemId = "00000006-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000007-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000003d-0000-0000-0000-000000000000",
                                           PropertyName = "Property(3d) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(3d) - 1 of 3",
                                           ItemId = "00000007-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000003e-0000-0000-0000-000000000000",
                                           PropertyName = "Property(3e) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(3e) - 2 of 3",
                                           ItemId = "00000007-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000003f-0000-0000-0000-000000000000",
                                           PropertyName = "Property(3f) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(3f) - 3 of 3",
                                           ItemId = "00000007-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000008-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000047-0000-0000-0000-000000000000",
                                           PropertyName = "Property(47) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(47) - 1 of 3",
                                           ItemId = "00000008-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000048-0000-0000-0000-000000000000",
                                           PropertyName = "Property(48) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(48) - 2 of 3",
                                           ItemId = "00000008-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000049-0000-0000-0000-000000000000",
                                           PropertyName = "Property(49) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(49) - 3 of 3",
                                           ItemId = "00000008-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000009-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000051-0000-0000-0000-000000000000",
                                           PropertyName = "Property(51) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(51) - 1 of 3",
                                           ItemId = "00000009-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000052-0000-0000-0000-000000000000",
                                           PropertyName = "Property(52) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(52) - 2 of 3",
                                           ItemId = "00000009-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000053-0000-0000-0000-000000000000",
                                           PropertyName = "Property(53) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(53) - 3 of 3",
                                           ItemId = "00000009-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000010-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000005b-0000-0000-0000-000000000000",
                                           PropertyName = "Property(5b) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(5b) - 1 of 3",
                                           ItemId = "00000010-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000005c-0000-0000-0000-000000000000",
                                           PropertyName = "Property(5c) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(5c) - 2 of 3",
                                           ItemId = "00000010-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000005d-0000-0000-0000-000000000000",
                                           PropertyName = "Property(5d) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(5d) - 3 of 3",
                                           ItemId = "00000010-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000011-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000065-0000-0000-0000-000000000000",
                                           PropertyName = "Property(65) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(65) - 1 of 3",
                                           ItemId = "00000011-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000066-0000-0000-0000-000000000000",
                                           PropertyName = "Property(66) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(66) - 2 of 3",
                                           ItemId = "00000011-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000067-0000-0000-0000-000000000000",
                                           PropertyName = "Property(67) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(67) - 3 of 3",
                                           ItemId = "00000011-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "00000012-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000006f-0000-0000-0000-000000000000",
                                           PropertyName = "Property(6f) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(6f) - 1 of 3",
                                           ItemId = "00000012-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000060-0000-0000-0000-000000000000",
                                           PropertyName = "Property(60) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(60) - 2 of 3",
                                           ItemId = "00000012-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000061-0000-0000-0000-000000000000",
                                           PropertyName = "Property(61) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(61) - 3 of 3",
                                           ItemId = "00000012-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000a-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000079-0000-0000-0000-000000000000",
                                           PropertyName = "Property(79) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(79) - 1 of 3",
                                           ItemId = "0000000a-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000007a-0000-0000-0000-000000000000",
                                           PropertyName = "Property(7a) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(7a) - 2 of 3",
                                           ItemId = "0000000a-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000007b-0000-0000-0000-000000000000",
                                           PropertyName = "Property(7b) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(7b) - 3 of 3",
                                           ItemId = "0000000a-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000b-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000083-0000-0000-0000-000000000000",
                                           PropertyName = "Property(83) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(83) - 1 of 3",
                                           ItemId = "0000000b-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000084-0000-0000-0000-000000000000",
                                           PropertyName = "Property(84) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(84) - 2 of 3",
                                           ItemId = "0000000b-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000085-0000-0000-0000-000000000000",
                                           PropertyName = "Property(85) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(85) - 3 of 3",
                                           ItemId = "0000000b-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000c-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "0000008d-0000-0000-0000-000000000000",
                                           PropertyName = "Property(8d) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(8d) - 1 of 3",
                                           ItemId = "0000000c-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "0000008e-0000-0000-0000-000000000000",
                                           PropertyName = "Property(8e) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(8e) - 2 of 3",
                                           ItemId = "0000000c-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "0000008f-0000-0000-0000-000000000000",
                                           PropertyName = "Property(8f) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(8f) - 3 of 3",
                                           ItemId = "0000000c-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000d-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "00000097-0000-0000-0000-000000000000",
                                           PropertyName = "Property(97) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(97) - 1 of 3",
                                           ItemId = "0000000d-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "00000098-0000-0000-0000-000000000000",
                                           PropertyName = "Property(98) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(98) - 2 of 3",
                                           ItemId = "0000000d-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "00000099-0000-0000-0000-000000000000",
                                           PropertyName = "Property(99) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(99) - 3 of 3",
                                           ItemId = "0000000d-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000e-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "000000a1-0000-0000-0000-000000000000",
                                           PropertyName = "Property(a1) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(a1) - 1 of 3",
                                           ItemId = "0000000e-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "000000a2-0000-0000-0000-000000000000",
                                           PropertyName = "Property(a2) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(a2) - 2 of 3",
                                           ItemId = "0000000e-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "000000a3-0000-0000-0000-000000000000",
                                           PropertyName = "Property(a3) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(a3) - 3 of 3",
                                           ItemId = "0000000e-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
                case "0000000f-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "000000ab-0000-0000-0000-000000000000",
                                           PropertyName = "Property(ab) - 1 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(ab) - 1 of 3",
                                           ItemId = "0000000f-0000-0000-0000-000000000000"
                                       },
                                  new WorkspaceItemProperty
                                       {
                                           Id = "000000ac-0000-0000-0000-000000000000",
                                           PropertyName = "Property(ac) - 2 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(ac) - 2 of 3",
                                           ItemId = "0000000f-0000-0000-0000-000000000000"
                                       },
                                         new WorkspaceItemProperty
                                       {
                                           Id = "000000ad-0000-0000-0000-000000000000",
                                           PropertyName = "Property(ad) - 3 of 3",
                                           PropertyTypeDescription = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyTypeId = "BASE_TYPE_WPI_PROPERTY",
                                           PropertyValue = "Property value(ad) - 3 of 3",
                                           ItemId = "0000000f-0000-0000-0000-000000000000"
                                       }
                               }.ToArray();
            }
            return new List<WorkspaceItemProperty>
                               {
                                   new WorkspaceItemProperty
                                       {
                                           Id = "ROOT",
                                           PropertyName = "PROPERTY_NAME1",
                                           PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                           PropertyTypeId = "BASE_TYPE",
                                           PropertyValue = "PROPERTY_VALUE1",
                                           ItemId = "ROOT"
                                       },
                                   new WorkspaceItemProperty
                                       {
                                           Id = "BASE_TYPE",
                                           PropertyName = "PROPERTY_NAME2",
                                           PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                           PropertyTypeId = "BASE_TYPE",
                                           PropertyValue = "PROPERTY_VALUE2",
                                           ItemId = "BASE_TYPE"
                                       },
                                   new WorkspaceItemProperty
                                       {
                                           Id = "TYPE_STRING",
                                           PropertyName = "PROPERTY_NAME3",
                                           PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                           PropertyTypeId = "BASE_TYPE",
                                           PropertyValue = "PROPERTY_VALUE3",
                                           ItemId = "TYPE_STRING"
                                       },
                                   new WorkspaceItemProperty
                                       {
                                           Id = "TYPE_INTEGER",
                                           PropertyName = "PROPERTY_NAME4",
                                           PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                           PropertyTypeId = "BASE_TYPE",
                                           PropertyValue = "PROPERTY_VALUE4",
                                           ItemId = "TYPE_INTEGER"
                                       },
                                   new WorkspaceItemProperty
                                       {
                                           Id = "TYPE_DATE",
                                           PropertyName = "PROPERTY_NAME5",
                                           PropertyTypeDescription = "NAME_PROPERTYTYPE",
                                           PropertyTypeId = "BASE_TYPE",
                                           PropertyValue = "PROPERTY_VALUE5",
                                           ItemId = "TYPE_DATE"
                                       },

                               }.ToArray();
        }

        /// <summary>
        /// Gets the mock properties for type id.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public static WorkspaceItemProperty[] GetMockPropertiesForTypeId(string typeId)
        {
            return GenerateRandomProperties(new WorkspaceItem { TypeId = typeId });
            
        }

        /// <summary>
        /// Gets the Workspace description based on the itemid
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>IEnumerable WorkspaceItemDescription</returns>
        public static WorkspaceItemDescription[] GetMockDescriptions(string itemId)
        {
            switch (itemId)
            {
                case "00000001-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000001-0000-0000-0000-000000000000",
                                           ItemId = "00000001-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           Title = "Description(01) - 1 of 2",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Image =GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png"),
                                          
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000002-0000-0000-0000-000000000000",
                                           ItemId = "00000001-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           Title = "Description(02) - 2 of 2",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Image =GetEmbeddedFile(Const.ResourceAssemblyName,"Description.png"),
                                       }
                                
                               }.ToArray();
                case "00000002-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000000b-0000-0000-0000-000000000000",
                                           ItemId = "00000002-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           Title = "Description(0b) - 1 of 2",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000000c-0000-0000-0000-000000000000",
                                           ItemId = "00000002-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(0c) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                               

                               }.ToArray();
                case "00000003-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000015-0000-0000-0000-000000000000",
                                           ItemId = "00000003-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(15) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000016-0000-0000-0000-000000000000",
                                           ItemId = "00000003-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(16) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                

                               }.ToArray();
                case "00000004-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000001f-0000-0000-0000-000000000000",
                                           ItemId = "00000004-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(1f) - 1 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000020-0000-0000-0000-000000000000",
                                           ItemId = "00000004-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                        CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(20) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                              

                               }.ToArray();
                case "00000005-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000029-0000-0000-0000-000000000000",
                                           ItemId = "00000005-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(29) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000002a-0000-0000-0000-000000000000",
                                           ItemId = "00000005-0000-0000-0000-000000000000",
                                           AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(2a) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                 
                               }.ToArray();
                case "00000006-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000033-0000-0000-0000-000000000000",
                                           ItemId = "00000006-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(33) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000034-0000-0000-0000-000000000000",
                                           ItemId = "00000006-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(34) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                

                               }.ToArray();
                case "00000007-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000003d-0000-0000-0000-000000000000",
                                           ItemId = "00000007-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(3d) - 1 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000003e-0000-0000-0000-000000000000",
                                           ItemId = "00000007-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(3e) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                               
                               }.ToArray();
                case "00000008-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000047-0000-0000-0000-000000000000",
                                           ItemId = "00000008-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(47) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000048-0000-0000-0000-000000000000",
                                           ItemId = "00000008-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(48) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                
                               }.ToArray();
                case "00000009-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000051-0000-0000-0000-000000000000",
                                           ItemId = "00000009-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(51) - 1 of 2",
                                        Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000052-0000-0000-0000-000000000000",
                                           ItemId = "00000009-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(52) - 2 of 2",
                                         Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                 

                               }.ToArray();
                case "00000010-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000005b-0000-0000-0000-000000000000",
                                           ItemId = "00000010-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(5b) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000005c-0000-0000-0000-000000000000",
                                           ItemId = "00000010-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(5c) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                  

                               }.ToArray();
                case "00000011-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000065-0000-0000-0000-000000000000",
                                           ItemId = "00000011-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(65) - 1 of 2",
                                         Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000066-0000-0000-0000-000000000000",
                                           ItemId = "00000011-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(66) - 2 of 2",
                                         Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                 

                               }.ToArray();
                case "00000012-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000006f-0000-0000-0000-000000000000",
                                           ItemId = "00000012-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(6f) - 1 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000070-0000-0000-0000-000000000000",
                                           ItemId = "00000012-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                         CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(70) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();
                case "0000000a-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000079-0000-0000-0000-000000000000",
                                           ItemId = "0000000a-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(79) - 1 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000007a-0000-0000-0000-000000000000",
                                           ItemId = "0000000a-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(7a) - 2 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();
                case "0000000b-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000083-0000-0000-0000-000000000000",
                                           ItemId = "0000000b-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                        CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(83) - 1 of 2",
                                         Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000084-0000-0000-0000-000000000000",
                                           ItemId = "0000000b-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(84) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();
                case "0000000c-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000008d-0000-0000-0000-000000000000",
                                           ItemId = "0000000c-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                         CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(8d) - 1 of 2",
                                         Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "0000008e-0000-0000-0000-000000000000",
                                           ItemId = "0000000c-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(8e) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();
                case "0000000d-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000097-0000-0000-0000-000000000000",
                                           ItemId = "0000000d-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                       CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(97) - 1 of 2",
                                        Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "00000098-0000-0000-0000-000000000000",
                                           ItemId = "0000000d-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(98) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();
                case "0000000e-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "000000a1-0000-0000-0000-000000000000",
                                           ItemId = "0000000e-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(a1) - 1 of 2",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "000000a2-0000-0000-0000-000000000000",
                                           ItemId = "0000000e-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                          CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(a2) - 2 of 2",
                                       Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();

                case "0000000f-0000-0000-0000-000000000000":
                    return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "000000ab-0000-0000-0000-000000000000",
                                           ItemId = "0000000f-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                         CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(ab) - 1 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "000000ac-0000-0000-0000-000000000000",
                                           ItemId = "0000000f-0000-0000-0000-000000000000",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "nl-BE",
                                           TypeId = "BASE_TYPE_WPI_DESCRIPTION",
                                           Title = "Description(ac) - 2 of 2",
                                          Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   
                               }.ToArray();


            }
            return new List<WorkspaceItemDescription>
                               {
                                   new WorkspaceItemDescription
                                       {
                                           Id = "ROOT",
                                           ItemId = "ROOT",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "LANGUAGE_ID1",
                                           Title = "DESCRIPTION_TEXT1",
                                           TypeId = "ROOT",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "BASE_TYPE",
                                           ItemId = "ROOT",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "LANGUAGE_ID2",
                                           Title = "DESCRIPTION_TEXT2",
                                           TypeId = "ROOT",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "TYPE_STRING",
                                           ItemId = "ROOT",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "LANGUAGE_ID3",
                                           Title = "DESCRIPTION_TEXT3",
                                           TypeId = "Base Type",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "TYPE_INTEGER",
                                           ItemId = "ROOT",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "LANGUAGE_ID4",
                                           Title = "DESCRIPTION_TEXT4",
                                           TypeId = "Base Type",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },
                                   new WorkspaceItemDescription
                                       {
                                           Id = "TYPE_DATE",
                                           ItemId = "ROOT",
                                            AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                           CultureId = "LANGUAGE_ID5",
                                           Title = "DESCRIPTION_TEXT5",
                                           TypeId = "Base Type",
                                           Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png")
                                       },

                               }.ToArray();
        }

        /// <summary>
        /// Gets the Mock Types 
        /// </summary>
        /// <returns>IEnumerable WorkspaceItem</returns>
        public static WorkspaceItem[] GetMockTypes()
        {
            return new List<WorkspaceItem>
                       {
                           new WorkspaceItem { Id = "ROOT", ParentId = "ROOT", TypeId = "ROOT", TypeTitle = "Root" },
                           new WorkspaceItem { Id = "BASE_TYPE", ParentId = "ROOT", ItemTitle = "Base Type", TypeId = "ROOT", TypeTitle = "Root"} ,
                           new WorkspaceItem { Id = "TYPE_STRING", ParentId = "BASE_TYPE", ItemTitle = "String", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_INTEGER", ParentId = "BASE_TYPE", ItemTitle = "Integer", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_DATE", ParentId = "BASE_TYPE", ItemTitle = "Date", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} 
                       }.ToArray(); ;
        }

        /// <summary>
        /// Gets the Languages
        /// </summary>
        /// <returns>IEnumerable WorkspaceItem</returns>
        public static WorkspaceItem[] GetMockLanguages()
        {
            return new List<WorkspaceItem>
                       {
                           new WorkspaceItem { Id = "ROOT", ParentId = "ROOT", TypeId = "ROOT", TypeTitle = "Root" },
                           new WorkspaceItem { Id = "BASE_TYPE", ParentId = "ROOT", ItemTitle = "Base Type", TypeId = "ROOT", TypeTitle = "Root"} ,
                           new WorkspaceItem { Id = "TYPE_STRING", ParentId = "BASE_TYPE", ItemTitle = "String", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_INTEGER", ParentId = "BASE_TYPE", ItemTitle = "Integer", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_DATE", ParentId = "BASE_TYPE", ItemTitle = "Date", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} 
                       }.ToArray(); ;
        }

        /// <summary>
        /// Gets the Workspace item based on a search string value
        /// </summary>
        /// <param name="searchString">Search string name</param>
        /// <returns>IEnumerable WorkspaceItem</returns>
        public static WorkspaceItem[] GetMockWorkspaceItemsBySearchString(string searchString)
        {
            return new List<WorkspaceItem>
                       {
                           new WorkspaceItem { Id = "ROOT", ParentId = "ROOT", TypeId = "ROOT", TypeTitle = "Root" },
                           new WorkspaceItem { Id = "BASE_TYPE", ParentId = "ROOT", ItemTitle = "Base Type", TypeId = "ROOT", TypeTitle = "Root"} ,
                           new WorkspaceItem { Id = "TYPE_STRING", ParentId = "BASE_TYPE", ItemTitle = "String", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_INTEGER", ParentId = "BASE_TYPE", ItemTitle = "Integer", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_DATE", ParentId = "BASE_TYPE", ItemTitle = "Date", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} 
                       }.ToArray(); ;
        }

        /// <summary>
        /// Gets the items for type id.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public static WorkspaceItem[] GetMockItemsForTypeId(string typeId)
        {
            return GenerateRandomWorkspaceItemsForTypeId(typeId);
        }

        /// <summary>
        /// Gets the mock items for type id with properties.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public static WorkspaceItem[] GetMockItemsForTypeIdWithProperties(string typeId)
        {
            var result = GenerateRandomWorkspaceItemsForTypeId(typeId);
            foreach (var r in result)
            { 
                r.Properties = GenerateRandomProperties(r);
            }
            return result;
        }

        /// <summary>
        /// Gets the Workspace based on the workspaceid
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        public static WorkspaceItem[] GetMockWorkspace(string workspaceId)
        {
            return new List<WorkspaceItem>
                       {
                           new WorkspaceItem { Id = "ROOT", ParentId = "ROOT", TypeId = "ROOT", TypeTitle = "Root" },
                           new WorkspaceItem { Id = "BASE_TYPE", ParentId = "ROOT", ItemTitle = "Base Type", TypeId = "ROOT", TypeTitle = "Root"} ,
                           new WorkspaceItem { Id = "TYPE_STRING", ParentId = "BASE_TYPE", ItemTitle = "String", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_INTEGER", ParentId = "BASE_TYPE", ItemTitle = "Integer", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} ,
                           new WorkspaceItem { Id = "TYPE_DATE", ParentId = "BASE_TYPE", ItemTitle = "Date", TypeId = "BASE_TYPE", TypeTitle = "Base Type"} 
                       }.ToArray();
        }

        /// <summary>
        /// Registers the Mock workspace
        /// </summary>
        /// <param name="workspaceItem"></param>
        /// <returns>String</returns>
        public static String RegisterMockWorkspace(WorkspaceItem workspaceItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Full workspace
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static WorkspaceItem GetMockFullWorkspaceItem(string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Mock Folders based on itemid
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <returns></returns>
        public static WorkspaceItem[] GetMockFolders(string workspaceId)
        {
            return new List<WorkspaceItem>
                       {
                           new WorkspaceItem
                               {
                                   Id = "ROOT",
                                   ParentId = "",
                                   TypeId = "ROOT",
                                   TypeTitle = "Root",
                                   ItemId = "ROOT",
                                   ItemTitle = "Root",
                                   ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png"),
                                   //Children = new List<WorkspaceItem>
                                   //               {
                                   //                   new WorkspaceItem
                                   //                       {
                                   //                           Id = "00000001-0000-0000-0000-000000000000",
                                   //                           ItemId = "00000001-0000-0000-0000-000000000000",
                                   //                           ParentId = "ROOT",
                                   //                           ItemTitle = "Title => Applications - 22/10/2010 15:13:11",
                                   //                           TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                   //                           TypeTitle = "Base Type",
                                   //                           SortOrder = 0,
                                   //                           ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName,"CloseFolder.png"),
                                                  //            Children = new List<WorkspaceItem>
                                                  //                           {
                                                  //                               new WorkspaceItem
                                                  //                                   {
                                                  //                                       Id = "00000002-0000-0000-0000-000000000000",
                                                  //                                       ParentId = "00000001-0000-0000-0000-000000000000",
                                                  //                                       TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                  //                                       TypeTitle = "Root",
                                                  //                                       ItemId = "00000002-0000-0000-0000-000000000000",
                                                  //                                       ItemTitle = "Title => Business applications - 22/10/2010 15:13:11",
                                                  //                                       SortOrder = 0,
                                                  //                                       ItemImage =
                                                  //                                           GetEmbeddedFile(
                                                  //                                               Const.
                                                  //                                                   ResourceAssemblyName,
                                                  //                                               "CloseFolder.png"),
                                                  //                                                Children =
                                                  //                                           new List<WorkspaceItem>
                                                  //                                               {
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000003-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000002-0000-0000-0000-000000000000",
                                                  //                                                               ItemId =  "00000003-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => Business application 1 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png")
                                                  //                                                       },
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000004-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                              "00000002-0000-0000-0000-000000000000",
                                                  //                                                              ItemId =  "00000004-0000-0000-0000-000000000000",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => Business application 2 - 22/10/2010 15:13:11",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Title => Business application 2 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png")
                                                  //                                                       },
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000005-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000002-0000-0000-0000-000000000000",
                                                  //                                                             ItemId   = "00000005-0000-0000-0000-000000000000",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => Business application 3 - 22/10/2010 15:13:11",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Base Type",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png")
                                                  //                                                       }
                                                                                                   
                                                  //                                               }.ToArray()
                                                  //                                   },
                                                  //                               new WorkspaceItem
                                                  //                                   {
                                                  //                                       Id = "00000006-0000-0000-0000-000000000000",
                                                  //                                       ParentId = "00000001-0000-0000-0000-000000000000",
                                                  //                                       ItemTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                  //                                       TypeId = "BASE_TYPE_UI_TRV_FOLDER",
                                                  //                                       TypeTitle = "Title => My applications - 22/10/2010 15:13:11",
                                                  //                                       ItemId = "00000006-0000-0000-0000-000000000000",
                                                  //                                       ItemImage =
                                                  //                                           GetEmbeddedFile(
                                                  //                                               Const.
                                                  //                                                   ResourceAssemblyName,
                                                  //                                               "CloseFolder.png"),
                                                  //                                                     Children =
                                                  //                                           new List<WorkspaceItem>
                                                  //                                               {
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000007-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000006-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_FOLDER",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                           "Title => My applications type 1- 22/10/2010 15:13:11",
                                                  //                                                           ItemId =  "00000007-0000-0000-0000-000000000000",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "CloseFolder.png"),
                                                  //                                                                Children =
                                                  //                                           new List<WorkspaceItem>
                                                  //                                               {
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000009-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000007-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_FOLDER",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                               ItemId =  "00000009-0000-0000-0000-000000000000",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My applications type 1.1 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "CloseFolder.png"),
                                                  //                                                                 Children =
                                                  //                                           new List<WorkspaceItem>
                                                  //                                               {
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000a-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000009-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                            ItemId   = "0000000A-0000-0000-0000-000000000000",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My applications 1 of type 1 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       },
                                                  //                                                new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000b-0000-0000-0000-000000000000",
                                                  //                                                               ItemId = 
                                                  //                                                               "0000000b-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000009-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My applications 2 of type 1 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       }}.ToArray()
                                                                                                                 
                                                  //                                                       }}.ToArray()
                                                  //                                                       },
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "00000008-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                                "00000006-0000-0000-0000-000000000000",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My applications type 2 - 22/10/2010 15:13:11",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_FOLDER",
                                                  //                                                               ItemId = "00000008-0000-0000-0000-000000000000",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Title => Business application 2 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "CloseFolder.png"),
                                                  //                                                                Children =
                                                  //                                           new List<WorkspaceItem>
                                                  //                                               {
                                                  //                                                   new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000c-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000008-0000-0000-0000-000000000000",
                                                  //                                                               ItemId =  "0000000c-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My application 3  - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       },
                                                  //                                                new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000d-0000-0000-0000-000000000000",
                                                  //                                                               ItemId =  "0000000d-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000008-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My application 4 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       },
                                                  //                                               new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000e-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000008-0000-0000-0000-000000000000",
                                                  //                                                               ItemId =  "0000000e-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My specific application 1 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       },
                                                  //                                               new WorkspaceItem
                                                  //                                                       {
                                                  //                                                           Id =
                                                  //                                                               "0000000f-0000-0000-0000-000000000000",
                                                  //                                                               ItemId =
                                                  //                                                               "0000000f-0000-0000-0000-000000000000",
                                                  //                                                           ParentId =
                                                  //                                                               "00000008-0000-0000-0000-000000000000",
                                                  //                                                           TypeId =
                                                  //                                                               "BASE_TYPE_UI_TRV_NODE_TEXT",
                                                  //                                                           TypeTitle =
                                                  //                                                               "Date1_Root",
                                                  //                                                           ItemTitle =
                                                  //                                                               "Title => My specific application 2 - 22/10/2010 15:13:11",
                                                  //                                                           ItemImage =
                                                  //                                                               GetEmbeddedFile
                                                  //                                                               (Const.
                                                  //                                                                    ResourceAssemblyName,
                                                  //                                                                "leafnode1.png"),
                                                                                                                 
                                                  //                                                       }}.ToArray()
                                                                                                                 
                                                  //                                                       }
                                                                                                   
                                                                                                   
                                                  //                                               }.ToArray()
                                                  //                                   },
                                                  //                               new WorkspaceItem
                                                  //                                   {
                                                  //                                       Id = "00000010-0000-0000-0000-000000000000",
                                                  //                                       ParentId = "00000001-0000-0000-0000-000000000000",
                                                  //                                       ItemTitle = "Title => App item 1 - 22/10/2010 15:13:11",
                                                  //                                       TypeId = "BASE_TYPE",
                                                  //                                       TypeTitle = "Base Type",
                                                  //                                       ItemId =  "00000010-0000-0000-0000-000000000000",
                                                  //                                       ItemImage =
                                                  //                                           GetEmbeddedFile(
                                                  //                                               Const.
                                                  //                                                   ResourceAssemblyName,
                                                  //                                               "leafnode1.png")
                                                  //                                   },
                                                  //                               new WorkspaceItem
                                                  //                                   {
                                                  //                                       Id = "00000011-0000-0000-0000-000000000000",
                                                  //                                       ItemId =  "00000011-0000-0000-0000-000000000000",
                                                  //                                       ParentId = "00000001-0000-0000-0000-000000000000",
                                                  //                                       ItemTitle = "Title => App item 2 - 22/10/2010 15:13:11",
                                                  //                                       TypeId = "BASE_TYPE",
                                                  //                                       TypeTitle = "Base Type",
                                                  //                                       ItemImage =
                                                  //                                           GetEmbeddedFile(
                                                  //                                               Const.
                                                  //                                                   ResourceAssemblyName,
                                                  //                                               "leafnode1.png")
                                                  //                                   },
                                                  //                               new WorkspaceItem
                                                  //                                   {
                                                  //                                       Id = "000000012-0000-0000-0000-000000000000",
                                                  //                                       ParentId = "00000001-0000-0000-0000-000000000000",
                                                  //                                       ItemId = "000000012-0000-0000-0000-000000000000",
                                                  //                                       ItemTitle = "Title => App item 3 - 22/10/2010 15:13:11",
                                                  //                                       TypeId = "BASE_TYPE",
                                                  //                                       TypeTitle = "Base Type",
                                                  //                                       ItemImage =
                                                  //                                           GetEmbeddedFile(
                                                  //                                               Const.
                                                  //                                                   ResourceAssemblyName,
                                                  //                                               "leafnode1.png")
                                                                                        
                                                  //                                   }
                                                  //                           }.ToArray()
                                                  //        }
                                                  //}.ToArray(),
                                  
                               },
                                  new WorkspaceItem
                               {
                                   Id = "ROOT1",
                                   ParentId = "",
                                   TypeId = "ROOT1",
                                   TypeTitle = "Root1",
                                   ItemId = "ROOT",
                                   ItemTitle = "Root1",
                                   ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png")
                               },
                                 new WorkspaceItem
                               {
                                   Id = "ROOT2",
                                   ParentId = "",
                                   TypeId = "ROOT2",
                                   TypeTitle = "Root2",
                                   ItemId = "ROOT",
                                   ItemTitle = "Root2",
                                   ItemImage = GetEmbeddedFile(Const.ResourceAssemblyName, "CloseFolder.png")
                               }

                                                             
                       }.ToArray();
        }

        /// <summary>
        /// Saves the dragged data workspaceitem
        /// </summary>
        /// <param name="targetWorkspace">targetworkspace name</param>
        /// <param name="sourceWorkspace">sourceworkspace name</param>
        public static void RegisterMockDraggedData(WorkspaceItem targetWorkspace, WorkspaceItem sourceWorkspace)
        {

        }

        /// <summary>
        /// Registers the description.
        /// </summary>
        /// <param name="workspaceItemDescription">The workspace item description.</param>
        /// <returns></returns>
        public static string RegisterMockDescription(WorkspaceItemDescription workspaceItemDescription)
        {
            string id = Guid.NewGuid().ToString();
            var description = new WorkspaceItemDescription
                                  {
                                      AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                                      CultureId = CultureInfo.CurrentCulture.Name,
                                      Id = id,
                                      Image = GetEmbeddedFile(Const.ResourceAssemblyName, "Description.png"),
                                      ItemId = string.IsNullOrEmpty(workspaceItemDescription.Id) ? Guid.NewGuid().ToString() : workspaceItemDescription.Id,
                                      Title = "Description of " + id
                                      //TypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.WorkspaceItemDescription)
            };
            return description.Id;
        }

        /// <summary>
        /// Registers the property.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <returns></returns>
        public static string RegisterMockProperty(WorkspaceItemProperty workspaceItemProperty)
        {
            string id = Guid.NewGuid().ToString();
            var property = new WorkspaceItemProperty
            {
                AdditionalInfoUri = "http://wwww.DescriptionInfo.com",
                Id = id,
                ItemId = string.IsNullOrEmpty(workspaceItemProperty.ItemId) ? Guid.NewGuid().ToString() : workspaceItemProperty.ItemId,
                PropertyName = "Property name of " + id,
                PropertyValue = "Property value of " + id,
                //PropertyTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.WorkspaceItemProperty),
                PropertyTypeDescription = "Propertytypedescription of " + id
            };
            return property.Id;
        }

        /// <summary>
        /// Add a Workspace
        /// </summary>
        /// <param name="workspace">workspace name</param>
        public static void AddWorkspace(WorkspaceItem workspace)
        {
            
        }

        /// <summary>
        /// Adds the Item for a  Workspace
        /// </summary>
        /// <param name="workspace">workspace name</param>
        public static void AddItem(WorkspaceItem workspace)
        {


        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public static bool InitializeMock()
        {
            return true;
        }

        /// <summary>
        /// Selects the by item id and culture id and type id.
        /// </summary>
        /// <returns></returns>
        public static WorkspaceItemDescription[] SelectByItemIdAndCultureIdAndTypeId()
        {
            return new WorkspaceItemDescription[] {};
        }


        #endregion // Mock methods

        #endregion // Public methods

        #region Private Methods

        /// <summary>
        /// Generates the random workspace items for type id.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        private static WorkspaceItem[] GenerateRandomWorkspaceItemsForTypeId(string typeId = null)
        {
            var result = new List<WorkspaceItem>(RandomNumber(1, 4));
            foreach (WorkspaceItem item in result)
            {
                item.Id = Guid.NewGuid().ToString();
                item.ParentId = Guid.NewGuid().ToString();
                item.ItemId = Guid.NewGuid().ToString();
                item.TypeId = typeId ?? string.Empty;
                item.TypeTitle = typeId + " title";
            }
            return result.ToArray(); ;
        }

        /// <summary>
        /// Generates the random properties.
        /// </summary>
        /// <param name="workspaceItem">The workspace item.</param>
        /// <returns></returns>
        private static WorkspaceItemProperty[] GenerateRandomProperties(WorkspaceItem workspaceItem)
        {
            var result = new List<WorkspaceItemProperty>(RandomNumber(0, 4));
            foreach (WorkspaceItemProperty property in result)
            {
                property.Id = Guid.NewGuid().ToString();
                property.ItemId = workspaceItem.ItemId;
                property.PropertyName = property.Id + " Name";
                property.PropertyTypeDescription = property.Id + " Description";
                property.PropertyValue = property.Id + " Value";
                property.AdditionalInfoUri = string.Empty;
            }
            return result.ToArray(); 
        }

        /// <summary>
        /// Randoms the number.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns></returns>
        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        #region Other methods

        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        private static Byte[] GetEmbeddedFile(string assemblyName, string fileName)
        {
            var r = new WorkspaceBrowserResource();
            return r.GetEmbeddedFile(assemblyName, fileName);
        }
        #endregion // Other methods

        #endregion // Private methods

        #region Inner classes

        /// <summary>
        /// Constant String Values
        /// </summary>
        public class Const
        {
            public const string ResourceAssemblyName = "Pms.ManageWorkspaces.Resources";
        }
        #endregion // Inner classes

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<WorkspaceBrowserDomainGenerator>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<WorkspaceBrowserDomainGenerator>.Validate(this);
        }
    }
}