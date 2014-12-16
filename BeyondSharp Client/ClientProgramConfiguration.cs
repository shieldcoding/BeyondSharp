namespace BeyondSharp.Client
{
    using Newtonsoft.Json;

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

            internal GraphicsConfiguration()
            {
                Width = DefaultWidth;
                Height = DefaultHeight;
            }

            [JsonProperty]
            public int Width { get; set; }

            [JsonProperty]
            public int Height { get; set; }
        }
    }
}