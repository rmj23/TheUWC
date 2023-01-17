namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmsSchoolInfo")]
    public partial class cmsSchoolInfo
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SchoolCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Zip { get; set; }

        [StringLength(50)]
        public string Principal { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string AstPrincipal { get; set; }

        [StringLength(50)]
        public string AstPhone { get; set; }

        [StringLength(50)]
        public string LC { get; set; }

        [StringLength(50)]
        public string LCPhone { get; set; }

        [StringLength(50)]
        public string AP { get; set; }

        [StringLength(50)]
        public string APPhone { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string GradeLevels { get; set; }

        [StringLength(50)]
        public string LicensesPurchased { get; set; }
    }
}
