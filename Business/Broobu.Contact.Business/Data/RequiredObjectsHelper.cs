// ***********************************************************************
// Assembly         : Iris.Contact.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="RequiredObjectsHelper.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Iris.Fx.Domain;
using Iris.Fx.Utils;
using log4net;

namespace Broobu.Contact.Business.Data
{
    /// <summary>
    /// Class RequiredObjectsHelper.
    /// </summary>
    public class RequiredObjectsHelper : Result
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        private string FileName { get; set; }
        /// <summary>
        /// Gets or sets the name of the directory.
        /// </summary>
        /// <value>The name of the directory.</value>
        private string DirectoryName { get; set; }
        /// <summary>
        /// Gets or sets the required objects document.
        /// </summary>
        /// <value>The required objects document.</value>
        private XDocument RequiredObjectsDocument { get; set; }
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>The elements.</value>
        private IEnumerable<XElement> Elements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredObjectsHelper"/> class.
        /// </summary>
        public RequiredObjectsHelper()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Gets the elements count.
        /// </summary>
        /// <value>The elements count.</value>
        public int ElementsCount
        {
            get { return Elements == null ? -1 : Elements.Count(); }
        }

        /// <summary>
        /// Gets the deserialized domain objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="func">The function.</param>
        /// <returns>List{``0}.</returns>
        public List<T> GetDeserializedDomainObjects<T>(XName name, Func<XElement, bool> func) where T : DomainObject<T>
        {
            Elements = GetXElements(name, func);
            return Elements == null || Elements.Count() == 0 ? new List<T>() : DomainSerializer<List<T>>.Deserialize(Elements.FirstOrDefault());
        }

        /// <summary>
        /// Gets the x elements.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="func">The function.</param>
        /// <returns>List{XElement}.</returns>
        public List<XElement> GetXElements(XName name, Func<XElement, bool> func)
        {
            if (HasErrors)
                return new List<XElement>();

            if (RequiredObjectsDocument == null) RequiredObjectsDocument = GetRequiredObjectsDocument(FileName);
            if (RequiredObjectsDocument != null)
            {
                if (RequiredObjectsDocument.Root == null)
                {
                    AddWarning("Root element of XDocument contains no elements");
                    _logger.WarnFormat("Root element of XDocument contains no elements");
                    return new List<XElement>();
                }
                return RequiredObjectsDocument.Root.Elements(name).Where(func).Descendants().ToList();
            }
            return new List<XElement>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredObjectsHelper"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public RequiredObjectsHelper(string fileName)
        {
            _logger = LogManager.GetLogger(GetType());
            FileName = fileName;

            try
            {
                var uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                DirectoryName = Path.GetDirectoryName(uri.LocalPath);
                if (DirectoryName == null)
                    AddError(String.Format("Failed to get location of assembly '{0}'", GetType()));
            }
            catch (Exception ex)
            {
                AddError("Failed to initialze." + ex.Message);
            }
        }

        /// <summary>
        /// Gets the required objects document.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>XDocument.</returns>
        private XDocument GetRequiredObjectsDocument(string fileName)
        {
            FileStream s = null;
            var xDocument = new XDocument();
            var path = Path.Combine(DirectoryName, "Data", fileName);
            if (!File.Exists(path))
                AddError(String.Format("File '{0}' not found", fileName));

            try
            {
                if (!HasErrors)
                {
                    s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    xDocument = XDocument.Load(s);
                    s.Close();
                    s.Dispose();
                    _logger.InfoFormat("Succesfully loaded '{0}' in XDocument", fileName);
                }
            }
            catch (Exception ex)
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
                AddError(ex.Message);
                _logger.ErrorFormat(ex.Message);
            }
            return xDocument;
        }

        /// <summary>
        /// Gets the required objects document.
        /// </summary>
        /// <returns>XDocument.</returns>
        public XDocument GetRequiredObjectsDocument()
        {
            return HasErrors ? new XDocument() : RequiredObjectsDocument;
        }
    }
}
