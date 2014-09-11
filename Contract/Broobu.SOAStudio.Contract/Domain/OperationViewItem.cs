using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Domain;
using Pms.Framework.Validation;

namespace Pms.SOAStudio.Contract.Domain
{
    public class OperationViewItem : DomainObject<OperationViewItem>
    {










        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<OperationViewItem>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<OperationViewItem>.Validate(this);
        }
    }
}
