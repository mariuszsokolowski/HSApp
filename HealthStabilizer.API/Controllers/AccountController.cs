using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HealthStabilizer.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        readonly SignInManager<User> _signInManager;
        readonly UserManager<User> _userManager;
        readonly IConfiguration _configuration;
        #endregion

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            try
            {
                var email = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == model.Login.ToUpper()).Email;
                var result = await _signInManager.PasswordSignInAsync(model.Login.ToUpper(), model.Password, false, false);


                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.NormalizedUserName == model.Login.ToUpper());
                    return GenerateJwtToken(model.Login, appUser);
                }

            }
            catch (Exception e)
            {
                throw new NotImplementedException("Problem in LogIn.");
            }
            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost("Logout")]
        public async Task<object> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();

        }


        [HttpPost("Register")]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            try
            {
                var user = new User
                {
                    UserName = model.Login,
                    Email = model.Email
                };

                var passwordValidator = new PasswordValidator<User>();
                var resultPasswordValdiator = await passwordValidator.ValidateAsync(_userManager, null, model.Password);
                if (!resultPasswordValdiator.Succeeded)
                    return BadRequest("Password is incorrect." + resultPasswordValdiator.Errors.FirstOrDefault().Description);

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return GenerateJwtToken(model.Email, user);
                }

            }
            catch
            {
                throw new NotImplementedException("Error in register Account.");
            }
            throw new NotImplementedException("Error in register Account.");

        }

        private string GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class LoginDto
        {
            [Required]
            [StringLength(100, ErrorMessage = "Login min length = 4", MinimumLength = 4)]
            public string Login { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Password min length = 8", MinimumLength = 8)]
            public string Password { get; set; }

        }

        public sealed class RegisterDto : LoginDto
        {

            [Required]
            public string Email { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "Password min length = 8", MinimumLength = 8)]
            public string ConfirmPassword { get; set; }
        }
    }
}