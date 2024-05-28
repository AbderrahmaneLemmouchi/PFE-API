using System.ComponentModel.DataAnnotations;

namespace PFE_API.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User() { }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            Role = "User";
        }

        public User(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
