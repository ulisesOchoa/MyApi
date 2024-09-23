using MyApi.Domain.Interfaces;

namespace MyApi.Domain.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}
