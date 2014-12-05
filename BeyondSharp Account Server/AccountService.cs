using BeyondSharp.AccountServer.Results;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer
{
    public class AccountService : IAccountService
    {
        private const string DATA_DIRECTORY = "Data";

        public AccountService()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }

        public LoginResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new LoginResult()
                {
                    Success = false,
                    Message = Localization.Strings.LoginBadArguments
                };
            }

            var databaseContext = new AccountDbContext();
            var account = databaseContext.Accounts
                .FirstOrDefault(a => a.Username == username.ToLower());

            if (account == null)
            {
                return new LoginResult()
                {
                    Success = false,
                    Message = Localization.Strings.LoginNoAccount
                };
            }

            using (var sha512 = new SHA512Managed())
            {
                var passwordData = Encoding.UTF8.GetBytes(password + account.PasswordSalt.ToString());
                var passwordHash = sha512.ComputeHash(passwordData);
                var passwordHex = BitConverter.ToString(passwordHash).Replace("-", string.Empty);

                if (!string.Equals(account.PasswordHash, passwordHex))
                {
                    return new LoginResult()
                    {
                        Success = false,
                        Message = Localization.Strings.LoginInvalid
                    };
                }
            }

            account.AuthenticationToken = Guid.NewGuid();
            account.AuthenticationExpiry = DateTime.Now.AddDays(1);
            databaseContext.SaveChanges();

            return new LoginResult()
            {
                Success = true,
                Message = Localization.Strings.LoginOK,
                AuthenticationToken = account.AuthenticationToken,
                AuthenticationExpiry = account.AuthenticationExpiry
            };
        }

        public VerifyResult Verify(string username, Guid authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(username) || authenticationToken == default(Guid))
            {
                return new VerifyResult()
                {
                    Success = false,
                    Message = Localization.Strings.VerifyBadArguments
                };
            }
            
            var databaseContext = new AccountDbContext();
            var account = databaseContext.Accounts
                .FirstOrDefault(a => a.Username == username.ToLower());

            if (account == null)
            {
                return new VerifyResult()
                {
                    Success = false,
                    Message = Localization.Strings.VerifyNoAccount
                };
            }

            if (account.AuthenticationToken.HasValue == false || account.AuthenticationToken.Value != authenticationToken)
            {
                return new VerifyResult()
                {
                    Success = false,
                    Message = Localization.Strings.VerifyInvalid
                };
            }


            if (account.AuthenticationExpiry.HasValue && account.AuthenticationExpiry < DateTime.Now)
            {
                return new VerifyResult()
                {
                    Success = false,
                    Message = Localization.Strings.VerifyExpired
                };
            }

            return new VerifyResult()
            {
                Success = true,
                Message = Localization.Strings.VerifyOK
            };
        }
    }
}
