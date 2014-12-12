namespace BeyondSharp.Client.World
{
    using BeyondSharp.Common.World;

    public class ClientWorld : IWorld
    {
        internal ClientWorld(ClientWorldManager manager)
        {
            Manager = manager;
        }

        public ClientWorldManager Manager { get; private set; }
    }
}