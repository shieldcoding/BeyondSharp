#region Usings

using Newtonsoft.Json;
using OpenTK;

#endregion

namespace BeyondSharp.Client
{
    public class ClientProgramConfiguration
    {
        internal ClientProgramConfiguration()
        {
            Graphics = new GraphicsConfiguration();
        }

        public GraphicsConfiguration Graphics { get; private set; }

        public class GraphicsConfiguration
        {
            private const int DefaultHeight = 600;
            private const VSyncMode DefaultVSyncMode = VSyncMode.On;
            private const int DefaultWidth = 800;

            internal GraphicsConfiguration()
            {
                Width = DefaultWidth;
                Height = DefaultHeight;
                VSync = DefaultVSyncMode;
            }

            [JsonProperty]
            public int Height { get; set; }

            [JsonProperty]
            public VSyncMode VSync { get; set; }

            [JsonProperty]
            public int Width { get; set; }
        }
    }
}