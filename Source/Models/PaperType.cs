namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaperType")]
    public partial class PaperType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaperType()
        {
            ContinuumDatas = new HashSet<ContinuumData>();
            twcGuidelines = new HashSet<twcGuideline>();
        }

        public int ID { get; set; }

        [Column("paperType")]
        [Required]
        [StringLength(100)]
        public string paperType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContinuumData> ContinuumDatas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<twcGuideline> twcGuidelines { get; set; }
    }
}
