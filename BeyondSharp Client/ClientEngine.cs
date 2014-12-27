#region Usings

using System;
using BeyondSharp.Client.Display;
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

        internal DisplayManager DisplayManager { get; private set; }
        internal InputManager InputManager { get; private set; }
        internal ClientNetworkManager NetworkManager { get; private set; }

        internal void Initialize()
        {
            InitializeDisplay();

            InitializeComponents();
        }

        private bool InitializeComponents()
        {
            NetworkManager.Initialize();
            InputManager.Initialize();

            return true;
        }

        private bool InitializeDisplay()
        {
            DisplayManager = new DisplayManager();
            DisplayManager.Initialize();

            DisplayManager.UpdateFrame += (sender, args) => UpdateFrame(TimeSpan.FromSeconds(args.Time));
            DisplayManager.RenderFrame += (sender, args) => RenderFrame(TimeSpan.FromSeconds(args.Time));

            return true;
        }

        private void RenderFrame(TimeSpan elapsedTime)
        {
        }

        internal void Run()
        {
        }

        private void UpdateFrame(TimeSpan elapsedTime)
        {
            NetworkManager.Update(elapsedTime);

            InputManager.Update(elapsedTime);
        }
    }
}