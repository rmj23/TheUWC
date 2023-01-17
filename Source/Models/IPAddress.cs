namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPAddress")]
    public partial class IPAddress
    {
        public int ID { get; set; }

        [Column("ipAddress")]
        [StringLength(15)]
        public string ipAddress1 { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string region { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(10)]
        public string zip { get; set; }

        [StringLength(50)]
        public string organization { get; set; }

        [StringLength(100)]
        public string isp { get; set; }
    }
}
