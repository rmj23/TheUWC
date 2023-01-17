namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConceptsPrintLookup")]
    public partial class ConceptsPrintLookup
    {
        public int ID { get; set; }

        public int? gradeID { get; set; }

        public int? monthID { get; set; }

        public int? levelID { get; set; }

        public int? conceptsID { get; set; }

        public virtual ConceptsPrint ConceptsPrint { get; set; }
    }
}
