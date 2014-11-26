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
        public NetworkConfiguration Network { get; private set; }

        public class NetworkConfiguration
        {
            [JsonProperty]
            public IPAddress Address { get; set; }

            [JsonProperty]
            [DefaultValue(7777)]
            public int Port { get; set; }

            public NetworkConfiguration()
            {
                Address = IPAddress.Any;
            }
        }
    }
}
