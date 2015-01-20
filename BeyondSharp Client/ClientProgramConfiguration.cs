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

        #region Nested type: GraphicsConfiguration

        public class GraphicsConfiguration
        {
            private const int DefaultHeight = 600;
            private const VSyncMode DefaultVSyncMode = VSyncMode.On;
            private const int DefaultWidth = 800;
            public const WindowState DefaultWindowState = WindowState.Normal;

            internal GraphicsConfiguration()
            {
                Width = DefaultWidth;
                Height = DefaultHeight;
                VSyncMode = DefaultVSyncMode;
                WindowState = DefaultWindowState;
            }

            [JsonProperty]
            public int Height { get; set; }

            [JsonProperty]
            public VSyncMode VSyncMode { get; set; }

            [JsonProperty]
            public int Width { get; set; }

            [JsonProperty]
            public WindowState WindowState { get; set; }
        }

        #endregion
    }
}