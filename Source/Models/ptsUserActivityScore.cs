namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ptsUserActivityScore")]
    public partial class ptsUserActivityScore
    {
        public int ID { get; set; }

        public int scoreID { get; set; }

        public int userID { get; set; }

        public DateTime timestamp { get; set; }

        public virtual ptsActivityScore ptsActivityScore { get; set; }

        public virtual User User { get; set; }
    }
}
