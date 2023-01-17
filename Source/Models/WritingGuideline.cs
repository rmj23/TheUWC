namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WritingGuideline")]
    public partial class WritingGuideline
    {
        public int ID { get; set; }

        public string content { get; set; }

        public string structure { get; set; }

        public string voice { get; set; }

        public string description { get; set; }

        public string fluency { get; set; }

        public string conventions { get; set; }

        public string presentation { get; set; }

        public string writingProcess { get; set; }

        public string research { get; set; }

        public string attitude { get; set; }

        public int? paperTypeID { get; set; }

        public int? gradeID { get; set; }
    }
}
