namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PointWinner
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Month { get; set; }

        public int UserID { get; set; }

        public DateTime timestamp { get; set; }

        public virtual User User { get; set; }
    }
}
