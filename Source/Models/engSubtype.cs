namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("engSubtype")]
    public partial class engSubtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public engSubtype()
        {
            engEngagements = new HashSet<engEngagement>();
            engSubtypeGrades = new HashSet<engSubtypeGrade>();
            engKeywords = new HashSet<engKeyword>();
        }

        public int ID { get; set; }

        public int ModuleID { get; set; }

        public int? TypeID { get; set; }

        [Column(TypeName = "text")]
        public string Contents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<engEngagement> engEngagements { get; set; }

        public virtual engModule engModule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<engSubtypeGrade> engSubtypeGrades { get; set; }

        public virtual engValidSubtype engValidSubtype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<engKeyword> engKeywords { get; set; }
    }
}
