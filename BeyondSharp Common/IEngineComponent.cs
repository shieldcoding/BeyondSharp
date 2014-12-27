namespace BeyondSharp.Common
{
    using System;

    public interface IEngineComponent
    {
        bool IsUpdateEnabled { get; }

        void Initialize();

        void Update(TimeSpan elapsedTime);
    }
}