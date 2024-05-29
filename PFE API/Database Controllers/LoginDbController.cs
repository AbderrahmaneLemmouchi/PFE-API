using PFE_API.Model;
using System.Security.Cryptography;
using System.Text;

namespace PFE_API.Database_Controllers
{
    public class LoginDbController
    {


        public static bool FindEmail(string email)
        {
            using var db = new DBcontext();
            var users = db.Users.AsEnumerable();
            var user = users.Where(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

            return !user.Any();
        }

        public static bool Login(string email, string password)
        {
            using var db = new DBcontext(); 
            var users = db.Users.AsEnumerable();
            var user = users.Where(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            using var sha256 = SHA256.Create();
            var hashedPassword = ConvertToHash(password, sha256);

            return user.Password == hashedPassword;
        }

        public static void Register(User user)
        {
            using var db = new DBcontext();
            using var sha256 = SHA256.Create();
            user.Password = ConvertToHash(user.Password, sha256);
            db.Users.Add(user);
            db.SaveChanges();
        }

        internal static User GetUser(string email)
        {
            using var db = new DBcontext();
            var users = db.Users.AsEnumerable();
            var user = users.Where(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return user;
        }

        private static string ConvertToHash(string input, HashAlgorithm algorithm)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = algorithm.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
