using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Network
{
    public interface ICommonPlayer
    {
        string Username { get; }

        Guid AuthenticationToken { get; }

        Guid HardwareToken { get; }
    }
}
