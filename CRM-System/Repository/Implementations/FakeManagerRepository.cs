using CRM_System.Models;
using CRM_System.Repository.Interfaces;

namespace CRM_System.Repository.Implementations
{
    public class FakeManagerRepository : IManagerRepository
    {
        public IEnumerable<Manager> Managers { get; }

        public FakeManagerRepository()
        {
            Managers = new List<Manager>
        {
            new Manager
            {
                Name = "Manager 1",
                Role = "manager"
            },
            new Manager
            {
                Name = "Manager 2",
                Role = "manager"
            },
            new Manager
            {
                Name = "Manager 3",
                Role = "manager"
            },
            new Manager
            {
                Name = "Manager 4",
                Role = "manager"
            },
            new Manager
            {
                Name = "Manager 5",
                Role = "manager"
            },
        };
        }

        public void Save(Manager manager)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}