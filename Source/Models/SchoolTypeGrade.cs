namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolTypeGrade")]
    public partial class SchoolTypeGrade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int TypeID { get; set; }

        public int GradeID { get; set; }

        public virtual SchoolTypeGrade SchoolTypeGrade1 { get; set; }

        public virtual SchoolTypeGrade SchoolTypeGrade2 { get; set; }
    }
}
