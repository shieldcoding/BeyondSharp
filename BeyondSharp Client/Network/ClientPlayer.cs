// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientPlayer.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Network
{
    using System;

    using BeyondSharp.Client.Entity;
    using BeyondSharp.Common.Entity;
    using BeyondSharp.Common.Network;

    /// <summary>
    /// The client player.
    /// </summary>
    public class ClientPlayer : IPlayer, IEntityController<ClientEntity, ClientEntityComponent>
    {
        #region Public Properties

        /// <summary>
        /// Gets the controlled entity.
        /// </summary>
        public ClientEntity ControlledEntity { get; internal set; }

        /// <summary>
        /// Gets the hardware token.
        /// </summary>
        public Guid HardwareToken { get; internal set; }

        /// <summary>
        /// Gets the session token.
        /// </summary>
        public Guid SessionToken { get; internal set; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; internal set; }

        #endregion
    }
}