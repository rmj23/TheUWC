namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrgStructureLookup")]
    public partial class OrgStructureLookup
    {
        public int ID { get; set; }

        public int gradeID { get; set; }

        public int monthID { get; set; }

        public int levelID { get; set; }

        public int orgStructureID { get; set; }

        public virtual OrganizationStructure OrganizationStructure { get; set; }
    }
}
