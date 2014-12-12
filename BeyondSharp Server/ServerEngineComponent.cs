namespace BeyondSharp.Server
{
    using System;

    using BeyondSharp.Common;

    public abstract class ServerEngineComponent : IEngineComponent
    {
        public ServerEngineComponent(ServerEngine engine)
        {
            Engine = engine;
        }

        public ServerEngine Engine { get; private set; }

        public abstract void Initialize();

        public abstract void Update(TimeSpan elapsedTime);
    }
}