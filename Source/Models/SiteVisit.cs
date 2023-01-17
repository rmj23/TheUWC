namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SiteVisit
    {
        public int ID { get; set; }

        public int? Site_ID { get; set; }

        public DateTime? Visit_Date { get; set; }

        public int? User_ID { get; set; }
    }
}
