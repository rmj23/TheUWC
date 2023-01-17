namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherMood")]
    public partial class TeacherMood
    {
        public int ID { get; set; }

        public int? TeacherID { get; set; }

        [StringLength(300)]
        public string Mood { get; set; }

        [StringLength(300)]
        public string MoodVal { get; set; }
    }
}
