namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LessonPlan")]
    public partial class LessonPlan
    {
        public int ID { get; set; }

        public int TeacherID { get; set; }

        public int CourseID { get; set; }

        public DateTime UploadDate { get; set; }

        [Column("LessonPlan")]
        [Required]
        public byte[] LessonPlan1 { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string LessonPlanTitle { get; set; }

        public virtual Course Course { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
