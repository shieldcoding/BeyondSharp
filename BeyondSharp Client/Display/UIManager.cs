using System;

namespace BeyondSharp.Client.Display
{
    public class UIManager : ClientEngineComponent
    {
        public UIManager(ClientEngine engine) : base(engine)
        {
        }

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