
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ProjectIdeasCulminatingActivitiesInsertViewModel
    {
        public List<SelectListItem> GradeLevels { get; set; }
        public ProjectIdeasCulminatingActivitiesModel PICAModel { get; set; }
        public List<ProjectIdeasCulminatingActivitiesModel> Models { get; set; }
    }
}