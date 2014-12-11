// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerProgramOptions.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server program options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server
{
    using CommandLine;

    /// <summary>
    /// The server program options.
    /// </summary>
    public class ServerProgramOptions
    {
        #region Constants

        /// <summary>
        /// The default path to the server's configuration file, relative to the server's installation directory.
        /// </summary>
        private const string DefaultConfigurationPath = "server_configuration.json";

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the configuration path.
        /// </summary>
        [Option('c', "configuration", DefaultValue = DefaultConfigurationPath)]
        public string ConfigurationPath { get; set; }

        #endregion
    }
}