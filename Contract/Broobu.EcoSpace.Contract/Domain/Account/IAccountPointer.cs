using Iris.Fx.Domain;


namespace Broobu.EcoSpace.Contract.Domain.Account
{
    public interface IAccountPointer : IDomainObject
    {
        string Username { get; set; }
    }
}