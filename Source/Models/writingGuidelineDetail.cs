namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class writingGuidelineDetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(1)]
        public string score { get; set; }

        [Required]
        [StringLength(100)]
        public string averageTimePeriod { get; set; }

        [StringLength(100)]
        public string title { get; set; }
    }
}
