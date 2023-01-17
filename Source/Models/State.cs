namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        [StringLength(5)]
        public string ID { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }
    }
}
