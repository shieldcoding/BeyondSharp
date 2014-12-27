#region Usings

using System.IO;
using CommandLine;
using Newtonsoft.Json;

#endregion

namespace BeyondSharp.Client
{
    public static class ClientProgram
    {
        public static ClientProgramConfiguration Configuration { get; private set; }
        public static ClientEngine Engine { get; private set; }
        public static ClientProgramOptions Options { get; private set; }

        private static bool Initialize(string[] args)
        {
            if (!ProcessCommandLine(args))
            {
                return false;
            }

            if (!ProcessConfiguration())
            {
                return false;
            }

            Engine = new ClientEngine();
            Engine.Initialize();

            return true;
        }

        public static void Main(string[] args)
        {
            if (Initialize(args))
            {
                Engine.Run();
            }

            SaveConfiguration();
        }

        private static bool ProcessCommandLine(string[] args)
        {
            return Parser.Default.ParseArguments(args, Options = new ClientProgramOptions());
        }

        private static bool ProcessConfiguration()
        {
            if (File.Exists(Options.ConfigurationPath))
            {
                var configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ClientProgramConfiguration>(configurationData);
            }
            else
            {
                Configuration = new ClientProgramConfiguration();
            }

            SaveConfiguration();
            return true;
        }

        private static void SaveConfiguration()
        {
            var configurationData = JsonConvert.SerializeObject(Configuration, Formatting.Indented);

            File.WriteAllText(Options.ConfigurationPath, configurationData);
        }
    }
}