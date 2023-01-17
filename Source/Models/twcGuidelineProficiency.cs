namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("twcGuidelineProficiency")]
    public partial class twcGuidelineProficiency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public twcGuidelineProficiency()
        {
            twcGuidelines = new HashSet<twcGuideline>();
        }

        public int ID { get; set; }

        public int GradeID { get; set; }

        public int EvaluationPeriodID { get; set; }

        public int ScheduleID { get; set; }

        public int ScoringLevelID { get; set; }

        public virtual CourseSchedule CourseSchedule { get; set; }

        public virtual EvaluationPeriod EvaluationPeriod { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ScoringLevel ScoringLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuideline> twcGuidelines { get; set; }
    }
}
