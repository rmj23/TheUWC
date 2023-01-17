namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Greeting
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column("Greeting", Order = 1)]
        [StringLength(100)]
        public string Greeting1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateLastUsed { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool currentGreeting { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool used { get; set; }
    }
}
