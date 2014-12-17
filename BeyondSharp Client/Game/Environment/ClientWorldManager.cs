namespace BeyondSharp.Client.Game.Environment
{
    using System;

    using BeyondSharp.Common.Game.Environment;

    public class ClientWorldManager : ClientEngineComponent, IWorldManager<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        public ClientWorldManager(ClientEngine engine)
            : base(engine)
        {
        }

        public ClientWorld World { get; private set; }

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