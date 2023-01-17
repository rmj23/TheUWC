namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScoringLevel")]
    public partial class ScoringLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScoringLevel()
        {
            twcGuidelineProficiencies = new HashSet<twcGuidelineProficiency>();
            WritingGuidelinesLookups = new HashSet<WritingGuidelinesLookup>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string sDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritingGuidelinesLookup> WritingGuidelinesLookups { get; set; }
    }
}
