namespace BeyondSharp.Server.Game.Environment
{
    using BeyondSharp.Common.Game.Environment;

    public class World : IWorld<WorldManager, World, WorldTile>
    {
        public World(WorldManager manager)
        {
            Manager = manager;
        }

        public WorldManager Manager { get; private set; }
    }
}