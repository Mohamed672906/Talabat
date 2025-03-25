using System.ComponentModel.DataAnnotations;

namespace Talabat.ABIS.DTOs
{
    public class RegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string DisplayName { get; set; }


        [Required]
        [Phone]
        public string PhoneNumber { get; set; }


        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@#$%^&+=!]).{4,}$",
   ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character, and be at least 4 characters long.")]
        public string Password { get; set; }



    }
}
