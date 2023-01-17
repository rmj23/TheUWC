namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentBank")]
    public partial class CommentBank
    {
        public int ID { get; set; }

        public int TeacherID { get; set; }

        [StringLength(400)]
        public string Comment { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
