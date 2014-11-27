using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkManager : ClientEngineComponent, INetworkManagerEngineComponent<ClientEngine>
    {
        public NetConnection Connection { get; private set; }

        public NetPeerConfiguration Configuration { get; private set; }

        public ClientNetworkManager(ClientEngine engine)
            :base(engine)
        {

        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
