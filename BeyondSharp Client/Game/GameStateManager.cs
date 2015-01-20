using System;

namespace BeyondSharp.Client.Game
{
    public class GameStateManager : ClientEngineComponent
    {
        public GameStateManager(ClientEngine engine)
            : base(engine)
        {
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdateFrame(TimeSpan elapsedTime)
        {
            throw new NotSupportedException();
        }

        internal override void OnRenderFrame(TimeSpan elapsedTime)
        {
            throw new NotSupportedException();
        }
    }
}