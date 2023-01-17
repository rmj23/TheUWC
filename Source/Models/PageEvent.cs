namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageEvent")]
    public partial class PageEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageEvent()
        {
            PageEvent1 = new HashSet<PageEvent>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int sessionEventID { get; set; }

        [StringLength(100)]
        public string startURL { get; set; }

        public int? prevPageEventID { get; set; }

        public DateTime? timeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageEvent> PageEvent1 { get; set; }

        public virtual PageEvent PageEvent2 { get; set; }

        public virtual SessionEvent SessionEvent { get; set; }
    }
}
