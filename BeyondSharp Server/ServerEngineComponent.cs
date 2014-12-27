#region Usings

using System;
using BeyondSharp.Common;

#endregion

namespace BeyondSharp.Server
{
    public abstract class ServerEngineComponent : IEngineComponent
    {
        public const bool IsUpdateEnabledByDefault = true;

        public ServerEngineComponent(ServerEngine engine)
        {
            Engine = engine;

            IsUpdateEnabled = IsUpdateEnabledByDefault;
        }

        public ServerEngine Engine { get; private set; }
        public abstract void Initialize();
        public bool IsUpdateEnabled { get; protected set; }

        public void Update(TimeSpan elapsedTime)
        {
            if (IsUpdateEnabled)
                OnUpdate(elapsedTime);
        }

        protected virtual void OnRuntimeReset()
        {
        }

        protected abstract void OnUpdate(TimeSpan elapsedTime);
    }
}