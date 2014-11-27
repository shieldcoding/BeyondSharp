﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    public interface ICommonEntityManager<EngineType, EntityType> : ICommonEngineComponent<EngineType>
        where EngineType : ICommonEngine
        where EntityType : ICommonEntity
    {
        /// <summary>
        /// Retrieves an entity with the given unique ID.
        /// </summary>
        /// <param name="id">The unique ID to retrieve the entity with.</param>
        /// <returns>The entity that has the unique ID.</returns>
        EntityType GetEntity(Guid id);
        
        /// <summary>
        /// Returns an enumeration of entities that match the specified type.
        /// </summary>
        /// <typeparam name="FilteredType"></typeparam>
        /// <returns></returns>
        IEnumerable<FilteredType> GetEntities<FilteredType>() where FilteredType : EntityType;

        /// <summary>
        /// Registers an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be registered.</param>
        void RegisterEntity(EntityType entity);

        /// <summary>
        /// Unregisters an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be unregistered.</param>
        void UnregisterEntity(EntityType entity);
    }
}
