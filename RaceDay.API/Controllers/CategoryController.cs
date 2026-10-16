using Microsoft.AspNetCore.Mvc;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public CategoryController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_context.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDto dto)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Organiser")
            {
                return StatusCode(403,
                    "Only organisers can create categories.");
            }

            var category = new Category
            {
                CategoryName = dto.CategoryName,
                Distance = dto.Distance,
                EventID = dto.EventID
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok("Category created successfully.");
        }
    }
}