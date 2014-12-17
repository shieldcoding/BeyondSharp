namespace BeyondSharp.Common.Game.Environment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IWorldTile<TWorldManager, TWorld, TWorldTile>
        where TWorldManager : IWorldManager<TWorldManager, TWorld, TWorldTile>
        where TWorld : IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldTile : IWorldTile<TWorldManager, TWorld, TWorldTile>
    {
        TWorld World { get; }
    }
}
