namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assignment")]
    public partial class Assignment
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Due { get; set; }

        public int? CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}
