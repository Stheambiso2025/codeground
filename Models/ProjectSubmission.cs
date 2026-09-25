using System;
using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class ProjectSubmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}