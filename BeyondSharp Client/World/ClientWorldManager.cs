using BeyondSharp.Common.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.World
{
    public class ClientWorldManager : ClientEngineComponent, ICommonWorldManager<ClientWorld>
    {
        public ClientWorld World { get; private set; }

        public ClientWorldManager(ClientEngine engine)
            :base(engine)
        {

        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
