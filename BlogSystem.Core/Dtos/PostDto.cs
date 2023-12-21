using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserLoginId { get; set; }
        [StringLength(maximumLength:100, MinimumLength =1, ErrorMessage ="El titulo debe tener entre 1 y 100 caracteres.")]
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ImageId { get; set; }
    }
}
