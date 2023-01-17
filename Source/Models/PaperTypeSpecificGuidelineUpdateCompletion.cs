namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaperTypeSpecificGuidelineUpdateCompletion")]
    public partial class PaperTypeSpecificGuidelineUpdateCompletion
    {
        public int ID { get; set; }

        public int paperTypeID { get; set; }

        public int writingGuidelineDetailsID { get; set; }

        public int evaluationTypeID { get; set; }
    }
}
