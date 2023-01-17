namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChartLookup2
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string monthID { get; set; }

        public int? gradeID { get; set; }

        public int? NSLID { get; set; }

        public int? scoreLevelID { get; set; }

        public int? posOnChart { get; set; }
    }
}
