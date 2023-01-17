namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WritingRangeLookup")]
    public partial class WritingRangeLookup
    {
        public int ID { get; set; }

        public int? gradeID { get; set; }

        public int? monthID { get; set; }

        public int? levelID { get; set; }

        public int? writingRangeID { get; set; }

        public virtual WritingRange WritingRange { get; set; }
    }
}
