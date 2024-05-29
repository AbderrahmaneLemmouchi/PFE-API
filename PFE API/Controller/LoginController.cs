using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PFE_API.Database_Controllers;
using PFE_API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PFE_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPFEController(IConfiguration config, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        private readonly IConfiguration _config = config;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [HttpGet("USERRRR")]
        public IActionResult Get()
        {
            var idUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(idUser);
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            var email = loginRequest.Email;
            var password = loginRequest.Password;

            if (!LoginDbController.Login(email, password))
            {
                string message = "The provided credentials are incorrect";
                string[] errors = ["The provided credentials are incorrect"];
                return Unauthorized(new { message, errors });
            }

            var user = LoginDbController.GetUser(email);
            var token = CreateToken(user);

            var response = new { api_token = token, email = email };
            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginRequest loginRequest, string role)
        {
            var email = loginRequest.Email;
            var password = loginRequest.Password;
            var r = role;

            var user = new User(email, password, r);
            LoginDbController.Register(user);
            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: DateTime.Now.AddDays(7), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;
        }

        [HttpPost("verify_token")]
        public IActionResult IsTokenValid(dynamic token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(token.api_token, validationParameters, out validatedToken);
            }
            catch
            {
                return UnprocessableEntity();
            }

            var response = new { api_token = token };

            return Ok(response);
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is expiration in the generated token
                ValidateAudience = false, // Because in the token creation the audience was not defined
                ValidateIssuer = false,   // Because in the token creation the issuer was not defined
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
            };
        }


        [HttpPost("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
