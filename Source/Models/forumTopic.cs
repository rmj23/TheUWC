namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class forumTopic
    {
        [Key]
        public int bcId { get; set; }

        [StringLength(255)]
        public string bcTitle { get; set; }

        [Column(TypeName = "text")]
        public string bcDesc { get; set; }

        public int? bcOrder { get; set; }

        public DateTime? bcLastUpdate { get; set; }
    }
}
