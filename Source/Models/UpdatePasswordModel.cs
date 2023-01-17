using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class UpdatePasswordModel

    {
        [Required(ErrorMessage = "The username Field is required")]
        public string UserName { get; set; }

        [RegularExpression(@"^(?:.*[a-z]){7,}$", ErrorMessage = "Password must be at least 7 characters long.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewPasswordAgain { get; set; }
        public LoginModel ConvertToLoginModel()
        {
            if (NewPassword != NewPasswordAgain)
                return null;
            LoginModel output = new LoginModel();
            output.UserName = this.UserName;
            output.Password = this.NewPassword;
            return output;
        }
        public UpdatePasswordModel()
        { }
        public UpdatePasswordModel(string email)
        {
            this.UserName = email;
        }
    }
}