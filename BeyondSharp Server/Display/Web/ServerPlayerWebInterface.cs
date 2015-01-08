using System;
using BeyondSharp.Common.Display.Web;
using BeyondSharp.Server.Network;

namespace BeyondSharp.Server.Display.Web
{
    public class ServerPlayerWebInterface : IPlayerWebInterface<ServerPlayer>
    {
        internal ServerPlayerWebInterface(ServerPlayer player)
        {
            Player = player;
        }

        #region IPlayerWebInterface<ServerPlayer> Members

        public Guid Id { get; private set; }
        public ServerPlayer Player { get; private set; }

        #endregion
    }
}