using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public bool Status { get; set; }
    }
}
