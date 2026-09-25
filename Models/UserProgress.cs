using System;
using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class UserProgress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}