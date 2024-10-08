namespace CKB.Domain.Common.Models
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>, new()
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }

        protected AggregateRoot(TId id)
        {
            Id = id;
        }

        protected AggregateRoot()
        {
            Id = new TId();
        }
    }
}