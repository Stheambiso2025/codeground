using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        // If this is a lesson quiz, this links to the lesson.
        // If null, it's a final test for a course.
        public int? LessonId { get; set; }

        // For final tests
        public int? CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsFinalTest { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}