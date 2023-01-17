namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvaluationPeriod")]
    public partial class EvaluationPeriod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvaluationPeriod()
        {
            twcGuidelineProficiencies = new HashSet<twcGuidelineProficiency>();
            Papers = new HashSet<Paper>();
            SchoolEvaluations = new HashSet<SchoolEvaluation>();
            WritingGuidelinesLookups = new HashSet<WritingGuidelinesLookup>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string evalDescription { get; set; }

        public int? monthOrder { get; set; }

        public int? monthConverter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paper> Papers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolEvaluation> SchoolEvaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritingGuidelinesLookup> WritingGuidelinesLookups { get; set; }
    }
}
