namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebAdminLead")]
    public partial class WebAdminLead
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WebAdminLeadID { get; set; }
    }
}
