using CRM_System.Models;

namespace CRM_System.Repository.Interfaces
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> Managers { get; }


        void Save(Manager manager);
        void Delete(long id);
    }
}
