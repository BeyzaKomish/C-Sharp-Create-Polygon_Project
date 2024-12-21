using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.ViewModels
{
    public class RegisterVM// Creating a register page and props, along with validations and error messages
	{
        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string? Password { get; set; }

        [Compare("Password" , ErrorMessage ="Passwords don't match!!!")]

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]

        [Column("Adress")]
        public string? Adress {  get; set; }

    }
}
