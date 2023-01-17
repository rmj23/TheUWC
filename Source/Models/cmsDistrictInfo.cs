namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cmsDistrictInfo")]
    public partial class cmsDistrictInfo
    {
        [Key]
        public int DistrictID { get; set; }

        [StringLength(50)]
        public string DistrictCode { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }

        [StringLength(50)]
        public string StreetAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Super { get; set; }

        [StringLength(50)]
        public string AsstSuper { get; set; }

        [StringLength(50)]
        public string CurrCoordinator { get; set; }

        [StringLength(50)]
        public string AccountsPayable { get; set; }

        [StringLength(50)]
        public string ElementarySchools { get; set; }

        [StringLength(50)]
        public string MiddleSchools { get; set; }

        [StringLength(50)]
        public string HighSchools { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string LicensesPurchased { get; set; }
    }
}
