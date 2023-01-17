namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ParentStudent")]
    public partial class ParentStudent
    {
        public int parentStudentID { get; set; }

        public int parentID { get; set; }

        public int studentID { get; set; }
    }
}
