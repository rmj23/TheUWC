namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grade")]
    public partial class Grade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grade()
        {
            Courses = new HashSet<Course>();
            engSubtypeGrades = new HashSet<engSubtypeGrade>();
            twcGuidelineProficiencies = new HashSet<twcGuidelineProficiency>();
            SchoolGrades = new HashSet<SchoolGrade>();
            WritingGuidelinesLookups = new HashSet<WritingGuidelinesLookup>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string gradeDescription { get; set; }

        [StringLength(10)]
        public string gradeLetter { get; set; }

        public int? gradeOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<engSubtypeGrade> engSubtypeGrades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritingGuidelinesLookup> WritingGuidelinesLookups { get; set; }
    }
}
