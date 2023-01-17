namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tmsTicket")]
    public partial class tmsTicket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tmsTicket()
        {
            tmsTicketAssignees = new HashSet<tmsTicketAssignee>();
            tmsTicketTypes = new HashSet<tmsTicketType>();
            tmsUpdates = new HashSet<tmsUpdate>();
            tmsUpdateRequests = new HashSet<tmsUpdateRequest>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Deadline { get; set; }

        public int? SubmitterID { get; set; }

        public bool? Acknowledged { get; set; }

        public bool? Resolved { get; set; }

        public DateTime? Completed { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        public string URL { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsTicketAssignee> tmsTicketAssignees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsTicketType> tmsTicketTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsUpdate> tmsUpdates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsUpdateRequest> tmsUpdateRequests { get; set; }
    }
}
