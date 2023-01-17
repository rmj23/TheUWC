using Source.Data;
using System.Collections.Generic;

namespace Source.Models

{

    public class ViewClassDataViewModel
    {
        public List<ClassDataModel> ClassData { get; set; }
        //public List<int> ScoreTypeList { get; set; }
        //public int[,] ScoreCheckArray { get; set; }
        public List<ProficiencyTypeModel> ProficiencyType { get; set; }
        public List<EvaluationTypeModel> EvaluationType { get; set; }
        public ViewClassDataViewModel(int teacherID)
        {
            Repository repo = new Repository();

            EvaluationType = repo.EvaluationSelectAllWithConventions();
            ProficiencyType = repo.ProficiencyTypeModelSelectAll();

        }

        //public void RefreshData(int teacherID)
        //{
        //    Repository repo = new Repository();
        //    //CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);
        //    //ClassData = repo.ClassDataSelectAllByClassID((int)CourseID, (int)EvalPeriodID, (int)YearID);
        //    //ClassData = ClassDataModelDB.SelectAllByClassID((int)CourseID, (int)EvalPeriodID, (int)YearID);
        //    RefreshList(ClassData);
        //}

        //public void RefreshList(List<ClassDataModel> ClassData)
        //{
        //  //Empty lists for keeping track of scored paper
        //    List<int> scoreTypeList = new List<int>(new int[] {0,0,0,0,0,0,0,0,0,0,0,0});
        //    int[,] scoreArray = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 },
        //   { 0,0,0,0,0},{ 0,0,0,0,0},{ 0,0,0,0,0},{ 0,0,0,0,0},{ 0,0,0,0,0}};
        //    for (var j = 0; j < 12; j++)
        //    {
        //        for (var i = 0; i < 5; i++)
        //        {
        //            foreach (var score in ClassData)
        //            {
        //                if (score.ScoreTypeID - 1 == j && score.ProficiencyTypeID - 1 == i)
        //                {
        //                    var k = scoreTypeList[j] + 1;
        //                    scoreTypeList[j] = k;
        //                    var z = scoreArray[j,i] + 1;
        //                    scoreArray[j, i] = z;

        //                }
        //            }
        //        }
        //    }
        //    ScoreTypeList = scoreTypeList;
        //    ScoreCheckArray = scoreArray;

        //}
    }
}