using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkProcessor
    {
        public ClientNetworkManager Manager { get; private set; }

        public ClientNetworkProcessor(ClientNetworkManager manager)
        {
            Manager = manager;
        }
    }
}
