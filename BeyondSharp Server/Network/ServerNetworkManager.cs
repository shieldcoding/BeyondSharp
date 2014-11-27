using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkManager : ServerEngineComponent, INetworkManagerEngineComponent<ServerEngine>
    {
        public NetServer Server { get; private set; }

        public NetPeerConfiguration Configuration { get; private set; }

        public ServerNetworkManager(ServerEngine engine)
            :base(engine)
        {
        }

        public override void Initialize()
        {
            Configuration = new NetPeerConfiguration(NetworkConstants.IDENTIFIER);
            Configuration.LocalAddress = IPAddress.Parse(ServerProgram.Configuration.Network.Address);
            Configuration.Port = ServerProgram.Configuration.Network.Port;
            Configuration.MaximumConnections = ServerProgram.Configuration.Network.MaximumConnections;

            Server = new NetServer(Configuration);
        }
    }
}
