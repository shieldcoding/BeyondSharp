﻿using CommandLineParser = CommandLine.Parser;

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

            SaveConfiguration();

            // ReSharper disable once InvertIf
            if (Options.PauseOnExit)
            {
                Console.WriteLine(Localization.Engine.PauseOnExit);
                Console.ReadKey();
            }
            
            Console.Write(Localization.Engine.Exit);
        }

        private static bool Initialize(string[] args)
        {
            if (!ProcessCommandLine(args))
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

        private static bool ProcessCommandLine(string[] args)
        {
            Console.WriteLine(Localization.Engine.ReadingCommandLine);
            return CommandLineParser.Default.ParseArguments(args, Options = new ServerProgramOptions());
        }

        private static bool ProcessConfiguration()
        {
            if (File.Exists(Options.ConfigurationPath))
            {
                Console.WriteLine(Localization.Engine.ReadingConfiguration);

                var configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ServerProgramConfiguration>(configurationData);
            }
            else
            {
                Console.WriteLine(Localization.Engine.NoConfiguration);

                Configuration = new ServerProgramConfiguration();
            }

            SaveConfiguration();

            return true;
        }

        private static void SaveConfiguration()
        {
            Console.WriteLine(Localization.Engine.SavingConfiguration);

            var configurationData = JsonConvert.SerializeObject(Configuration);
            File.WriteAllText(Options.ConfigurationPath, configurationData);
        }
    }
}