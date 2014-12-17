namespace BeyondSharp.Server.Game.Environment
{
    using System;

    using BeyondSharp.Common.Game.Environment;

    public class WorldManager : ServerEngineComponent, IWorldManager<WorldManager, World, WorldTile>
    {
        public WorldManager(ServerEngine engine)
            : base(engine)
        {
        }

        public World World { get; private set; }

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