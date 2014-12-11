// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerProgram.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    using CommandLineParser = CommandLine.Parser;

    /// <summary>
    /// The server program.
    /// </summary>
    public static class ServerProgram
    {
        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public static ServerProgramConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the engine.
        /// </summary>
        public static ServerEngine Engine { get; private set; }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public static ServerProgramOptions Options { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        public static void Main(string[] arguments)
        {
            if (ProcessCommandLine(arguments))
            {
                Console.WriteLine(Localization.Engine.ProcessedCommandLine);

                if (ProcessConfiguration())
                {
                    Console.WriteLine(Localization.Engine.ProcessedConfiguration);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The process command line.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool ProcessCommandLine(string[] arguments)
        {
            Console.WriteLine(Localization.Engine.ReadingCommandLine);
            return CommandLineParser.Default.ParseArguments(arguments, Options = new ServerProgramOptions());
        }

        /// <summary>
        /// The process configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        #endregion
    }
}