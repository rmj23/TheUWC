using Source.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Source.Models
{
    public class ViewBookshelfViewModel
    {
        public List<PaperModel> Papers { get; set; }
        public int CourseID { get; set; }
        public int BookshelfContentId { get; set; }
        public int PaperFilterID { get; set; }
        public List<SelectListItem> BookshelfContentLkp { get; set; }
        public List<BookshelfPaperModel> BookshelfPapers { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public List<SelectListItem> BookshelfFilter { get; set; }
        public ViewBookshelfViewModel() { }

        public ViewBookshelfViewModel(int studentId)
        {
            Repository repo = new Repository();

            Papers = new List<PaperModel>();
            Classes = ClassModelControls.GetSelectListItems(repo.ClassModelSelectAllByStudent(studentId));
        }

        public void getBookShelfPapersClass(int courseId)
        {
            Repository repo = new Repository();

            BookshelfPapers = repo.BookshelfPaperSelectAllInClass(courseId);
            //BookshelfPapers = BookshelfPaperModelDb.selectAllInClass(courseId);
            BookshelfPapers = BookshelfPapers.Where(e => e.contentTypeId == BookshelfContentId).ToList();
            Papers = new List<PaperModel>();
            foreach (var paper in BookshelfPapers)
            {
                var PaperModel = repo.PaperModelSelectOneByPaperID(paper.paperId);
                var Student = repo.StudentModelSelectOne(paper.studentId);
                PaperModel.firstName = Student.FirstName;
                PaperModel.lastName = Student.LastName;
                Papers.Add(PaperModel);
            }
        }

        public void getBookShelfPapersDistrict(int districtId)
        {
            Repository repo = new Repository();

            BookshelfPapers = repo.BookshelfPaperSelectAllInDistrict(districtId);
            //BookshelfPapers = BookshelfPaperModelDb.SelectAllInDistrict(districtId);
            BookshelfPapers = BookshelfPapers.Where(e => e.contentTypeId == BookshelfContentId).ToList();
            Papers = new List<PaperModel>();
            foreach (var paper in BookshelfPapers)
            {
                var PaperModel = repo.PaperModelSelectOneByPaperID(paper.paperId);
                var Student = repo.StudentModelSelectOne(paper.studentId);
                PaperModel.firstName = Student.FirstName;
                PaperModel.lastName = Student.LastName;
                Papers.Add(PaperModel);
            }
        }

        public void getBookShelfPapersSchool(int schoolId)
        {
            Repository repo = new Repository();

            BookshelfPapers = repo.BookshelfPaperSelectAllInSchool(schoolId);
            //BookshelfPapers = BookshelfPaperModelDb.SelectAllInSchool(schoolId);
            BookshelfPapers = BookshelfPapers.Where(e => e.contentTypeId == BookshelfContentId).ToList();
            Papers = new List<PaperModel>();
            foreach (var paper in BookshelfPapers)
            {
                var PaperModel = repo.PaperModelSelectOneByPaperID(paper.paperId);
                var Student = repo.StudentModelSelectOne(paper.studentId);
                PaperModel.firstName = Student.FirstName;
                PaperModel.lastName = Student.LastName;
                Papers.Add(PaperModel);
            }
        }
    }
}