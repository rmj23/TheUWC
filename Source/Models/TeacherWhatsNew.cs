namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherWhatsNew")]
    public partial class TeacherWhatsNew
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int twnID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime dateEntered { get; set; }

        public DateTime? dateUsed { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string description { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool isSelected { get; set; }
    }
}
