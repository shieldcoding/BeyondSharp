using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common
{
    public interface IEngineComponent
    {
        void Initialize();

        void Update(TimeSpan elapsedTime);
    }
}
