namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("engSubtypeGrade")]
    public partial class engSubtypeGrade
    {
        public int ID { get; set; }

        public int? subtypeID { get; set; }

        public int? gradeID { get; set; }

        public virtual engSubtype engSubtype { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
