using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; } // HTML content

        public string CodeExample { get; set; } // code block shown in lesson

        public string Language { get; set; } // "python" or "java" for syntax highlighting

        public int OrderIndex { get; set; }

        public virtual Course Course { get; set; }
    }
}