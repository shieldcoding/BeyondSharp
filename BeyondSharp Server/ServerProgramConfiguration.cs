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

        internal bool Validate()
        {
            return Runtime.Validate() && Network.Validate();
        }

        public class RuntimeConfiguration
        {
            private const string DefaultApplicationBase = "Runtime";

            private const bool DefaultRestrictRuntimeDomain = true;

            private const string DefaultRuntimeDataDirectory = "Runtime Data";

            public RuntimeConfiguration()
            {
                ApplicationBase = DefaultApplicationBase;
                RuntimeAssembly = null;
                RestrictRuntimeDomain = DefaultRestrictRuntimeDomain;
                RuntimeDataDirectory = DefaultRuntimeDataDirectory;
            }

            [JsonProperty]
            [DefaultValue(DefaultApplicationBase)]
            public string ApplicationBase { get; private set; }

            [JsonProperty]
            public string RuntimeAssembly { get; private set; }

            [JsonProperty]
            [DefaultValue(DefaultRestrictRuntimeDomain)]
            public bool RestrictRuntimeDomain { get; private set; }

            [JsonProperty]
            [DefaultValue(DefaultRuntimeDataDirectory)]
            public string RuntimeDataDirectory { get; private set; }

            internal bool Validate()
            {
                if (string.IsNullOrEmpty(ApplicationBase))
                    ApplicationBase = DefaultApplicationBase;

                if (string.IsNullOrEmpty(RuntimeDataDirectory))
                    RuntimeDataDirectory = DefaultRuntimeDataDirectory;
                
                return true;
            }
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

            internal bool Validate()
            {
                if (Port <= 0)
                    Port = CommonNetworkConstants.DefaultPort;

                if (MaximumConnections <= 0)
                    MaximumConnections = CommonNetworkConstants.DefaultMaximumConnections;

                return true;
            }
        }
    }
}