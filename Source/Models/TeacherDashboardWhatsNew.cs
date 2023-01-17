namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherDashboardWhatsNew")]
    public partial class TeacherDashboardWhatsNew
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string description { get; set; }

        public DateTime? lastUpdated { get; set; }
    }
}
