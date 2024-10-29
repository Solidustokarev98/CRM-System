namespace CRM_System.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
