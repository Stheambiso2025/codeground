using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; } // emoji like 🐍 or ☕

        public string Slug { get; set; } // "python" or "java"

        public int OrderIndex { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}