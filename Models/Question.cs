using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyCode.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        // Store "A", "B", "C", or "D"
        [Required]
        public string CorrectOption { get; set; }

        public int OrderIndex { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}