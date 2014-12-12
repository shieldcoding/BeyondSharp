using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Network
{
    public interface IPlayer
    {
        string Username { get; }

        Guid SessionToken { get; }

        Guid HardwareToken { get; }
    }
}
