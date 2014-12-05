using BeyondSharp.AccountServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .ToTable("Accounts");

            modelBuilder.Entity<Account>()
                .HasKey(account => account.ID);

            modelBuilder.Entity<Account>()
                .Property(account => account.ID)
                .HasColumnType("uniqueidentifier");

            modelBuilder.Entity<Account>()
                .Property(account => account.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Account>()
                .Property(account => account.Username)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(account => account.Username)
                .HasColumnType("varchar");

            modelBuilder.Entity<Account>()
                .Property(account => account.Username)
                .HasMaxLength(32);

            modelBuilder.Entity<Account>()
                .Property(account => account.PasswordHash)
                .HasColumnType("char");

            modelBuilder.Entity<Account>()
                .Property(account => account.PasswordHash)
                .HasMaxLength(128);
        }
    }
}
