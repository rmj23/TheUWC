using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}