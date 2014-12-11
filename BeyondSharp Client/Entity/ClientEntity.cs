// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientEntity.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Entity
{
    using System;

    using BeyondSharp.Common.Entity;

    /// <summary>
    /// The client entity.
    /// </summary>
    public class ClientEntity : IEntity<ClientEntity, ClientEntityComponent>
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
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}