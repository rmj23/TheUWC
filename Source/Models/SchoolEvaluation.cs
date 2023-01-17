namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolEvaluation")]
    public partial class SchoolEvaluation
    {
        public int ID { get; set; }

        public int? schoolID { get; set; }

        public int? evaluationID { get; set; }

        public virtual EvaluationPeriod EvaluationPeriod { get; set; }

        public virtual School School { get; set; }
    }
}
