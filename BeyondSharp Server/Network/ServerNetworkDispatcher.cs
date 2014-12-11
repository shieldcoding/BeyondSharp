// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerNetworkDispatcher.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server network dispatcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BeyondSharp.Common.Extensions;
    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The server network dispatcher.
    /// </summary>
    internal class ServerNetworkDispatcher
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerNetworkDispatcher"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public ServerNetworkDispatcher(ServerNetworkManager manager)
        {
            this.Manager = manager;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public ServerNetworkManager Manager { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Dispatches a message to the client to notify it that it has successfully authenticated with the server with the intention of receiving it back.
        /// </summary>
        /// <param name="player">
        /// The player to dispatch the message to.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to dispatch a connection accepted message, but received a null reference.
        /// </exception>
        internal void DispatchConnectionAcceptedMessage(ServerPlayer player)
        {
            if (player.Equals(null))
            {
                throw new ArgumentNullException();
            }

            var message = this.CreateMessage(NetworkProtocol.ConnectAccept);
            this.DispatchMessage(message, player);
        }

        /// <summary>
        /// Dispatches a request to the client to supply its authentication details.
        /// </summary>
        /// <param name="player">
        /// The player to dispatch the authentication request to.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to dispatch a connection authentication message, but received a null reference.
        /// </exception>
        internal void DispatchConnectionAuthMessage(ServerPlayer player)
        {
            if (player.Equals(null))
            {
                throw new ArgumentNullException();
            }

            var message = this.CreateMessage(NetworkProtocol.ConnectionAuthenticate);
            this.DispatchMessage(message, player);
        }

        /// <summary>
        /// Creates a new outgoing network message using the specified protocol.
        /// </summary>
        /// <param name="protocol">
        /// The type of message in the protocol to be used.
        /// </param>
        /// <param name="additionalCapacity">
        /// The number of bytes to additionally allocate for the message.
        /// </param>
        /// <returns>
        /// The newly-created <see cref="NetOutgoingMessage"/> with the network protocol.
        /// </returns>
        private NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = this.Manager.Server.CreateMessage(sizeof(short) + additionalCapacity);
            message.Write((short)protocol);

            return message;
        }

        /// <summary>
        /// The dispatch message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="recipients">
        /// The recipients.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        private void DispatchMessage(
            NetOutgoingMessage message, 
            IEnumerable<ServerPlayer> recipients, 
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, 
            int channel = 0)
        {
            this.Manager.Server.SendMessage(
                message, 
                recipients.Select(recipient => recipient.Connection).ToList(), 
                method, 
                channel);
        }

        /// <summary>
        /// The dispatch message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        private void DispatchMessage(
            NetOutgoingMessage message, 
            ServerPlayer recipient, 
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, 
            int channel = 0)
        {
            this.DispatchMessage(message, recipient.Yield(), method, channel);
        }

        #endregion
    }
}