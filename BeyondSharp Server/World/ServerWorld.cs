using BeyondSharp.Common.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.World
{
    public class ServerWorld : ICommonWorld
    {
        public ServerWorldManager Manager { get; private set; }

        public ServerWorld(ServerWorldManager manager)
        {
            Manager = manager;
        }
    }
}
