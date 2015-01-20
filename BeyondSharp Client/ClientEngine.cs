#region Usings

using System;
using BeyondSharp.Client.Game;
using BeyondSharp.Client.Input;
using BeyondSharp.Client.Network;
using BeyondSharp.Common;
using OpenTK;
using OpenTK.Graphics;

#endregion

namespace BeyondSharp.Client
{
    public class ClientEngine : GameWindow, IEngine<ClientEngineComponent>
    {
        internal ClientEngine()
            : base(
                ClientProgram.Configuration.Graphics.Width, ClientProgram.Configuration.Graphics.Height,
                GraphicsMode.Default, Localization.Client.DefaultWindowTitle)
        {
            State = ClientEngineState.Created;

            NetworkManager = new ClientNetworkManager(this);
            InputManager = new InputManager(this);
        }

        internal ClientEngineState State { get; private set; }
        internal GameStateManager GameStateManager { get; private set; }
        internal InputManager InputManager { get; private set; }
        internal ClientNetworkManager NetworkManager { get; private set; }

        public EngineSide Side
        {
            get { return EngineSide.Client; }
        }

        internal bool Initialize()
        {
            try
            {
                State = ClientEngineState.Initializing;

                InitializeComponents();

                State = ClientEngineState.Initialized;

                return true;
            }
            catch (Exception ex)
            {
                State = ClientEngineState.Error;

                CrashAndDisplayException(ex);

                return false;
            }
        }

        private void InitializeComponents()
        {
            NetworkManager.Initialize();
            InputManager.Initialize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            State = ClientEngineState.Running;
        }

        internal void CrashAndDisplayException(Exception ex)
        {
            try
            {
                Exit();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            ClientProgram.Configuration.Graphics.Width = Width;
            ClientProgram.Configuration.Graphics.Height = Height;
            ClientProgram.Configuration.Graphics.VSyncMode = VSync;
        }

        protected override void OnWindowStateChanged(EventArgs e)
        {
            base.OnWindowStateChanged(e);

            ClientProgram.Configuration.Graphics.WindowState = WindowState;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var elapsedTime = TimeSpan.FromSeconds(e.Time);

            InputManager.UpdateFrame(elapsedTime);

            base.OnUpdateFrame(e);
        }
    }
}