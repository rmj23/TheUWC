namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentCourse")]
    public partial class StudentCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentCourse()
        {
            Comments = new HashSet<Comment>();
            GoalsIndividualStudents = new HashSet<GoalsIndividualStudent>();
        }

        public int ID { get; set; }

        public int studentID { get; set; }

        public int courseID { get; set; }

        public bool? enrolled { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsIndividualStudent> GoalsIndividualStudents { get; set; }

        public virtual Student Student { get; set; }
    }
}
