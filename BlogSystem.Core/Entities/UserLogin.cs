using System;
using System.Collections.Generic;

namespace BlogSystem.Core.Entities
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public bool Status { get; set; }

        public virtual UserAccount User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
