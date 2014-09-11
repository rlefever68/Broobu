using System.Collections.Generic;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    public interface IAccountPointerContainer
    {
        IEnumerable<IAccountPointer> Accounts { get; }
        IAccountPointer AddAccountPointer(IAccountPointer pointer);
    }
}