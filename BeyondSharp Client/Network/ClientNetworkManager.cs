using BeyondSharp.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkManager : ClientEngineComponent, INetworkManagerEngineComponent<ClientEngine>
    {
        public ClientNetworkManager(ClientEngine engine)
            :base(engine)
        {

        }
    }
}
