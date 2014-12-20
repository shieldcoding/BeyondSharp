namespace BeyondSharp.Server
{
    using System;
    using System.IO;
    using System.Security;
    using System.Security.Permissions;
    using System.Threading;
    using System.Threading.Tasks;

    using BeyondSharp.Common;
    using BeyondSharp.Server.Game.Object;
    using BeyondSharp.Server.Network;

    public class ServerEngine : Engine<ServerEngineComponent>
    {
        private const string RuntimeDomainFriendlyName = "BeyondSharp Runtime Domain";

        private AppDomain runtimeDomain = null;

        private CancellationTokenSource runtimeCancellationTokenSource = null;
        
        private Task runtimeTask = null;

        internal ServerEngine()
        {
            Side = EngineSide.Server;
        }

        public ServerNetworkManager NetworkManager { get; private set; }

        public EntityManager EntityManager { get; private set; }

        public bool IsRuntimeActive { get; private set; }
        
        internal void Initialize()
        {
            NetworkManager = new ServerNetworkManager(this);
            EntityManager = new EntityManager(this);
        }

        internal void Run()
        {
            while (ServerProgram.State == ServerProgramState.Running)
            {
                runtimeCancellationTokenSource = new CancellationTokenSource();

                runtimeTask = Task.Factory.StartNew(() => StartRuntime(), runtimeCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                runtimeTask.Wait();
            }
        }
        
        private bool StartRuntime()
        {
            if (!LoadRuntime())
                return false;

            runtimeDomain.GetAssemblies();

            return true;
        }


        private bool LoadRuntime()
        {
            if (!UnloadRuntime())
                return false;
            
            var runtimeDomainSetup = new AppDomainSetup
                {
                    ApplicationBase = Path.GetFullPath(ServerProgram.Configuration.Runtime.ApplicationBase)
                };

            var runtimeDomainPermissions = new PermissionSet(PermissionState.Unrestricted);

            if (ServerProgram.Configuration.Runtime.RestrictRuntimeDomain)
            {
                runtimeDomainPermissions = new PermissionSet(PermissionState.None);

                var executionPermission = new SecurityPermission(SecurityPermissionFlag.Execution);
                runtimeDomainPermissions.AddPermission(executionPermission);

                var dataDirectoryPermission = new FileIOPermission(FileIOPermissionAccess.AllAccess, Path.GetFullPath(ServerProgram.Configuration.Runtime.RuntimeDataDirectory));
                runtimeDomainPermissions.AddPermission(dataDirectoryPermission);
            }

            runtimeDomain = AppDomain.CreateDomain(RuntimeDomainFriendlyName, null, runtimeDomainSetup, runtimeDomainPermissions);

            return true;
        }

        private bool UnloadRuntime()
        {
            if (runtimeDomain == null)
                return true;

            if (!UnloadRuntimeDomain())
                return false;

            runtimeDomain = null;

            return true;
        }
        
        private bool UnloadRuntimeDomain()
        {
            if (runtimeDomain == null)
                return false;

            try
            {
                AppDomain.Unload(runtimeDomain);
            }
            catch (CannotUnloadAppDomainException)
            {
                return false;
            }

            return true;
        }

        private void ExecuteRuntimeUpdateLoop()
        {
            var lastUpdate = DateTime.Now;

            while (ServerProgram.State == ServerProgramState.Running && !runtimeCancellationTokenSource.IsCancellationRequested)
            {
                var elapsedTime = DateTime.Now - lastUpdate;


                lastUpdate = DateTime.Now;
            }
        }

        public void StopRuntime()
        {
        }



        /*


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
        }*/
    }
}