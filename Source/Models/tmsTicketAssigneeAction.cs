namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicketAssigneeAction")]
    public partial class tmsTicketAssigneeAction
    {
        public int ID { get; set; }

        public int AssigneeID { get; set; }

        public string Action { get; set; }
    }
}
