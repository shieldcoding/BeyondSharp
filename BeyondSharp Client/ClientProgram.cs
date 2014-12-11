// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientProgram.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client
{
    using System.IO;

    using Newtonsoft.Json;

    /// <summary>
    /// The client program.
    /// </summary>
    public static class ClientProgram
    {
        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public static ClientProgramConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the engine.
        /// </summary>
        public static ClientEngine Engine { get; private set; }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public static ClientProgramOptions Options { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
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
            return CommandLine.Parser.Default.ParseArguments(arguments, Options = new ClientProgramOptions());
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
                configurationData = File.ReadAllText(Options.ConfigurationPath);
                Configuration = JsonConvert.DeserializeObject<ClientProgramConfiguration>(configurationData);
            }
            else
            {
                Configuration = new ClientProgramConfiguration();
            }

            configurationData = JsonConvert.SerializeObject(Configuration);
            File.WriteAllText(Options.ConfigurationPath, configurationData);

            return true;
        }

        #endregion
    }
}