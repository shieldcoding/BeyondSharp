#region Usings

using System;
using BeyondSharp.Common.Game.Map;

#endregion

namespace BeyondSharp.Client.Game.Map
{
    public class ClientWorldManager : ClientEngineComponent,
        IWorldManager<ClientWorldManager, ClientWorld, ClientWorldTile>
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