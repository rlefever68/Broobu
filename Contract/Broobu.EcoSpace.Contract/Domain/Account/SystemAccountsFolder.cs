using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    [DataContract]
    public sealed class SystemAccountsFolder : Folder
    {
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        public SystemAccountsFolder()
        {
            DisplayName = "System Accounts";
            AddPart(new AdministratorAccountPointer());
            AddPart(new GuestAccountPointer());
        }



        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<SystemAccountsFolder>.Validate(this,columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<SystemAccountsFolder>.Validate(this);
        }
    }
}