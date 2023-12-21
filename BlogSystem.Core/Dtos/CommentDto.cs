using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserLoginId { get; set; }
        public string Content { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ResponseId { get; set; }
    }
}
