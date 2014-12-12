namespace BeyondSharp.Client.World
{
    using System;

    using BeyondSharp.Common.World;

    public class ClientWorldManager : ClientEngineComponent, ICommonWorldManager<ClientWorld>
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