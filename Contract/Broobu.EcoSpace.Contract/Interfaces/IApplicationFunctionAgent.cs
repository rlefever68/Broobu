using System;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Menu;

namespace Broobu.EcoSpace.Contract.Interfaces
{
    public interface IApplicationFunctionAgent : IApplicationFunction
    {
        event Action<MenuButton[]> GetAllApplicationFunctionsCompleted;
        void GetAllApplicationFunctionsAsync();
        void GetAllApplicationFunctionsAsync(Action<MenuButton[]> action);
    }
}