using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MonthlyPointsViewModel
    {
        public List<MonthlyPointsModel> Months { get; set; }
        public MonthlyPointsViewModel()
        {
            Repository repo = new Repository();

            Months = repo.MonthlyPointModelSelectAll();
        }
    }
}