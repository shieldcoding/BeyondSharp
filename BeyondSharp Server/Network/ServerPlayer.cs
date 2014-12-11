// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerPlayer.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Network
{
    using System;

    using BeyondSharp.Common.Network;
    using BeyondSharp.Server.Entity;

    using Lidgren.Network;

    /// <summary>
    /// The server player.
    /// </summary>
    public class ServerPlayer : ServerEntityController, IPlayer
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerPlayer"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        internal ServerPlayer(NetConnection connection)
        {
            this.Connection = connection;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the hardware token.
        /// </summary>
        public Guid HardwareToken { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether is authenticated.
        /// </summary>
        public bool IsAuthenticated { get; internal set; }

        /// <summary>
        /// Gets the session token.
        /// </summary>
        public Guid SessionToken { get; internal set; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; internal set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the connection.
        /// </summary>
        internal NetConnection Connection { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The disconnect.
        /// </summary>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public void Disconnect(string reason = null)
        {
            if (this.Connection == null)
            {
                return;
            }

            this.Connection.Disconnect(reason);
        }

        #endregion
    }
}