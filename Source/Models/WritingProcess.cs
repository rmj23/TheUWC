namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WritingProcess")]
    public partial class WritingProcess
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string cHeader { get; set; }

        [StringLength(2000)]
        public string cDescription { get; set; }

        [StringLength(500)]
        public string cFooter { get; set; }

        [StringLength(1)]
        public string cLevel { get; set; }
    }
}
