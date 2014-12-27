namespace BeyondSharp.Server.Network
{
    using System;

    using BeyondSharp.Common.Extensions;
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
        
        private void ProcessStatusChangedMessage()
        {
            var status = (NetConnectionStatus)CurrentMessage.ReadByte();

            switch (status)
            {
                case NetConnectionStatus.Connected:
                    ProcessConnectedStatusMessage();
                    return;
                case NetConnectionStatus.Disconnected:
                    ProcessDisconnectedStatusMessage();
                    return;
            }
        }

        private void ProcessConnectedStatusMessage()
        {
            var logMessage = Localization.Network.PlayerConnecting
                .FormatKeyWithValue("ip", CurrentPlayer.Connection.RemoteEndPoint.ToString());

            ServerProgram.Logger.Info(logMessage);

            Manager.OnPlayerConnecting(CurrentPlayer);
        }

        private void ProcessDisconnectedStatusMessage()
        {
            var baseLogMessage = Localization.Network.PlayerDisconnected;

            if (CurrentPlayer.IsAuthenticated)
                baseLogMessage = Localization.Network.PlayerDisconnectedWithUsername;

            var logMessage = baseLogMessage
                .FormatKeyWithValue("username", CurrentPlayer.Username)
                .FormatKeyWithValue("ip", CurrentPlayer.Connection.RemoteEndPoint.ToString());

            ServerProgram.Logger.Info(logMessage);

            Manager.OnPlayerDisconnect(CurrentPlayer);
        }

        private bool ProcessDataMessage()
        {
            var protocol = (NetworkProtocol)CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    return ProcessConnectionRequest();
                case NetworkProtocol.ConnectionAuthenticate:
                    return ProcessConnectionAuthenticate();
                case NetworkProtocol.ConnectionAccepted:
                    return ProcessConnectionAccepted();
            }

            return false;
        }

        private bool ProcessConnectionRequest()
        {
            var version = CurrentMessage.ReadDouble();

            if (Math.Abs(version - NetworkConstants.Version) > 0)
            {
                CurrentPlayer.Disconnect(Network.DisconnectProtocolMismatch);
                return false;
            }

            Manager.Dispatcher.DispatchConnectionAuthMessage(CurrentPlayer);
            return true;
        }

        private bool ProcessConnectionAuthenticate()
        {
            var username = CurrentMessage.ReadString();
            var sessionToken = Guid.Parse(CurrentMessage.ReadString());
            var hardwareToken = Guid.Parse(CurrentMessage.ReadString());

            //TODO: Validate the session token with the login server.

            CurrentPlayer.Username = username;
            CurrentPlayer.SessionToken = sessionToken;
            CurrentPlayer.HardwareToken = hardwareToken;
            CurrentPlayer.IsAuthenticated = true;

            Manager.Dispatcher.DispatchConnectionAcceptedMessage(CurrentPlayer);
            return true;
        }

        private bool ProcessConnectionAccepted()
        {
            if (!CurrentPlayer.IsAuthenticated)
                return false;

            var logMessage = Localization.Network.PlayerConnected
                .FormatKeyWithValue("username", CurrentPlayer.Username)
                .FormatKeyWithValue("ip", CurrentPlayer.Connection.RemoteEndPoint.ToString());

            ServerProgram.Logger.Info(logMessage);

            Manager.OnPlayerConnected(CurrentPlayer);
            return true;
        }
    }
}