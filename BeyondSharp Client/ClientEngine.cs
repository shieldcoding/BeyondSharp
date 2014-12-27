namespace BeyondSharp.Client
{
    using System;
    using System.Drawing;

    using BeyondSharp.Client.Display;
    using BeyondSharp.Client.Game;
    using BeyondSharp.Client.Input;
    using BeyondSharp.Client.Network;
    using BeyondSharp.Common;

    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    public class ClientEngine : Engine<ClientEngineComponent>
    {
        internal ClientEngine()
        {
            Side = EngineSide.Client;
        }

        internal DisplayManager DisplayManager { get; private set; }

        internal ClientNetworkManager NetworkManager { get; private set; }

        internal InputManager InputManager { get; private set; }
        
        internal void Initialize()
        {

            NetworkManager = new ClientNetworkManager(this);
            InputManager = new InputManager(this);

            NetworkManager.Initialize();
            InputManager.Initialize();
        }

        private bool InitializeDisplay()
        {
            DisplayManager = new DisplayManager();
            DisplayManager.Initialize();

            DisplayManager.UpdateFrame += (sender, args) => UpdateFrame(TimeSpan.FromSeconds(args.Time));
            DisplayManager.RenderFrame += (sender, args) => RenderFrame(TimeSpan.FromSeconds(args.Time));

            return true;
        }

        private bool InitializeComponents()
        {
            return true;
        }

        internal void Run()
        {
            try
            {
                Window.Run();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Window.Dispose();
                Window = null;
            }
        }

        private void UpdateFrame(TimeSpan elapsedTime)
        {
            NetworkManager.Update(elapsedTime);

            InputManager.Update(elapsedTime);
        }

        private void RenderFrame(TimeSpan elapsedTime)
        {
            GL.ClearColor(Color.AliceBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Window.SwapBuffers();
        }
    }
}