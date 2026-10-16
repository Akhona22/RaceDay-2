using Microsoft.AspNetCore.Mvc;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public EnrolmentController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEnrolments()
        {
            return Ok(_context.Enrolments.ToList());
        }

        [HttpPost]
        public IActionResult CreateEnrolment(EnrolmentDto dto)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Participant")
            {
                return StatusCode(403,
                    "Only participants can enrol.");
            }

            var participantId =
                HttpContext.Session.GetInt32("UserID");

            if (participantId == null)
            {
                return Unauthorized("Please login first.");
            }

            var enrolment = new Enrolment
            {
                ParticipantID = participantId.Value,
                EventID = dto.EventID,
                CategoryID = dto.CategoryID,
                EnrolmentDate = DateTime.Now
            };

            _context.Enrolments.Add(enrolment);
            _context.SaveChanges();

            return Ok("Enrolment successful.");
        }
    }
}
