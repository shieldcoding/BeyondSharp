namespace BeyondSharp.Common.Entity
{
    using System;
    using System.Collections.Generic;

    public interface IEntityManager<EntityType, EntityComponentType> : IEngineComponent
        where EntityType : IEntity<EntityComponentType>
        where EntityComponentType : IEntityComponent
    {
        /// <summary>
        ///     Retrieves an entity with the given unique ID.
        /// </summary>
        /// <param name="id">The unique ID to retrieve the entity with.</param>
        /// <returns>The entity that has the unique ID.</returns>
        EntityType GetEntity(Guid id);

        /// <summary>
        ///     Returns an enumeration of entities that match the specified type.
        /// </summary>
        /// <typeparam name="FilteredType"></typeparam>
        /// <returns></returns>
        IEnumerable<FilteredType> GetEntities<FilteredType>() where FilteredType : EntityType;

        /// <summary>
        ///     Registers an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be registered.</param>
        /// <returns>The ID of the entity.</returns>
        Guid RegisterEntity(EntityType entity);

        /// <summary>
        ///     Unregisters an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be unregistered.</param>
        void UnregisterEntity(EntityType entity);
    }
}