using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    public static class ClientProgram
    {
        public static ClientEngine Engine { get; private set; }

        public static ClientProgramConfiguration Configuration { get; private set; }

        public static ClientProgramOptions Options { get; private set; }

        public static void Main(string[] args)
        {
        }

        private static bool ProcessCommandLine(string[] arguments)
        { return CommandLine.Parser.Default.ParseArguments(arguments, Options = new ClientProgramOptions()); }

        private static bool ProcessConfiguration()
        {
            string configurationData = null;

            if (File.Exists(Options.ConfigurationPath))
            {
                configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ClientProgramConfiguration>(configurationData);
            }
            else
                Configuration = new ClientProgramConfiguration();

            configurationData = JsonConvert.SerializeObject(Configuration);
            File.WriteAllText(Options.ConfigurationPath, configurationData);

            return true;
        }
    }
}
