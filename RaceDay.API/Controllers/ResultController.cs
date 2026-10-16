using Microsoft.AspNetCore.Mvc;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public ResultController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllResults()
        {
            return Ok(_context.Results.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var result = _context.Results
                .FirstOrDefault(r => r.ResultID == id);

            if (result == null)
            {
                return NotFound("Result not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateResult(ResultDto dto)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Organiser")
            {
                return StatusCode(403,
                    "Only organisers can capture results.");
            }

            var existingResult = _context.Results
                .FirstOrDefault(r => r.EnrolmentID == dto.EnrolmentID);

            if (existingResult != null)
            {
                return BadRequest(
                    "A result already exists for this enrolment.");
            }

            var result = new Result
            {
                EnrolmentID = dto.EnrolmentID,
                FinishTime = dto.FinishTime,
                Position = dto.Position
            };

            _context.Results.Add(result);
            _context.SaveChanges();

            return Ok("Result captured successfully.");
        }
    }
}