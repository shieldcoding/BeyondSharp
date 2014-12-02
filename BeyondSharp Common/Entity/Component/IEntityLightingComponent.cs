using BeyondSharp.Common.Entity.Component.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity.Component
{
    [SynchronizedComponent(IDENTIFIER)]
    public class IEntityLightingComponent : ICommonEntityComponent
    {
        private const string IDENTIFIER = "Lighting";
    }
}
