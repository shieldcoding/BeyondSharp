namespace BeyondSharp.Client
{
    using System;

    using BeyondSharp.Common;

    public abstract class ClientEngineComponent : IEngineComponent
    {
        private const bool IsUpdateEnabledByDefault = true;
        private const bool IsRenderEnabledByDefault = false;

        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;

            IsUpdateEnabled = IsUpdateEnabledByDefault;
            IsRenderEnabled = IsRenderEnabledByDefault;
        }

        public bool IsUpdateEnabled { get; protected set; }

        public bool IsRenderEnabled { get; protected set; }

        public ClientEngine Engine { get; private set; }

        public abstract void Initialize();

        public abstract void Update(TimeSpan elapsedTime);
    }
}