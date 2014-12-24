namespace BeyondSharp.Server
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security;
    using System.Security.Permissions;
    using System.Threading;
    using System.Threading.Tasks;
    using BeyondSharp.Common;
    using BeyondSharp.Server.Game;
    using BeyondSharp.Server.Game.Object;
    using BeyondSharp.Server.Network;

    public class ServerEngine : Engine<ServerEngineComponent>
    {
        private const string RuntimeDomainFriendlyName = "BeyondSharp Runtime Domain";

        private CancellationTokenSource runtimeCancellationTokenSource = null;
        
        private Task runtimeTask = null;

        internal ServerEngine()
        {
            Side = EngineSide.Server;
        }

        public ServerNetworkManager NetworkManager { get; private set; }

        public EntityManager EntityManager { get; private set; }

        public ApplicationRuntime Runtime { get; private set; }

        public bool IsRuntimeActive { get; private set; }
        
        internal bool Initialize()
        {
            NetworkManager = new ServerNetworkManager(this);
            EntityManager = new EntityManager(this);

            return LoadRuntime();
        }

        private bool LoadRuntime()
        {
            var runtimePath = Path.Combine(ServerProgram.Configuration.Runtime.ApplicationDirectory, ServerProgram.Configuration.Runtime.ApplicationFile);

            if (!File.Exists(runtimePath))
            {
                ServerProgram.Logger.Fatal(Localization.Engine.ApplicationFileNotFound);
                return false;
            }

            try
            {
                var assemblyData = File.ReadAllBytes(runtimePath);
                var assembly = AppDomain.CurrentDomain.Load(assemblyData);

                var runtimeCandidates = assembly.GetTypes()
                    .Where(t => typeof(ApplicationRuntime).IsAssignableFrom(t))
                    .Where(t => !t.IsAbstract && t.IsPublic)
                    .ToList();

                if (runtimeCandidates.Count == 0)
                {
                    ServerProgram.Logger.Fatal(Localization.Engine.ApplicationFileNoRuntime);
                    return false;
                }

                if (runtimeCandidates.Count > 1)
                {
                    ServerProgram.Logger.Warn(Localization.Engine.ApplicationFileMultipleRuntimes);
                }

                var runtimeType = runtimeCandidates.First();
                Runtime = (ApplicationRuntime) Activator.CreateInstance(runtimeType);

                return true;
            }
            catch (BadImageFormatException)
            {
                ServerProgram.Logger.Fatal(Localization.Engine.ApplicationFileInvalid);
            }

            return false;
        }

        internal void Run()
        {
            runtimeCancellationTokenSource = new CancellationTokenSource();

            runtimeTask = Task.Factory.StartNew(ExecuteRuntimeUpdateLoop, runtimeCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            runtimeTask.Wait();
        }

        private void ExecuteRuntimeUpdateLoop()
        {
            Runtime.Initialize();

            var lastUpdate = DateTime.Now;
            while (ServerProgram.State == ServerProgramState.Running && !runtimeCancellationTokenSource.IsCancellationRequested)
            {
                var elapsedTime = DateTime.Now - lastUpdate;


                lastUpdate = DateTime.Now;
            }
        }

        public void StopRuntime()
        {
            if (runtimeCancellationTokenSource != null && !runtimeCancellationTokenSource.IsCancellationRequested)
            {
                runtimeCancellationTokenSource.Cancel();
            }
        }
    }
}