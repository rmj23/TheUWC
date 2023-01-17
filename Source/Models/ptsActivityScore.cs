namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ptsActivityScore")]
    public partial class ptsActivityScore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ptsActivityScore()
        {
            ptsUserActivityScores = new HashSet<ptsUserActivityScore>();
        }

        [Key]
        public int scoreID { get; set; }

        public int? scoreAmount { get; set; }

        [StringLength(50)]
        public string activityDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ptsUserActivityScore> ptsUserActivityScores { get; set; }
    }
}
