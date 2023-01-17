namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaperComment
    {
        [Key]
        [Column(Order = 0)]
        public int commentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int teacherID { get; set; }

        [Required]
        [StringLength(150)]
        public string commentDescription { get; set; }
    }
}
