using System.ComponentModel.DataAnnotations;

namespace MyCode.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string ActivationCode { get; set; }

        public bool IsAdmin { get; set; }
        //public bool IsAdmin { get; set; }

    }
}