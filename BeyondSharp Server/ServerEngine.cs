namespace BeyondSharp.Server
{
    using System;
    using System.Security;
    using System.Security.Permissions;

    using BeyondSharp.Common;
    using BeyondSharp.Server.Entity;
    using BeyondSharp.Server.Network;

    public class ServerEngine : Engine<ServerEngineComponent>
    {
        private const string RuntimeDomainFriendlyName = "BeyondSharp Runtime Domain";

        private AppDomain runtimeDomain;

        internal ServerEngine()
        {
            Side = EngineSide.Server;
        }

        public ServerNetworkManager NetworkManager { get; private set; }

        public ServerEntityManager EntityManager { get; private set; }

        public bool IsRuntimeActive { get; private set; }

        internal void Initialize()
        {
            NetworkManager = new ServerNetworkManager(this);
            EntityManager = new ServerEntityManager(this);
        }

        internal void Run()
        {
        }

        /// <summary>
        ///     Stops and restarts all engine components, clearing out the runtime in the process before reloading it.
        /// </summary>
        internal void ResetPlatform()
        {
            if (IsRuntimeActive)
            {
                UnloadRuntime();
            }

            LoadRuntime();
        }

        /// <summary>
        ///     Loads the runtime into the application domain.
        /// </summary>
        private void LoadRuntime()
        {
            // The runtime has to be inactive before we can load it.
            if (IsRuntimeActive)
            {
                throw new Exception();
            }

            // Creating the runtime security permissions.
            var permissions = new PermissionSet(PermissionState.None);

            var runtimeDomainSetup = new AppDomainSetup
                                         {
                                             ApplicationBase = ServerProgram.Configuration.Runtime.Path
                                         };

            // Creating the runtime domain.
            runtimeDomain = AppDomain.CreateDomain(RuntimeDomainFriendlyName);

            IsRuntimeActive = true;
        }

        private void UnloadRuntime()
        {
            AppDomain.Unload(runtimeDomain);
        }
    }
}