namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EvaluationScore
    {
        public int ID { get; set; }

        public int ScoreTypeID { get; set; }

        public int EvaluationID { get; set; }

        [Required]
        [StringLength(2)]
        public string ScoreData { get; set; }

        public int ProficiencyTypeID { get; set; }

        public virtual Evaluation Evaluation { get; set; }

        public virtual ProficiencyType ProficiencyType { get; set; }

        public virtual ValidScoreType ValidScoreType { get; set; }
    }
}
