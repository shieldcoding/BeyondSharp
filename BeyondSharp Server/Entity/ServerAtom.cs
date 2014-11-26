using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Entity
{
    public abstract class ServerAtom : ServerDatum, ICommonAtom
    {
        public string Name { get; private set; }
    }
}
