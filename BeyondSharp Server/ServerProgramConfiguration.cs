#region Usings

using System.ComponentModel;
using System.Net;
using BeyondSharp.Common.Network;
using Newtonsoft.Json;

#endregion

namespace BeyondSharp.Server
{
    public class ServerProgramConfiguration
    {
        public ServerProgramConfiguration()
        {
            Runtime = new RuntimeConfiguration();
            Network = new NetworkConfiguration();
        }

        public NetworkConfiguration Network { get; private set; }
        public RuntimeConfiguration Runtime { get; private set; }

        internal bool Validate()
        {
            return Runtime.Validate() && Network.Validate();
        }

        #region Nested type: NetworkConfiguration

        public class NetworkConfiguration
        {
            public NetworkConfiguration()
            {
                Address = IPAddress.Any.ToString();
                Port = NetworkConstants.DefaultPort;
                MaximumConnections = NetworkConstants.DefaultMaximumConnections;
            }

            [JsonProperty]
            public string Address { get; private set; }

            [JsonProperty]
            [DefaultValue(NetworkConstants.DefaultMaximumConnections)]
            public int MaximumConnections { get; private set; }

            [JsonProperty]
            [DefaultValue(NetworkConstants.DefaultPort)]
            public int Port { get; private set; }

            internal bool Validate()
            {
                if (Port <= 0)
                    Port = NetworkConstants.DefaultPort;

                if (MaximumConnections <= 0)
                    MaximumConnections = NetworkConstants.DefaultMaximumConnections;

                return true;
            }
        }

        #endregion

        #region Nested type: RuntimeConfiguration

        public class RuntimeConfiguration
        {
            private const string DefaultApplicationDirectory = "Runtime";
            private const string DefaultApplicationFile = "";
            private const string DefaultDataDirectory = "Runtime Data";

            public RuntimeConfiguration()
            {
                ApplicationDirectory = DefaultApplicationDirectory;
                ApplicationFile = DefaultApplicationFile;
                DataDirectory = DefaultDataDirectory;
            }

            [JsonProperty]
            [DefaultValue(DefaultApplicationDirectory)]
            public string ApplicationDirectory { get; private set; }

            [JsonProperty]
            [DefaultValue(DefaultApplicationFile)]
            public string ApplicationFile { get; private set; }

            [JsonProperty]
            [DefaultValue(DefaultDataDirectory)]
            public string DataDirectory { get; private set; }

            internal bool Validate()
            {
                if (string.IsNullOrEmpty(ApplicationDirectory))
                    ApplicationDirectory = DefaultApplicationDirectory;

                if (string.IsNullOrEmpty(ApplicationFile))
                    ApplicationFile = DefaultApplicationFile;

                if (string.IsNullOrEmpty(DataDirectory))
                    DataDirectory = DefaultDataDirectory;

                return true;
            }
        }

        #endregion
    }
}