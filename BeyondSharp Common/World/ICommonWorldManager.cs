using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.World
{
    public interface ICommonWorldManager<WorldType> : ICommonEngineComponent
        where WorldType : ICommonWorld
    {
        WorldType World { get; }
    }
}
