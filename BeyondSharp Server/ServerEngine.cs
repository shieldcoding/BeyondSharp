using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerEngine : Engine
    {
        public ServerEngine()
        {
            Side = EngineSide.Server;
        }
    }
}
