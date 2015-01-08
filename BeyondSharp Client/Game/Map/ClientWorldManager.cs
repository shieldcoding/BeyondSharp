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

        protected override void OnUpdateFrame(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        internal override void OnRenderFrame(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}