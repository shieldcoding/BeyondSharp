namespace BeyondSharp.Client.Game.Environment
{
    using BeyondSharp.Common.Game.Map;

    public class ClientWorld : IWorld<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        internal ClientWorld(ClientWorldManager manager)
        {
            Manager = manager;
        }

        public ClientWorldManager Manager { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public ClientWorldTile GetTile(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}