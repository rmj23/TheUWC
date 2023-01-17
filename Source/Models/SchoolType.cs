namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolType")]
    public partial class SchoolType
    {
        public int ID { get; set; }

        [Column("SchoolType")]
        [StringLength(100)]
        public string SchoolType1 { get; set; }
    }
}
