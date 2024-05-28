using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PFE_API.Database_Controllers;
using PFE_API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PFE_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPFEController : ControllerBase
    {
        private IConfiguration _config;
        public LoginPFEController(IConfiguration config)
        {
            //_config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            _config = config;
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
                //return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            var response = new { api_token = token, email=email };
            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginRequest loginRequest)
        {
            //your logic for register process
            //If register usrename and password are correct then proceed to generate token

            var email = loginRequest.Email;
            var password = loginRequest.Password;

            //if (LoginDbController.FindEmail(email))
            //{
            //    return Unauthorized();
            //}

            var user = new User(email, password);
            LoginDbController.Register(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                             _config["Jwt:Issuer"],
                                          null,
                                                       expires: DateTime.Now.AddDays(7),
                                                                    signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
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

            var response = new { api_token=token };

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
