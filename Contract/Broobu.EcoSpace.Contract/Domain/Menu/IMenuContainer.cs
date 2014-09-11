using System.Collections.Generic;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    public interface IMenuContainer
    {
        IEnumerable<IMenuButton> Buttons { get; } 
    }
}