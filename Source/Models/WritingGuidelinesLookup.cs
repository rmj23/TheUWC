namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WritingGuidelinesLookup")]
    public partial class WritingGuidelinesLookup
    {
        public int ID { get; set; }

        public int? gradeID { get; set; }

        public int? monthID { get; set; }

        public int? guidelineID { get; set; }

        public int? levelID { get; set; }

        public virtual EvaluationPeriod EvaluationPeriod { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ScoringLevel ScoringLevel { get; set; }

        public virtual WritingGuideline1 WritingGuideline { get; set; }
    }
}
