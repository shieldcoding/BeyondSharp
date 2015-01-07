#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using BeyondSharp.Common.Extensions;
using BeyondSharp.Common.Network;
using BeyondSharp.Server.Game.Map;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkDispatcher :
        INetworkDispatcher<ServerNetworkManager, ServerNetworkProcessor, ServerNetworkDispatcher>
    {
        internal ServerNetworkDispatcher(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public ServerNetworkManager Manager { get; private set; }

        private NetOutgoingMessage CreateMessage(NetworkProtocol protocol, int additionalCapacity = 0)
        {
            var message = Manager.Server.CreateMessage(sizeof (short) + additionalCapacity);
            message.Write((short) protocol);

            return message;
        }

        internal void DispatchConnectionAcceptedMessage(ServerPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            var message = CreateMessage(NetworkProtocol.ConnectionAccepted);
            DispatchMessage(message, player);
        }

        internal void DispatchConnectionAuthRequestMessage(ServerPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            var message = CreateMessage(NetworkProtocol.ConnectionAuthRequest);
            DispatchMessage(message, player);
        }

        private void DispatchMessage(NetOutgoingMessage message, IEnumerable<ServerPlayer> recipients,
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            Manager.Server.SendMessage(message, recipients.Select(recipient => recipient.Connection).ToList(), method,
                channel);
        }

        private void DispatchMessage(NetOutgoingMessage message, ServerPlayer recipient,
            NetDeliveryMethod method = NetDeliveryMethod.ReliableOrdered, int channel = 0)
        {
            DispatchMessage(message, recipient.Yield(), method, channel);
        }

        internal void DispatchWorldDataMessage(IEnumerable<ServerPlayer> players, IEnumerable<ServerWorldTile> tiles)
        {
            var message = CreateMessage(NetworkProtocol.WorldData);

            DispatchMessage(message, players);
        }
    }
}