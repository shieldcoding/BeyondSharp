using BeyondSharp.Common.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.World
{
    public class ClientWorld : ICommonWorld
    {
        public ClientWorldManager Manager { get; private set; }

        internal ClientWorld(ClientWorldManager manager)
        {
            Manager = manager;
        }
    }
}
