// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientNetworkProcessor.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client network processor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Network
{
    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The client network processor.
    /// </summary>
    internal class ClientNetworkProcessor
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientNetworkProcessor"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        internal ClientNetworkProcessor(ClientNetworkManager manager)
        {
            this.Manager = manager;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current message.
        /// </summary>
        internal NetIncomingMessage CurrentMessage { get; private set; }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        internal ClientNetworkManager Manager { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        internal void Process(NetIncomingMessage message)
        {
            this.CurrentMessage = message;

            switch (this.CurrentMessage.MessageType)
            {
                case NetIncomingMessageType.StatusChanged:
                    this.ProcessStatusChanged();
                    break;

                case NetIncomingMessageType.Data:
                    this.ProcessDataMessage();
                    break;
            }
        }

        /// <summary>
        /// The process connect request.
        /// </summary>
        private void ProcessConnectRequest()
        {
            this.Manager.Dispatcher.DispatchConnectionAuthenticate();
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
                    this.ProcessConnectRequest();
                    return;
            }
        }

        /// <summary>
        /// The process status changed.
        /// </summary>
        private void ProcessStatusChanged()
        {
        }

        #endregion
    }
}