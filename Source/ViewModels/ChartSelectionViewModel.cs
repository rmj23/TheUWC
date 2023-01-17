using System;

namespace Source.Models
{
    public class ChartSelectionViewModel
    {
        public int PaperID { get; set; }
        public DateTime EvaluationDate { get; set; }
        public int ProficiencyID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        //public List<int> GroupedScores { get; set; }
        //public List<List<string>> LevelList { get; set; }
        //public string[] BelowArray { get; set; }
        //public string[] BasicArray { get; set; }
        //public string[] ProfArray { get; set; }
        //public string[] AdvancedArray { get; set; }
        //public string[] PlusArray { get; set; }


        //    public ChartSelectionViewModel(int teacherID)
        //    {
        //        Repository repo = new Repository();

        //        YearID = repo.SelectCurrentYearID();
        //        CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, YearID), true);
        //        EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAll(), true);
        //    }

        //    public ChartSelectionViewModel(int teacherID, int courseID)//This constructor is used when there is a default class selected.
        //    {
        //        Repository repo = new Repository();

        //        this.State = EvalCourseSelectionState.CourseSelected;
        //        this.CourseID = courseID;
        //        YearID = repo.SelectCurrentYearID();
        //        CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true, courseID);
        //        EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAll(), true);
        //    }
        //    public void RefreshData(int teacherID)
        //    {
        //        Repository repo = new Repository();

        //        //LevelList = ChartSelectionDB.ChartDataSelection(CourseID, EvalPeriodID);
        //        BelowArray = LevelList[4].ToArray();
        //        BasicArray = LevelList[3].ToArray();
        //        ProfArray = LevelList[2].ToArray();
        //        AdvancedArray = LevelList[1].ToArray();
        //        PlusArray = LevelList[0].ToArray();

        //        GroupedScores = new List<int> { LevelList[0].Count, LevelList[1].Count, LevelList[2].Count, LevelList[3].Count, LevelList[4].Count };
        //        CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);
        //        EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAll(), true);
        //    }
    }

    //public static class CustomJavascriptSerialier
    //{
    //    public static string Serialize(object o)
    //    {
    //        JavaScriptSerializer js = new JavaScriptSerializer();
    //        return js.Serialize(o);
    //    }
    //}

    //public static class ChartSelectionDB
    //{
    //    public static List<List<string>> ChartDataSelection(int courseID, int EvalPeriodID)
    //    {
    //        List<string> BelowList = new List<string>();
    //        List<string> BasicList = new List<string>();
    //        List<string> ProficientList = new List<string>();
    //        List<string> AdvancedList = new List<string>();
    //        List<string> PlusList = new List<string>();
    //        List<List<string>> levelList = new List<List<string>>() { PlusList, AdvancedList, ProficientList, BasicList, BelowList };

    //        var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        var cmd = new SqlCommand("PaperDataForChart", conn);
    //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@courseID", courseID);
    //        cmd.Parameters.AddWithValue("@evaluationPeriodID", EvalPeriodID);
    //        try
    //        {
    //            conn.Open();
    //            var dtr = cmd.ExecuteReader();
    //            {
    //                while (dtr.Read())
    //                {
    //                    int score = Convert.ToInt32(dtr["ProficiencyID"]);
    //                    string fName = dtr["firstName"].ToString();
    //                    string lName = dtr["lastName"].ToString();
    //                    string name = " " + fName + " " + lName;

    //                    switch (score)
    //                    {
    //                        //Below Basic
    //                        case 1:
    //                            BelowList.Add(name);
    //                            break;
    //                        //Basic
    //                        case 2:
    //                            BasicList.Add(name);
    //                            break;
    //                        //Proficient
    //                        case 3:
    //                            ProficientList.Add(name);
    //                            break;
    //                        //Advanced
    //                        case 4:
    //                            AdvancedList.Add(name);
    //                            break;
    //                        //Advanced+
    //                        case 5:
    //                            PlusList.Add(name);
    //                            break;


    //                    }
    //                }
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            ErrorModelDb.InsertSqlError(ex.ToString());
    //        }
    //        finally { conn.Close(); }
    //        return levelList;
    //    }
    //}

}
