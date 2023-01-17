namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SitesMonitored")]
    public partial class SitesMonitored
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string SiteName { get; set; }
    }
}
