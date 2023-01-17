namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class validGoalTopic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public validGoalTopic()
        {
            GoalsIndividualStudents = new HashSet<GoalsIndividualStudent>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsIndividualStudent> GoalsIndividualStudents { get; set; }
    }
}
