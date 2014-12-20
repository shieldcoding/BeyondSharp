namespace BeyondSharp.Server.Network
{
    using System;
    using System.Collections.Generic;

    using BeyondSharp.Common.Extensions;

    using System.Linq;

    using BeyondSharp.Common.Network;
    using BeyondSharp.Server.Game.Map;

    using Lidgren.Network;

    internal class ServerNetworkDispatcher
    {
        public ServerNetworkDispatcher(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public ServerNetworkManager Manager { get; private set; }

        private void DispatchMessage(NetOutgoingMessage message, IEnumerable<ServerPlayer> recipients, NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            Manager.Server.SendMessage(message, recipients.Select(recipient => recipient.Connection).ToList(), method, channel);
        }

        private void DispatchMessage(NetOutgoingMessage message, ServerPlayer recipient, NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            DispatchMessage(message, recipient.Yield(), method, channel);
        }

        private NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = Manager.Server.CreateMessage(sizeof(short) + additionalCapacity);
            message.Write((short)protocol);

            return message;
        }

        internal void DispatchConnectionAuthMessage(ServerPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            var message = CreateMessage(NetworkProtocol.ConnectionAuthenticate);
            DispatchMessage(message, player);
        }

        internal void DispatchConnectionAcceptedMessage(ServerPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            var message = CreateMessage(NetworkProtocol.ConnectAccept);
            DispatchMessage(message, player);
        }

        internal void DispatchWorldDataMessage(IEnumerable<ServerPlayer> players, IEnumerable<ServerWorldTile> tiles)
        {
            var message = CreateMessage(NetworkProtocol.WorldData);

            DispatchMessage(message, players);
        }
    }
}