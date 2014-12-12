namespace BeyondSharp.Server.World
{
    using System;

    using BeyondSharp.Common.World;

    public class ServerWorldManager : ServerEngineComponent, ICommonWorldManager<ServerWorld>
    {
        public ServerWorldManager(ServerEngine engine)
            : base(engine)
        {
        }

        public ServerWorld World { get; private set; }

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