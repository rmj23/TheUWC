namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPAddressCity")]
    public partial class IPAddressCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IPAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }
    }
}
