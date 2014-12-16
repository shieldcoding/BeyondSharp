namespace BeyondSharp.Client
{
    using System;
    using System.Runtime.Remoting.Channels;

    using BeyondSharp.Common;

    using OpenTK;

    public class ClientEngine : Engine<ClientEngineComponent>
    {
        internal ClientEngine()
        {
            Side = EngineSide.Client;
        }

        internal GameWindow Window { get; private set; }

        internal void Initialize()
        {
            Window = new GameWindow(ClientProgram.Configuration.Graphics.Width, ClientProgram.Configuration.Graphics.Height);
            Window.UpdateFrame += (sender, args) => UpdateFrame(TimeSpan.FromSeconds(args.Time));
            Window.RenderFrame += (sender, args) => RenderFrame(TimeSpan.FromSeconds(args.Time));
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
        }

        private void RenderFrame(TimeSpan elapsedTime)
        {
            
        }
    }
}