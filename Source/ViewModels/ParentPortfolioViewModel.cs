using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ParentPortfolioViewModel
    {
        public List<MyStudentPortfolioViewModel> AllStudents { get; set; }
        public List<StudentModel> AllStudentsModel { get; set; }
        //public ParentPortfolioViewModel(int parentID)
        //{
        //    Repository repo = new Repository();
        //    List<MyStudentPortfolioViewModel> allStudents = new List<MyStudentPortfolioViewModel>();
        //    AllStudentsModel = repo.StudentModelSelectAllByParentID(parentID);
        //    foreach (var student in AllStudentsModel)
        //    {
        //        allStudents.Add(new MyStudentPortfolioViewModel(student.StudentID));
        //    }
        //    AllStudents = allStudents;
        //}
    }

}