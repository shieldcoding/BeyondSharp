using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineParser = CommandLine.Parser;

namespace BeyondSharp.Server
{
    public static class ServerProgram
    {
        public static ServerEngine Engine { get; private set; }

        public static ServerProgramConfiguration Configuration { get; private set; }

        public static ServerProgramOptions Options { get; private set; }

        public static void Main(string[] arguments)
        {
            if (ProcessCommandLine(arguments))
            {
                if (ProcessConfiguration())
                {

                }
            }
        }

        private static bool ProcessCommandLine(string[] arguments)
        {
            Console.WriteLine(Localization.Strings.ProgramReadingCommandLine);
            return CommandLineParser.Default.ParseArguments(arguments, Options = new ServerProgramOptions());
        }

        private static bool ProcessConfiguration()
        {
            string configurationData = null;

            if (File.Exists(Options.ConfigurationPath))
            {
                Console.WriteLine(Localization.Strings.ProgramReadingConfiguration);

                configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ServerProgramConfiguration>(configurationData);
            }
            else
            {
                Console.WriteLine(Localization.Strings.ProgramNoConfiguration);

                Configuration = new ServerProgramConfiguration();
            }

            Console.WriteLine(Localization.Strings.ProgramSavingConfiguration);

            configurationData = JsonConvert.SerializeObject(Configuration);
            File.WriteAllText(Options.ConfigurationPath, configurationData);

            return true;
        }
    }
}
