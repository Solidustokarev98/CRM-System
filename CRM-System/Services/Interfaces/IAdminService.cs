using CRM_System.Models;

namespace CRM_System.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Manager> GetManagers();

        Manager GetManager(long id);
        void SaveManager(Manager manager);
    }
}
