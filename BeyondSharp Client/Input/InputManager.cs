#region Usings

using System;
using OpenTK.Input;

#endregion

namespace BeyondSharp.Client.Input
{
    public class InputManager : ClientEngineComponent
    {
        private KeyboardState _oldKeyboardState;

        public InputManager(ClientEngine engine)
            : base(engine)
        {
        }

        public override void Initialize()
        {
            _oldKeyboardState = Keyboard.GetState();
        }

        protected override void OnUpdateFrame(TimeSpan elapsedTime)
        {
            var newKeyboardState = Keyboard.GetState();

            _oldKeyboardState = newKeyboardState;
        }

        internal override void OnRenderFrame(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}