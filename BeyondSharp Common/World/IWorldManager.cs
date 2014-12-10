using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.World
{
    public interface ICommonWorldManager<WorldType> : IEngineComponent
        where WorldType : IWorld
    {
        WorldType World { get; }
    }
}
