// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerNetworkProcessor.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server network processor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Network
{
    using System;

    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The server network processor.
    /// </summary>
    internal class ServerNetworkProcessor
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerNetworkProcessor"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        internal ServerNetworkProcessor(ServerNetworkManager manager)
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

        #region Properties

        /// <summary>
        /// Gets the current message being processed by the network processor.
        /// </summary>
        internal NetIncomingMessage CurrentMessage { get; private set; }

        /// <summary>
        /// Gets the current player that owns the current message being processed by the network processor.
        /// </summary>
        internal ServerPlayer CurrentPlayer { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The process message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        internal void ProcessMessage(NetIncomingMessage message)
        {
            this.CurrentMessage = message;
            this.CurrentPlayer = this.Manager.GetOrRegisterPlayer(message.SenderConnection);

            switch (message.MessageType)
            {
                case NetIncomingMessageType.ConnectionApproval:
                    this.ProcessConnectionApprovalMessage();
                    break;

                case NetIncomingMessageType.StatusChanged:
                    this.ProcessStatusChangedMessage();
                    break;

                case NetIncomingMessageType.Data:
                    this.ProcessDataMessage();
                    break;
            }

            this.CurrentMessage = null;
            this.CurrentPlayer = null;
        }

        /// <summary>
        /// The process connection accepted.
        /// </summary>
        private void ProcessConnectionAccepted()
        {
            this.Manager.OnPlayerConnected(this.CurrentPlayer);
        }

        /// <summary>
        /// The process connection approval message.
        /// </summary>
        private void ProcessConnectionApprovalMessage()
        {
        }

        /// <summary>
        /// The process connection authenticate.
        /// </summary>
        private void ProcessConnectionAuthenticate()
        {
            var username = this.CurrentMessage.ReadString();
            var sessionToken = Guid.Parse(this.CurrentMessage.ReadString());
            var hardwareToken = Guid.Parse(this.CurrentMessage.ReadString());

            // Validate the session token with the login server.
            this.Manager.Dispatcher.DispatchConnectionAcceptedMessage(this.CurrentPlayer);
        }

        /// <summary>
        /// The process connection request.
        /// </summary>
        private void ProcessConnectionRequest()
        {
            var version = this.CurrentMessage.ReadDouble();

            if (version != CommonNetworkConstants.ProtocolVersion)
            {
                this.CurrentPlayer.Disconnect(Localization.Network.DisconnectProtocolMismatch);
                return;
            }

            this.Manager.Dispatcher.DispatchConnectionAuthMessage(this.CurrentPlayer);
        }

        /// <summary>
        /// The process data message.
        /// </summary>
        private void ProcessDataMessage()
        {
            var protocol = (NetworkProtocol)this.CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    this.ProcessConnectionRequest();
                    return;

                case NetworkProtocol.ConnectionAuthenticate:
                    this.ProcessConnectionAuthenticate();
                    return;
            }
        }

        /// <summary>
        /// The process status changed message.
        /// </summary>
        private void ProcessStatusChangedMessage()
        {
        }

        #endregion
    }
}