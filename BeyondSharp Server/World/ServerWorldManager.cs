using BeyondSharp.Common.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.World
{
    public class ServerWorldManager : ServerEngineComponent, ICommonWorldManager<ServerWorld>
    {
        public ServerWorld World { get; private set; }

        public ServerWorldManager(ServerEngine engine)
            : base(engine)
        {

        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}
