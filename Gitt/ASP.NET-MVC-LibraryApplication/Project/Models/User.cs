using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public  class User : IdentityUser
    {

		[StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        public string? Adress {  get; set; }

        public string UserType { get; set; }
        // storing the usertype either student or librarian


    }
}
