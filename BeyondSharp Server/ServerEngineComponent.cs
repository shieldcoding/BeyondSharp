namespace BeyondSharp.Server
{
    using System;

    using BeyondSharp.Common;

    public abstract class ServerEngineComponent : IEngineComponent
    {
        public const bool IsUpdateEnabledByDefault = true;

        public ServerEngineComponent(ServerEngine engine)
        {
            Engine = engine;

            IsUpdateEnabled = IsUpdateEnabledByDefault;
        }

        public ServerEngine Engine { get; private set; }

        public bool IsUpdateEnabled { get; protected set; }

        public abstract void Initialize();

        protected virtual void OnRuntimeReset()
        {
        }

        public abstract void Update(TimeSpan elapsedTime);
    }
}