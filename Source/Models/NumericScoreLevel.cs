namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NumericScoreLevel")]
    public partial class NumericScoreLevel
    {
        public int ID { get; set; }

        [StringLength(2)]
        public string scoreLevelName { get; set; }
    }
}
