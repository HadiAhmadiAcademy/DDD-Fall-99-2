using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Domain
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        private List<DomainEvent> _uncommittedEvents = new List<DomainEvent>();
        protected AggregateRoot() { }
        public AggregateRoot(TKey id) : base(id)
        {
        }
        protected void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            this._uncommittedEvents.Add(@event);
        }
        public void ClearUncommittedEvents()
        {
            this._uncommittedEvents.Clear();
        }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();
    }
}