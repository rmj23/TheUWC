namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class validPaperType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int paperTypeID { get; set; }

        [StringLength(35)]
        public string paperType { get; set; }
    }
}
