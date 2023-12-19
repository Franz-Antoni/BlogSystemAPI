using System;
using System.Collections.Generic;

namespace BlogSystem.Core.Entities
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
