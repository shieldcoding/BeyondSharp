using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    public class ClientEngine : ICommonEngine
    {
        public EngineSide Side { get { return EngineSide.Client; } }
    }
}
