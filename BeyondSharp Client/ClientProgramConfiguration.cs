namespace BeyondSharp.Client
{
    using Newtonsoft.Json;

    using OpenTK;

    public class ClientProgramConfiguration
    {
        internal ClientProgramConfiguration()
        {
            Graphics = new GraphicsConfiguration();
        }

        public GraphicsConfiguration Graphics { get; private set; }

        public class GraphicsConfiguration
        {
            private const int DefaultWidth = 800;

            private const int DefaultHeight = 600;

            private const VSyncMode DefaultVSyncMode = VSyncMode.On;

            internal GraphicsConfiguration()
            {
                Width = DefaultWidth;
                Height = DefaultHeight;
                VSync = DefaultVSyncMode;
            }

            [JsonProperty]
            public int Width { get; set; }

            [JsonProperty]
            public int Height { get; set; }

            [JsonProperty]
            public VSyncMode VSync { get; set; }
        }
    }
}