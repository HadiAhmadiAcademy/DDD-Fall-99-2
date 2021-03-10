using System;

namespace Framework.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; private set; }
        protected Entity() { }
        protected Entity(TKey id)
        {
            Id = id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var entity = (Entity<TKey>) obj;
            return entity.Id.Equals(this.Id);
        }
    }
}
