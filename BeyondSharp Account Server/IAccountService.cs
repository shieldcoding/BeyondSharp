using BeyondSharp.AccountServer.Models;
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
        VerifyResult Authorize(string username, Guid authenticationToken);
    }
}
