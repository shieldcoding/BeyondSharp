namespace BeyondSharp.Common.Entity
{
    using System;
    using System.Collections.Generic;

    public interface IEntityManager<TEntity, TEntityComponent> : IEngineComponent
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
        /// <summary>
        ///     Retrieves an entity with the given unique ID.
        /// </summary>
        /// <param name="id">The unique ID to retrieve the entity with.</param>
        /// <returns>The entity that has the unique ID.</returns>
        TEntity GetEntity(Guid id);

        /// <summary>
        ///     Returns an enumeration of entities that match the specified type.
        /// </summary>
        /// <typeparam name="FilteredType"></typeparam>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        ///     Registers an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be registered.</param>
        /// <returns>The ID of the entity.</returns>
        Guid RegisterEntity(TEntity entity);

        /// <summary>
        ///     Unregisters an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be unregistered.</param>
        void UnregisterEntity(TEntity entity);
    }
}