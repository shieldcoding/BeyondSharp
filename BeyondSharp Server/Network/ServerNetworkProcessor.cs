#region Usings

using System;
using BeyondSharp.Common.Extensions;
using BeyondSharp.Common.Network;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkProcessor :
        INetworkProcessor<ServerNetworkManager, ServerNetworkProcessor, ServerNetworkDispatcher>
    {
        internal ServerNetworkProcessor(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public ServerPlayer CurrentPlayer { get; internal set; }

        #region INetworkProcessor<ServerNetworkManager,ServerNetworkProcessor,ServerNetworkDispatcher> Members

        public NetIncomingMessage CurrentMessage { get; internal set; }
        public ServerNetworkManager Manager { get; private set; }

        public void Process(NetIncomingMessage message)
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

        #endregion

        private void ProcessConnectedStatusMessage()
        {
            var logMessage = Localization.Network.PlayerConnecting
                .FormatKeyWithValue("ip", CurrentPlayer.Connection.RemoteEndPoint.ToString());

            ServerProgram.Logger.Info(logMessage);

            Manager.OnPlayerConnecting(CurrentPlayer);
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

        private bool ProcessConnectionAuthRequest()
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

        private bool ProcessConnectionRequest()
        {
            var version = CurrentMessage.ReadDouble();

            if (Math.Abs(version - NetworkConstants.Version) > 0)
            {
                CurrentPlayer.Disconnect(Localization.Network.DisconnectProtocolMismatch);
                return false;
            }

            Manager.Dispatcher.DispatchConnectionAuthRequestMessage(CurrentPlayer);
            return true;
        }

        private bool ProcessDataMessage()
        {
            var protocol = (NetworkProtocol) CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    return ProcessConnectionRequest();
                case NetworkProtocol.ConnectionAuthRequest:
                    return ProcessConnectionAuthRequest();
                case NetworkProtocol.ConnectionAccepted:
                    return ProcessConnectionAccepted();
            }

            return false;
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

        private void ProcessStatusChangedMessage()
        {
            var status = (NetConnectionStatus) CurrentMessage.ReadByte();

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
    }
}