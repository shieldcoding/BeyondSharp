namespace BeyondSharp.Common.Entity
{
    using System;

    public interface IEntity<TEntity, TEntityComponent>
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
        Guid ID { get; }

        string Name { get; }

        string Description { get; }
    }
}