using System.Collections.Generic;

namespace Source.Models
{
    public class ViewPortfolioViewModel
    {
        public PaperModel Paper { get; set; }
        public List<PaperModel> AllPapers { get; set; }
        /// <summary>
        /// List of student IDs that have a paper not graded for specific course
        /// </summary>
        public List<int> StudentsNeedGrading { get; set; }
        /// <summary>
        /// List of Student IDs that do not have a paper entered for a specific course and month
        /// </summary>
        public List<int> StudentMonthNeedUpload { get; set; }

    }

}
