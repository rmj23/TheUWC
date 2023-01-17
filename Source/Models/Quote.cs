namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quote
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Author { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateLastUsed { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool used { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool currentQuote { get; set; }
    }
}
