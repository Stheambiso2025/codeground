using System;
using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}