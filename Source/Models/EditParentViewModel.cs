using Source.Data;

namespace Source.Models
{
    public class EditParentViewModel
    {
        public ParentModel Parent { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public EditParentViewModel(int? userID)
        {
            Repository repo = new Repository();

            Parent = repo.ParentModelSelectOneByUserID((int)userID);
        }
        public EditParentViewModel()
        {

        }
    }
}