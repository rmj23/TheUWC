using System;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class ClassGoalsModel
    {
        public int ID { get; set; }
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please enter a goal description.")]
        public string FullDescription { get; set; }
        [Required]
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeadlineDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinished { get; set; }
        public string CourseTitle { get; set; }
    }
}
