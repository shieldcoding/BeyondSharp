using BeyondSharp.Common.Network;
using BeyondSharp.Server.Entity;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    public class ServerPlayer : ServerEntityController, IPlayer
    {
        public string Username { get; internal set; }

        public Guid SessionToken { get; internal set; }

        public Guid HardwareToken { get; internal set; }

        public bool IsAuthenticated { get; internal set; }

        internal NetConnection Connection { get; private set; }

        internal ServerPlayer(NetConnection connection)
        {
            Connection = connection;
        }

        public void Disconnect(string reason = null)
        {
            if (Connection == null)
                return;

            Connection.Disconnect(reason);
        }
    }
}
