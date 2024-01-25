using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.UserLogin.Request
{
    public class CreateUserLoginRequest
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
    }
}
