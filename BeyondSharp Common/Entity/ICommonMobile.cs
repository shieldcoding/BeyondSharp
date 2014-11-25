using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The base entity-type for controlled objects shared between the server and its clients.
    /// 
    /// Entities of this type typically represent a player or an NPC.
    /// </summary>
    public interface ICommonMobile : ICommonMovable
    {
    }
}
