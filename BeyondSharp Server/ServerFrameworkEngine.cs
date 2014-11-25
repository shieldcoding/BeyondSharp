using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerFrameworkEngine : FrameworkEngine
    {
        public ServerFrameworkEngine()
        {
            Side = FrameworkEngineSide.Server;
        }
    }
}
