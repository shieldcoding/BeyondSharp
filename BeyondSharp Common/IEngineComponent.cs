#region Usings

using System;

#endregion

namespace BeyondSharp.Common
{
    public interface IEngineComponent
    {
        bool IsUpdateEnabled { get; }
        void Initialize();
        void Update(TimeSpan elapsedTime);
    }
}