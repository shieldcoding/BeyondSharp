namespace BeyondSharp.Common.Game.Map
{
    public interface IWorldManager<TWorldManager, TWorld, TWorldTile> : IEngineComponent
        where TWorldManager : IWorldManager<TWorldManager, TWorld, TWorldTile>
        where TWorld : IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldTile : IWorldTile<TWorldManager, TWorld, TWorldTile>
    {
    }
}