namespace BeyondSharp.Client
{
    using System;
    using System.Drawing;

    using BeyondSharp.Common;

    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

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
            Window.VSync = ClientProgram.Configuration.Graphics.VSync;
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
            GL.ClearColor(Color.AliceBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Window.SwapBuffers();
        }

        private void RenderFrame(TimeSpan elapsedTime)
        {
        }
    }
}