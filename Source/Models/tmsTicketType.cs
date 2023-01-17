namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicketType")]
    public partial class tmsTicketType
    {
        public int ID { get; set; }

        public int TicketID { get; set; }

        public int TypeID { get; set; }

        public virtual tmsTicket tmsTicket { get; set; }

        public virtual tmsType tmsType { get; set; }
    }
}
