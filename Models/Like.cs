using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}