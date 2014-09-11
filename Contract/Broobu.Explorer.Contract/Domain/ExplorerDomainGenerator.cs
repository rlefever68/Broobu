using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Explorer.Resources;
using Iris.Fx.Domain;

namespace Iris.Explorer.Contract.Domain
{
    public class ExplorerDomainGenerator
    {
        #region " properties "
        private static XmlDocument _xmlDocumentEnums;
        private static XmlDocument XmlDocumentEnums
        {
            get { return _xmlDocumentEnums ?? (_xmlDocumentEnums = GetXmlDocument(XmlDocumentEnumsFileName)); }
        }
        private static XmlDocument _xmlDocumentTypes;
        private static XmlDocument XmlDocumentTypes
        {
            get { return _xmlDocumentTypes ?? (_xmlDocumentTypes = GetXmlDocument(XmlDocumentTypesFileName)); ; }
        }
        private static XmlDocument _xmlDocumentDescriptions;
        private static XmlDocument XmlDocumentDescriptions
        {
            get { return _xmlDocumentDescriptions ?? (_xmlDocumentDescriptions = GetXmlDocument(XmlDocumentDescriptionsFileName)); ; }
        }
        #endregion

        #region " Constants "
        private const string XmlDocumentEnumsFileName        = "Pms.Explorer.Resources.Constants.Enums.xml";
        private const string XmlDocumentTypesFileName        = "Pms.Explorer.Resources.Constants.Types.xml";
        private const string XmlDocumentDescriptionsFileName = "Pms.Explorer.Resources.Constants.Descriptions.xml";
        
     

        private const string XmlPrefix                       = "T";
        private const string XmlUrn                          = "urn:{0}-schema";
        private const string XpathBase                       = "/TYPES/{0}:ENUMS/{0}:ENUM";
        private const string XpathLanguages                  = "/TYPES/{0}:ENUMS/{0}:ENUM/{0}:Id";
        private const string XpathLanguagesDescriptions      = "/TYPES/{0}:ENUMS/{0}:ENUM[@Culture='{1}']/{0}:Id";
        private const string XpathDescriptions               = "/{0}:DESCRIPTIONS/{0}:ITEMS[@CultureId='{1}' and @TypeId='{2}']/*";
        
        public enum EnumBaseType
        {
            Base, Languages, TreeViewFolder, TreeViewLeaf, Translations, WorkspaceItemProperty, WorkspaceItemDescription
        }
        #endregion

        public static IEnumerable<DescriptionItem> GetDescriptionItems(string cultureId, string typeId)
        {
            List<DescriptionItem> result = null;
            string xpathQuery = String.Format(XpathDescriptions, XmlPrefix, cultureId, typeId);
            XmlNodeList nodes = GetXmlNodeList(EnumBaseType.Translations, xpathQuery);

            if (nodes != null && nodes.Count > 0)
            {
                result = new List<DescriptionItem>();
                foreach (XmlNode node in nodes)
                {
                    DescriptionItem descriptionItem = new DescriptionItem
                                                          {
                                                              Id = node.Attributes["Id"].Value,
                                                              TypeId = EnumerationItemType.TypeIdTranslations,
                                                              CultureId = cultureId,
                                                              ObjectId = node.Attributes["ObjectId"].Value,
                                                              Title = node.InnerText,
                                                              Blob = new byte[] { },
                                                              Url = String.Empty,
                                                              AdditionalInfoUri = String.Empty
                                                          };
                    result.Add(descriptionItem);
                }
            }

            return result;
        }

        public static IEnumerable<EnumerationItem> GetEnumerationItemsTypes()
        {
            List<EnumerationItem> result = null;
            XmlNodeList nodes = GetXmlNodeList(EnumBaseType.Base);

            if (nodes != null && nodes.Count > 0)
            {
                result = new List<EnumerationItem>();
                foreach (XmlNode node in nodes)
                {
                    int sortOrder;
                    int.TryParse(GetXmlNodeInnerText(node, "SortOrder"), out sortOrder);
                    EnumerationItem enumeration = new EnumerationItem
                                                      {
                                                          AdditionalInfoUri = String.Empty,
                                                          Id = GetXmlNodeInnerText(node, "Id"),
                                                          SortOrder = sortOrder,
                                                          Title = GetXmlNodeInnerText(node, "Title"),
                                                          TypeId = GetXmlNodeInnerText(node, "TypeId"),
                                                          Image = new byte[] { },
                                                          DateModified = DateTime.Now
                                                      };
                    result.Add(enumeration);
                }
            }
            return result;
        }

        public static IEnumerable<EnumerationItem> GetEnumerationItemsLanguages()
        {
            return CreateEnumerationItemsFromCultureInfos(GetXmlNodeList(EnumBaseType.Languages));
        }

        public static IEnumerable<EnumerationItem> GetEnumerationItemsLanguagesForDescriptions()
        {
            string xpathQuery = String.Format(XpathLanguagesDescriptions, XmlPrefix, CultureInfo.CurrentCulture.Name.Substring(0, 2));
            XmlNodeList xmlNodeList = GetXmlNodeList(EnumBaseType.Languages, xpathQuery);
            return CreateEnumerationItemsFromCultureInfos(xmlNodeList);
        }

        private static IEnumerable<EnumerationItem> CreateEnumerationItemsFromCultureInfos(XmlNodeList nodes)
        {
            List<EnumerationItem> result = null;
            if (nodes != null && nodes.Count > 0)
            {
                var cultureInfos = GetCultureInfos(nodes);
                result = new List<EnumerationItem>();
                int sortOrder = 1;
                foreach (CultureInfo cultureInfo in cultureInfos)
                {
                    EnumerationItem enumeration = new EnumerationItem
                    {
                        Id = cultureInfo.Name,
                        TypeId = EnumerationItemType.TypeIdLanguages,
                        Title = cultureInfo.EnglishName,
                        Image = new byte[] { },
                        SortOrder = sortOrder++,
                        DateModified = DateTime.Now
                    };
                    result.Add(enumeration);
                }
            }
            return result;
        }

        private static IEnumerable<CultureInfo> GetCultureInfos(XmlNodeList nodes)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            var currentCultureFound = false;
            var errors = new List<String>();
            var cultureInfoName = String.Empty;
            var cultureInfos = new List<CultureInfo>();

            foreach (XmlNode node in nodes)
            {
                try
                {
                    cultureInfoName = node.InnerText;
                    if (!currentCultureFound) currentCultureFound = (currentCultureName == cultureInfoName);
                    var info = new CultureInfo(cultureInfoName);
                    cultureInfos.Add(info);
                }
                catch (CultureNotFoundException ex)
                {
                    errors.Add(String.Format("Culture provided in embedded Xml file '{0}' ( Culture = '{1}' ) is not valid\n" +
                               ex.InnerException, XmlDocumentEnumsFileName, cultureInfoName));
                }
            }
            if (!currentCultureFound) cultureInfos.Add(new CultureInfo(currentCultureName));
            return cultureInfos;
        }

        private static Stream GetEmbeddedFile(string fileName)
        {
            var r = new ExplorerResource();
            return r.GetEmbeddedXmlFile(fileName);
        }

        private static XmlDocument GetXmlDocument(string fileName)
        {
            var stream = GetEmbeddedFile(fileName);
            var xmlDocument = GetXmlDocument(stream);
            return xmlDocument;
        }

        private static XmlDocument GetXmlDocument(Stream stream)
        {
            var xmlDocument = new XmlDocument();
            if (stream != null)
            {
                var reader = new StreamReader(stream);
                xmlDocument.LoadXml(reader.ReadToEnd());
                reader.Close();
            }

            return xmlDocument;
        }

        private static XmlNodeList GetXmlNodeList(EnumBaseType enumerationType)
        {
            switch (enumerationType)
            {
                case EnumBaseType.Languages:
                    return GetXmlNodeList(enumerationType, String.Format(XpathLanguages, XmlPrefix));
                case EnumBaseType.Base:
                    return GetXmlNodeList(enumerationType, String.Format(XpathBase, XmlPrefix));
                //case EnumerationType.Descriptions:
                //    return GetXmlNodeList(enumerationType, XpathDescriptions);
            }
            return null;
        }

        private static XmlNodeList GetXmlNodeList(EnumBaseType enumerationType, string xpathQuery)
        {
            string typeId = GetEnumerationTypeId(enumerationType);
            switch (enumerationType)
            {
                case EnumBaseType.Languages:
                    return GetXmlNodeList(XmlDocumentEnums, typeId, xpathQuery);
                case EnumBaseType.Base:
                    return GetXmlNodeList(XmlDocumentTypes, typeId, xpathQuery);
                case EnumBaseType.Translations:
                    return GetXmlNodeList(XmlDocumentDescriptions, typeId, xpathQuery);
            }
            return null;
        }

        public static string GetEnumerationTypeId(EnumBaseType enumerationType)
        {
            switch (enumerationType)
            {
                case EnumBaseType.Base: return EnumerationItemType.TypeIdBase;
                case EnumBaseType.Languages: return EnumerationItemType.TypeIdLanguages;
                case EnumBaseType.TreeViewFolder: return EnumerationItemType.TypeIdTreeViewFolder;
                case EnumBaseType.TreeViewLeaf: return EnumerationItemType.TypeIdTreeViewLeaf;
                case EnumBaseType.Translations: return EnumerationItemType.TypeIdTranslations;
                case EnumBaseType.WorkspaceItemDescription: return EnumerationItemType.TypeIdDescriptions;
                case EnumBaseType.WorkspaceItemProperty: return EnumerationItemType.TypeIdProperties;
            }
            return string.Empty;
        }

        private static XmlNodeList GetXmlNodeList(XmlDocument xmlDocument, string typeId, string xpath)
        {
            // Set up namespace manager for XPath   
            var xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
            xmlNamespaceManager.AddNamespace(XmlPrefix, String.Format(XmlUrn, typeId));

            // execute xpath query
            try
            {
                return xmlDocument.SelectNodes(xpath, xmlNamespaceManager);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static object DeSerializeFromXmlString(Type typeToDeserialize, string xmlString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream memoryStream = new MemoryStream(bytes);
            XmlSerializer xmlSerializer = new XmlSerializer(typeToDeserialize);
            return xmlSerializer.Deserialize(memoryStream);
        }

        private static string SerializeToXmlString(object objectToSerialize)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
            xmlSerializer.Serialize(memoryStream, objectToSerialize);
            ASCIIEncoding ascii = new ASCIIEncoding();
            return ascii.GetString(memoryStream.ToArray());
        }

        private static String GetXmlNodeInnerText(XmlNode node, string id)
        {
            XmlElement e = node[id];
            return e == null ? String.Empty : e.InnerText;
        }
    }
}
