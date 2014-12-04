using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkProcessor
    {
        public ServerNetworkManager Manager { get; private set; }

        public ServerNetworkProcessor(ServerNetworkManager manager)
        {
            Manager = manager;
        }

        public void ProcessMessage(NetIncomingMessage message)
        {

        }
    }
}
