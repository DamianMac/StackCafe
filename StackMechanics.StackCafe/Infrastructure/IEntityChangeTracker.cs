using System.Collections.Generic;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IEntityChangeTracker
    {
        void Track(IEntity entity);
        IEnumerable<IEntity> TrackedEntities { get; }
    }
}