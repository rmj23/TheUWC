namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Glossary")]
    public partial class Glossary
    {
        public int glossaryID { get; set; }

        [StringLength(85)]
        public string term { get; set; }

        public string definition { get; set; }
    }
}
