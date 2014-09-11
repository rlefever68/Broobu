using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Pms.WorkspaceBrowser.Contract.Constants
{
    public class WorkspaceXml
    {
        public const string Xml_directive       = "<?xml version='1.0'?>";
        public const string Culture_nl          = "nl";
        public const string Culture_fr          = "fr";
        public const string Culture_pt          = "pt";
        public const string Culture_en          = "en";
        public const string Culture_de          = "de";
        public const string Culture_ru          = "ru";
        public const string Xml_attr_item_id    = "ItemId";
        public const string Xml_attr_culture    = "Culture";
        public const string Xml_element_desc    = "DESCRIPTION";
        public const string Xml_element_descs   = "DESCRIPTIONS";
        public const string Xml_element_item    = "ITEM";
        public const string Xml_element_items   = "ITEMS";
        public const string Xml_prefix          = "T";// Types

        /// <summary>
        /// Gets the XML node list.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="xpath">The xpath query.</param>
        /// <returns></returns>
        public static XmlNodeList GetXmlNodeList(string xml, string uri, string xpath)
        {
            // create xml doc
            var xmlDocument = new XmlDocument();

            // Load data   
            xmlDocument.LoadXml(xml);

            // Set up namespace manager for XPath   
            var xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
            xmlNamespaceManager.AddNamespace(Xml_prefix, uri);

            // execute xpath query 
            return xmlDocument.SelectNodes(xpath, xmlNamespaceManager);
        }

        public static string GetDescription(string xml, string uri, string itemId, string cultureId)
        {
            var culture =  cultureId.Substring(0, 2);
            var query   = "/" + Xml_prefix + ":" + Xml_element_items + "/" + Xml_prefix + ":" + Xml_element_descs + "[@" + Xml_attr_culture + "=" + "'" + culture + "'" + "]" + "/" + Xml_prefix + ":" + Xml_element_desc + "[@" + Xml_attr_item_id + "=" + "'" + itemId + "'" + "]";
            var nodes   = GetXmlNodeList(xml, uri, query);

            if (nodes != null)
            {
                // if translation not found get the english translation
                if (nodes.Count == 0)
                {
                    var querydef = "/" + Xml_prefix + ":" + Xml_element_items + "/" + Xml_prefix + ":" + Xml_element_item + "[@" + Xml_attr_item_id + "=" + "'" + itemId + "'" + "]";
                    var nodedef = GetXmlNodeList(xml, uri, querydef);
                    if (nodedef != null && nodedef.Count == 1) return nodedef[0].InnerText;
                }
                if (nodes.Count == 1)
                {
                    return nodes[0].InnerText;
                }
            }
            return String.Empty;
        }
    }
}
