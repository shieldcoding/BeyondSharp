namespace BeyondSharp.Common
{
    using System;

    public interface IEngineComponent
    {
        void Initialize();

        void Update(TimeSpan elapsedTime);
    }
}