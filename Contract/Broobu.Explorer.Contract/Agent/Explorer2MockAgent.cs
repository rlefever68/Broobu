using System;
using Iris.Explorer.Contract.Interfaces;
using Iris.Fx.Domain;

namespace Iris.Explorer.Contract.Agent
{
    public class Explorer2MockAgent : IExplorer2Agent
    {
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
