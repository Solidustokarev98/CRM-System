using CRM_System.Db;
using CRM_System.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM_System.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        public IActionResult AddClient(Client _client)
        {
            _context.Clients.Add(_client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditClient(Client _client)
        {
            _context.Clients.Update(_client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddEvent(Event _event)
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


