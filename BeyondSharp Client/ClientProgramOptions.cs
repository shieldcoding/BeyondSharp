using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    public class ClientProgramOptions
    {
        private const string DEFAULT_CONFIGURATION_PATH = "client_configuration.json";

        [Option('c', "configuration", DefaultValue = DEFAULT_CONFIGURATION_PATH)]
        public string ConfigurationPath { get; set; }
    }
}
