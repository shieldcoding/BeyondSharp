#region Usings

using System;
using BeyondSharp.Client.Game;
using BeyondSharp.Client.Input;
using BeyondSharp.Client.Network;
using BeyondSharp.Common;
using OpenTK;

#endregion

namespace BeyondSharp.Client
{
    public class ClientEngine : Engine<ClientEngineComponent>
    {
        internal ClientEngine()
        {
            Side = EngineSide.Client;

            NetworkManager = new ClientNetworkManager(this);
            InputManager = new InputManager(this);
        }

        internal GameManager GameManager { get; private set; }
        internal InputManager InputManager { get; private set; }
        internal ClientNetworkManager NetworkManager { get; private set; }

        internal bool Initialize()
        {
            if (!InitializeCore())
            {
                return false;
            }

            if (!InitializeComponents())
            {
                return false;
            }

            return true;
        }

        internal void Run()
        {
            GameManager.RenderFrame += UpdateFrame;
            GameManager.UpdateFrame += RenderFrame;
            GameManager.Run();
        }

        private bool InitializeComponents()
        {
            try
            {
                NetworkManager.Initialize();
                InputManager.Initialize();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool InitializeCore()
        {
            try
            {
                GameManager = new GameManager();
                GameManager.Initialize();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void OnRenderFrame(TimeSpan elapsedTime)
        {
        }

        private void OnUpdateFrame(TimeSpan elapsedTime)
        {
            NetworkManager.UpdateFrame(elapsedTime);

            InputManager.UpdateFrame(elapsedTime);
        }

        private void RenderFrame(object sender, FrameEventArgs args)
        {
            OnRenderFrame(TimeSpan.FromSeconds(args.Time));
        }

        private void UpdateFrame(object sender, FrameEventArgs args)
        {
            OnUpdateFrame(TimeSpan.FromSeconds(args.Time));
        }
    }
}