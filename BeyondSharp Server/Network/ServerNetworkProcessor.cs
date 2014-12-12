namespace BeyondSharp.Server.Network
{
    using System;

    using BeyondSharp.Common.Network;
    using BeyondSharp.Server.Localization;

    using Lidgren.Network;

    internal class ServerNetworkProcessor
    {
        internal ServerNetworkProcessor(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public ServerNetworkManager Manager { get; private set; }

        public NetIncomingMessage CurrentMessage { get; internal set; }

        public ServerPlayer CurrentPlayer { get; internal set; }

        internal void ProcessMessage(NetIncomingMessage message)
        {
            CurrentMessage = message;
            CurrentPlayer = Manager.GetOrRegisterPlayer(message.SenderConnection);

            switch (message.MessageType)
            {
                case NetIncomingMessageType.ConnectionApproval:
                    ProcessConnectionApprovalMessage();
                    break;
                case NetIncomingMessageType.StatusChanged:
                    ProcessStatusChangedMessage();
                    break;
                case NetIncomingMessageType.Data:
                    ProcessDataMessage();
                    break;
            }

            CurrentMessage = null;
            CurrentPlayer = null;
        }

        private void ProcessConnectionApprovalMessage()
        {
        }

        private void ProcessStatusChangedMessage()
        {
        }

        private void ProcessDataMessage()
        {
            var protocol = (NetworkProtocol)CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    ProcessConnectionRequest();
                    return;
                case NetworkProtocol.ConnectionAuthenticate:
                    ProcessConnectionAuthenticate();
                    return;
            }
        }

        private void ProcessConnectionRequest()
        {
            var version = CurrentMessage.ReadDouble();

            if (version != CommonNetworkConstants.Version)
            {
                CurrentPlayer.Disconnect(Network.DisconnectProtocolMismatch);
                return;
            }

            Manager.Dispatcher.DispatchConnectionAuthMessage(CurrentPlayer);
        }

        private void ProcessConnectionAuthenticate()
        {
            var username = CurrentMessage.ReadString();
            var sessionToken = Guid.Parse(CurrentMessage.ReadString());
            var hardwareToken = Guid.Parse(CurrentMessage.ReadString());

            // Validate the session token with the login server.

            Manager.Dispatcher.DispatchConnectionAcceptedMessage(CurrentPlayer);
        }

        private void ProcessConnectionAccepted()
        {
            Manager.OnPlayerConnected(CurrentPlayer);
        }
    }
}