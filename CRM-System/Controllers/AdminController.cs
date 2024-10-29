using CRM_System.Db;
using CRM_System.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var managers = _context.Managers.Where(u => u.Role == "Manager").ToList();
            return View(managers);
        }
        public IActionResult AddManager(Manager user)
        {
            user.Role = "Manager";
            _context.Managers.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteManager(int id)
        {
            var user = _context.Managers.Find(id);
            if (user != null)
            {
                _context.Managers.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
