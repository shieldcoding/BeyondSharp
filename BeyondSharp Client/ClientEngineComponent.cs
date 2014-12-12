namespace BeyondSharp.Client
{
    using System;

    using BeyondSharp.Common;

    public abstract class ClientEngineComponent : IEngineComponent
    {
        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;
        }

        public ClientEngine Engine { get; private set; }

        public abstract void Initialize();

        public abstract void Update(TimeSpan elapsedTime);
    }
}