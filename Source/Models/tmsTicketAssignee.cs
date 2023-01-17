namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicketAssignee")]
    public partial class tmsTicketAssignee
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int TicketID { get; set; }

        public bool Active { get; set; }

        public DateTime? DateAssigned { get; set; }

        public virtual tmsTicket tmsTicket { get; set; }

        public virtual User User { get; set; }
    }
}
