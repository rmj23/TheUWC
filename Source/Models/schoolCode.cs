namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class schoolCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public schoolCode()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int ID { get; set; }

        [Column("schoolCode")]
        [Required]
        [StringLength(20)]
        public string schoolCode1 { get; set; }

        public int schoolID { get; set; }

        public int? numberOfCodesUsed { get; set; }

        public int? totalNumberofCodes { get; set; }

        public int districtID { get; set; }

        public virtual District District { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
