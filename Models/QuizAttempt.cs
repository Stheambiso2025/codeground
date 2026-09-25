using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyCode.Models
{
    public class QuizAttempt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int QuizId { get; set; }

        public int Score { get; set; }

        public int TotalQuestions { get; set; }

        public DateTime AttemptedAt { get; set; }
    }
}