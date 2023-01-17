namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicketAcknowledged")]
    public partial class tmsTicketAcknowledged
    {
        public int ID { get; set; }

        public int? TicketID { get; set; }

        public DateTime? DateAcknowledged { get; set; }

        public bool? Acknowledged { get; set; }
    }
}
