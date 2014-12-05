using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.AccountServer.Models
{
    [Table("Accounts")]
    public class Account
    {
        public Guid ID { get; set; }

        public string Username { get; set; }

        [Required]
        [MinLength(128)]
        [MaxLength(128)]
        public string PasswordHash { get; set; }

        public Guid PasswordSalt { get; set; }

        public Guid? AuthenticationToken { get; set; }

        public DateTime? AuthenticationExpiry { get; set; }
    }
}
