namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcademicYear")]
    public partial class AcademicYear
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string SchoolYear { get; set; }

        public bool IsCurrent { get; set; }
    }
}
