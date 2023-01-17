using Dapper;
using DevOne.Security.Cryptography.BCrypt;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Source.Data
{
    public class Repository
    {
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            return conn;
        }
        //Select All Users
        public List<UserModel> UserSelectAll()
        {
            List<UserModel> output = new List<UserModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("UserSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.ToString());
            }
            return output;
        }

        // insert sql error
        public void InsertSqlError(string errorMessage)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Query("tblErrorInsert", new
                {
                    @errorTypeID = 1,
                    @errorMessage = errorMessage,
                    @timeStamp = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
            }
        }

        // academic year select all
        public List<AcademicYearModel> SelectAllAcademicYearModels()
        {
            var output = new List<AcademicYearModel>();
            try
            {
                using (var conn = GetConnection()) //Dapper will close the connection for us when it's done.
                {
                    output = conn.Query<AcademicYearModel>("AcademicYearSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // select current year id
        public int SelectCurrentYearID()
        {
            int output = 0;
            try
            {
                using (var conn = GetConnection())
                {
                    output = conn.Query<int>("SelectCurrentYearID", commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        //user register
        public UserModel InsertUser(LoginModel login, UserModel user)
        {
            UserModel output = null;
            try
            {
                using (var conn = GetConnection())
                {
                    output = conn.Query<UserModel>("UserRegister", new
                    {
                        @email = login.UserName,
                        @passwordHash = login.Hash,
                        @salt = login.Salt,
                        @firstname = user.FirstName,
                        @lastName = user.LastName,
                        @roleID = user.RoleID,
                        @schoolCode = login.schoolCode,
                        @globalRoleId = user.globalRoleId,
                        @isVerified = false
                    }, commandType: CommandType.StoredProcedure).First();
                }
            }
            catch (Exception ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        //user login
        public UserModel Login(LoginModel login)
        {
            UserModel output = null;
            try
            {
                using (var conn = GetConnection())
                {
                    output = conn.Query<UserModel>("UserLogin", new
                    {
                        @email = login.UserName,
                        @passwordHash = login.Hash
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        // user get salt
        public string RetrieveSalt(string username)
        {
            string output = null;
            try
            {
                using (var conn = GetConnection())
                {
                    output = conn.Query<string>("UserGetSalt", new
                    {
                        @email = username
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        // reset password
        public void ResetPassword(LoginModel login)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Query<int>("UserResetPassword", new
                    {
                        @email = login.UserName,
                        @passwordHash = login.Hash,
                        @salt = login.Salt
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // class select all by teacher and year
        public List<ClassModel> SelectAllByTeacherAndYear(int TeacherID, int YearID)
        {
            List<ClassModel> output = new List<ClassModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllByTeacherAndYear", new
                    {
                        @teacherID = TeacherID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // student select all by class
        public List<StudentModel> SelectAllByClass(int? CourseID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllByClass", new
                    {
                        @classID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // goals select by student
        public List<StudentGoalsModel> GoalsSelectByStudent(int? StudentID)
        {
            List<StudentGoalsModel> output = new List<StudentGoalsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentGoalsModel>("GoalsSelectByStudentID", new
                    {
                        @studentID = StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }
        public List<ClassGoalsModel> GoalsSelectByClass(int TeacherID, int CourseID)
        {
            List<ClassGoalsModel> output = new List<ClassGoalsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassGoalsModel>("GoalsSelectByClass", new
                    {
                        @teacherID = TeacherID,
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // select all by teacher
        public List<ClassModel> SelectAllByTeacher(int TeacherID)
        {
            List<ClassModel> output = new List<ClassModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllByTeacher", new
                    {
                        @teacherID = TeacherID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // select guideline by level and type
        public List<ContinuumModel> SelectGuidlineByLevelAndType(int LevelID, int EvaluationTypeID, int paperTypeID)
        {
            List<ContinuumModel> output = new List<ContinuumModel>();
            int LevelIDbelow = LevelID;
            int LevelIDabove = LevelID + 1;

            if (LevelID > 1)
            {
                LevelIDbelow = LevelID - 1;
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumModel>("ContinuumSelectbyLevelandType", new
                    {
                        @levelIDbelow = LevelIDbelow,
                        @levelID = LevelID,
                        @levelIDabove = LevelIDabove,
                        @evaluationTypeID = EvaluationTypeID,
                        @paperTypeID = paperTypeID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // paper select all
        public List<PaperTypeModel> PaperSelectAll()
        {
            List<PaperTypeModel> output = new List<PaperTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperTypeModel>("PaperTypeSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // evaluation select all without conventions
        public List<EvaluationTypeModel> EvaluationSelectAllWithoutConventions()
        {
            List<EvaluationTypeModel> output = new List<EvaluationTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationTypeModel>("ValidEvaluationTypeSelectAll", commandType: CommandType.StoredProcedure).ToList();
                    var elementToRemove = output.Where(x => x.Title == "Conventions").FirstOrDefault();
                    output.Remove(elementToRemove);
                    //foreach (var x in output)
                    //{
                    //    if (x.Title == "Conventions")
                    //    {
                    //        output.Remove(x);
                    //    }
                    //}
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public void CourseSemesterUpdate(CourseSemesterModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Execute("dbo.CourseSemesterUpdate", new { model.ID, model.SubjectID, model.SemesterID, model.MidtermDate },
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // class select one by id
        public ClassModel ClassSelectOneByID(int ID)
        {
            ClassModel output = new ClassModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectOneByID", new
                    {
                        @ID = ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // evaluation select all with conventions
        public List<EvaluationTypeModel> EvaluationSelectAllWithConventions()
        {
            List<EvaluationTypeModel> output = new List<EvaluationTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationTypeModel>("ValidEvaluationTypeSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // get level by month and grade
        public int GetLevelByMonthAndGrade(int MonthID, int GradeID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("ContinuumProficiencyLevelByMonthandGrade", new
                    {
                        @monthID = MonthID,
                        @gradeID = GradeID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // get user by id
        public UserModel UserSelectOne(int ID)
        {
            UserModel output = new UserModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("UserSelectOne", new
                    {
                        @ID = ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }
        // assignment select all by course
        public List<AssignmentModel> AssignmentSelectAllByCourse(int CourseID)
        {
            List<AssignmentModel> output = new List<AssignmentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<AssignmentModel>("AssignmentSelectAllByCourse", new
                    {
                        @CourseID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // assignment select one
        public AssignmentModel AssignmentSelectOne(int ID)
        {
            AssignmentModel output = new AssignmentModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<AssignmentModel>("AssignmentSelectOne", new
                    {
                        @ID = ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // assignment insert
        public void AssignmentInsert(AssignmentModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("AssignmentInsert", new
                    {
                        @Name = model.Name,
                        @Description = model.Description,
                        @Due = model.Due,
                        @CourseID = model.CourseID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // assignment update
        public void AssignmentUpdate(AssignmentModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("AssignmentUpdate", new
                    {
                        @ID = model.ID,
                        @Name = model.Name,
                        @Description = model.Description,
                        @Due = model.Due,
                        @CourseID = model.CourseID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // assignment delete
        public void AssignmentDelete(AssignmentModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("AssignmentDelete", new
                    {
                        @ID = model.ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // BENCHMARK REPORTS SELECT ALL SCHOOLS ALL GRADES

        public BenchmarkReportsModel BenchmarkReportsSelectAllSchoolsAllGrades(int EvalPeriod, int UserID, int YearID)
        {
            BenchmarkReportsModel model = new BenchmarkReportsModel()
            {
                courseID = null,
                gradeID = null,
                schoolID = null,
                evalPeriodID = EvalPeriod
            };

            try
            {
                using (SqlConnection conn = GetConnection())
                {


                    var output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsSelectAllSchoolsAllGrades", new
                    {
                        @evalPeriodID = EvalPeriod,
                        @userID = UserID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    // create student full name string
                    foreach (var x in output)
                    {
                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;

        }

        // BENCHMARK REPORTS ALL SCHOOLS SPECIFIC GRADE
        public BenchmarkReportsModel BenchmarkReportsAllSchoolsSpecificGrade(int GradeID, int EvalPeriod, int UserID, int YearID)
        {
            BenchmarkReportsModel model = new BenchmarkReportsModel()
            {
                courseID = null,
                gradeID = GradeID,
                schoolID = null,
                evalPeriodID = EvalPeriod
            };

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsAllSchoolsSpecificGrade", new
                    {
                        @gradeID = GradeID,
                        @evalPeriodID = EvalPeriod,
                        @userID = UserID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    // add student if thier prof id is equal to the prof id
                    foreach (var x in output)
                    {
                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;
        }

        // BENCHMARK REPORTS SPECIFIC SCHOOL ALL GRADES
        public BenchmarkReportsModel BenchmarkReportsSpecificSchoolAllGrades(int EvalPeriod, int SchoolID, int YearID)
        {
            BenchmarkReportsModel model = new BenchmarkReportsModel()
            {
                courseID = null,
                gradeID = null,
                schoolID = SchoolID,
                evalPeriodID = EvalPeriod
            };

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsSelectSpecificSchoolAllGrades", new
                    {
                        @evalPeriodID = EvalPeriod,
                        @schoolID = SchoolID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    // add student, just like above
                    foreach (var x in output)
                    {
                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;
        }

        // BENCHMARK REPORT SELECT ALL BY SCHOOL AND GRADE YEAR
        public BenchmarkReportsModel BenchmarkReportsSpecificSchoolSpecificGradeYear(int EvalPeriod, int SchoolID, int GradeID, int YearID)
        {
            BenchmarkReportsModel model = new BenchmarkReportsModel()
            {
                courseID = null,
                gradeID = GradeID,
                schoolID = SchoolID,
                evalPeriodID = EvalPeriod
            };

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsSelectAllBySchoolandGradeYear", new
                    {
                        @gradeID = GradeID,
                        @evalPeriodID = EvalPeriod,
                        @schoolID = SchoolID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    // add students, just like above
                    foreach (var x in output)
                    {
                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;
        }

        // BENCHMARK REPORTS SPECIFIC SCHOOL SPECIFI GRADE
        public BenchmarkReportsModel BenchmarkReportsSpecificSchoolSpecificGrade(int EvalPeriod, int SchoolID, int GradeID)
        {
            BenchmarkReportsModel model = new BenchmarkReportsModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsSelectAllBySchoolandGrade", new
                    {
                        @gradeID = GradeID,
                        @evalPeriodID = EvalPeriod,
                        @schoolID = SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    // set things, almost the same as above
                    model.courseID = null;
                    model.gradeID = GradeID;
                    model.schoolID = SchoolID;
                    model.evalPeriodID = EvalPeriod;

                    foreach (var x in output)
                    {
                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;
        }

        //BENCHMARK REPORTS SPECIFIC SCHOOL SPECIFIC COURSE
        public List<BenchmarkReportsModel> BenchmarkReportsSpecificSchoolSpecificCourse(int CourseID, int EvalPeriod, int YearID)
        {
            List<BenchmarkReportsModel> output = new List<BenchmarkReportsModel>();
            BenchmarkReportsModel model = new BenchmarkReportsModel();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BenchmarkReportsModel>("BenchmarkReportsSelectAllByCourseID", new
                    {
                        @courseID = CourseID,
                        @evaluationperiodID = EvalPeriod,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in output)
                    {
                        // set things. like above
                        x.courseID = CourseID;
                        x.gradeID = null;
                        x.schoolID = null;
                        x.evalPeriodID = EvalPeriod;

                        string fullStudentName = x.firstName + " " + x.lastName;
                        model.SelectByProfID(x.ProficiencyID).Students.Add(fullStudentName);
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // BOOKSHELF SELECT ALL
        public List<BookshelfContent> BookshelfContentSelectAll()
        {
            List<BookshelfContent> output = new List<BookshelfContent>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BookshelfContent>("BookshelfContentSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // BOOKSHELF PAPER INSERT
        public void BookshelfPaperInsert(BookshelfPaperModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("BookshelfPaperInsert", new
                    {
                        @paperId = model.paperId,
                        @studentId = model.studentId
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //BOOKSHELF SELECT ALL IN CLASS
        public List<BookshelfPaperModel> BookshelfPaperSelectAllInClass(int ClassID)
        {
            List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BookshelfPaperModel>("BookshelfSelectAllInClass", new
                    {
                        @classId = ClassID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //BOOKSHELF SELECT ALL IN DISTRICT
        public List<BookshelfPaperModel> BookshelfPaperSelectAllInDistrict(int DistrictID)
        {
            List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BookshelfPaperModel>("BookshelfPaperSelectAllInDistrict", new
                    {
                        @districtId = DistrictID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // BOOKSHELF SELECT ALL IN SCHOOL
        public List<BookshelfPaperModel> BookshelfPaperSelectAllInSchool(int SchoolID)
        {
            List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BookshelfPaperModel>("BookshelfPaperSelectAllInSchool", new
                    {
                        @schoolId = SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // BOOKSHELF SELECT ALL BY STUDENT
        public List<BookshelfPaperModel> BookshelfPaperSelectAllByStudent(int StudentID)
        {
            List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<BookshelfPaperModel>("BookshelfSelectAllByStudent", new
                    {
                        @studentId = StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //  CHARACTERISTIC SELECT ALL BY ELEMENT ID
        public List<CharacteristicModel> CharacteristicSelectAllByElementID(int ElementID)
        {
            List<CharacteristicModel> output = new List<CharacteristicModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<CharacteristicModel>("CharacteristicSelectbyElementID", new
                    {
                        @elementID = ElementID
                    }, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CHARACTERISTIC SELECT ALL
        public List<CharacteristicModel> CharacteristicSelectAll()
        {
            List<CharacteristicModel> output = new List<CharacteristicModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<CharacteristicModel>("CharacteristicSelectAll", commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS DATA SELECT ALL BY CLASS ID
        public List<ClassDataModel> ClassDataSelectAllByClassID(int ClassID, int EvalPeriod, int Year)
        {
            List<ClassDataModel> output = new List<ClassDataModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassDataModel>("EvaluationScoresSelectAllByCourseIDNew", new
                    {
                        @courseID = ClassID,
                        @evalPeriodID = EvalPeriod
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in output)
                    {
                        x.NameTitle = x.LastName + ", " + x.FirstName + "; " + x.PaperTitle + "; Draft # " + x.Draft;
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS GOALS INSERT CLASS GOALS
        public void ClassGoalsInsertClassGoals(ClassGoalsModel model, int TeacherID, int CourseID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsInsertClassGoal", new
                    {
                        @shortDescription = model.ShortDescription,
                        @fullDescription = model.FullDescription,
                        @teacherID = model.TeacherID,
                        @courseID = CourseID,
                        @deadlineDate = model.DeadlineDate
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CLASS GOALS GOALS SELECT BY ID
        public ClassGoalsModel ClassGoalsSelectByID(int GoalID, int CourseID)
        {
            ClassGoalsModel output = new ClassGoalsModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassGoalsModel>("GoalsClassSelectByID", new
                    {
                        @goalID = GoalID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    output.ID = GoalID;
                    output.CourseID = CourseID;
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS GOALS SELECT BY CLASS
        public List<ClassGoalsModel> ClassGoalsSelectByClass(int TeacherID, int CourseID)
        {
            List<ClassGoalsModel> output = new List<ClassGoalsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassGoalsModel>("GoalsSelectByClass", new
                    {
                        @teacherID = TeacherID,
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in output)
                    {
                        x.TeacherID = TeacherID;
                        x.CourseID = CourseID;
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // UPDATE CLASS GOAL
        public void ClassGoalUpdateClassGoal(ClassGoalsModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsClassUpdateByID", new
                    {
                        @goalID = model.ID,
                        @fullDescription = model.FullDescription,
                        @dateAssigned = model.DateAdded,
                        @deadline = model.DeadlineDate
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CLASS GOALS MARKE COMPLETED
        public void ClassGoalMarkCompleted(int GoalID, DateTime DateNow)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ClassGoalsMarkCompleted", new
                    {
                        @goalID = GoalID,
                        @dateNow = DateNow
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CLASS GOAL DELETE CLASS GOAL
        public void ClassGoalDeleteClassGoal(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsDeleteClassGoal", new
                    {
                        @ID = ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CLASS GOAL SELECT BY COURSE ID
        public List<ClassGoalsModel> ClassGoalSelectByCourseID(int CourseID)
        {
            List<ClassGoalsModel> output = new List<ClassGoalsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassGoalsModel>("ClassGoalsSelectByCourseID", new
                    {
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS LEVEL SELECT ALL
        public List<ClassLevelModel> ClassLevelSelectAll()
        {
            List<ClassLevelModel> output = new List<ClassLevelModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassLevelModel>("ClassLevelSelectAll").ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS MODEL COURSE INSERT
        public int ClassModelCourseInsert(ClassModel model)
        {
            var output = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("CourseInsert", new
                    {
                        @courseTitle = model.CourseTitle,
                        @semesterID = model.SemesterID,
                        @gradeID = model.GradeID,
                        @teacherID = model.TeacherID,
                        @schoolID = model.SchoolID,
                        @period = model.Period,
                        @subjectID = model.SubjectID,
                        @yearID = model.YearID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        // CLASS MODEL SELECT ALL BUT ID
        public int ClassModelSelectByAllButID(ClassModel model)
        {
            int ID = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var output = conn.Query<ClassModel>("CourseFindByAllExceptID", new
                    {
                        @semesterID = model.SemesterID,
                        @gradeID = model.GradeID,
                        @yearID = model.YearID,
                        @teacherID = model.TeacherID,
                        @schoolID = model.SchoolID,
                        @period = model.Period,
                        @subjectID = model.SubjectID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    ID = output.ID;
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return ID;
        }

        // CLASS MODEL SELECT ALL BY TEACHER AND COURSE
        public ClassModel ClassModelSelectAllByTeacherAndCourse(int TeacherID, int CourseID)
        {
            ClassModel output = new ClassModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllByTeacherAndCourse", new
                    {
                        @teacherID = TeacherID,
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS MODEL SELECT ALL BY STUDENT
        public List<ClassModel> ClassModelSelectAllByStudent(int StudentID)
        {
            List<ClassModel> output = new List<ClassModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllByStudent", new
                    {
                        @studentID = StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS MODEL SELECT ALL BY STUDENT AND YEAR
        public List<ClassModel> ClassModelSelectAllByStudentAndYear(int StudentID, int YearID)
        {
            List<ClassModel> output = new List<ClassModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllByStudentAndYear", new
                    {
                        @studentID = StudentID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CLASS MODEL SELECT ALL BY SCHOOL AND GRADE AND YEAR
        public List<ClassModel> ClassModelSelectAllBySchoolAndGradeAndYear(int SchoolID, int GradeID, int YearID)
        {
            List<ClassModel> output = new List<ClassModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ClassModel>("ClassSelectAllBySchoolIDandGradeIdandYearID", new
                    {
                        @schoolID = SchoolID,
                        @gradeID = GradeID,
                        @yearID = YearID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONFERENCE NOTES SELECT NOTES BY COURSE AND STUDENT
        public List<ConferenceNotesModel> ConferenceNotesSelectNotesByCourseAndStudent(int CourseID, int StudentID)
        {
            List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceNotesModel>("ConferenceNotesSelectByStudentAndCourse", new
                    {
                        @studentID = StudentID,
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONFERENCE NOTES SELECT BY STUDENT
        public List<ConferenceNotesModel> ConferenceNotesSelectNotesByStudentID(int StudentID)
        {
            List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceNotesModel>("ConferenceNotesSelectbyStudentID", new
                    {
                        @studentID = StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONFERENCE NOTES SELECT NOTE BY ID
        public ConferenceNotesModel ConferenceNotesSelectNoteByID(int ConferenceID)
        {
            ConferenceNotesModel output = new ConferenceNotesModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceNotesModel>("ConferenceNotesSelectByID", new
                    {
                        @conferenceID = ConferenceID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //  CONFERENCE NOTES EDIT NOTES
        public void ConferenceNotesEditNotes(ConferenceNotesModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ConferenceNotesUpdate", new
                    {
                        @conferenceID = model.ConferenceID,
                        @stageOrDraftID = model.StageOrDraftID,
                        @comments = model.Comments
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONFERENCE NOTES DELETE NOTES
        public void ConferenceNotesDeleteNotes(int ConID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ConferenceNotesDeleteByID", new
                    {
                        @conID = ConID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONFERENCE NOTES INSERT NOTES
        public void ConferenceNotesInsertNotes(InsertConferenceNotesViewModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ConferenceNotesInsert", new
                    {
                        @date = model.ReturnDate,
                        @studentID = model.ConferenceNotes.StudentID,
                        @conferenceTypeID = model.ConferenceNotes.ConferenceTypeID,
                        @stageOrDraftID = model.ConferenceNotes.StageOrDraftID,
                        @comments = model.ConferenceNotes.Comments,
                        @courseID = model.ConferenceNotes.CourseID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONFERENCE NOTES TYPE DESCRIPTION SELECT ALL
        public List<ConferenceNotesModel> ConferenceNotesTypeDescriptionSelectAll()
        {
            List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceNotesModel>("ConferenceTypeDescriptionSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONFERENCE NOTES STAGE OR DRAFT SELECT ALL
        public List<ConferenceNotesModel> ConferenceNotesStageOrDraftSelectAll()
        {
            List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceNotesModel>("ConferenceStageOrDraftSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString()); ;
            }

            return output;
        }

        // CONFERENCE TOOL SELECT ALL TYPES
        public List<SelectListItem> ConferenceToolSelectAllTypes()
        {
            List<SelectListItem> output = new List<SelectListItem>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<ConferenceToolModel>("ConferenceToolSelectAllType", commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in data)
                    {
                        SelectListItem selectListItem = new SelectListItem()
                        {
                            Value = x.ConferenceTypeID.ToString(),
                            Text = x.ConferenceType.ToString()
                        };

                        output.Add(selectListItem);
                    }

                    output.Insert(0, new SelectListItem() { Text = "--- Please Select Type ---", Value = "0", Selected = true });
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONFERENCE TOOL UPLOAD CONFERENCE
        public void ConferenceToolUploadConference(ConferenceToolViewModel model, int StudentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ConferenceToolUpload", new
                    {
                        @ConferenceTypeID = model.ConferenceTypeID,
                        @StudentID = StudentID,
                        @SourceID = model.SourceID,
                        @ElementID = model.ElementID,
                        @RoleHelpID = model.RoleID,
                        @ConfToolSpecifics = model.ConfToolSpecifics,
                        @DateCreated = model.DateCreated
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONFERENCE TOOL SELECRT ALL BY STUDENT
        public List<ConferenceToolModel> ConferenceToolSelectAllByStudentID(int StudentID)
        {
            List<ConferenceToolModel> output = new List<ConferenceToolModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ConferenceToolModel>("ConferenceToolSelectAllByStudentID", new
                    {
                        @studentID = StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in output)
                    {
                        if (x.ConferenceTypeID == 1)
                        {
                            x.Media = PaperModelSelectOneByPaperID(x.SourceID).Paper;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTACT MODEL INSERT CONTACT REQUEST
        public void ContactRequestInsert(ContactModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContactRequestInsert", new
                    {
                        @Reason = model.Reason,
                        @FirstName = model.FirstName,
                        @LastName = model.LastName,
                        @Email = model.Email,
                        @Phone = model.Phone,
                        @City = model.City,
                        @StreetNumber = model.StreetNumber,
                        @StreetName = model.StreetName,
                        @Country = model.Country,
                        @State = model.State,
                        @ZipCode = model.ZipCode,
                        @Message = model.Message
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTACT ACKNOWLEDGE CONTACT REQUEST
        public void ContactAcknowledgeContactRequest(int ContactRequestID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContactRequestAcknowledgeResquest", new
                    {
                        @requestID = ContactRequestID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTACT RESOLVE CONTACT REQUEST
        public void ContactResolveContactRequest(int ContactRequestID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContactRequestResolveRequest", new
                    {
                        @requestID = ContactRequestID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTACT DELETE CONTACT REQUEST
        public void ContactDeleteContactRequest(int ContactRequestID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContactRequestDeleterequest", new
                    {
                        @requestID = ContactRequestID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //  CONTACT INSERT WEB ADMIN COMMENT
        public void ContactInsertWebAdminComment(int ContactRequestID, string Comment)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContactRequestInsertComment", new
                    {
                        @comment = Comment,
                        @requestID = ContactRequestID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTACT SELECT ALL REQUESTS
        public List<ContactModel> ContactSelectAllRequest()
        {
            List<ContactModel> output = new List<ContactModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContactModel>("ContactRequestSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTACT SELECT REQUEST BY ID
        public ContactModel ContactSelectRequestByID(int ContactRequestID)
        {
            ContactModel output = new ContactModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContactModel>("ContactRequestSelectByID", new
                    {
                        @requestID = ContactRequestID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTINUUM HELPER GET LEVEL BY MONTH AND GRADE
        public int ContinuumHelperGetLevelByMonthAndGrade(int MonthID, int GradeID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<ContinuumProficiencyLevelModel>("ContinuumProficiencyLevelByMonthandGrade", new
                    {
                        @monthID = MonthID,
                        @gradeID = GradeID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    output = data.levelID;
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //  CONTINUUM LEVEL SELECT ALL
        public List<ContinuumLevelModel> ContinuumLevelSelectAll()
        {
            List<ContinuumLevelModel> output = new List<ContinuumLevelModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumLevelModel>("twcLevelSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTINUUM SELECT PROFICIENCY LEVEL BY MONTH AND GRADE
        public int ContinuumSelectProficiencyLevelByMonthAndGrade(int MonthID, int GradeID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("SelectProficiencyLevelByMonthAndGrade", new
                    {
                        @monthID = MonthID,
                        @gradeID = GradeID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTINUUM INSERT GUIDLINES
        public void ContinuumInsertGuidlines(int LevelID, int PaperTypeID, int EvaluationTypeID, string Guidelines)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContinuumDataInsert", new
                    {
                        @LevelID = LevelID,
                        @PaperTypeID = PaperTypeID,
                        @EvaluationTypeID = EvaluationTypeID,
                        @Guidelines = Guidelines
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTINUUM ENTRY DELETE
        public void ContinuumEntryDelete(int ContinuumID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContinuumEntryDelete", new
                    {
                        @continuumID = ContinuumID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTINUUM EDIT CONTINUUM
        public void ContinuumEditContinuum(ContinuumModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ContinuumDataEdit", new
                    {
                        @continuumID = model.ContinuumID,
                        @guidelines = model.Guidelines,
                        @PaperTypeID = model.PaperTypeID,
                        @LevelID = model.LevelID,
                        @EvaluationTypeID = model.EvaluationTypeID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // CONTINUUM SLECT ALL BY CONTINUUM ID
        public ContinuumModel ContinuumSelectAllByContinuumID(int ContinuumID)
        {
            ContinuumModel output = new ContinuumModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumModel>("ContinuumSelectByContinuumID", new
                    {
                        @continuumID = ContinuumID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTINUUM VIEW DATA
        public List<ContinuumModel> ContinuumViewData()
        {
            List<ContinuumModel> output = new List<ContinuumModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumModel>("ContinuumDataViewAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // CONTINUUM TYPE SELECT ALL
        public List<ContinuumTypeModel> ContinuumTypeSelectAll()
        {
            List<ContinuumTypeModel> output = new List<ContinuumTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumTypeModel>("ContinuumTypeSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // COURSE SEMESTER INSERT
        public void CourseSemseterInsert(CourseSemesterViewModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("CourseSemesterInsert", new
                    {
                        @schoolID = model.SchoolID,
                        @subjectID = model.SubjectID,
                        @semesterID = model.SemesterID,
                        @midtermDate = model.CourseSemesterModel.MidtermDate
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // COURSE SEMESTER SELECT ALL
        public List<CourseSemesterModel> CourseSemesterSelectAll(int SchoolID)
        {
            List<CourseSemesterModel> output = new List<CourseSemesterModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<CourseSemesterModel>("CourseSemesterSelectAllBySchoolID", new
                    {
                        @schoolID = SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT CONTINUUM BUILD CUSTOM CONTINUUM
        public List<ProjectContinuumModel> ProjectContinuumBuildCustomContinuum()
        {
            List<ProjectContinuumModel> output = new List<ProjectContinuumModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectContinuumModel>("CustomContinuumBlankBuild",
                        commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in output)
                    {
                        x.Guideline = "";
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GET DEFAULT CLASS SETTINGS
        public DefualtClassSettings DefaultClassGetSettingsDefaultClass(int TeacherID)
        {
            DefualtClassSettings output = new DefualtClassSettings();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<DefualtClassSettings>("SettingsDefualtEnabledGet", new
                    {
                        @teacherID = TeacherID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // DEFAULT CLASS SET DEFAULT SETTINGS
        public void DefaultClassSetDefaultSettings(DefualtClassSettings model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("SettingsDefualtEnabledSet", new
                    {
                        @ID = model.SettingDefualtId,
                        @courseID = model.DefualtClass,
                        @IsDefualtEnabled = model.DefualtClass
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // DISTRICT ADMIN SELECT ONE BY USER MODEL
        public DistrictAdminModel DistrictAdminSelectOneByUserModel(UserModel model)
        {
            DistrictAdminModel output = new DistrictAdminModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<DistrictAdminModel>("DistrictAdminSelectByUserID", new
                    {
                        @userID = model.ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // DISTRICT SELECT ALL
        public List<DistrictModel> DistrictSelectAll()
        {
            List<DistrictModel> output = new List<DistrictModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<DistrictModel>("DistrictSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // DISTRICT SELECT INDIVIDUAL DISTRICT
        public DistrictModel DistrictSelectIndividualDistrict(int DistrictID)
        {
            DistrictModel output = new DistrictModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<DistrictModel>("DistrictSelectByID", new
                    {
                        @districtID = DistrictID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //BEGIN GlobalRole Methods
        public void UnAssignUserFromRole(int userId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("UnassignUserFromRole", new
                    {
                        userId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void AssignUserToRole(int roleId, int userId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("AssignUserToRole", new
                    {
                        userId,
                        roleId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public List<GlobalRoleModel> GlobalRoleSelectAll()
        {
            List<GlobalRoleModel> output = new List<GlobalRoleModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GlobalRoleModel>("GlobalRoleSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public void DeleteGlobalRole(int roleId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("GlobalRoleDelete", new
                    {
                        roleId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void UpdateGlobalRole(int roleId, string newRoleName)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("GlobalRoleUpdate", new
                    {
                        roleId,
                        newRoleName
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void InsertGlobalRole(string roleName)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("GlobalRoleInsert", new
                    {
                        roleName
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        //BEGIN View methods
        public bool CanUserAccessView(int roleId, int viewId)
        {
            bool output = false;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<bool>("CanUserAccessView", new
                    {
                        roleId,
                        viewId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        // working on district model with the insert function
        public void AssignViewToRole(int viewId, int roleId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("ViewsGlobalRolesInsert", new
                    {
                        viewId,
                        roleId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void RemoveViewFromRole(int viewId, int roleId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("ViewsGlobalRolesDelete", new
                    {
                        viewId,
                        roleId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void InsertViewName(string viewName, string controllerName, int ViewID, int RoleID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ViewsInsertView", new
                    {
                        viewName,
                        controllerName,
                        ViewID,
                        RoleID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public List<ViewsModel> ViewsSelectAll()
        {
            List<ViewsModel> output = new List<ViewsModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ViewsModel>("ViewsSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public List<WebAdminFeedbackToolViewer> GetAllConferenceToolFeedback(int studentID)
        {
            List<WebAdminFeedbackToolViewer> output = new List<WebAdminFeedbackToolViewer>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<WebAdminFeedbackToolViewer>("ConferenceToolFeedbackSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public List<WritingElementModel> WritingElementSelectAll()
        {
            List<WritingElementModel> output = new List<WritingElementModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<WritingElementModel>("validEvaluationTypeSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        //  DISTRICT INSERT
        public void DistrictInsert(DistrictModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("DistrictInsert", new
                    {
                        @DistrictName = model.DistrictName,
                        @Country = model.Country,
                        @State = model.State,
                        @SuperintendentName = model.SuperintendentName,
                        @SuperintendentEmail = model.SuperintendentEmail,
                        @SuperintendentPhone = model.SuperintendentPhone,
                        @AstSuperintendentName = model.AstSuperintendentName,
                        @AstSuperintendentEmail = model.AstSuperintendentEmail,
                        @AstSuperintendentPhone = model.AstSuperintendentPhone,
                        @CurriculumCoordinatorName = model.CurriculumCoordinatorName,
                        @CurriculumCoordinatorEmail = model.CurriculumCooridnatorEmail,
                        @CurriculumCoordinatorPhone = model.CurriculumCoordinatorPhone,
                        @AccountsPayableName = model.AccountsPayableName,
                        @AccountsPayableEmail = model.AccountsPayableEmail,
                        @AccountsPayablePhone = model.AccountsPayablePhone,
                        @ElemSchoolNumber = model.ElemSchoolNumber,
                        @MidSchoolNumber = model.MidSchoolNumber,
                        @HighSchoolNumber = model.HighSchoolNumber,
                        @Website = model.Website,
                        @LicensesPurchased = model.LicensesPurchased,
                        @Street = model.Street,
                        @ZipCode = model.ZipCode
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //  ELEMENT SELECT ALL
        public List<ElementModel> ElementSelectAll()
        {
            List<ElementModel> output = new List<ElementModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ElementModel>("ElementSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // ELEMENT SELECT BY CHARACTERISTIC ID
        public int ElementSelectByCharacteristicID(int CharacteristicID)
        {
            int output = -1;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query("ElementGetIDFromCharacteristic", new
                    {
                        @characteristicId = CharacteristicID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // ENGAGEMENT INSERt - create
        public void EngagementInsert(EngagementModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("EngagementInsert", new
                    {
                        @title = model.Title,
                        @gradeLevelRangeID = model.GradeLevelRangeID,
                        @text = model.Text,
                        @keywords = model.Keywords
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // ENGAGEMENT EDIT - UPDATE
        public void EngagementEdit(EngagementModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("EngagementEdit", new
                    {
                        @ID = model.ID,
                        @Title = model.Title,
                        @GradeLevelRangeID = model.GradeLevelRangeID,
                        @Text = model.Text,
                        @Keywords = model.Keywords
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // ENGAGEMENT SELECT ALL - READ
        public List<EngagementModel> EngagementSelectAll()
        {
            List<EngagementModel> output = new List<EngagementModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EngagementModel>("EngagementsSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // ENGAGEMENT VOID - DELETE
        public void EngagementDelete(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("EngagementDelete", new
                    {
                        @ID = ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // ENGAGEMENT SELECT BY GRADE LEVEL RANGE
        public List<EngagementModel> EngagementSelectByGradeLevelRange(int GradeLevelRange)
        {
            List<EngagementModel> output = new List<EngagementModel>();

            //call engagement select all and filter it with linq
            output = EngagementSelectAll().Where(x => x.GradeLevelRangeID == GradeLevelRange).ToList();

            return output;
        }

        //ENGAGEMENT SELECT ONE
        public EngagementModel EngagementSelectOne(int ID)
        {
            EngagementModel output = new EngagementModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = EngagementSelectAll().Where(x => x.ID == ID).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // ERROR SELECT ERROR BY TYPE
        public List<ErrorModel> ErrorSelectErrorByType(int ErrorTypeID)
        {
            List<ErrorModel> output = new List<ErrorModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ErrorModel>("tblErrorSelectByType", new
                    {
                        ErrorTypeID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // ERROR TYPE FROP DOWN POP
        public List<SelectListItem> ErrorTypeDropDownPop()
        {
            List<SelectListItem> output = new List<SelectListItem>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<ErrorModel>("tblErrorDrop", commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in data)
                    {
                        output.Add(new SelectListItem()
                        {
                            Text = x.ErrorType.ToString(),
                            Value = x.ErrorID.ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // EVALUATION PERIOD SELECT ALL
        public List<EvaluationPeriodModel> EvaluationPeriodSelectAll()
        {
            List<EvaluationPeriodModel> output = new List<EvaluationPeriodModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationPeriodModel>("EvaluationPeriodSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // evaluation period select all benchmark
        public List<EvaluationPeriodModel> EvaluationPeriodSelectAllBenchmark()
        {
            List<EvaluationPeriodModel> output = new List<EvaluationPeriodModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationPeriodModel>("EvaluationPeriodSelectAllBenchmark2", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // evaluation score get comments and feedback
        public EvaluationScoreModel EvaluationScoreGetCommentsandFeedback(int EvalID)
        {
            EvaluationScoreModel output = new EvaluationScoreModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationScoreModel>("GetCommentsandFeedback", new
                    {
                        EvalID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //  EVALUATION SCORE SELECT PROFICIENY LEVEL
        public int EvaluationScoreSelectProficienyLevel(int EvalID)
        {
            int proficienyID = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    proficienyID = conn.Query<int>("EvaluationSelectProficiencyLevel", new
                    {
                        EvalID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return proficienyID;
        }

        //  EVALUATION SCORE UPDATE OVERALL PROFICIENCY 
        public void EvaluationScoreUpdateOverallProficiency(int EvalID, int ProfLevel)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProficiencyLevelUpdate", new
                    {
                        EvalID,
                        ProfLevel
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // EVALUATION SCORE UPDATE COMMENT AND FEED BACK
        public void EvaluationScoreUpdateCommentsAndFeedback(EvaluationScoreModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("EvaluationCommentsandFeedbackUpdate", new
                    {
                        model.EvaluationID,
                        model.StudentFeedback,
                        model.Comments
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // EVALUATION SCORE SELECT BY ID
        public EvaluationScoreModel EvaluationScoreSelectByID(int ID)
        {
            EvaluationScoreModel output = new EvaluationScoreModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<EvaluationScoreModel>("EvaluationScoresSelectOne", new
                    {
                        ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //  EVALUATION SCORE UPDATE
        public void EvaluationScoreUpdate(EvaluationScoreModel model, int GradeID)
        {
            // update prof level for new score
            List<string> score = new List<string>();
            score.Add(model.ScoreData);

            List<int> scoreConvert = ContinuumModelFunctions.ScoreDictionaryConversion(score);
            int intScore = scoreConvert[0];

            //get the month of the paper
            var monthID = PaperModelGetMonthByEvalID(model.EvaluationID);
            var proficienyID = ContinuumHelperModel.getProficiency(monthID, GradeID, intScore);

            //  update score
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("EvaluationScoreUpdate", new
                    {
                        model.ID,
                        model.ScoreData,
                        proficienyID,
                        model.IsFinal
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // EVALUATION SCORE UPDATE CONVENTION SCORE
        public void EvaluationScoreUpdateConventionScore(EvaluationScoreModel model)
        {
            List<string> ConventionScore = new List<string>();
            var spellingScore = "";
            var usageScore = "";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<EvaluationScoreModel>("EvaluationScoresSelectAllByEvaluationID", new
                    {
                        model.EvaluationID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in data)
                    {
                        if (x.ScoreTypeID == 7)
                        {
                            spellingScore = x.ScoreData.ToString();
                            ConventionScore.Add(spellingScore);
                        }
                        else if (x.ScoreTypeID == 8)
                        {
                            usageScore = x.ScoreData.ToString();
                            ConventionScore.Add(usageScore);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            int ConventionScoreAvg = 0;
            List<int> ConventionScoresInt = ContinuumModelFunctions.ScoreDictionaryConversion(ConventionScore);

            foreach (var x in ConventionScoresInt)
            {
                ConventionScoreAvg += x;
            }

            ConventionScoreAvg = ConventionScoreAvg / ConventionScoresInt.Count;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ConventionScoreUpdate", new
                    {
                        @EvaluationID = model.EvaluationID,
                        @ScoreData = ContinuumModelFunctions.ConvertScore(ConventionScoreAvg)
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //EVALUATION UPDATE HOLISTIC SCORE
        public void EvaluationUpdateHolisticScore(int EvalID, int CourseID)
        {
            List<string> Scores = new List<string>();
            List<string> ConventionScores = new List<string>();

            string ideasContentScore;
            string orgStructureScore;
            string voiceScore;
            string wordScore;
            string sentenceScore;
            string conventionScore;
            string spellingScore;
            string usageScore;
            string presentationScore;
            string writingScore;
            string researchScore;
            string attitudeScore;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<EvaluationScoreModel>("EvaluationScoresSelectAllByEvaluationID", new
                    {
                        EvalID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var x in data)
                    {
                        if (x.ScoreTypeID == 1)
                        {
                            ideasContentScore = x.ScoreData.ToString();
                            Scores.Add(ideasContentScore);
                        }
                        else if (x.ScoreTypeID == 2)
                        {
                            orgStructureScore = x.ScoreData.ToString();
                            Scores.Add(orgStructureScore);
                        }
                        else if (x.ScoreTypeID == 3)
                        {
                            voiceScore = x.ScoreData.ToString();
                            Scores.Add(voiceScore);
                        }
                        else if (x.ScoreTypeID == 4)
                        {
                            wordScore = x.ScoreData.ToString();
                            Scores.Add(wordScore);
                        }
                        else if (x.ScoreTypeID == 5)
                        {
                            sentenceScore = x.ScoreData.ToString();
                            Scores.Add(sentenceScore);
                        }
                        else if (x.ScoreTypeID == 6)
                        {
                            conventionScore = x.ScoreData.ToString();
                            Scores.Add(conventionScore);
                        }
                        else if (x.ScoreTypeID == 7)
                        {
                            spellingScore = x.ScoreData.ToString();
                            //Scores.Add(spellingScore);
                        }
                        else if (x.ScoreTypeID == 8)
                        {
                            usageScore = x.ScoreData.ToString();
                            //Scores.Add(usageScore);
                        }
                        else if (x.ScoreTypeID == 9)
                        {
                            presentationScore = x.ScoreData.ToString();
                            Scores.Add(presentationScore);
                        }
                        else if (x.ScoreTypeID == 10)
                        {
                            writingScore = x.ScoreData.ToString();
                            Scores.Add(writingScore);
                        }
                        else if (x.ScoreTypeID == 11)
                        {
                            researchScore = x.ScoreData.ToString();
                            Scores.Add(researchScore);
                        }
                        else if (x.ScoreTypeID == 12)
                        {
                            attitudeScore = x.ScoreData.ToString();
                            Scores.Add(attitudeScore);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            int holisticint = 0;
            string holisticScore;

            //convert scores to in
            List<int> intScoreList = ContinuumModelFunctions.ScoreDictionaryConversion(Scores);

            foreach (var x in intScoreList)
            {
                holisticint += x;
            }

            holisticint = holisticint / intScoreList.Count;
            holisticScore = ContinuumModelFunctions.ConvertScore(holisticint);

            //update holistic band (score)
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("HolisticScoreUpdate", new
                    {
                        EvalID,
                        holisticScore
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            //update overall prof level
            int proficiencyLevel = ContinuumHelperGetLevelByMonthAndGrade(DateTime.Today.Month, ClassSelectOneByID(CourseID).GradeID);
            int newProficiencyLevel = holisticint / proficiencyLevel;
            EvaluationScoreUpdateOverallProficiency(EvalID, newProficiencyLevel);
        }
        public List<ContinuumModel> ViewAllContinuumData(int paperTypeID)
        {
            List<ContinuumModel> output = new List<ContinuumModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ContinuumModel>("ContinuumDataViewAllByPaperType", new { paperTypeID }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.ToString());
            }
            return output;
        }

        // GLOSSARY MODEL SELECT ALL
        public List<GlossaryModel> GlossaryModelSelectAll()
        {
            List<GlossaryModel> output = new List<GlossaryModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GlossaryModel>("GlossarySelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GLOSSARY MODEL SELECT BY LETTER
        public List<GlossaryModel> GlossaryModelSelectByLetter(char letter)
        {
            List<GlossaryModel> output = new List<GlossaryModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GlossaryModel>("GlossarySelectByLetter", new
                    {
                        letter
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GLOSSARY MODEL SELECT BY TERM
        public List<GlossaryModel> GlossaryModelSelectByTerm(string term)
        {
            List<GlossaryModel> output = new List<GlossaryModel>();

            // call glossary model select all and filter by term
            output = GlossaryModelSelectAll().Where(x => x.Term == term).ToList();

            return output;
        }

        // GLOSSARY MODEL INSERT
        public void GlossaryModelInsert(GlossaryModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GlossaryInsert", new
                    {
                        model.Term,
                        model.Definition
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GRADE LEVEL MODEL SELECT ALL
        public List<GradeLevelModel> GradeLevelModelSelectAll()
        {
            List<GradeLevelModel> output = new List<GradeLevelModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GradeLevelModel>("GradeLevelRangeSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GRADE MODEL SELECT ALL
        public List<GradeModel> GradeModelSelectAll()
        {
            List<GradeModel> output = new List<GradeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GradeModel>("GradeSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GRADE MODEL SELECT ONE BY ID
        public GradeModel GradeModelSelectOneByID(int GradeID)
        {
            GradeModel output = new GradeModel();

            output = GradeModelSelectAll().Where(x => x.GradeID == GradeID).FirstOrDefault();

            return output;
        }

        // GRADE MODEL SELECT ID BY PAPER
        public int GradeModelSelectIDByPaper(int PaperId)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query("GradeSelectByPaper", new
                    {
                        PaperId
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MEDIA MODEL INSERT MEDIA
        public void GroupMediaModelInsertMedia(int StudentID, int ProjectID, byte[] Media, string MediaType, int GroupID, string Title)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GroupMediaUpload", new
                    {
                        StudentID,
                        ProjectID,
                        MediaType,
                        Media,
                        GroupID,
                        Title,
                        @uploadTimestamp = DateTime.Now.ToLocalTime()
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MEDIA MODEL SELECT ALL BY GROUP
        public List<GroupMediaModel> GroupMediaModelSelectAllByGroup(int GroupID, int ProjectID)
        {
            List<GroupMediaModel> output = new List<GroupMediaModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GroupMediaModel>("GroupMediaSelectAllByGroup", new
                    {
                        GroupID,
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MEDIA MODEL VIEW INDIVIDUAL MEDIA
        public GroupMediaModel GroupMediaModelViewIndividualMedia(int ID)
        {
            GroupMediaModel output = new GroupMediaModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GroupMediaModel>("GroupMediaSelectOne", new
                    {
                        ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MEDIA MODEL DELETE
        public void GroupMediaModelDelete(int GroupID, int ProjectID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GroupMediaDelete", new
                    {
                        GroupID,
                        ProjectID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MODEL INSERT return group id
        public int GroupModelInsert(int ProjectID, int GroupNumber)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query("GroupInsert", new
                    {
                        GroupNumber,
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MODEL SELECT BY GROUP ID
        public GroupModel GroupModelSelectByGroupID(int GroupID)
        {
            GroupModel output = new GroupModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<GroupModel>("GroupSelectOne", new
                    {
                        GroupID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MODEL INSERT STUDENT TO A GROUP
        public void GroupModelInsertStudentToGroup(int GroupID, int StudentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentGroupInsert", new
                    {
                        GroupID,
                        StudentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MODEL REMOVE STUDENT FROM GROUP
        public void GroupModelRemoveStudentFromGroup(int GroupID, int StudentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentGroupRemoveStudent", new
                    {
                        GroupID,
                        StudentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MODEL GET GROUP ID
        public int GroupModelGetGroupID(int GroupNumber, int ProjectID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query("GroupGetGroupId", new
                    {
                        GroupNumber,
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MODEL GET GROUP IDS FROM PROJECT ID
        public List<int> GroupModelGetGroupIDsFromProjectID(int ProjectID)
        {
            List<int> output = new List<int>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("GroupSelectIDsByProjectID", new
                    {
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // GROUP MODEL UPDATE GROUP INFO 
        public void GroupModelUpdateGroupInfo(int GroupID, string ProjectSubtitle)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GroupUpdateGroupInfo", new
                    {
                        GroupID,
                        ProjectSubtitle
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MODEL UPDATE GROUP NUMBER
        public void GroupModelUpdateGroupNumber(int GroupID, int GroupNumber)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GroupUpdateGroupNum", new
                    {
                        GroupID,
                        GroupNumber
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // GROUP MODEL DELETE GROUP
        public void GroupModelDeleteGroup(int GroupID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GroupDeleteGroup", new
                    {
                        GroupID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // LESSON PLAN MODEL INSERT
        public void LessonPlanModelInsert(LessonPlanModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("LessonPlanInsert", new
                    {
                        model.TeacherID,
                        model.CourseID,
                        model.Title,
                        model.Objective,
                        model.Standard,
                        model.EngageDesc,
                        model.ModelDesc,
                        model.ExploreDesc,
                        model.ExplainDesc,
                        model.ApplyDesc,
                        model.ShareDesc
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // LESSON PLAN MODEL DELETE
        public void LessonPlanModelDelete(int LessonPlanID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("LessonPlanDelete", new
                    {
                        LessonPlanID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // LESSON PLAN MODEL SELECT ALL
        public List<LessonPlanModel> LessonPlanModelSelectAll()
        {
            List<LessonPlanModel> output = new List<LessonPlanModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<LessonPlanModel>("LessonPlanSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // LESSON PLAN MODEL SELECT ALL BY TEACHER ID
        public List<LessonPlanModel> LessonPlanSelectAllByTeacherID(int TeacherID)
        {
            List<LessonPlanModel> output = new List<LessonPlanModel>();

            // call lesson plan select all, and filter
            output = LessonPlanModelSelectAll().Where(x => x.TeacherID == TeacherID).ToList();

            return output;
        }

        // LESSON PLAN MODEL SELECT ON BY LESSON PLAN ID
        public LessonPlanModel LessonPlanModelSelectbyLessonPlanID(int LessonPlanID)
        {
            LessonPlanModel output = new LessonPlanModel();

            // call lesson plan select all, and filter
            output = LessonPlanModelSelectAll().Where(x => x.ID == LessonPlanID).FirstOrDefault();

            return output;
        }

        //  LOGIN MODEL GET USERS WITHOUT PASSWORD
        public List<UserModel> LoginModelGetUsersWithoutPassword()
        {
            List<UserModel> output = new List<UserModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("UserGetWithoutHash",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // LOGIN MODEL SET NEW PASSWORD
        public void LoginModelSetNewPassword(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string Salt = BCryptHelper.GenerateSalt();
                    string Hash = BCryptHelper.HashPassword("iLoveWriting!", Salt);

                    conn.Query("UserSetWithoutHash", new
                    {
                        ID,
                        @salt = Salt,
                        @passwordHash = Hash
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void LoginModelSetNewPassword(UserModel user, string newpass)
        {


            string Salt = BCryptHelper.GenerateSalt();
            string Hash = BCryptHelper.HashPassword(newpass, Salt);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("UserSetWithoutHash", new
                    {
                        user.ID,
                        @salt = Salt,
                        @passwordHash = Hash
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }


        }

        // MONTHLY POINTS MODEL SELECT ALL
        public List<MonthlyPointsModel> MonthlyPointModelSelectAll()
        {
            List<MonthlyPointsModel> output = new List<MonthlyPointsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<MonthlyPointsModel>("ptsMonthlyGoalsSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // MONTHLY POINT MODEL SELECT ONE
        public MonthlyPointsModel MonthlyPointsModelSelectOne(int ID)
        {
            MonthlyPointsModel output = new MonthlyPointsModel();

            output = MonthlyPointModelSelectAll().Where(x => x.ID == ID).FirstOrDefault();

            return output;
        }

        // MONTHLY POINT MODEL UPDATE TOTAL
        public void MonthlyPointModelUpdateTotal(MonthlyPointsModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ptsMonthlyGoalUpdate", new
                    {
                        model.Month,
                        model.Total
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER HISTORY MODEL SELECT HISTORY ALL BY STUDENT -- NEEDS CHECKING
        public List<PaperHistoryModel> PaperHistoryModelSelectAllByStudent(int StudentID)
        {
            List<PaperHistoryModel> output = new List<PaperHistoryModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperHistoryModel>("PaperHistorySelectAllByStudent", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL PAPER UPLAOD DATA ONLY
        public void PaperModelPaperUploadDataOnly(PaperModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PaperUploadDataOnly", new
                    {
                        model.PaperID,
                        model.Paper,
                        model.FileName
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER MODEL PAPER UPLOAD
        public void PaperModelPaperUpload(PaperModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PaperUpload", new
                    {
                        model.StudentID,
                        model.CourseID,
                        model.uploadDate,
                        model.paperTypeID,
                        model.Paper,
                        model.FileName,
                        model.PaperTitle,
                        model.EvaluationPeriodID,
                        model.Draft,
                        model.Continuing
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER MODEL PAPER BENCHMARK PERIOD CHECK
        public void PaperModelPaperBenckmarkPeriodCheck(PaperModel model)
        {
            if (model.EvaluationPeriodID > 12)
            {
                List<PaperModel> output = new List<PaperModel>();

                try
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        output = conn.Query<PaperModel>("BenchmarkReportsCheckCourseStudentEvalPeriod", new
                        {
                            model.StudentID,
                            @evalPeriodID = model.EvaluationPeriodID,
                            model.CourseID
                        }, commandType: CommandType.StoredProcedure).ToList();

                        foreach (var paper in output)
                        {
                            try
                            {
                                conn.Query("BenchmarkReportsEvalPeriodUpdate", new
                                {
                                    paper.PaperID,
                                    @evalPeriodID = paper.EvaluationPeriodID
                                }, commandType: CommandType.StoredProcedure);
                            }
                            catch (SqlException ex)
                            {
                                InsertSqlError(ex.Message.ToString());
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    InsertSqlError(ex.Message.ToString());
                }
            }
            else
            {
                // do nothing
            }
        }





        //UserPointsModel Methods
        public void InsertPoints(int scoreID, int userID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("ptsMonthlyTotalInsert", new
                    {
                        scoreID,
                        userID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public int SelectPoints(int userID)
        {
            var output = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("ptsMonthlyTotalsSelectOne", new
                    {
                        userID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public List<UserModel> SelectContestants()
        {
            List<UserModel> output = new List<UserModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("PointsWinnersPoolSelectAll", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public List<PointWinnersModel> SelectWinnersUserIDs()
        {
            List<PointWinnersModel> output = new List<PointWinnersModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PointWinnersModel>("PointSelectWinner", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public List<PointWinnersModel> SelectPreviousWinnersIds()
        {
            List<PointWinnersModel> output = new List<PointWinnersModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PointWinnersModel>("PointsSelectPreviousWinners", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;

        }
        //Validation Model Methods
        public void ValidationModelInsert(string VerificationCode, int userID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("VerificationCodeInsert", new
                    {
                        VerificationCode,
                        @UserID = userID
                    },
                    commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public bool ValidationModelCheck(string VerificationCode, string UserEmail)
        {
            bool output = false;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<bool>("VerificationCodeCheck", new
                    {
                        VerificationCode,
                        UserEmail
                    }, commandType: CommandType.StoredProcedure).First();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public void InsertVerificationCode(string Email, string VerifCode)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("ForgotPasswordEmailInsert", new
                    {
                        Email,
                        VerifCode
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public ForgotPasswordModel CheckVerificationCode(string VerifCode)
        {
            ForgotPasswordModel output = new ForgotPasswordModel();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ForgotPasswordModel>("CheckVerificationCode", new
                    {
                        VerifCode
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }

        // PAPER MODEL CHECK IF PAPER GRADED
        public List<PaperModel> PaperModelCheckIfPaperGraded(int CourseID)
        {
            List<PaperModel> output = new List<PaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperModel>("PaperSelectNeedsGrading", new
                    {
                        CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL ADD TO BOOKSHELF
        public void PaperModelAddPaperToBookshelf(int PaperID, int ContentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PaperAddToBookshelf", new
                    {
                        PaperID,
                        ContentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER MODEL MONTH CHECK
        public List<PaperModel> PaperModelMonthCheck(int CourseID, int EvalMonthID)
        {
            List<PaperModel> output = new List<PaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperModel>("PaperCourseMonthCheck", new
                    {
                        CourseID,
                        EvalMonthID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL SELECT ONE BY PAPER ID
        public PaperModel PaperModelSelectOneByPaperID(int PaperID)
        {
            PaperModel output = new PaperModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperModel>("PaperSelectOne", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //PAPER MODEL SELECT ALL BY STUDENT
        public List<PaperModel> PaperModelSelectAllByStudent(int StudentID)
        {
            List<PaperModel> output = new List<PaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperModel>("PaperSelectAllByStudent", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL VIEW SPECIFIC PAPER
        public PaperModel PaperModelViewSpecificPaper(int PaperID)
        {
            PaperModel model = new PaperModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    model = conn.Query<PaperModel>("PaperIndividualSelect", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return model;
        }

        // PAPER MODEL SELECT ALL BY STUDENT AND CLASS
        public List<PaperModel> PaperModelSelectAllByStudentAndClass(int StudentID, int CourseID)
        {
            List<PaperModel> output = new List<PaperModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperModel>("PaperSelectAllByStudentandCourseID", new
                    {
                        StudentID,
                        CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL UPDATE
        public void PaperModelUpdate(PaperModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PaperUpdate", new
                    {
                        model.PaperID,
                        model.StudentID,
                        model.CourseID,
                        model.uploadDate,
                        model.paperTypeID,
                        model.Paper,
                        model.FileName,
                        model.PaperTitle,
                        model.EvaluationPeriodID,
                        model.Draft,
                        model.Continuing
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER MODEL DELETE PAPER
        public void PaperModelDelete(int PaperID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PaperDeleteByID", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PAPER MODEL GET MONTH BY PAPER ID
        public int PaperModelGetMonthByPaperID(int PaperID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("PaperMonthIDByPaperID", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER MODEL GET MONTH BY EVAL ID
        public int PaperModelGetMonthByEvalID(int EvalID)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("PaperMonthIDByEvaluationID", new
                    {
                        EvalID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER RESULTS MODEL SELECT REPORT
        public List<PaperResultsModel> PaperResultsModelSelectReport(int PaperID)
        {
            List<PaperResultsModel> output = new List<PaperResultsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperResultsModel>("PaperResultsSelectAll", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PAPER RESULTS MODEL SELECT ALL STUDENT FEEDBACK
        public List<PaperResultsModel> PaperResultsModelSelectAllStudentFeedback(int StudentID)
        {
            List<PaperResultsModel> output = new List<PaperResultsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<PaperResultsModel>("PaperResultsSelectAllByStudentID", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PARENT MODEL SELECT ALL BY STUDENT
        public List<ParentModel> ParentModelSelectAllByStudent(int StudentID)
        {
            List<ParentModel> output = new List<ParentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ParentModel>("ParentSelectAllByStudent", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PARENT MODEL SELECT ONE BY USER ID
        public ParentModel ParentModelSelectOneByUserID(int UserID)
        {
            ParentModel output = new ParentModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ParentModel>("ParentSelectOneByUserID", new
                    {
                        UserID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PARENT MODEL INSERT
        public void ParentModelInsert(ParentModel model, int StudentID)
        {
            LoginModel login = new LoginModel();
            login.NewUserParent(model.Email, "iLoveWriting1!", model);

            if (model.Prefix == null)
            {
                model.Prefix = "N/A";
            }
            if (model.MiddleName == null)
            {
                model.MiddleName = "N/A";
            }
            if (model.Suffix == null)
            {
                model.Suffix = "N/A";
            }
            if (model.PhoneNumber == null)
            {
                model.PhoneNumber = "N/A";
            }

            var salt = BCryptHelper.GenerateSalt();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ParentInsert", new
                    {
                        model.FirstName,
                        model.LastName,
                        model.MiddleName,
                        model.Email,
                        StudentID,
                        model.Prefix,
                        model.Suffix,
                        salt,
                        @passwordHash = BCryptHelper.HashPassword("iLoveWriting1!", salt)
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PARENT MODEL REMOVE ASSOCIATION TO STUDENT
        public void ParentModelRemoveAssociation(int pUserId, int StudentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ParentRemoveAssociationToStudent", new
                    {
                        pUserId,
                        StudentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PARENT MODEL UPDATE CONTACT INFO
        public void ParentModelUpdateContactInfo(ParentModel model)
        {
            if (model.Prefix == null)
            {
                model.Prefix = "N/A";
            }
            if (model.Suffix == null)
            {
                model.Suffix = "N/A";
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ParentUpdateContactInfo", new
                    {
                        model.Prefix,
                        model.Email,
                        model.FirstName,
                        model.LastName,
                        model.Suffix,
                        model.ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //PARENT MODEL SELECT ONE BY USER MODEL
        public ParentModel ParentModelSelectOneByUserModel(UserModel model)
        {
            ParentModel output = new ParentModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ParentModel>("ParentSelectOneByUserID", new
                    {
                        model.ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PASSWORD UPDATE MODEL CHANGE PASSWORD
        public void PasswordUpdateModelChangePassword(PasswordUpdateModel model)
        {
            //string salt = BCryptHelper.GenerateSalt();
            //string hash = BCryptHelper.HashPassword(model.NewPassword, salt);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("PasswordChange", new
                    {
                        @email = model.Username,
                        model.Salt,
                        @passwordHash = model.Hash
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROFICIENCY TYPE MODEL SELECT ALL
        public List<ProficiencyTypeModel> ProficiencyTypeModelSelectAll()
        {
            List<ProficiencyTypeModel> output = new List<ProficiencyTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProficiencyTypeModel>("ProficiencyTypeSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT CONTINUUM MODEL BUILD CONTINUUM
        // needs testing
        public List<List<ProjectContinuumModel>> ProjectContinuumModelBuildContinuum()
        {
            List<List<ProjectContinuumModel>> output = new List<List<ProjectContinuumModel>>();
            Dictionary<string, List<ProjectContinuumModel>> characteristicMap = new Dictionary<string, List<ProjectContinuumModel>>();

            // get all characteristic id's
            List<CharacteristicModel> allCharacteristics = CharacteristicSelectAll();

            foreach (var characteristic in allCharacteristics)
            {
                characteristicMap.Add(characteristic.ID.ToString(), new List<ProjectContinuumModel>());
            }

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<ProjectContinuumModel>("ProjectContinuumSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();

                    foreach (var rowOfData in data)
                    {
                        string charID = rowOfData.CharacteristicID.ToString();
                        characteristicMap[charID].Add(rowOfData);
                    }

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            foreach (KeyValuePair<string, List<ProjectContinuumModel>> entry in characteristicMap)
            {
                output.Add(entry.Value);
            }

            return output;
        }

        // PROJECT CONTINUUM MODEL INSERT GUIDELINES
        public void ProjectContinuumModelInsertGuidelines(int ElementID, int CharacteristicID, int LevelID, string Guideline)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectContinuumInsert", new
                    {
                        ElementID,
                        CharacteristicID,
                        LevelID,
                        Guideline
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //PROJECT CONTINUUM MODEL EDIT CONTINUUM
        public void ProjectContinuumModelEditContinuum(int ContinuumID, int ElementID, int CharacteristicID, int LevelID, string Guideline)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectContinuumEdit", new
                    {
                        ContinuumID,
                        ElementID,
                        CharacteristicID,
                        LevelID,
                        Guideline
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT CONTINUUM MODEL DELETE ENTRY
        public void ProjectContinuumModelDeleteEntry(int ContinuumID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectContinummDelete", new
                    {
                        ContinuumID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //PROJECT CONTINUUM MODEL PROJECT EVAL INSERT
        public int ProjectContinuumModelProjectEvalInsert(int ProjectID, int StudentID, int YearId, int ProficiencyID, string HolisticScore, DateTime EvalDate, string Comments, string Feedback)
        {
            int output = -1;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("ProjectEvaluationInsert", new
                    {
                        ProjectID,
                        StudentID,
                        YearId,
                        ProficiencyID,
                        HolisticScore,
                        EvalDate,
                        Comments,
                        Feedback
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT CONTINUUM MODEL SELECT ALL
        public List<ProjectContinuumModel> ProjectContinuumModelSelectAll()
        {
            List<ProjectContinuumModel> output = new List<ProjectContinuumModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectContinuumModel>("ProjectContinuumSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //PROJECT CONTINUUM MODEL SELECT ALL BY CONTINUUM ID
        public ProjectContinuumModel ProjectContinuumModelSelectByContinuumID(int ContinuumID)
        {
            ProjectContinuumModel output = new ProjectContinuumModel();

            output = ProjectContinuumModelSelectAll().Where(x => x.Id == ContinuumID).FirstOrDefault();

            return output;
        }

        // PROJECT EVAL MODEL INSERT
        public int ProjectEvalModelInsert(ProjectEvaluationModel model)
        {
            int output = -1;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("ProjectEvaluationInsert", new
                    {
                        model.projectId,
                        model.studentId,
                        model.yearId,
                        model.proficiencyId,
                        model.holisticScore,
                        DateTime.Now,
                        model.comments,
                        model.feedback
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //PROJECT EVAL MODEL INSERT HOLISTIC AND PROFICIENCY
        public void ProjectEvalModelInsertHolisticAndProficiency(string HolisticScore, int OverallProficiency, int ProjectEvalID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectEvaluationInsertHolisticAndProficiency", new
                    {
                        HolisticScore,
                        OverallProficiency,
                        ProjectEvalID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT EVAL SCORES MODEL INSERT
        public void ProjectEvalScoresModelInsert(int ProjectEvalID, int CharacteristicID, int ElementID, int ProficiencyID, int Score)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectEvaluationScoresInsert", new
                    {
                        ProjectEvalID,
                        CharacteristicID,
                        ElementID,
                        ProficiencyID,
                        Score
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT IDEAS INSERT 
        public void ProjectIdeasModelInsert(ProjectIdeasCulminatingActivitiesModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectIdeas_CulminatingActivitiesInsert", new
                    {
                        model.Title,
                        model.GradeLevelRangeID,
                        model.Idea,
                        model.Keywords,
                        model.Type
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT IDEAS SELECT ALL
        public List<ProjectIdeasCulminatingActivitiesModel> ProjectIdeasModelSelectAll()
        {
            List<ProjectIdeasCulminatingActivitiesModel> output = new List<ProjectIdeasCulminatingActivitiesModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectIdeasCulminatingActivitiesModel>("ProjectIdeas_CulminatingActivitiesSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT IDEAS UPDATE
        public void ProjectIdeasModelUpdate(ProjectIdeasCulminatingActivitiesModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectIdeas_CulminatingActivitiesUpdate", new
                    {
                        model.Title,
                        model.GradeLevelRangeID,
                        model.Idea,
                        model.Keywords,
                        model.Type,
                        model.ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //PROJECT IDEAS MODEL DELETE
        public void ProjectIdeasModelDelete(ProjectIdeasCulminatingActivitiesModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectIdeas_CulminatingActivitiesDelete", new
                    {
                        model.ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT MODEL INSERT
        public int ProjectModelInsert(ProjectModel model)
        {
            int output = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<int>("ProjectInsert", new
                    {
                        model.courseId,
                        model.projectName,
                        model.dueDate,
                        model.continuumTypeId,
                        model.customCriteria
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT MODEL
        public void ProjectModelDelete(int ProjectID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectDelete", new
                    {
                        ProjectID
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT MODEL SELECT ALL
        public List<ProjectModel> ProjectModelSelectAll(int CourseID)
        {
            List<ProjectModel> output = new List<ProjectModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectModel>("ProjectSelectAll", new
                    {
                        CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT MODEL SELECT ONE 
        public ProjectModel ProjectModelSelectOne(int ProjectID)
        {
            ProjectModel output = new ProjectModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectModel>("ProjectSelectOne", new
                    {
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT MODEL SELECT ALL BY STUDENT
        public List<ProjectModel> ProjectModelSelectAllByStudent(int StudentID)
        {
            List<ProjectModel> output = new List<ProjectModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectModel>("ProjectSelectAllByStudent", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // PROJECT MODEL UPDATE
        public void ProjectModelUpdate(ViewGroupsViewModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ProjectEdit", new
                    {
                        model.project.projectId,
                        model.project.courseId,
                        model.project.projectName,
                        model.project.dueDate
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // PROJECT RESULTS CHAR MODEL SELECT CHAR
        public List<ProjectResultsCharacteristicModel> ProjectResultsCharacteristicModelSelectChar(int EvalID, int ElementID)
        {
            List<ProjectResultsCharacteristicModel> output = new List<ProjectResultsCharacteristicModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectResultsCharacteristicModel>("ProjectResultsSelectCharacteristics", new
                    {
                        EvalID,
                        ElementID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            foreach (var characteristic in output)
            {
                characteristic.CharacteristicHolisticScore = ProjectResultsCharacteristicModel.GetHolisticScore(characteristic.CharacteristicScore);
            }

            return output;
        }

        // PROJECT RESULTS ELEMENT MODEL
        // name is confusing
        public List<ProjectResultsElementModel> ProjectResultsElementModelInsertElements(int EvalID)
        {
            List<ProjectResultsElementModel> output = new List<ProjectResultsElementModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectResultsElementModel>("ProjectResultsSelectElements", new
                    {
                        EvalID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //PROJECT RESULTS STUDENT MODEL SELECT ALL STUDENTS
        public List<ProjectResultsStudentModel> ProjectResultsStudentModelSelectAllStudents(int GroupID)
        {
            List<ProjectResultsStudentModel> output = new List<ProjectResultsStudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ProjectResultsStudentModel>("ProjectResultsSelectStudents", new
                    {
                        GroupID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // QUOTES MODEL SELECT DAILT QUOTES
        public QuoteModel QuoteModelSelectDailyQuotes()
        {
            QuoteModel output = new QuoteModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<QuoteModel>("SelectDailyQuote",
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // QUOTES MODEL SELECT ALL
        public List<QuoteModel> QuoteModelSelectAll()
        {
            List<QuoteModel> output = new List<QuoteModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<QuoteModel>("QuotesSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // QUOTES MODEL SELECT ONE 
        public QuoteModel QuoteModelSelectOne(int QuoteID)
        {
            QuoteModel output = new QuoteModel();

            output = QuoteModelSelectAll().Where(x => x.ID == QuoteID).FirstOrDefault();

            return output;
        }

        // QUOTES MODEL UPDATE
        public void QuotesModelUpdate(QuoteModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("QuotesUpdate", new
                    {
                        model.Description,
                        model.Author,
                        model.ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // QUOTES MODEL INSERT
        public void QuotesModelInsert(QuoteModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("QuotesInsert", new
                    {
                        model.Description,
                        model.Author
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // QUOTES MODEL DELETE
        public void QuotesModelDelete(int QuoteID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("QuotesDelete", new
                    {
                        QuoteID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // ROLE CONFERENCE MODEL SELECT ALL
        public List<RoleConferenceModel> RoleConferenceModelSelectAll()
        {
            List<RoleConferenceModel> output = new List<RoleConferenceModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<RoleConferenceModel>("ConferenceToolRoleSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // SCHOOL MODEL SELECT ALL
        public List<SchoolModel> SchoolModelSelectAll()
        {
            List<SchoolModel> output = new List<SchoolModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<SchoolModel>("SchoolSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // SCHOOL MODEL SELECT ONE
        public SchoolModel SchoolModelSelectOne(int SchoolID)
        {
            SchoolModel output = new SchoolModel();

            output = SchoolModelSelectAll().Where(x => x.ID == SchoolID).FirstOrDefault();

            return output;
        }

        // SCHOOL MODEL SELECT ALL BY DISTRICT
        public List<SchoolModel> SchoolModelSelectAllByDistrict(int DistrictID)
        {
            List<SchoolModel> output = new List<SchoolModel>();

            output = SchoolModelSelectAll().Where(x => x.districtID == DistrictID).ToList();

            return output;
        }

        // SCORE TYPE MODEL SELECT ALL
        public List<ScoreTypeModel> ScoreTypeModelSelectAll()
        {
            List<ScoreTypeModel> output = new List<ScoreTypeModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ScoreTypeModel>("ScoreTypeSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // SEMSESTER MODEL SELECT ALL
        public List<SemesterModel> SemesterModelSelectAll()
        {
            List<SemesterModel> output = new List<SemesterModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<SemesterModel>("SemesterSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // SEMESTER MODEL SELECT BY ID 
        public SemesterModel SemesterModelSelectByID(int SemesterID)
        {
            SemesterModel output = new SemesterModel();

            output = SemesterModelSelectAll().Where(x => x.SemesterID == SemesterID).FirstOrDefault();

            return output;
        }

        // STUDENT COURSE MODEL ENROLL
        public void StudentCourseModelEnroll(StudentCourseModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentCourseEnroll", new
                    {
                        model.StudentID,
                        model.CourseID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // STUDENT COURSE MODEL UNENROLL
        public void StudentCourseModelUnenroll(StudentCourseModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentCourseUnenroll", new
                    {
                        model.StudentID,
                        model.CourseID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // STUDENT GOALS MODEL INSERT INDIVIDUAL STUDENT GOAL
        public void StudentGoalsModelInsertIndividualStudentGoal(StudentGoalsModel model, int StudentID, int CourseID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsInsertIndividualStudent", new
                    {
                        model.GoalPaperID,
                        model.GoalPaperTitle,
                        model.Description,
                        StudentID,
                        CourseID,
                        model.DeadlineDate,
                        model.DateAdded,
                        model.UserID,
                        model.GoalScoreTypeID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // STUDENT GOALS MODEL SELECT BY GOAL ID
        public StudentGoalsModel StudentGoalsModelSelectByGoalID(int GoalID)
        {
            StudentGoalsModel output = new StudentGoalsModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentGoalsModel>("GoalsSelectByGoalID", new
                    {
                        GoalID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // STUDENT GOALS MODEL
        public void StudentGoalsModelUpdateGoal(StudentGoalsModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsUpdateByID", new
                    {
                        model.GoalID,
                        model.Description
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // STUDENT GOALS MODEL DELETE GOAL
        public void StudentGoalsModelDeleteGoal(int GoalID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsDeleteByID", new
                    {
                        GoalID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // STUDENT GOALS MODEL MARK GOAL COMPLETED
        public void StudentGoalsModelMarkGoalCompleted(int GoalID, DateTime DateNow)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("GoalsStudentMarkCompleted", new
                    {
                        GoalID,
                        DateNow
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        //STUDENT GOALS MODEL SELECT BY COURSE
        public List<StudentGoalsModel> StudentGoalsModelSelectByCourse(int StudentID, int CourseID)
        {
            List<StudentGoalsModel> output = new List<StudentGoalsModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentGoalsModel>("GoalsSelectByCourseID", new
                    {
                        StudentID,
                        CourseID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // STUDENT MODEL *********
        public List<StudentModel> StudentModelSelectAllBySchool(int SchoolID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllBySchool", new
                    {
                        SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public StudentModel StudentModelSelectOne(int StudentID)
        {
            StudentModel output = new StudentModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectOne", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectByDistrict(int DistrictID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllByDistrict", new
                    {
                        DistrictID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectAllInClass(int ClassID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllInClass", new
                    {
                        ClassID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectAllInClassNotInGroup(int ClassID, int ProjectID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllInClassNotInGroup", new
                    {
                        ClassID,
                        ProjectID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectAllInGroup(int GroupID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllInGroup", new
                    {
                        GroupID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectAllNotInClass(int ClassID, int DistrictID)
        {
            List<StudentModel> output = new List<StudentModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentSelectAllNotInClass", new
                    {
                        ClassID,
                        DistrictID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public void StudentModelInsert(StudentModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentInsert", new
                    {
                        model.FirstName,
                        model.MiddleName,
                        model.LastName,
                        model.Suffix,
                        model.StudentNumber,
                        model.SchoolID,
                        model.DistrictID,
                        model.Email
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        public List<UserModel> StudentModelSelectUserByStudentID(int StudentID)
        {
            List<UserModel> output = new List<UserModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("StudentSelectUserByStudentID", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public void StudentModelDeleteByStudentID(int StudentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentDeleteByStudentID", new
                    {
                        StudentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        public void StudentModelUpdateInfo(StudentModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("StudentUpdateInfo", new
                    {
                        model.UserID,
                        model.FirstName,
                        model.MiddleName,
                        model.LastName,
                        model.StudentNumber,
                        model.Email,
                        model.Suffix
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        public StudentModel StudentModelSelectOneByUserModel(UserModel model)
        {
            StudentModel output = new StudentModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentModel>("StudentIDSelectByUserID", new
                    {
                        @userID = model.ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<StudentModel> StudentModelSelectAllByParentID(int ParentID)
        {
            List<StudentModel> output = new List<StudentModel>();
            List<StudentModel> DistinctAllStudentModel = new List<StudentModel>();
            List<int> studentIDList = new List<int>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    var data = conn.Query<StudentModel>("StudentSelectAllByParentID", new
                    {
                        ParentID
                    }, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var student in output)
                    {
                        if (!(studentIDList.Contains(student.ID)))
                        {
                            studentIDList.Add(student.ID);
                            DistinctAllStudentModel.Add(student);
                        }
                    }
                    output = DistinctAllStudentModel;
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // SUBJECT MODEL
        public List<SubjectModel> SubjectModelSelectAll()
        {
            List<SubjectModel> output = new List<SubjectModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<SubjectModel>("SubjectSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public SubjectModel SubjectModelSelectByID(int SubjectID)
        {
            SubjectModel output = new SubjectModel();

            output = SubjectModelSelectAll().Where(x => x.ID == SubjectID).FirstOrDefault();

            return output;
        }

        // SUBSCRIPTION REQUEST MODEL
        public void SubscriptionRequestModelInsert(SubscriptionRequestModel model)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("InsertSubscriptionRequest", new
                    {
                        model.FirstName,
                        model.LastName,
                        model.Prefix,
                        model.Email,
                        model.Phone,
                        model.ContinuumType,
                        model.Edition
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // TEACHER BOOKSHELF REQUEST MODEL
        public List<TeacherBookshelfRequestModel> TeacherBookshelfRequestModelSelectAllByTeacher(int TeacherID)
        {
            List<TeacherBookshelfRequestModel> output = new List<TeacherBookshelfRequestModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherBookshelfRequestModel>("TeacherBookshelfViewQueue", new
                    {
                        TeacherID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public void TeacherBookshelfRequestModelAcknowledgeRequest(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("AcknowledgeBookshelfRequest", new
                    {
                        ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        public void TeacherBookshelfRequestModelDenyRequest(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("DenyBookshelfRequest", new
                    {
                        ID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // TEACHER MODEL
        public List<TeacherModel> TeacherModelSelectAllBySchool(int SchoolID)
        {
            List<TeacherModel> output = new List<TeacherModel>();

            output = TeacherModelSelectAll().Where(x => x.SchoolID == SchoolID).ToList();

            return output;
        }

        public List<TeacherModel> TeacherModelSelectAll()
        {
            List<TeacherModel> output = new List<TeacherModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<TeacherModel> TeacherModelSelectAllBySubject(int SubjectID)
        {
            List<TeacherModel> output = new List<TeacherModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherSelectAllBySubject", new
                    {
                        SubjectID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<TeacherModel> TeacherModelSelectAllByDistrict(int DistrictID)
        {
            List<TeacherModel> output = new List<TeacherModel>();

            output = TeacherModelSelectAll().Where(x => x.DistrictID == DistrictID).ToList();

            return output;
        }

        public TeacherModel TeacherModelSelectOneByUserModel(UserModel model)
        {
            TeacherModel output = new TeacherModel(model);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherIDSelectByUserID", new
                    {
                        model.ID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public TeacherModel TeacherModelSelectTeacherFromPaper(int PaperID)
        {
            TeacherModel output = new TeacherModel();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherSelectOneFromPaper", new
                    {
                        PaperID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        public List<TeacherModel> TeacherModelSelectTeachersUnassignedToRole(int RoleID, int DistrictID, int SchoolID)
        {
            List<TeacherModel> output = new List<TeacherModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherSelectAllNotAssignedToRole", new
                    {
                        RoleID,
                        DistrictID,
                        SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }


        public List<TeacherModel> TeacherModelSelectTeachersAssignedToRole(int RoleID, int DistrictID, int SchoolID)
        {
            List<TeacherModel> output = new List<TeacherModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherModel>("TeacherSelectAllAssignedToRole", new
                    {
                        RoleID,
                        DistrictID,
                        SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // TEACHER USAGE REPORT MODE
        public List<TeacherUsageReportModel> TeacherUsageReportModelGetReports(int EvalPeriod, int UserID, int SchoolID)
        {
            List<TeacherUsageReportModel> output = new List<TeacherUsageReportModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<TeacherUsageReportModel>("GetTeacherUsage", new
                    {
                        UserID,
                        EvalPeriod,
                        SchoolID
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        //GET TEACHER ID BY USER ID
        public int GetTeacherIDByUserID(int UserID)
        {
            int teacherID = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    teacherID = conn.Query<int>("GetTeacherIDByUserID", new
                    {
                        UserID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return teacherID;
        }

        // GET STUDENT ID, COURSE ID, AND IF ENROLLED
        // GETS ALL DATA FROM STUDENT COURSE TABLE
        public List<StudentCourseModel> StudentCourseModelSelectAll()
        {
            List<StudentCourseModel> output = new List<StudentCourseModel>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<StudentCourseModel>("StudentCourseSelectAll",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }
        public List<UserModel> SelectSchoolAdmins()
        {
            List<UserModel> output = new List<UserModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<UserModel>("SelectSchoolAdmins",
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
            return output;
        }
        public void SetDefaultClass(int CourseID, int TeacherID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("SetDefaultClass", new { CourseID, TeacherID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }
        public void DeleteMidtermDate(int ID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("DeleteMidtermDate", new { ID }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
                throw ex;
            }
        }
        // GET CHART DATA
        public List<ChartSelectionViewModel> GetChartData(int courseID, int evalPeriod)
        {
            List<ChartSelectionViewModel> output = new List<ChartSelectionViewModel>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    output = conn.Query<ChartSelectionViewModel>("PaperDataForChart", new
                    {
                        courseID,
                        @evaluationPeriodID = evalPeriod
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return output;
        }

        // INSERT STUDENT DISTRICT, CREATES ACCOUNT
        public int StudentInsertDistrict(string firstName, string middleName, string lastName, string studentNumber, int districtID, string suffix, string email)
        {
            int studentID = 0;
            string salt = BCryptHelper.GenerateSalt();
            string hash = BCryptHelper.HashPassword("iLoveWriting!", salt);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    studentID = conn.Query<int>("StudentInsertDistrict", new
                    {
                        @firstName = firstName,
                        @middleName = middleName,
                        @lastName = lastName,
                        @studentNumber = studentNumber,
                        @districtID = districtID,
                        @suffix = suffix,
                        @email = email,
                        @salt = salt,
                        @passwordHash = hash
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return studentID;
        }

        // DOES PARENT EXIST
        public int DoesParentExist(string parentEmail)
        {
            int ParentID = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    ParentID = conn.Query<int>("ParentSelectIDByEmail", new
                    {
                        @email = parentEmail
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return ParentID;
        }

        // ASSIGN PARENT TO STUDENT
        public void AssignParentToStudent(int parentID, int studentID)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ParentStudentInsert", new
                    {
                        @parentID = parentID,
                        @studentID = studentID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // INSERT PARENT, CREATE ACCOUNT, AND ASSIGN PARENT TO STUDENT
        public void InsertParentAndAssignParentToStudent(string prefix, string firstName, string lastName, string email, string suffix, int studentID)
        {
            string salt = BCryptHelper.GenerateSalt();
            string hash = BCryptHelper.HashPassword("iLoveWriting!", salt);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("ParentInsert", new
                    {
                        @prefix = prefix,
                        @firstName = firstName,
                        @lastName = lastName,
                        @email = email,
                        @suffix = suffix,
                        @studentID = studentID,
                        @salt = salt,
                        @passwordHash = hash
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }
        }

        // DELETES COURSE
        public int CourseDelete(int CourseID)
        {
            int success = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query<int>("CourseDelete", new
                    {
                        @courseID = CourseID
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    success = 1;
                }
            }
            catch(SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return success;
        }

        // UPDATES THE COURSE INFORMATION 
        public bool CourseUpdate(EditClassModel model)
        {
            bool success = false;
          
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Query("CourseUpdate", new
                    {
                        @courseTitle = model.CourseTitle,
                        @courseID = model.CourseID,
                        @semesterID = model.SelectedCourseID,
                        @gradeID = model.SelectedGradeID,
                        @yearID = model.SelectedYearID,
                        @subjectID = model.SelectedSubjectID,
                        @period = model.SelectedPeriodID
                    }, commandType: CommandType.StoredProcedure);
                }

                success = true;
            }
            catch (SqlException ex)
            {
                InsertSqlError(ex.Message.ToString());
            }

            return success;
        }
    }
}