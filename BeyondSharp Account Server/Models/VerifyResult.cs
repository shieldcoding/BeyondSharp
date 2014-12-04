
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer.Models
{
    [DataContract]
    public class VerifyResult
    {
        public bool Success { get; set; }

        public DateTime AuthenticationExpiry { get; set; }
    }
}
