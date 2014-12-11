// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEntity.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Entity
{
    using System;

    using BeyondSharp.Common.Entity;

    /// <summary>
    /// The server-sided representation of an entity.
    /// </summary>
    public class ServerEntity : IEntity<ServerEntity, ServerEntityComponent>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid ID { get; internal set; }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public ServerEntityManager Manager { get; internal set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}