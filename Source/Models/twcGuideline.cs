namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("twcGuideline")]
    public partial class twcGuideline
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public twcGuideline()
        {
            twcGuidelineProficiencies = new HashSet<twcGuidelineProficiency>();
        }

        public int ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string GuidelineText { get; set; }

        public int PaperTypeID { get; set; }

        public int EvaluationTypeID { get; set; }

        public int LevelID { get; set; }

        public virtual PaperType PaperType { get; set; }

        public virtual ValidScoreType ValidScoreType { get; set; }

        public virtual twcLevel twcLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }
    }
}
