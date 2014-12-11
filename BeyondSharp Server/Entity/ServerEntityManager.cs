// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEntityManager.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server entity manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BeyondSharp.Common.Entity;

    /// <summary>
    /// The server-sided entity manager.
    /// </summary>
    public class ServerEntityManager : ServerEngineComponent, IEntityManager<ServerEntity, ServerEntityComponent>
    {
        #region Fields
        
        /// <summary>
        /// The collection of all registered server entities.
        /// </summary>
        private readonly EntityCollection<ServerEntity, ServerEntityComponent> entityCollection = null;
        
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEntityManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The server engine that the server entity manager is registered to.
        /// </param>
        public ServerEntityManager(ServerEngine engine)
            : base(engine)
        {
            this.entityCollection = new EntityCollection<ServerEntity, ServerEntityComponent>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Retrieves all entities registered to the server entity manager.
        /// </summary>
        /// <returns>
        /// An enumeration of all entities registered on the server.
        /// </returns>
        public IEnumerable<ServerEntity> GetEntities()
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
        /// The <see cref="ServerEntity"/>.
        /// </returns>
        public ServerEntity GetEntity(Guid entityId)
        {
            return entityId == default(Guid) ? null : this.entityCollection.GetEntity(entityId);
        }

        /// <summary>
        /// Attempts to initialize the server-sided entity manager.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// This isn't implemented yet.
        /// </exception>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers an entity with the server entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be registered to the server entity manager.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/> of the entity, now that its been registered to the server.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Tried to register an entity with the server entity manager, but received a null reference.
        /// </exception>
        public Guid RegisterEntity(ServerEntity entity)
        {
            if (entity.Equals(null))
            {
                throw new ArgumentNullException();
            }

            if (this.entityCollection.Contains(entity))
            {
                return entity.ID;
            }

            entity.ID = Guid.NewGuid();
            entity.Manager = this;

            this.entityCollection.Add(entity);

            return entity.ID;
        }

        /// <summary>
        /// Unregisters an entity from the server entity manager.
        /// </summary>
        /// <param name="entity">
        /// The entity to be unregistered from the server entity manager.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to unregister an entity from the server entity manager, but received a null reference.
        /// </exception>
        public void UnregisterEntity(ServerEntity entity)
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