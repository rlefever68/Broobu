using Iris.Explorer.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Iris.Explorer.Contract.Agent
{
    public class Explorer2Agent : DiscoProxy<IExplorer2>, IExplorer2Agent
    {
        public EnumerationItem[] GetEnumerationItemsForReasonAndAdviceTitles(string categoryId, string problemId, string subjectId, string adviceCode)
        {
	        IExplorer2 clt = null;
	        try
	        {
	            clt = CreateClient();
                return clt.GetEnumerationItemsForReasonAndAdviceTitles(categoryId, problemId, subjectId, adviceCode);

	        }
	        finally
	        {
                CloseClient(clt);
	        }
        }

        public EnumerationItem[] GetEnumerationItemsLikeType(string typeId)
        {
            IExplorer2 clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsLikeType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(string typeId, string property)
        {
            IExplorer2 clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(typeId, property);

            }
            finally
            {
                CloseClient(clt);
            }
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(string typeId, string property, string propertyValue)
        {
            IExplorer2 clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(typeId, property, propertyValue);

            }
            finally
            {
                CloseClient(clt);
            }
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsLikeType(string typeId)
        {
            IExplorer2 clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationPropertyItemsLikeType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
        }

        public EnumerationPropertyItem GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(string enumerationId, string property)
        {
            IExplorer2 clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(enumerationId, property);

            }
            finally
            {
                CloseClient(clt);
            }
        }
    }
}
