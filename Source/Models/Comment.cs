namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }

        [Column("Comment")]
        public string Comment1 { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? studentCourseID { get; set; }

        public bool? Completed { get; set; }

        public virtual StudentCourse StudentCourse { get; set; }
    }
}
