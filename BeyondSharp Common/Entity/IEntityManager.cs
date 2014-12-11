// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The EntityManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Entity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The EntityManager interface.
    /// </summary>
    /// <typeparam name="EntityType">
    /// The type of entity registered with this manager.
    /// </typeparam>
    /// <typeparam name="EntityComponentType">
    /// The type of entity component held by entities registered with this manager.
    /// </typeparam>
    public interface IEntityManager<EntityType, EntityComponentType> : IEngineComponent
        where EntityType : IEntity<EntityComponentType> where EntityComponentType : IEntityComponent
    {
        #region Public Methods and Operators

        /// <summary>
        /// Returns an enumeration of entities registered to this manager.
        /// </summary>
        /// <returns>
        /// An enumeration of entities registered to this manager.
        /// </returns>
        IEnumerable<EntityType> GetEntities();

        /// <summary>
        /// Retrieves an entity with the given unique ID.
        /// </summary>
        /// <param name="id">
        /// The unique ID to retrieve the entity with.
        /// </param>
        /// <returns>
        /// The entity that has the unique ID.
        /// </returns>
        EntityType GetEntity(Guid id);

        /// <summary>
        /// Registers an entity with the entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be registered.
        /// </param>
        /// <returns>
        /// The ID of the entity.
        /// </returns>
        Guid RegisterEntity(EntityType entity);

        /// <summary>
        /// Unregisters an entity with the entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be unregistered.
        /// </param>
        void UnregisterEntity(EntityType entity);

        #endregion
    }
}