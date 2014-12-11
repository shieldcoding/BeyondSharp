// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientNetworkDispatcher.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client network dispatcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Network
{
    using System;

    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The client network dispatcher.
    /// </summary>
    internal class ClientNetworkDispatcher
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientNetworkDispatcher"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        internal ClientNetworkDispatcher(ClientNetworkManager manager)
        {
            this.Manager = manager;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the manager.
        /// </summary>
        internal ClientNetworkManager Manager { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sends the initial connection request packet to the server containing the network protocol version.
        /// </summary>
        internal void DispatchConnectRequest()
        {
            var message = this.CreateMessage(NetworkProtocol.ConnectionRequest, sizeof(double));
            message.Write(CommonNetworkConstants.ProtocolVersion);

            this.DispatchMessage(message);
        }

        /// <summary>
        /// The dispatch connection authenticate.
        /// </summary>
        internal void DispatchConnectionAuthenticate()
        {
            var message = this.CreateMessage(NetworkProtocol.ConnectionAuthenticate);
            message.Write(this.Manager.Player.Username);
            message.Write(this.Manager.Player.SessionToken.ToString("N"));
            message.Write(this.Manager.Player.HardwareToken.ToString("N"));

            this.DispatchMessage(message);
        }

        /// <summary>
        /// The create message.
        /// </summary>
        /// <param name="protocol">
        /// The protocol.
        /// </param>
        /// <param name="additionalCapacity">
        /// The additional capacity.
        /// </param>
        /// <returns>
        /// The <see cref="NetOutgoingMessage"/>.
        /// </returns>
        private NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = this.Manager.Client.CreateMessage(sizeof(short) + Math.Max(0, additionalCapacity));
            message.Write((short)protocol);

            return message;
        }

        /// <summary>
        /// The dispatch message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="channel">
        /// The channel.
        /// </param>
        private void DispatchMessage(
            NetOutgoingMessage message, 
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, 
            int channel = 0)
        {
            if (this.Manager.IsConnected)
            {
                this.Manager.Connection.SendMessage(message, method, channel);
            }
        }

        #endregion
    }
}