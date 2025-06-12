using AuthAPI.Models;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static AuthAPI.Models.ApplicationDbContext;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenServices jwtTokenService;

        public AuthController(UserManager<ApplicationUser> userManager,IJwtTokenServices jwtTokenServices)
        {
            this.userManager = userManager;
            this.jwtTokenService = jwtTokenServices;
        }

        [HttpGet("user-details")]
        public async Task<IActionResult> Detail([FromQuery] string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return NotFound("user not");
            }
            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(new { Username = user.UserName });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null && !await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized();
            }
            var token = jwtTokenService.GenerateToken(user.Id, user.UserName);
            return token != null ? Ok(new { Token = token }) : BadRequest("Token generation failed.");
        }                                                                                                                                                
    }
}