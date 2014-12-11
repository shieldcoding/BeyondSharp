// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientProgramOptions.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client program options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client
{
    using CommandLine;

    /// <summary>
    /// The client program options.
    /// </summary>
    public class ClientProgramOptions
    {
        #region Constants

        /// <summary>
        /// The default path to the client's configuration file, relative to the client's installation directory.
        /// </summary>
        private const string DefaultConfigurationPath = "client_configuration.json";

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