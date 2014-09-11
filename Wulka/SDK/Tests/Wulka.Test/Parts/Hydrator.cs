using System;
using System.ComponentModel.Composition;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Domain.Interfaces;
using Iris.Fx.Interfaces;

namespace Iris.Fx.Test.Parts
{
    [Export(typeof(IHydrate))]
    internal class Hydrator : IHydrate
    {
        public void Hydrate<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            Console.WriteLine("OnHydrate");
        }
    }
}
