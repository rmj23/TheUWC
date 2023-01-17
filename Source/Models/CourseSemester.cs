namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseSemester")]
    public partial class CourseSemester
    {
        public int ID { get; set; }

        public int SchoolID { get; set; }

        public int SubjectID { get; set; }

        public int SemesterID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MidtermDate { get; set; }

        public virtual School School { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
