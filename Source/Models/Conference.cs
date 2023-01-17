namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conference
    {
        [Key]
        [Column(Order = 0)]
        public int conferenceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int studentID { get; set; }

        public DateTime? date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int conferenceTypeID { get; set; }

        [StringLength(20)]
        public string stageOrDraft { get; set; }

        [StringLength(100)]
        public string comments { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }
    }
}
