#region Usings

using CommandLine;

#endregion

namespace BeyondSharp.Client
{
    public class ClientProgramOptions
    {
        private const string DefaultConfigurationPath = "client_configuration.json";

        [Option('c', "configuration", DefaultValue = DefaultConfigurationPath)]
        public string ConfigurationPath { get; set; }
    }
}