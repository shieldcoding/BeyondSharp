using CommandLineParser = CommandLine.Parser;

namespace BeyondSharp.Server
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    public static class ServerProgram
    {
        public static ServerEngine Engine { get; private set; }

        public static ServerProgramConfiguration Configuration { get; private set; }

        public static ServerProgramOptions Options { get; private set; }

        public static void Main(string[] arguments)
        {
            if (Initialize(arguments))
                Engine.Run();

            // ReSharper disable once InvertIf
            if (Options.PauseOnExit)
            {
                Console.WriteLine(Localization.Engine.PauseOnExit);
                Console.ReadKey();
            }

            Console.Write(Localization.Engine.Exit);
        }

        private static bool Initialize(string[] arguments)
        {
            if (!ProcessCommandLine(arguments))
            {
                return false;
            }

            Console.WriteLine(Localization.Engine.ProcessedCommandLine);

            if (!ProcessConfiguration())
                return false;

            Console.WriteLine(Localization.Engine.ProcessedConfiguration);

            Engine = new ServerEngine();
            Engine.Initialize();

            return true;
        }

        private static bool ProcessCommandLine(string[] arguments)
        {
            Console.WriteLine(Localization.Engine.ReadingCommandLine);
            return CommandLineParser.Default.ParseArguments(arguments, Options = new ServerProgramOptions());
        }

        private static bool ProcessConfiguration()
        {
            string configurationData = null;

            if (File.Exists(Options.ConfigurationPath))
            {
                Console.WriteLine(Localization.Engine.ReadingConfiguration);

                configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ServerProgramConfiguration>(configurationData);
            }
            else
            {
                Console.WriteLine(Localization.Engine.NoConfiguration);

                Configuration = new ServerProgramConfiguration();
            }

            Console.WriteLine(Localization.Engine.SavingConfiguration);

            configurationData = JsonConvert.SerializeObject(Configuration);
            File.WriteAllText(Options.ConfigurationPath, configurationData);

            return true;
        }
    }
}