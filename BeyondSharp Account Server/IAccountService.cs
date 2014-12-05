using BeyondSharp.AccountServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        LoginResult Login(string username, string password);

        [OperationContract]
        VerifyResult Verify(string username, Guid authenticationToken);
    }
}
