// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonNetworkConstants.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The common network constants.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Network
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The common network constants.
    /// </summary>
    public static class CommonNetworkConstants
    {
        #region Constants

        /// <summary>
        /// The default value for the number of maximum connections the server can hold.
        /// </summary>
        public const int DefaultMaximumConnections = 80;

        /// <summary>
        /// The default value for the port that the server listens for connections on.
        /// </summary>
        public const int DefaultPort = 7777;

        /// <summary>
        /// The network identifier used by the "lidgren" networking library.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public const string Identifier = "BeyondSharp";

        /// <summary>
        /// The version of the network protocol employed by the common library.
        /// </summary>
        public const double ProtocolVersion = 0.01;

        #endregion
    }
}