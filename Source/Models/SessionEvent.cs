namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SessionEvent")]
    public partial class SessionEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SessionEvent()
        {
            PageEvents = new HashSet<PageEvent>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ipID { get; set; }

        public int? userID { get; set; }

        public DateTime? startTime { get; set; }

        public DateTime? endTime { get; set; }

        public virtual IPAdress IPAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageEvent> PageEvents { get; set; }

        public virtual User User { get; set; }
    }
}
