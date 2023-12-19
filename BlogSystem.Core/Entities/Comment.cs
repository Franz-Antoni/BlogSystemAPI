using System;
using System.Collections.Generic;

namespace BlogSystem.Core.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            InverseResponse = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserLoginId { get; set; }
        public string Content { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ResponseId { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual Comment? Response { get; set; }
        public virtual UserLogin UserLogin { get; set; } = null!;
        public virtual ICollection<Comment> InverseResponse { get; set; }
    }
}
