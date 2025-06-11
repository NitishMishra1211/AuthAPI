using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models
{
    public class RegisterModel
    {
        public string FullName { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }= string.Empty;

    }
}
