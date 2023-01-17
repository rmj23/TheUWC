namespace Source.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GuidelineUpdateCompletion")]
    public partial class GuidelineUpdateCompletion
    {
        public int ID { get; set; }

        public int? IdeasContentID { get; set; }

        public int? OrganizationStructureID { get; set; }

        public int? VoiceID { get; set; }

        public int? WordChoiceID { get; set; }

        public int? SentenceStructureID { get; set; }

        public int? ConventionsID { get; set; }

        public int? PublishingID { get; set; }

        public int? WritingProcessID { get; set; }

        public int? ResearchID { get; set; }

        public int? AttitudeRangeID { get; set; }

        public int writingGuideLineDetailsID { get; set; }
    }
}
