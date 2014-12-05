using BeyondSharp.AccountServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer
{
    public class AccountDbContext : DbContext
    {
        private const string DEFAULT_CONNECTION_STRING = "DefaultConnection";

        public DbSet<Account> Accounts { get; set; }

        public AccountDbContext()
            : this(DEFAULT_CONNECTION_STRING) { }

        public AccountDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }
    }
}
