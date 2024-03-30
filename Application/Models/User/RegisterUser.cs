using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class RegisterUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
    }
}
