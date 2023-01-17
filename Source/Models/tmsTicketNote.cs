namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicketNote")]
    public partial class tmsTicketNote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int TicketID { get; set; }

        public int SubmitterID { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
