namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("engEngagement")]
    public partial class engEngagement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public engEngagement()
        {
            engKeywords = new HashSet<engKeyword>();
        }

        public int ID { get; set; }

        public int? SubtypeID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int? OrderNumber { get; set; }

        [Column(TypeName = "text")]
        public string Contents { get; set; }

        public virtual engSubtype engSubtype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<engKeyword> engKeywords { get; set; }
    }
}
