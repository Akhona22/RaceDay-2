using Microsoft.AspNetCore.Mvc;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public AuthController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Auth Controller is working!");
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == dto.Email &&
                u.Password == dto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetString("FirstName", user.FirstName);

            return Ok(new
            {
                Message = "Login successful",
                UserID = user.UserID,
                FirstName = user.FirstName,
                Role = user.Role
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Ok("Logged out successfully.");
        }

        [HttpGet("current-user")]
        public IActionResult CurrentUser()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            var firstName = HttpContext.Session.GetString("FirstName");
            var role = HttpContext.Session.GetString("Role");

            if (userId == null)
            {
                return Unauthorized("No user is logged in.");
            }

            return Ok(new
            {
                UserID = userId,
                FirstName = firstName,
                Role = role
            });
        }
    }
}