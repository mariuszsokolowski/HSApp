using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.User;
using HealthStabilizer.Services.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        readonly SignInManager<User> _signInManager;
        readonly UserManager<User> _userManager;
        readonly IConfiguration _configuration;
        readonly string _requestUserID;
        readonly DBContext _context;
        readonly UserService _userService;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            DBContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _requestUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context = context;
            _userService = new UserService(context);
        }

        [HttpGet("Seciurity")]
        public async Task<IActionResult> GetUserSeciurity()
        {
            try
            {
                return Ok(await _userService.GetSeciurityAsync(_requestUserID));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("Seciurity/{id}")]
        public async Task<IActionResult> ChangeUserSeciurity(string id, [FromBody] UserSeciurity model)
        {
            try
            {
                await _userService.SetSeciurityAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var result = await _userService.GetProfileAsync(_requestUserID);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("Profile/{id}")]
        public async Task<IActionResult> ChangeUserProfile(string id, [FromBody] UserProfile model)
        {
            try
            {
                await _userService.SetProfileAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }



    }
}