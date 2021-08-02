using System;
using System.Collections.Generic;

namespace GeekTime.Domain.Abstractions
{
    public abstract class Entity : IEntity
    {
        public abstract object[] GetKeys();

        #region Domain Event
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Entity()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        #endregion

        public override string ToString()
        {
            return $"[Etity: {GetType().Name}] Keys = {string.Join(",", GetKeys())}";
        }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        int? _requestedHashCode;

        public virtual TKey Id { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TKey> item)) return false;

            if (Object.ReferenceEquals(this, obj)) return true;

            if (this.GetType() != obj.GetType()) return false;


            return (item.IsTransient() || !this.IsTransient()) ? false : item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (IsTransient()) return base.GetHashCode();

            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (Object.Equals(left, null)) return Object.Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }


        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Id = {Id}";
        }
    }
}
