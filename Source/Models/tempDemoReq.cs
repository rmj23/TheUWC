namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tempDemoReq")]
    public partial class tempDemoReq
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string emailAd { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(150)]
        public string school { get; set; }

        [StringLength(50)]
        public string district { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(18)]
        public string zipCode { get; set; }

        [StringLength(500)]
        public string comments { get; set; }

        [StringLength(50)]
        public string position { get; set; }

        [StringLength(50)]
        public string licType { get; set; }

        public bool ackKnod { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public DateTime? dateAdded { get; set; }
    }
}
