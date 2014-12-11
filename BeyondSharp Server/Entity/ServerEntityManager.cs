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
    /// The server entity manager.
    /// </summary>
    public class ServerEntityManager : ServerEngineComponent, IEntityManager<ServerEntity, ServerEntityComponent>
    {
        #region Fields

        /// <summary>
        /// The list of all registered server entities.
        /// </summary>
        private readonly List<ServerEntity> entities = new List<ServerEntity>();

        /// <summary>
        /// The entity lock.
        /// </summary>
        private readonly object entityLock = new object();

        /// <summary>
        /// A lookup for retrieving an entity by an ID.
        /// </summary>
        private readonly Dictionary<Guid, ServerEntity> entityLookup = new Dictionary<Guid, ServerEntity>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEntityManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ServerEntityManager(ServerEngine engine)
            : base(engine)
        {
            this.entityLock = new object();
            this.entities = new List<ServerEntity>();
            this.entityLookup = new Dictionary<Guid, ServerEntity>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Retrieves all entities of the specified type registered to this manager.
        /// </summary>
        /// <returns>
        /// An enumeration of all entities registered on the server.
        /// </returns>
        public IEnumerable<ServerEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        /// <summary>
        /// Gets the entity with the specified ID or null if there is no entity with that ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the entity to be retrieved.
        /// </param>
        /// <returns>
        /// The <see cref="ServerEntity"/> with that ID that is registered on the server.
        /// </returns>
        public ServerEntity GetEntity(Guid id)
        {
            if (id == default(Guid))
            {
                return null;
            }

            return this.entityLookup.ContainsKey(id) ? this.entityLookup[id] : null;
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
        /// The register entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public Guid RegisterEntity(ServerEntity entity)
        {
            lock (this.entityLock)
            {
                if (this.entities.Contains(entity))
                {
                    if (entity.ID == default(Guid))
                    {
                        return default(Guid);
                    }
                }
                else
                {
                    entity.ID = Guid.NewGuid();
                    entity.Manager = this;

                    this.entities.Add(entity);
                    this.entityLookup.Add(entity.ID, entity);
                }
            }

            return entity.ID;
        }

        /// <summary>
        /// The unregister entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public void UnregisterEntity(ServerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            lock (this.entityLock)
            {
                this.entities.Remove(entity);
                this.entityLookup.Remove(entity.ID);
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