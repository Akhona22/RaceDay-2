using Microsoft.AspNetCore.Mvc;
using RaceDay.API.Data;
using RaceDay.API.DTOs;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public EventController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            return Ok(_context.Events.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var evt = _context.Events.FirstOrDefault(e => e.EventID == id);

            if (evt == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto dto)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Organiser")
            {
                return StatusCode(403,
                    "Only organisers can create events.");
            }

            var evt = new Event
            {
                EventName = dto.EventName,
                Description = dto.Description,
                EventDate = dto.EventDate,
                Location = dto.Location,
                Distance = dto.Distance,
                EventTypeID = dto.EventTypeID,
                OrganiserID = dto.OrganiserID
            };

            _context.Events.Add(evt);
            _context.SaveChanges();

            return Ok("Event created successfully.");
        }
    }
}
