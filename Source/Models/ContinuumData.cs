namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContinuumData")]
    public partial class ContinuumData
    {
        public int ID { get; set; }

        public int PaperTypeID { get; set; }

        public int EvaluationTypeID { get; set; }

        public int LevelID { get; set; }

        [Required]
        public string Guidelines { get; set; }

        public virtual ValidEvaluationType ValidEvaluationType { get; set; }

        public virtual twcLevel twcLevel { get; set; }

        public virtual PaperType PaperType { get; set; }
    }
}
