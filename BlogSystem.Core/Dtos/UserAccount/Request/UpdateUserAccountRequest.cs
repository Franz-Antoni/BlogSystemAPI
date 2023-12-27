using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.UserAccount.Request
{
    public class UpdateUserAccountRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
    }
}
