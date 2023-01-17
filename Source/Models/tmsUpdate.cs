namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsUpdate")]
    public partial class tmsUpdate
    {
        public int ID { get; set; }

        public int TicketID { get; set; }

        public DateTime DateCreated { get; set; }

        [Column(TypeName = "text")]
        public string Details { get; set; }

        public virtual tmsTicket tmsTicket { get; set; }
    }
}
