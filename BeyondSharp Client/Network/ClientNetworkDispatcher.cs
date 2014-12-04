using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkDispatcher
    {
        public ClientNetworkManager Manager { get; private set; }

        public ClientNetworkDispatcher(ClientNetworkManager manager)
        {
            Manager = manager;
        }

        protected void DispatchMessage(NetOutgoingMessage message, NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            if (Manager.IsConnected)
                Manager.Connection.SendMessage(message, method, channel);
        }

        protected NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = Manager.Client.CreateMessage(sizeof(short) + additionalCapacity);
            message.Write((short)protocol);

            return message;
        }

        /// <summary>
        /// Sends the initial connection request packet to the server containing the network protocol version.
        /// </summary>
        public void DispatchConnectRequest()
        {
            var message = CreateMessage(NetworkProtocol.ConnectRequest, sizeof(double));
            message.Write(NetworkConstants.VERSION);

            DispatchMessage(message);
        }

        /// <summary>
        /// Sends a packet telling the server that the client is disconnecting.
        /// </summary>
        /// <param name="reason">The reason for which the client is disconnecting.</param>
        public void DispatchDisconnect(string reason)
        {
            var message = CreateMessage(NetworkProtocol.Disconnect);
            message.Write(reason);

            DispatchMessage(message);
        }
    }
}
