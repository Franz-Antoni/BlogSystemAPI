using System;
using System.Collections.Generic;

namespace BlogSystem.Core.Entities
{
    public partial class Image
    {
        public Image()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string? Path { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
