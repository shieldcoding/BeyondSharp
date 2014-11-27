using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common
{
    public interface ICommonEngineComponent<EngineType>
        where EngineType : ICommonEngine
    {
        EngineType Engine { get; }

        void Initialize();
    }
}
