using BeyondSharp.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkManager : ServerEngineComponent, INetworkManagerEngineComponent<ServerEngine>
    {
        public ServerNetworkManager(ServerEngine engine)
            :base(engine)
        {

        }
    }
}
