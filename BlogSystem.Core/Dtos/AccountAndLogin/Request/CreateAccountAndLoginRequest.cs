using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.AccountAndLogin.Request
{
    public class CreateAccountAndLoginRequest
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public bool Gender { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
    }
}
