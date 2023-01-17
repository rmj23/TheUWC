using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MonthlyPointsContestantsViewModel
    {
        public List<UserModel> Contestants { get; set; }
        public MonthlyPointsContestantsViewModel()
        {
            Repository repo = new Repository();
            Contestants = repo.SelectContestants();
        }
    }
}