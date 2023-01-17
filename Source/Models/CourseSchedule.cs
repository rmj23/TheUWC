namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseSchedule")]
    public partial class CourseSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSchedule()
        {
            twcGuidelineProficiencies = new HashSet<twcGuidelineProficiency>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ScheduleDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }
    }
}
