using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    public interface ICommonEntityManager<EntityType, EntityComponentType> : ICommonEngineComponent
        where EntityType : ICommonEntity<EntityComponentType>
        where EntityComponentType : ICommonEntityComponent
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
        /// <returns>The ID of the entity.</returns>
        Guid RegisterEntity(EntityType entity);

        /// <summary>
        /// Unregisters an entity with the entity manager.
        /// </summary>
        /// <param name="entity">The entity to be unregistered.</param>
        void UnregisterEntity(EntityType entity);
    }
}
