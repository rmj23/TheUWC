using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}