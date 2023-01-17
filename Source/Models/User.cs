namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            PointWinners = new HashSet<PointWinner>();
            ptsUserActivityScores = new HashSet<ptsUserActivityScore>();
            SessionEvents = new HashSet<SessionEvent>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
            tmsTickets = new HashSet<tmsTicket>();
            tmsUpdateRequests = new HashSet<tmsUpdateRequest>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string middleName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string pwd { get; set; }

        public int roleID { get; set; }

        public bool? active { get; set; }

        public int? schoolID { get; set; }

        public int? districtID { get; set; }

        [StringLength(50)]
        public string phoneNumber { get; set; }

        public bool? participate { get; set; }

        public bool? testAccount { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public string passwordHash { get; set; }

        public string salt { get; set; }

        public virtual District District { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PointWinner> PointWinners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ptsUserActivityScore> ptsUserActivityScores { get; set; }

        public virtual Role Role { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionEvent> SessionEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsTicket> tmsTickets { get; set; }

        public virtual tmsTicketAssignee tmsTicketAssignee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmsUpdateRequest> tmsUpdateRequests { get; set; }
    }
}
