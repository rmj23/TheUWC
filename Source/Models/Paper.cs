namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paper")]
    public partial class Paper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paper()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public int PaperID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public DateTime UploadDate { get; set; }

        public int? PaperType { get; set; }

        [Column("Paper")]
        public byte[] Paper1 { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string PaperTitle { get; set; }

        public int? EvaluationPeriodID { get; set; }

        [StringLength(20)]
        public string HolisticScoreLetter { get; set; }

        public int? EvaluationID { get; set; }

        public int? Draft { get; set; }

        public bool? Continuing { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public virtual Evaluation Evaluation { get; set; }

        public virtual EvaluationPeriod EvaluationPeriod { get; set; }

        public virtual Student Student { get; set; }
    }
}
