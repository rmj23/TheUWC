using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public abstract class ACourseStudentYearSelectionViewModel
    {
        public enum CourseStudentYearSelectionState
        {
            Invalid,
            YearSelected,
            CourseSelected,
            StudentSelected
        }
        public int YearID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<StudentModel> Students { get; set; }
        public CourseStudentYearSelectionState State { get; set; }
        public ACourseStudentYearSelectionViewModel()
        {
            this.State = State;
        }
        public abstract void getNewPortfolio();
    }
    public abstract class ACourseStudentYearSelectionListViewModel
    {
        public enum CourseStudentYearSelectionListState
        {
            Invalid,
            YearSelected,
            CourseSelected,
            StudentSelected
        }
        //changed to not accept null
        public int YearID { get; set; }
        public int? CourseID { get; set; }
        public int? StudentID { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> StudentDropDown { get; set; }
        public CourseStudentYearSelectionListState State { get; set; }
        public ACourseStudentYearSelectionListViewModel()
        {
            this.State = CourseStudentYearSelectionListState.Invalid;
        }
    }

    public abstract class ACourseSelectionViewModel
    {
        public enum CourseSelectionState
        {
            Invalid,
            CourseSelected
        }
        public int CourseID { get; set; }
        public int? YearID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public CourseSelectionState State { get; set; }
        public ACourseSelectionViewModel()
        {
            this.State = CourseSelectionState.Invalid;
        }
        public abstract void CourseSelected();
    }
    public abstract class ASchoolEvalSelectionViewModel
    {
        public enum SchoolEvalSelectionState
        {
            Invalid,
            SchoolSelected,
            EvalPeriodSelected
        }
        public int UserID { get; set; }
        public int SchoolID { get; set; }
        public int EvalPeriodID { get; set; }
        public List<SelectListItem> SchoolDropDown { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public SchoolEvalSelectionState State { get; set; }
        public ASchoolEvalSelectionViewModel()
        {
            this.State = SchoolEvalSelectionState.Invalid;
        }
        public abstract void RefreshEvaluationPeriodDropDown();
    }
    public abstract class AStudentSelectionViewModel
    {
        public enum StudentSelectionState
        {
            Invalid,
            CourseSelected,
            StudentSelected
        }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> StudentDropDown { get; set; }
        public StudentSelectionState State { get; set; }
        public AStudentSelectionViewModel()
        {
            this.State = StudentSelectionState.Invalid;
        }
        public abstract void RefreshStudentDropDown();
    }
    public abstract class AYearCourseSelection
    {
        public enum YearCourseSelectionState
        {
            Invalid,
            YearSelected,
            CourseSelected
        }

        public int CourseID { get; set; }
        public int YearID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public YearCourseSelectionState State { get; set; }
        public AYearCourseSelection()
        {
            this.State = YearCourseSelectionState.Invalid;
        }
        public abstract void RefreshCourseDropDown(int teacherID);
    }
    public abstract class AEvalCourseSelection
    {
        public enum EvalCourseSelectionState
        {
            Invalid,
            EvalPeriodSelected,
            CourseSelected,
            YearSelected
        }
        public int? CourseID { get; set; }
        public int? EvalPeriodID { get; set; }
        public int? YearID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public EvalCourseSelectionState State { get; set; }
        public AEvalCourseSelection()
        {
            this.State = EvalCourseSelectionState.Invalid;
        }
    }

    public abstract class AEvalCourseSelectionWithoutNullables
    {
        public enum EvalCourseSelectionState
        {
            Invalid,
            EvalPeriodSelected,
            CourseSelected,
            YearSelected
        }
        public int CourseID { get; set; }
        public int EvalPeriodID { get; set; }
        public int YearID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public EvalCourseSelectionState State { get; set; }
        public AEvalCourseSelectionWithoutNullables()
        {
            this.State = EvalCourseSelectionState.Invalid;
        }
    }
    public abstract class AEvalCourseSelectionWithoutYear
    {
        public enum EvalCourseSelectionState
        {
            Invalid,
            EvalPeriodSelected,
            CourseSelected
        }
        public int CourseID { get; set; }
        public int EvalPeriodID { get; set; }
        public int YearID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public EvalCourseSelectionState State { get; set; }
        public AEvalCourseSelectionWithoutYear()
        {
            this.State = EvalCourseSelectionState.Invalid;
        }
    }

    public abstract class ASchoolGradeEvaluationPeriod
    {
        public enum UseForDistrictAdminBenchmark
        {
            Invalid,
            YearSelected,
            SchoolSelected,
            GradeLevelSelected,
            EvalPeriodSelected
        }
        public int UserID { get; set; }
        public int YearID { get; set; }
        public int SchoolID { get; set; }
        public int EvalPeriodID { get; set; }
        public int GradeLevelID { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public List<SelectListItem> SchoolDropDown { get; set; }
        public List<SelectListItem> GradeLevelDropDown { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public UseForDistrictAdminBenchmark State { get; set; }
        public ASchoolGradeEvaluationPeriod()
        {
            this.State = UseForDistrictAdminBenchmark.Invalid;
        }
        public abstract void RefreshSchoolDropDown();
        public abstract void RefreshGradeDropDown();
        public abstract void RefreshEvalDropDown();
    }

    public abstract class AYearGradeCourseEvaluationViewModel
    {
        public enum YearGradeCoursePeriod
        {
            Invalid,
            YearSelected,
            GradeLevelSelected,
            CourseSelected
        }
        public int SchoolID { get; set; }
        public int YearID { get; set; }
        public int GradeLevelID { get; set; }
        public int CourseID { get; set; }
        public YearGradeCoursePeriod State { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public List<SelectListItem> GradeLevelDropDown { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
    }
    public abstract class AGradeEvaluationPeriodViewModel
    {
        public enum GradeEvaluationPeriod
        {
            Invalid,
            GradeLevelSelected,
            EvalPeriodSelected,
            YearSelected,
            CourseSelected
        }
        public int EvalPeriodID { get; set; }
        public int GradeLevelID { get; set; }
        public int CourseID { get; set; }
        public int SchoolID { get; set; }
        public int YearID { get; set; }
        public GradeEvaluationPeriod State { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        public List<SelectListItem> GradeLevelDropDown { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
    }
    public abstract class ACoursePaperEvaluationViewModel
    {
        public enum CoursePaperEvaluation
        {
            Invalid,
            CourseSelected,
            PaperTypeSelected,
            EvaluationTypeSelected
        }
        public int CourseID { get; set; }
        public int PaperTypeID { get; set; }
        public int EvaluationTypeID { get; set; }
        public CoursePaperEvaluation State { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<SelectListItem> PaperTypeDropDown { get; set; }
        public List<SelectListItem> EvaluationTypeDropDown { get; set; }
    }
    public abstract class ADistrictSchoolSelection
    {
        public enum DistrictSchoolSelection
        {
            Invalid,
            DistrictSelected,
            SchoolSelected
        }
        public int DistrictID { get; set; }
        public int SchoolSelected { get; set; }
        public List<SelectListItem> DistrictDropDown { get; set; }
        public List<SelectListItem> SchoolDropDown { get; set; }
    }
    public abstract class APaperResultsSelection
    {
        public enum PaperResultSelection
        {
            Invalid,
            PaperSelected
        }
        public PaperResultSelection State { get; set; }
        public APaperResultsSelection()
        {
            this.State = PaperResultSelection.Invalid;
        }
        public int PaperID { get; set; }
        public List<SelectListItem> PaperDropDown { get; set; }
    }
    public abstract class AGroupSelectionViewModel
    {
        public enum GroupStudentSelectionState
        {
            Invalid,
            GroupSelected,
        }
        public int groupNumber { get; set; }
        public int studentId { get; set; }
        public List<SelectListItem> groupDdl { get; set; }
        public GroupStudentSelectionState State { get; set; }
        public AGroupSelectionViewModel()
        {
            this.State = State;
        }
    }
    public abstract class AYearCourseStudentMonthSelectionViewModel
    {
        public enum YearCourseStudentMonthSelectionState
        {
            Invalid,
            YearSelected,
            CourseSelected,
            StudentSelected,
            EvalMonthSelected
        }
        public int YearID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int EvalMonthID { get; set; }
        public List<SelectListItem> YearDropDown { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }
        public List<StudentModel> Students { get; set; }
        public List<SelectListItem> EvalMonthDropDown { get; set; }
        public YearCourseStudentMonthSelectionState State { get; set; }
        public AYearCourseStudentMonthSelectionViewModel()
        {
            this.State = State;
        }
    }
    public abstract class ACharacteristicElementSelectionViewModel
    {
        public enum CharacteristicElementSelectionState
        {
            Invalid,
            ElementSelected,
            CharacteristicSelected
        }
        public int ElementID { get; set; }
        public int CharacteristicID { get; set; }
        public List<SelectListItem> ElementDropDown { get; set; }
        public List<SelectListItem> CharacteristicDropDown { get; set; }
        public CharacteristicElementSelectionState State { get; set; }
        public ACharacteristicElementSelectionViewModel()
        {
            this.State = State;
        }
        public abstract void getNewCharacteristics(int elementID);
    }
    public abstract class AConferenceToolSelectionViewModel
    {
        public enum ConferenceToolSelectionState
        {
            Invaild,
            //Paper, Project, etc
            ConferenceTypeSelected,
            //Specfic paper or project using reference of conferenceType
            SourceSelected,
            //Again either paper elements or project elements will be selected
            ElementSelected,
            //Role of the person to review source document
            RoleHelpSelected
        }
        public int ConferenceTypeID { get; set; }
        public int SourceID { get; set; }
        public int ElementID { get; set; }
        public int RoleHelpID { get; set; }
        public List<SelectListItem> ConferenceTypeDropDown { get; set; }
        public List<SelectListItem> SourceDropDown { get; set; }
        public List<SelectListItem> ElementDropDown { get; set; }
        public List<SelectListItem> RoleHelpDropDown { get; set; }
        public ConferenceToolSelectionState State { get; set; }

    }

    public abstract class AGlobalRoleAssignmentSelection
    {
        public enum GlobalRoleAssignmentSelectionState
        {
            Invalid,
            RoleSelected
        }

        public int roleId { get; set; }
        public List<SelectListItem> rolesDropDown { get; set; }
        public GlobalRoleAssignmentSelectionState State { get; set; }

        public AGlobalRoleAssignmentSelection()
        {
            this.State = State;
        }

        public abstract void UpdateViews(int roleId);
    }
    public abstract class ATeacherRoleAssignmentSelection
    {
        public enum TeacherRoleAssignmentState
        {
            Invalid,
            DistrictSelected,
            SchoolSelected,
            RoleSelected
        }
        public int districtId { get; set; }
        public int schoolId { get; set; }
        public int roleId { get; set; }
        public TeacherRoleAssignmentState State { get; set; }
        public ATeacherRoleAssignmentSelection()
        {
            this.State = State;
        }
    }
}


