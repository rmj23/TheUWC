namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactRequest")]
    public partial class ContactRequest
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }

        public string Message { get; set; }

        [StringLength(50)]
        public string StreetNumber { get; set; }

        [StringLength(50)]
        public string StreetName { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
