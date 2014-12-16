namespace BeyondSharp.Client
{
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
        }

        internal void Run()
        {
            using (Window = new GameWindow(ClientProgram.Configuration.Graphics.Width, ClientProgram.Configuration.Graphics.Height))
            {
                Window.Run();
            }
        }
    }
}