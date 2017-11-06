using System;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Get(Guid id);
        void Add(TAggregateRoot item);
    }
}
