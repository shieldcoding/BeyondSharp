namespace BeyondSharp.Server
{
    using CommandLine;

    public class ServerProgramOptions
    {
        private const string DefaultConfigurationPath = "server_configuration.json";
        private const bool DefaultPauseOnExit = true;

        [Option('c', "configuration", DefaultValue = DefaultConfigurationPath)]
        public string ConfigurationPath { get; set; }

        [Option('p', "pause", DefaultValue = DefaultPauseOnExit)]
        public bool PauseOnExit { get; set; }
    }
}