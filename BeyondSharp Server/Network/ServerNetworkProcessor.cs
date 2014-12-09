using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    internal class ServerNetworkProcessor
    {
        public ServerNetworkManager Manager { get; private set; }

        public NetIncomingMessage CurrentMessage { get; internal set; }

        public ServerPlayer CurrentPlayer { get; internal set; }

        internal ServerNetworkProcessor(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        internal void ProcessMessage(NetIncomingMessage message)
        {
            CurrentMessage = message;
            CurrentPlayer = Manager.GetOrRegisterPlayer(message.SenderConnection);

            switch (message.MessageType)
            {
                case NetIncomingMessageType.Data:
                    ProcessDataMessage();
                    break;
            }

            CurrentMessage = null;
            CurrentPlayer = null;
        }

        private void ProcessDataMessage()
        {
            var protocol = (NetworkProtocol) CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectRequest:
                    ProcessConnectRequest();
                    return;
            }
        }

        private void ProcessConnectRequest()
        {
            var version = CurrentMessage.ReadDouble();

            if (version != NetworkConstants.VERSION)
            {
                CurrentPlayer.Disconnect(Localization.Network.DisconnectProtocolMismatch);
                return;
            }
        }
    }
}
