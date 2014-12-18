namespace BeyondSharp.Server.Game.Map
{
    using BeyondSharp.Common.Game.Map;

    public class ServerWorld : IWorld<ServerWorldManager, ServerWorld, ServerWorldTile>
    {
        public ServerWorldManager Manager { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public ServerWorldTile GetTile(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        internal void Initialize(ServerWorldManager manager, int width, int height)
        {
            Manager = manager;
            Width = width;
            Height = height;
        }

        public byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(byte[] data)
        {
            throw new System.NotImplementedException();
        }
    }
}