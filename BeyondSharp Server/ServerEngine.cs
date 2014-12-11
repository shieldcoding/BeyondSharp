// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEngine.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server
{
    using System;
    using System.Security;
    using System.Security.Permissions;

    using BeyondSharp.Common;
    using BeyondSharp.Server.Entity;
    using BeyondSharp.Server.Network;

    /// <summary>
    /// The server engine.
    /// </summary>
    public class ServerEngine : Engine<ServerEngineComponent>
    {
        #region Constants

        /// <summary>
        /// The friendly name of the runtime's application domain.
        /// </summary>
        private const string RuntimeDomainFriendlyName = "BeyondSharp Runtime Domain";

        #endregion

        /// <summary>
        /// Indicates that this engine is operating as a client.
        /// </summary>
        public override EngineSide Side
        {
            get { return EngineSide.Server; }
        }

        #region Public Properties

        /// <summary>
        /// Gets the entity manager.
        /// </summary>
        public ServerEntityManager EntityManager { get; private set; }

        /// <summary>
        /// Gets the network manager.
        /// </summary>
        public ServerNetworkManager NetworkManager { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether is runtime active.
        /// </summary>
        internal bool IsRuntimeActive { get; private set; }

        /// <summary>
        /// Gets the runtime domain.
        /// </summary>
        internal AppDomain RuntimeDomain { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the runtime into the application domain.
        /// </summary>
        internal void LoadRuntime()
        {
            // The runtime has to be inactive before we can load it.
            if (this.IsRuntimeActive)
            {
                throw new Exception(string.Empty);
            }

            // Creating the runtime security permissions.
            var permissions = new PermissionSet(PermissionState.None);

            var setup = new AppDomainSetup();
            setup.ApplicationBase = ServerProgram.Configuration.Runtime.Path;

            // Creating the runtime domain.
            this.RuntimeDomain = AppDomain.CreateDomain(RuntimeDomainFriendlyName);
        }

        /// <summary>
        /// Stops and restarts all engine components, clearing out the runtime in the process before reloading it.
        /// </summary>
        internal void ResetPlatform()
        {
            if (this.IsRuntimeActive)
            {
                this.UnloadRuntime();
            }

            this.LoadRuntime();
        }

        /// <summary>
        /// The unload runtime.
        /// </summary>
        internal void UnloadRuntime()
        {
            AppDomain.Unload(this.RuntimeDomain);
        }

        #endregion
    }
}