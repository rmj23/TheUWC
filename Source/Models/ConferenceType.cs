namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConferenceType
    {
        public int conferenceTypeID { get; set; }

        [StringLength(50)]
        public string description { get; set; }
    }
}
