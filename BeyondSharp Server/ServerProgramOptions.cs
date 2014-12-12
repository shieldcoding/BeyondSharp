namespace BeyondSharp.Server
{
    using CommandLine;

    public class ServerProgramOptions
    {
        private const string DEFAULT_CONFIGURATION_PATH = "server_configuration.json";

        [Option('c', "configuration", DefaultValue = DEFAULT_CONFIGURATION_PATH)]
        public string ConfigurationPath { get; set; }
    }
}