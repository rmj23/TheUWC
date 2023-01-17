namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequiredPoint
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Month { get; set; }

        public int Points { get; set; }
    }
}
