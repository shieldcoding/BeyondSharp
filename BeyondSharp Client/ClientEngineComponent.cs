#region Usings

using System;
using BeyondSharp.Common;

#endregion

namespace BeyondSharp.Client
{
    public abstract class ClientEngineComponent : IEngineComponent
    {
        private const bool IsRenderEnabledByDefault = false;
        private const bool IsUpdateEnabledByDefault = true;

        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;

            IsUpdateEnabled = IsUpdateEnabledByDefault;
            IsRenderEnabled = IsRenderEnabledByDefault;
        }

        public ClientEngine Engine { get; private set; }
        public bool IsRenderEnabled { get; protected set; }
        public bool IsUpdateEnabled { get; protected set; }
        public abstract void Initialize();
        protected abstract void OnUpdateFrame(TimeSpan elapsedTime);
        internal abstract void OnRenderFrame(TimeSpan elapsedTime);

        internal void RenderFrame(TimeSpan elapsedTime)
        {
            if (IsRenderEnabled)
                OnRenderFrame(elapsedTime);
        }

        internal void UpdateFrame(TimeSpan elapsedTime)
        {
            if (IsUpdateEnabled)
                OnUpdateFrame(elapsedTime);
        }
    }
}