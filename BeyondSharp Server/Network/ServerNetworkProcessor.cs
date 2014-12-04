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

        public ServerNetworkProcessor(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public void ProcessMessage(NetIncomingMessage message)
        {
            var protocol = (NetworkProtocol)message.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectRequest:
                    ProcessConnectRequest(message);
                    return;
            }
        }

        private void ProcessConnectRequest(NetIncomingMessage message)
        {
            var version = message.ReadDouble();

            if (version != NetworkConstants.VERSION)
            {

            }
        }
    }
}
