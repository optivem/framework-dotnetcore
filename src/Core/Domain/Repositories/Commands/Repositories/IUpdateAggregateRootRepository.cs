﻿using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IUpdateAggregateRootRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task UpdateAsync(TAggregateRoot aggregateRoot);
    }
}