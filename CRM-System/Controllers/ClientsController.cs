using CRM_System.Db;
using CRM_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRM_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Добавить клиента
        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return Ok(client);
        }

        // Изменить клиента
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            if (id != client.Id) return BadRequest();

            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // Удалить клиента
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
