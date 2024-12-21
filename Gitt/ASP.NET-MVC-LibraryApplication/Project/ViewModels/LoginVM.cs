using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class LoginVM// Creating a login page and props, along with validations and error messages
    {
        [Required(ErrorMessage ="Username is Required")]

        public string? Username { get; set; }

        [Required(ErrorMessage ="Password is Required")]

        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
