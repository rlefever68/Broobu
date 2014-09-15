// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 08-11-2014
// ***********************************************************************
// <copyright file="RelationItem.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract.Properties;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Utils;
using Wulka.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class RelationItem.
    /// </summary>
    [DataContract]
    public class Link : TaxonomyObject<Link>, ILink 
    {

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public virtual IDomainObject Source 
        {
            get 
            {
                return GetSource();
            }
            set
            {
                if (value == null) return;
                SourceId = value.Id;
//                SourceDisplayInfo = value.DisplayInfo;
                Master.Register(value);
            }
        }

        public IDisplayInfo SourceDisplayInfo { get; set; }

        protected virtual IDomainObject GetSource()
        {
            DoGetSource();
            return Master.Find(SourceId);
            //CompositionHelper.ComposeParts(this, GetSourceFactoryType());
            //return (ObjectFactory == null)
            //    ? Master.Find(SourceId)
            //    : ObjectFactory.GetById(SourceId);
        }

        private void DoGetSource()
        {
            var args =new ObjectEventArgs();
            if (OnGetSource != null)
                OnGetSource(this, args);
            if (args.Object != null)
                Master.Register(args.Object);
        }

        protected virtual Type GetSourceFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public virtual IDomainObject Target
        {
            get
            {
                return GetTarget();
            }
            set
            {
                if (value == null) return;
                TargetId = value.Id;
                TargetDisplayInfo = value.DisplayInfo;
                Master.Register(value);
            }
        }

        public IDisplayInfo TargetDisplayInfo { get; set; }


        public byte[] SourceImage { get; set; }
        public byte[] TargetImage { get; set; }
        public string SourceDisplayName { get; set; }
        public string TargetDisplayName { get; set; }

        protected virtual IDomainObject GetTarget()
        {
            DoGetTarget();
            return Master.Find(TargetId); 
            //CompositionHelper.ComposeParts(this,GetTargetFactoryType());
            //return (ObjectFactory==null) 
            //    ? 
            //    : ObjectFactory.GetById(TargetId);
        }

        private void DoGetTarget()
        {
            var arg = new ObjectEventArgs();
            if (OnGetTarget != null)
                OnGetTarget(this, arg);
            if (arg.Object != null)
                Master.Register(arg.Object);
        }

        [Import(typeof(IObjectFactory))]
        public IObjectFactory ObjectFactory;

       
        protected virtual Type GetTargetFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Gets or sets the type of the relation.
        /// </summary>
        /// <value>The type of the relation.</value>
        [DataMember]
        public string RelationType {get; set;}

        /// <summary>
        /// Gets or sets the relation from.
        /// </summary>
        /// <value>The relation from.</value>
        [DataMember]
        public string SourceId { get; set; }

        /// <summary>
        /// Gets or sets the relation to.
        /// </summary>
        /// <value>The relation to.</value>
        [DataMember]
        public string TargetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        public Link()
        {
            Icon = Resources.Link;
            IsActive = true;
        }


        [DataMember]
        public bool IsActive { get; set; }

        public event EventHandler OnGetSource;
        public event EventHandler OnGetTarget;

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Link>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Link>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof (TaxonomyPortal);
        }
    }

    internal class ObjectEventArgs : EventArgs
    {
        public IDomainObject Object { get; set; }
    }
}
