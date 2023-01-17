namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblError")]
    public partial class tblError
    {
        public int ID { get; set; }

        [Required]
        public string errorDescription { get; set; }
    }
}
