namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvatarImg")]
    public partial class AvatarImg
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string imgSrc { get; set; }
    }
}
