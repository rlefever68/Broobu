using System;
using System.Collections.Generic;
using Iris.Explorer.Business.Interfaces;

namespace Iris.Explorer.Business
{
    public class ExplorerMockProvider : IExplorerProvider
    {
        public void Initialize()
        {
        }

        bool IExplorer.Initialize()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItems()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsTop()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem GetPerspectiveItem(string id)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string typeId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsTop()
        {
            throw new NotImplementedException();
        }

        public EnumerationItem GetEnumerationItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsForType(string typeId)
        {
            const int minvalue = 1;
            const int maxvalue = 10;
            var r = new Random();
            int amount = r.Next(maxvalue, maxvalue);
            var result = new List<EnumerationItem>(amount);

            for (int i = minvalue; i <= amount; i++)
            {
                result.Add(
                    new EnumerationItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        SortOrder = i,
                        Title = "Title " + i,
                        TypeId = typeId,
                        Image = new byte[] { },
                        DateModified = DateTime.Now,
                        AdditionalInfoUri = String.Empty
                    });
            }
            return result.ToArray();
        }

        public EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsForSearch(string searchString)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem GetEnumerationPropertyItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId)
        {
            const int minvalue = 1;
            const int maxvalue = 10;
            var r = new Random();
            int amount = r.Next(maxvalue, maxvalue);
            var result = new List<EnumerationPropertyItem>(amount);

            for (int i = minvalue; i <= amount; i++)
            {
                result.Add(
                    new EnumerationPropertyItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        EnumerationId = Guid.NewGuid().ToString(),
                        Title = "Property " + i,
                        TypeId = Guid.NewGuid().ToString(),
                        Value = "Value " + i,
                        AdditionalInfoUri = String.Empty
                    });
            }
            return result.ToArray();
        }

        public EnumerationLinkItem GetEnumerationLinkItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem DeleteEnumerationItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem DeleteEnumerationPropertyItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem DeleteEnumerationLinkItem(string id)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem DeletePerspectiveItem(string id)
        {
            throw new NotImplementedException();
        }


        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId)
        {
            const int minvalue = 1;
            const int maxvalue = 10;
            var r = new Random();
            int amount = r.Next(maxvalue, maxvalue);
            var result = new List<EnumerationPropertyItem>(amount);

            for (int i = minvalue; i <= amount; i++)
            {
                result.Add(
                    new EnumerationPropertyItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        EnumerationId = Guid.NewGuid().ToString(),
                        Title = "Property " + i,
                        TypeId = typeId,
                        Value = "Value " + i,
                        AdditionalInfoUri = String.Empty
                    });
            }
            return result.ToArray();
        }

        public EnumerationItem[] GetEnumerationItemsForReasonAndAdviceTitles(string categoryId, string problemId, string subjectId, string adviceCode)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsLikeType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(string typeId, string property)
        {
            throw new NotImplementedException();
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(string typeId, string property, string propertyValue)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsLikeType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(string enumerationId, string property)
        {
            throw new NotImplementedException();
        }
    }
}
