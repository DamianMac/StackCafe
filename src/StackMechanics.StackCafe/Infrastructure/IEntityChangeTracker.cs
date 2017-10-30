using System.Collections.Generic;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IEntityChangeTracker
    {
        IEnumerable<IEntity> TrackedEntities { get; }
        void Track(IEntity entity);
    }
}