using System;
using System.Linq;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IEntityChangeTracker _changeTracker;
        private readonly IMediator _mediator;
        private bool _abandoned;
        private bool _completed;

        public UnitOfWork(IMediator mediator, IEntityChangeTracker changeTracker)
        {
            _mediator = mediator;
            _changeTracker = changeTracker;
        }

        public void Dispose()
        {
            if (_completed) return;
            if (_abandoned) return;

            throw new InvalidOperationException("Unit of work must be either completed or abandoned before disposal");
        }

        public void Complete()
        {
            if (_completed) throw new InvalidOperationException("Unit of work has already been completed");
            if (_abandoned) throw new InvalidOperationException("Unit of work has already been abandoned");

            while (true)
            {
                var domainEventsThisPass = _changeTracker
                    .TrackedEntities
                    .SelectMany(e => e.DomainEvents.GetAndClear())
                    .ToArray();

                if (domainEventsThisPass.Length == 0) break;

                foreach (var domainEvent in domainEventsThisPass)
                {
                    ((dynamic) _mediator).Publish((dynamic) domainEvent);
                }
            }

            _completed = true;
        }

        public void Abort()
        {
            if (_completed) throw new InvalidOperationException("Unit of work has already been completed");
            if (_abandoned) throw new InvalidOperationException("Unit of work has already been abandoned");

            _abandoned = true;
        }
    }
}