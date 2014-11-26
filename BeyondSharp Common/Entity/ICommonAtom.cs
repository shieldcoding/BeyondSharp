using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The base entity-type for mappable objects shared between the server and its clients.
    /// </summary>
    public interface ICommonAtom
    {
        string Name { get; }
    }
}
