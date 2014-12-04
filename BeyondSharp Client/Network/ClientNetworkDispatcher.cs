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
    }
}
