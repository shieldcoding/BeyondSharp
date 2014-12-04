using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    internal class ServerNetworkDispatcher
    {
        public ServerNetworkManager Manager { get; private set; }

        public ServerNetworkDispatcher(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public void DispatchMessage(NetOutgoingMessage message)
        {

        }
    }
}
