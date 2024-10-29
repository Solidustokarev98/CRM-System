using CRM_System.Models;
using CRM_System.Repository.Interfaces;
using CRM_System.Services.Interfaces;

namespace CRM_System.Services.Implementations
{
    public class AdminService 
    {
        private readonly IManagerRepository _manager;

        public AdminService(IManagerRepository manager)
        {
            _manager = manager;
        }


        public IEnumerable<Manager> GetManagers()
        {
            return _manager.Managers;
        }

        public Manager GetManager(long id)
        {
            return _manager.Managers.FirstOrDefault(e => e.Id == id) ?? new Manager();
        }

        public void SaveProduct(Manager manager)
        {
            _manager.Save(manager);
        }
    }
}
