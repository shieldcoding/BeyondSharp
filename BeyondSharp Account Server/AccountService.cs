using BeyondSharp.AccountServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer
{
    public class AccountService : IAccountService
    {
        public LoginResult Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public VerifyResult Authorize(string username, Guid authenticationToken)
        {
            throw new NotImplementedException();
        }
    }
}
