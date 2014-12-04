using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Network
{
    public interface ICommonAccount
    {
        /// <summary>
        /// The username of the account.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The authentication token is issued by the master login server, the server verifies this token when the client connects.
        /// </summary>
        Guid AuthenticationToken { get; }

        /// <summary>
        /// A GUID representing
        /// </summary>
        Guid HardwareToken { get; }
    }
}
