namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartLookup")]
    public partial class ChartLookup
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string monthID { get; set; }

        public int gradeID { get; set; }

        public int NSLID { get; set; }

        public int scoreLevelID { get; set; }

        public int posOnChart { get; set; }
    }
}
