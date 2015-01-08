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
        public bool IsUpdateEnabled { get; protected set; }
        public abstract void Initialize();

        public void UpdateFrame(TimeSpan elapsedTime)
        {
            if (IsUpdateEnabled)
                OnUpdateFrame(elapsedTime);
        }


        protected abstract void OnUpdateFrame(TimeSpan elapsedTime);
    }
}