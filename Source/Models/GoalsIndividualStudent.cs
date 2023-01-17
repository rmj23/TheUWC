namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoalsIndividualStudent")]
    public partial class GoalsIndividualStudent
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string description { get; set; }

        public int? goalTopicID { get; set; }

        public int studentCourseID { get; set; }

        public int teacherID { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime? deadlineDate { get; set; }

        public DateTime? dateFinished { get; set; }

        [StringLength(500)]
        public string fullDescription { get; set; }

        public virtual StudentCourse StudentCourse { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual validGoalTopic validGoalTopic { get; set; }
    }
}
