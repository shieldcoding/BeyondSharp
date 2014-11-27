using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerProgramOptions
    {
        private const string DEFAULT_CONFIGURATION_PATH = "server_configuration.json";

        [Option('c', "configuration", DefaultValue = DEFAULT_CONFIGURATION_PATH)]
        public string ConfigurationPath { get; set; }
    }
}
