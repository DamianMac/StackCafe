using System;
using System.Collections.Generic;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public class MemoryRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        private readonly Dictionary<Guid, TAggregateRoot> _items = new Dictionary<Guid, TAggregateRoot>();

        public TAggregateRoot Get(Guid id)
        {
            return _items[id];
        }

        public void Add(TAggregateRoot item)
        {
            _items[item.Id] = item;
        }
    }
}