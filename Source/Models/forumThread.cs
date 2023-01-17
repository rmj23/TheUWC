namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class forumThread
    {
        [Key]
        public int psId { get; set; }

        public int? psRelTopId { get; set; }

        [StringLength(255)]
        public string psName { get; set; }

        [StringLength(255)]
        public string psEmail { get; set; }

        [StringLength(255)]
        public string psSubject { get; set; }

        [Column(TypeName = "text")]
        public string psPost { get; set; }

        public DateTime? psDate { get; set; }

        public int? psRelBcId { get; set; }

        public DateTime? psLastUpdate { get; set; }

        [StringLength(20)]
        public string psIP { get; set; }
    }
}
