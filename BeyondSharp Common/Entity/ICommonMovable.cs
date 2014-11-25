using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The base entity-type for mappable objects that are capable of motion shared between the server and its clients.
    /// 
    /// For clarification purposes, a mappable object capable of motion means that the object can have its location changed.
    /// </summary>
    public interface ICommonMovable : ICommonAtom
    {
    }
}
