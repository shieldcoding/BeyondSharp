#region Usings

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BeyondSharp.Server.Localization;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using CommandLineParser = CommandLine.Parser;

#endregion

namespace BeyondSharp.Server
{
    public static class ServerProgram
    {
        private const string DefaultServerLogger = "DefaultServerLogger";
        private static CancellationTokenSource serverProgramCancellationTokenSource;
        private static Task serverProgramTask;
        public static ServerProgramConfiguration Configuration { get; private set; }
        public static ServerEngine Engine { get; private set; }
        public static ILog Logger { get; private set; }
        public static ServerProgramOptions Options { get; private set; }
        public static ServerProgramState State { get; private set; }

        public static void Main(string[] arguments)
        {
            State = ServerProgramState.New;

            if (Initialize(arguments))
            {
                State = ServerProgramState.Running;

                serverProgramCancellationTokenSource = new CancellationTokenSource();

                serverProgramTask = Task.Factory.StartNew(() => Engine.Run(), serverProgramCancellationTokenSource.Token,
                    TaskCreationOptions.LongRunning, TaskScheduler.Default);
                serverProgramTask.Wait();

                State = ServerProgramState.Stopped;
            }

            SaveConfiguration();

            // ReSharper disable once InvertIf
            if (Options.PauseOnExit)
            {
                Console.WriteLine(Program.PauseOnExit);
                Console.ReadKey();
            }

            Console.Write(Program.Exit);
        }

        private static bool Initialize(string[] args)
        {
            State = ServerProgramState.Initializing;

            if (!ProcessCommandLine(args))
            {
                return false;
            }

            Console.WriteLine(Program.ProcessedCommandLine);

            if (!ProcessConfiguration())
            {
                return false;
            }

            Console.WriteLine(Program.ProcessedConfiguration);

            XmlConfigurator.Configure();

            Logger = LogManager.GetLogger(DefaultServerLogger);
            Logger.Info(Program.LoggerStarted);

            Engine = new ServerEngine();
            if (!Engine.Initialize())
                return false;

            State = ServerProgramState.Initialized;
            return true;
        }

        private static bool ProcessCommandLine(string[] args)
        {
            Console.WriteLine(Program.ReadingCommandLine);
            return CommandLineParser.Default.ParseArguments(args, Options = new ServerProgramOptions());
        }

        private static bool ProcessConfiguration()
        {
            if (File.Exists(Options.ConfigurationPath))
            {
                Console.WriteLine(Program.ReadingConfiguration);

                var configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ServerProgramConfiguration>(configurationData);
            }
            else
            {
                Console.WriteLine(Program.NoConfiguration);

                Configuration = new ServerProgramConfiguration();
            }

            try
            {
                if (!File.Exists(Options.ConfigurationPath))
                {
                    throw new FileNotFoundException();
                }

                var configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ServerProgramConfiguration>(configurationData);
            }
            catch (Exception)
            {
                Configuration = null;
            }

            if (Configuration == null)
            {
                Configuration = new ServerProgramConfiguration();
            }

            Configuration.Validate();
            SaveConfiguration();

            return true;
        }

        private static void SaveConfiguration()
        {
            Console.WriteLine(Program.SavingConfiguration);

            var configurationData = JsonConvert.SerializeObject(Configuration, Formatting.Indented);
            File.WriteAllText(Options.ConfigurationPath, configurationData);
        }

        public static void Stop()
        {
            if (serverProgramCancellationTokenSource != null &&
                !serverProgramCancellationTokenSource.IsCancellationRequested)
                serverProgramCancellationTokenSource.Cancel();
        }
    }
}