using System;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public class TrackingRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        private readonly IEntityChangeTracker _changeTracker;
        private readonly MemoryRepository<TAggregateRoot> _memoryRepository;

        public TrackingRepository(IEntityChangeTracker changeTracker, MemoryRepository<TAggregateRoot> memoryRepository)
        {
            _changeTracker = changeTracker;
            _memoryRepository = memoryRepository;
        }

        public void Add(TAggregateRoot item)
        {
            _changeTracker.Track(item);
            _memoryRepository.Add(item);
        }

        public TAggregateRoot Get(Guid id)
        {
            var item = _memoryRepository.Get(id);
            _changeTracker.Track(item);
            return item;
        }
    }
}