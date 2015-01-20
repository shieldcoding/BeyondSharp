#region Usings

using System;
using BeyondSharp.Common.Network;
using BeyondSharp.Server.Display.Web;
using BeyondSharp.Server.Game.Object;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Server.Network
{
    public class ServerPlayer : EntityController, INetworkPlayer
    {
        internal ServerPlayer(NetConnection connection)
        {
            Connection = connection;
        }

        internal NetConnection Connection { get; private set; }
        public bool IsAuthenticated { get; internal set; }
        public ServerPlayerWebInterface PlayerInterface { get; internal set; }

        public void Disconnect(string reason = null)
        {
            if (Connection == null)
            {
                return;
            }

            Connection.Disconnect(reason);
        }

        #region INetworkPlayer Members

        public Guid HardwareToken { get; internal set; }
        public Guid SessionToken { get; internal set; }
        public string Username { get; internal set; }

        #endregion
    }
}