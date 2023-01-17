namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassLevel")]
    public partial class ClassLevel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Level { get; set; }
    }
}
