using BeyondSharp.Common;
using BeyondSharp.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerEngine : CommonEngine<ServerEngineComponent>
    {
        public ServerEntityManager EntityManager { get; private set; }

        internal ServerEngine()
        {
            Side = EngineSide.Server;
        }
    }
}
