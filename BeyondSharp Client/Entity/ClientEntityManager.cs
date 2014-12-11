// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientEntityManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client entity manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BeyondSharp.Common.Entity;

    /// <summary>
    /// The client-sided entity manager.
    /// </summary>
    public class ClientEntityManager : ClientEngineComponent, IEntityManager<ClientEntity, ClientEntityComponent>
    {
        #region Fields
        
        /// <summary>
        /// The collection of all registered client entities.
        /// </summary>
        private readonly EntityCollection<ClientEntity, ClientEntityComponent> entityCollection = null; 

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientEntityManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The client engine that the client entity manager is registered to.
        /// </param>
        internal ClientEntityManager(ClientEngine engine)
            : base(engine)
        {
            this.entityCollection = new EntityCollection<ClientEntity, ClientEntityComponent>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Retrieves all entities registered to the client entity manager.
        /// </summary>
        /// <returns>
        /// An enumeration of all entities registered on the client.
        /// </returns>
        public IEnumerable<ClientEntity> GetEntities()
        {
            return this.entityCollection.ToList();
        }

        /// <summary>
        /// Retrieves the entity with the specified ID or null if there is no entity registered with that ID.
        /// </summary>
        /// <param name="entityId">
        /// The ID of the entity to be retrieved.
        /// </param>
        /// <returns>
        /// The <see cref="ClientEntity"/>.
        /// </returns>
        public ClientEntity GetEntity(Guid entityId)
        {
            return entityId == default(Guid) ? null : this.entityCollection.GetEntity(entityId);
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers an entity with the client entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be registered to the client entity manager.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/> of the entity, now that its been registered to the client.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Tried to register an entity with the client entity manager, but received a null reference.
        /// </exception>
        public Guid RegisterEntity(ClientEntity entity)
        {
            if (entity.Equals(null))
            {
                throw new ArgumentNullException();
            }

            this.entityCollection.Add(entity);

            return entity.ID;
        }

        /// <summary>
        /// Unregisters an entity from the client entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be unregistered from the client entity manager.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to unregister an entity from the client entity manager, but received a null reference.
        /// </exception>
        public void UnregisterEntity(ClientEntity entity)
        {
            if (entity.Equals(null))
            {
                throw new ArgumentNullException();
            }

            if (this.entityCollection.Remove(entity))
            {
                // Once the entity has been unregistered we remove its ID.
                entity.ID = default(Guid);
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}