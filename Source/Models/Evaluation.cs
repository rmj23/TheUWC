namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluation")]
    public partial class Evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evaluation()
        {
            EvaluationScores = new HashSet<EvaluationScore>();
            Papers = new HashSet<Paper>();
        }

        public int ID { get; set; }

        public int PaperID { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        [StringLength(500)]
        public string StudentFeedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluationScore> EvaluationScores { get; set; }

        public virtual Paper Paper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paper> Papers { get; set; }
    }
}
