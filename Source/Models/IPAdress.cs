namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPAdress")]
    public partial class IPAdress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IPAdress()
        {
            SessionEvents = new HashSet<SessionEvent>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(15)]
        public string ipAddress { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string region { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(10)]
        public string zip { get; set; }

        [StringLength(50)]
        public string organization { get; set; }

        [StringLength(100)]
        public string isp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionEvent> SessionEvents { get; set; }
    }
}
