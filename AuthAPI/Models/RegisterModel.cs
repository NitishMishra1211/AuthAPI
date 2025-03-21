namespace AuthAPI.Models
{
    public class RegisterModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }= string.Empty;

    }
}
