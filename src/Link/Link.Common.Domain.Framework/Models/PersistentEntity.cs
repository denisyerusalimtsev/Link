namespace Link.Common.Domain.Framework.Models
{
    public abstract class PersistentEntity<T, TState> : Entity<T>
    {
        public TState State { get; }

        protected PersistentEntity(TState state)
        {
            State = state;
        }
    }
}
