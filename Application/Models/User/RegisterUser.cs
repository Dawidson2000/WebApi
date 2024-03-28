using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class RegisterUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
    }
}
