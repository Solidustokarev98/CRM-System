using CRM_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRM_System.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
