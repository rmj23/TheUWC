namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            GoalsByClasses = new HashSet<GoalsByClass>();
            LessonPlans = new HashSet<LessonPlan>();
            Papers = new HashSet<Paper>();
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string courseTitle { get; set; }

        public int? semesterID { get; set; }

        public int? gradeID { get; set; }

        public int? yearID { get; set; }

        public int? teacherID { get; set; }

        public int? schoolID { get; set; }

        public int? period { get; set; }

        public int? subjectID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Course Course1 { get; set; }

        public virtual Course Course2 { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual School School { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsByClass> GoalsByClasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonPlan> LessonPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paper> Papers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
