using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PFE_API.Model
{
    public class AppUser : IdentityUser
    {
    }

    public class PfeLogin
    {

        public static bool Login(string email, string password)
        {

            return true;
        }
    }

    //public class AppDbContext : IdentityDbContext<AppUser>
    //{
    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    {

    //    }
    //}
}
