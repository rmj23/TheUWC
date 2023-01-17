using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MonthlyPointWinnersViewModel
    {
        public List<UserModel> Winners { get; set; }
        public List<UserModel> PreviousWinners { get; set; }
        public List<string> PreviousMonths { get; set; }
        public MonthlyPointWinnersViewModel()
        {
            Repository repo = new Repository();
            List<PointWinnersModel> winners = new List<PointWinnersModel>();
            winners = repo.SelectWinnersUserIDs();
            Winners = GetUsersFromIDs(winners);
            List<PointWinnersModel> previousWinners = repo.SelectPreviousWinnersIds();
            PreviousWinners = GetUsersFromIDs(previousWinners);
            PreviousMonths = GetPreviousWinnerMonths(previousWinners);
        }
        private List<UserModel> GetUsersFromIDs(List<PointWinnersModel> UserIds)
        {
            List<UserModel> output = new List<UserModel>();
            Repository repo = new Repository();
            for (int i = 0; i < UserIds.Count; i++)
            {
                var user = repo.UserSelectOne(UserIds[i].ID);
                output.Add(user);
            }
            return output;
        }
        private List<string> GetPreviousWinnerMonths(List<PointWinnersModel> previousWinners)
        {
            List<string> months = new List<string>();
            foreach (var winner in previousWinners)
            {
                months.Add(winner.Month);
            }
            return months;

        }
    }
}