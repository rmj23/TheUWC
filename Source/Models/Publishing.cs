namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publishing")]
    public partial class Publishing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publishing()
        {
            PublishingLookups = new HashSet<PublishingLookup>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string cHeader { get; set; }

        [StringLength(2000)]
        public string cDescription { get; set; }

        [StringLength(1000)]
        public string cFooter { get; set; }

        [StringLength(1)]
        public string cLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PublishingLookup> PublishingLookups { get; set; }
    }
}
