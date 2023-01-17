using System;

namespace Source.Models
{
    public class TicketModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public int SubmitterID { get; set; }
        public bool Acknowledged { get; set; }
        public bool Resolved { get; set; }
        public DateTime Completed { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Priority { get; set; }
    }

}