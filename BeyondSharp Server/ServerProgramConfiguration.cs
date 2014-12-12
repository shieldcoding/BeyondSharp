namespace BeyondSharp.Server
{
    using System.ComponentModel;
    using System.Net;

    using BeyondSharp.Common.Network;

    using Newtonsoft.Json;

    public class ServerProgramConfiguration
    {
        public ServerProgramConfiguration()
        {
            Runtime = new RuntimeConfiguration();
            Network = new NetworkConfiguration();
        }

        public RuntimeConfiguration Runtime { get; private set; }

        public NetworkConfiguration Network { get; private set; }

        public class RuntimeConfiguration
        {
            public RuntimeConfiguration()
            {
                Path = ServerConstants.DefaultRuntimePath;
            }

            [JsonProperty]
            [DefaultValue(ServerConstants.DefaultRuntimePath)]
            public string Path { get; private set; }
        }

        public class NetworkConfiguration
        {
            public NetworkConfiguration()
            {
                Address = IPAddress.Any.ToString();
                Port = CommonNetworkConstants.DefaultPort;
                MaximumConnections = CommonNetworkConstants.DefaultMaximumConnections;
            }

            [JsonProperty]
            public string Address { get; private set; }

            [JsonProperty]
            [DefaultValue(CommonNetworkConstants.DefaultPort)]
            public int Port { get; private set; }

            [JsonProperty]
            [DefaultValue(CommonNetworkConstants.DefaultMaximumConnections)]
            public int MaximumConnections { get; private set; }
        }
    }
}