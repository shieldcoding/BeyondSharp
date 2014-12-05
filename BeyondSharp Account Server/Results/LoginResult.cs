using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer.Results
{
    [DataContract]
    public class LoginResult
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public Guid? AuthenticationToken { get; set; }

        [DataMember]
        public DateTime? AuthenticationExpiry { get; set; }
    }
}
