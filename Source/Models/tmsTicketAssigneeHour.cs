namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tmsTicketAssigneeHour
    {
        public int ID { get; set; }

        public int AssigneeID { get; set; }

        public DateTime Start { get; set; }

        public DateTime? Finish { get; set; }
    }
}
