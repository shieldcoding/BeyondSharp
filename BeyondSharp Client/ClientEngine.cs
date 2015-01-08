#region Usings

using System;
using System.Runtime.Remoting.Channels;
using BeyondSharp.Client.Display;
using BeyondSharp.Client.Game;
using BeyondSharp.Client.Input;
using BeyondSharp.Client.Network;
using BeyondSharp.Common;

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
        
        internal void Run()
        {
            GameManager.RenderFrame += (sender, args) => OnRenderFrame(TimeSpan.FromSeconds(args.Time));
            GameManager.UpdateFrame += (sender, args) => OnUpdateFrame(TimeSpan.FromSeconds(args.Time));
            GameManager.Run();
        }


        private void OnUpdateFrame(TimeSpan elapsedTime)
        {

            NetworkManager.Update(elapsedTime);

            InputManager.Update(elapsedTime);
        }

        private void OnRenderFrame(TimeSpan elapsedTime)
        {

        }

    }
}