using System.Collections.Generic;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public class EntityChangeTracker : IEntityChangeTracker
    {
        private readonly List<IEntity> _trackedEntities = new List<IEntity>();

        public void Track(IEntity entity)
        {
            _trackedEntities.Add(entity);
        }

        public IEnumerable<IEntity> TrackedEntities => _trackedEntities.ToArray();
    }
}