using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EngagementsViewModel
    {
        public EngagementModel Engagement { get; set; }
        public List<EngagementModel> Engagements { get; set; }
        public List<SelectListItem> GradeLevelRange { get; set; }
        public int GradeLevelRangeID { get; set; }
        public EngagementsViewModel(int Id)
        {
            Repository repo = new Repository();



            //if (ID != null)
            //{
                Engagement = repo.EngagementSelectOne(Id);
            //}
            //if (GradeLevelRangeID != 0)
            //{
            //    GradeLevelRange = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
            //    Engagements = repo.EngagementSelectByGradeLevelRange(GradeLevelRangeID);
            //    //Engagements = EngagementModelDB.SelectByGradeLevelRange(GradeLevelRangeID);
            //    //var x = repo.EngagementSelectByGradeLevelRange(GradeLevelRangeID);
            //}
            //else
            //{
                // when user enters to the engagement webpage it sets k-1 data as default
                //Engagements = repo.EngagementSelectByGradeLevelRange(1);
                //Engagements = EngagementModelDB.SelectByGradeLevelRange(1);
                //GradeLevelRange = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());

            //}
        }
    }
}