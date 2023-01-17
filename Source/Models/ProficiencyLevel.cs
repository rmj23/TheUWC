namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProficiencyLevel")]
    public partial class ProficiencyLevel
    {
        public int ID { get; set; }

        [Column("ProficiencyLevel")]
        [Required]
        [StringLength(1)]
        public string ProficiencyLevel1 { get; set; }
    }
}
