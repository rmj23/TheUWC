namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("District")]
    public partial class District
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public District()
        {
            schoolCodes = new HashSet<schoolCode>();
            Schools = new HashSet<School>();
            Users = new HashSet<User>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DistrictName { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(5)]
        public string Code { get; set; }

        [StringLength(50)]
        public string SuperintendentName { get; set; }

        [StringLength(50)]
        public string SuperintendentEmail { get; set; }

        [StringLength(50)]
        public string SuperintendentPhone { get; set; }

        [StringLength(50)]
        public string AstSuperintendentName { get; set; }

        [StringLength(50)]
        public string AstSuperintendentEmail { get; set; }

        [StringLength(50)]
        public string AstSuperintendentPhone { get; set; }

        [StringLength(50)]
        public string CurriculumCoordinatorName { get; set; }

        [StringLength(50)]
        public string CurriculumCoordinatorEmail { get; set; }

        [StringLength(50)]
        public string AccountsPayableName { get; set; }

        [StringLength(5)]
        public string ElemSchoolNumber { get; set; }

        [StringLength(5)]
        public string MidSchoolNumber { get; set; }

        [StringLength(5)]
        public string HighSchoolNumber { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(5)]
        public string LicensesPurchased { get; set; }

        [StringLength(50)]
        public string DistrictAdminName { get; set; }

        [StringLength(50)]
        public string DistrictAdminEmail { get; set; }

        [StringLength(50)]
        public string DistrictAdminPhone { get; set; }

        [StringLength(50)]
        public string AccountsPayableEmail { get; set; }

        [StringLength(50)]
        public string AccountsPayablePhone { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(15)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string CurriculumCoordinatorPhone { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schoolCode> schoolCodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<School> Schools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
