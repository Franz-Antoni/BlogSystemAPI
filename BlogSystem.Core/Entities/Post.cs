using System;
using System.Collections.Generic;

namespace BlogSystem.Core.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UserLoginId { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ImageId { get; set; }

        public virtual Image? Image { get; set; }
        public virtual UserLogin UserLogin { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
