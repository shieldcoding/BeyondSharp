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
    /// The client entity manager.
    /// </summary>
    public class ClientEntityManager : ClientEngineComponent, IEntityManager<ClientEntity, ClientEntityComponent>
    {
        #region Fields

        /// <summary>
        /// The entities.
        /// </summary>
        private List<ClientEntity> entities = null;

        /// <summary>
        /// The entity lock.
        /// </summary>
        private object entityLock = null;

        /// <summary>
        /// The entity lookup.
        /// </summary>
        private Dictionary<Guid, ClientEntity> entityLookup = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientEntityManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        internal ClientEntityManager(ClientEngine engine)
            : base(engine)
        {
            this.entityLock = new object();
            this.entities = new List<ClientEntity>();
            this.entityLookup = new Dictionary<Guid, ClientEntity>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get entities.
        /// </summary>
        /// <returns>
        /// An enumeration of all entities registered on the client.
        /// </returns>
        public IEnumerable<ClientEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ClientEntity"/>.
        /// </returns>
        public ClientEntity GetEntity(Guid id)
        {
            if (id == default(Guid))
            {
                return null;
            }

            lock (this.entityLock)
            {
                if (this.entityLookup.ContainsKey(id))
                {
                    return this.entityLookup[id];
                }
                else
                {
                    return null;
                }
            }
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
        /// The register entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public Guid RegisterEntity(ClientEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            lock (this.entityLock)
            {
                if (!this.entities.Contains(entity))
                {
                    this.entities.Add(entity);
                }

                if (!this.entityLookup.ContainsKey(entity.ID))
                {
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
        public void UnregisterEntity(ClientEntity entity)
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