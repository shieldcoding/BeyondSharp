﻿#region Usings

using System;

#endregion

namespace BeyondSharp.Client.Input
{
    public class InputManager : ClientEngineComponent
    {
        public InputManager(ClientEngine engine)
            : base(engine)
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