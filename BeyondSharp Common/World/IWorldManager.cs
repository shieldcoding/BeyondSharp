namespace BeyondSharp.Common.World
{
    public interface ICommonWorldManager<WorldType> : IEngineComponent
        where WorldType : IWorld
    {
        WorldType World { get; }
    }
}