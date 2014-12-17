namespace BeyondSharp.Client.Game.Environment
{
    using BeyondSharp.Common.Game.Environment;

    public class ClientWorld : IWorld<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        internal ClientWorld(ClientWorldManager manager)
        {
            Manager = manager;
        }

        public ClientWorldManager Manager { get; private set; }
    }
}