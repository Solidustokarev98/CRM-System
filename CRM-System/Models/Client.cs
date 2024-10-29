namespace CRM_System.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public int ManagerId { get; set; } 
        public Manager _Manager { get; set; }
    }
}
