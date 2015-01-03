#region Usings

using BeyondSharp.Common.Network;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkDispatcher :
        INetworkDispatcher<ClientNetworkManager, ClientNetworkProcessor, ClientNetworkDispatcher>
    {
        public ClientNetworkDispatcher(ClientNetworkManager manager)
        {
            Manager = manager;
        }

        public ClientNetworkManager Manager { get; private set; }

        protected NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = Manager.Client.CreateMessage(sizeof (short) + additionalCapacity);
            message.Write((short) protocol);

            return message;
        }

        internal void DispatchConnectionAuthenticate()
        {
            var message = CreateMessage(NetworkProtocol.ConnectionAuthenticate);
            message.Write(Manager.Player.Username);
            message.Write(Manager.Player.SessionToken.ToString("N"));
            message.Write(Manager.Player.HardwareToken.ToString("N"));

            DispatchMessage(message);
        }

        /// <summary>
        ///     Sends the initial connection request packet to the server containing the network protocol version.
        /// </summary>
        public void DispatchConnectRequest()
        {
            var message = CreateMessage(NetworkProtocol.ConnectionRequest, sizeof (double));
            message.Write(NetworkConstants.Version);

            DispatchMessage(message);
        }

        protected void DispatchMessage(NetOutgoingMessage message,
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            if (Manager.IsConnected)
            {
                Manager.Connection.SendMessage(message, method, channel);
            }
        }
    }
}