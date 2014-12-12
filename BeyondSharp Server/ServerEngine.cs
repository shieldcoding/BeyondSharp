using BeyondSharp.Common;
using BeyondSharp.Server.Entity;
using BeyondSharp.Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public class ServerEngine : Engine<ServerEngineComponent>
    {
        private const string RUNTIME_DOMAIN_FRIENDLY_NAME = "BeyondSharp Runtime Domain";

        public ServerNetworkManager NetworkManager { get; private set; }

        public ServerEntityManager EntityManager { get; private set; }

        internal AppDomain RuntimeDomain { get; private set; }

        internal bool IsRuntimeActive { get; private set; }

        internal ServerEngine()
        {
            Side = EngineSide.Server;
        }

        /// <summary>
        /// Stops and restarts all engine components, clearing out the runtime in the process before reloading it.
        /// </summary>
        internal void ResetPlatform()
        {

            if (IsRuntimeActive)
                UnloadRuntime();

            LoadRuntime();
        }


        /// <summary>
        /// Loads the runtime into the application domain.
        /// </summary>
        internal void LoadRuntime()
        {
            // The runtime has to be inactive before we can load it.
            if (IsRuntimeActive)
                throw new Exception("");

            // Creating the runtime security permissions.
            var permissions = new PermissionSet(PermissionState.None);

            var setup = new AppDomainSetup();
            setup.ApplicationBase = ServerProgram.Configuration.Runtime.Path;


            // Creating the runtime domain.
            RuntimeDomain = AppDomain.CreateDomain(RUNTIME_DOMAIN_FRIENDLY_NAME);
        }

        internal void UnloadRuntime()
        {
            AppDomain.Unload(RuntimeDomain);
        }
    }
}
