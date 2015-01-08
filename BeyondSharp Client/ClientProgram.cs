#region Usings

using System;
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

            if (!InitializeEngine())
            {
                return false;
            }

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
            try
            {
                var configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ClientProgramConfiguration>(configurationData);
            }
            catch (Exception)
            {
                Configuration = null;
            }

            if (Configuration == null)
            {
                Configuration = new ClientProgramConfiguration();
            }

            SaveConfiguration();
            return true;
        }

        private static bool InitializeEngine()
        {
            try
            {
                Engine = new ClientEngine();
                Engine.Initialize();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void SaveConfiguration()
        {
            var configurationData = JsonConvert.SerializeObject(Configuration, Formatting.Indented);

            File.WriteAllText(Options.ConfigurationPath, configurationData);
        }
    }
}