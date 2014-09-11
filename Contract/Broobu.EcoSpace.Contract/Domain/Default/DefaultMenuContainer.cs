using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Wulka.Domain;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public sealed class DefaultMenuContainer : MenuContainer
    {
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<DefaultMenuContainer>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<DefaultMenuContainer>.Validate(this);
        }


        public DefaultMenuContainer()
        {
            AddPart( new PageCategory() { DisplayName = "Insoft" });
            AddPart( new PageCategory() { DisplayName = "CC4ID" });
        }


    }
}
