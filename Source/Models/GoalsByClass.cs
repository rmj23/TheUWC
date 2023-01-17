namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoalsByClass")]
    public partial class GoalsByClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string shortDescription { get; set; }

        [Required]
        [StringLength(500)]
        public string fullDescription { get; set; }

        public int teacherID { get; set; }

        public int courseID { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime deadlineDate { get; set; }

        public DateTime? dateFinished { get; set; }

        public virtual Course Course { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
