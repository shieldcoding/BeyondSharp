namespace BeyondSharp.Server.World
{
    using BeyondSharp.Common.World;

    public class ServerWorld : IWorld
    {
        public ServerWorld(ServerWorldManager manager)
        {
            Manager = manager;
        }

        public ServerWorldManager Manager { get; private set; }
    }
}