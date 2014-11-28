using BeyondSharp.Common.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerProgramConfiguration
    {
        public RuntimeConfiguration Runtime { get; private set; }

        public NetworkConfiguration Network { get; private set; }

        public ServerProgramConfiguration()
        {
            Runtime = new RuntimeConfiguration();
            Network = new NetworkConfiguration();
        }

        public class RuntimeConfiguration
        {
            [JsonProperty]
            [DefaultValue(ServerConstants.DEFAULT_RUNTIME_PATH)]
            public string Path { get; private set; }

            public RuntimeConfiguration()
            {
                Path = ServerConstants.DEFAULT_RUNTIME_PATH;
            }
        }

        public class NetworkConfiguration
        {
            [JsonProperty]
            public string Address { get; private set; }

            [JsonProperty]
            [DefaultValue(NetworkConstants.DEFAULT_PORT)]
            public int Port { get; private set; }

            [JsonProperty]
            [DefaultValue(NetworkConstants.DEFAULT_MAXIMUM_CONNECTIONS)]
            public int MaximumConnections { get; private set; }

            public NetworkConfiguration()
            {
                Address = IPAddress.Any.ToString();
                Port = NetworkConstants.DEFAULT_PORT;
                MaximumConnections = NetworkConstants.DEFAULT_MAXIMUM_CONNECTIONS;
            }
        }
    }
}
