using CRM_System.Db;
using CRM_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_System.Controllers
{
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Добавить событие
        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return Ok(newEvent);
        }
    }
}
