using System;
using System.Collections.Generic;
using System.Linq;
using StackMechanics.StackCafe.Domain;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public static class EntityCollectionExtensions
    {
        public static TEntity Get<TEntity>(this ICollection<TEntity> items, Guid id) where TEntity : IEntity
        {
            return items.Where(item => item.Id == id).Single();
        }
    }
}