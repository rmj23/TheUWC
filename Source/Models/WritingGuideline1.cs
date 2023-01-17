namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WritingGuidelines")]
    public partial class WritingGuideline1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WritingGuideline1()
        {
            WritingGuidelinesLookups = new HashSet<WritingGuidelinesLookup>();
        }

        public int ID { get; set; }

        public int paperTypeID { get; set; }

        public int evaluationTypeID { get; set; }

        [Required]
        public string guideline { get; set; }

        public int detailsID { get; set; }

        public virtual ValidEvaluationType ValidEvaluationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritingGuidelinesLookup> WritingGuidelinesLookups { get; set; }
    }
}
