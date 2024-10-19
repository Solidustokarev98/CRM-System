namespace CRM_System.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string EventType { get; set; } // 'Meeting', 'Call', 'Contract'
        public string Description { get; set; }
        public string Outcome { get; set; } // 'Call Back', 'Ready to sign', 'Thinking'
    }
}
