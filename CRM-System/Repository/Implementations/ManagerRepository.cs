using CRM_System.Db;
using CRM_System.Models;
using CRM_System.Repository.Interfaces;
using System;

namespace CRM_System.Repository.Implementations
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context;

        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;

            Managers = _context.Managers;
        }


        public IEnumerable<Manager> Managers { get; }


        public void Save(Manager @new)
        {
            if (@new.Id == 0)
            {
                _context.Managers.Add(@new);
            }
            else
            {
                var product = _context.Managers.FirstOrDefault(e => e.Id == @new.Id);

                if (product is null)
                {
                    throw new ArgumentNullException($"Manager with id: {@new.Id} is null");
                }

                product.Name = @new.Name;
                product.Email = @new.Email;
                product.Role = @new.Role;
            }

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var product = _context.Managers.FirstOrDefault(e => e.Id == id);

            if (product is null)
            {
                throw new ArgumentNullException($"Product with id: {product.Id} is null");
            }

            _context.Managers.Remove(product);

            _context.SaveChanges();
        }
    }

}