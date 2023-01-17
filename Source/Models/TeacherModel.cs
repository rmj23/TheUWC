namespace Source.Models
{
    public class TeacherModel : UserModel
    {
        public int TeacherID { get; set; }
        public string SchoolName { get; set; }
        public TeacherModel()
        { }
        public TeacherModel(UserModel userModel)
        {
            this.Active = userModel.Active;
            this.DistrictID = userModel.DistrictID;
            this.Email = userModel.Email;
            this.FirstName = userModel.FirstName;
            this.Gender = userModel.Gender;
            this.ID = userModel.ID;
            this.LastName = userModel.LastName;
            this.MiddleName = userModel.MiddleName;
            this.Participate = userModel.Participate;
            this.Password = userModel.Password;
            this.PhoneNumber = userModel.PhoneNumber;
            this.RoleID = userModel.RoleID;
            this.SchoolID = userModel.SchoolID;
            this.TestAccount = userModel.TestAccount;
        }
    }

    // delete all
    public static class TeacherModelDb
    {
        //private const int unassignedId = 99;
        //public static List<TeacherModel> SelectAllBySchool(int SchoolID)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("TeacherSelectAllBySchool", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@schoolId", SchoolID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    Email = dtr["email"].ToString(),
        //                    SchoolName = dtr["schoolName"].ToString()
        //                });
        //            } while (dtr.Read());

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectAll()
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    globalRole = dtr["globalRole"].ToString(),
        //                    globalRoleId = Convert.ToInt32(dtr["globalRoleId"]),
        //                    DistrictID = Convert.ToInt32(dtr["DistrictID"]),
        //                    SchoolID = Convert.ToInt32(dtr["SchoolID"])
        //                });

        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectAllByDistrictWithNoRoles(int districtId)
        //{
        //    List<TeacherModel> teachers = selectAll();
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    foreach (TeacherModel teacher in teachers)
        //    {
        //        if (teacher.globalRoleId == unassignedId)
        //        {
        //            if (districtId != 0)
        //            {
        //                if (teacher.DistrictID == districtId)
        //                {
        //                    output.Add(teacher);
        //                }

        //            }
        //            else
        //            {
        //                output.Add(teacher);
        //            }
        //        }

        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectAllByDistrictAssignedToARole(int districtId)
        //{
        //    List<TeacherModel> teachers = selectAll();
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    foreach (TeacherModel teacher in teachers)
        //    {
        //        if (teacher.globalRoleId != unassignedId)
        //        {
        //            if (districtId != 0)
        //            {
        //                if (teacher.DistrictID == districtId)
        //                {
        //                    output.Add(teacher);
        //                }

        //            }
        //            else
        //            {
        //                output.Add(teacher);
        //            }
        //        }
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectTeachersUnassignedToRoleAllDistricts(int roleId)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectAllAssignedToRoleAllDistricts", conn);
        //    cmd.Parameters.AddWithValue("@roleId", roleId);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    globalRole = dtr["globalRole"].ToString()
        //                });

        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectTeachersAssignedToRoleAllDistricts(int roleId)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectAllAssignedToRoleAllDistricts", conn);
        //    cmd.Parameters.AddWithValue("@roleId", roleId);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    globalRole = dtr["globalRole"].ToString()
        //                });

        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> SelectAllBySubject(int subjectId)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("TeacherSelectAllBySubject", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@subjectId", subjectId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    Email = dtr["email"].ToString(),
        //                    SchoolName = dtr["schoolName"].ToString()

        //                });
        //            } while (dtr.Read());

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static List<TeacherModel> SelectAllByDistrict(int districtId)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("TeacherSelectAllByDistrict", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@districtId", districtId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    Email = dtr["email"].ToString(),
        //                    SchoolName = dtr["schoolName"].ToString()

        //                });
        //            } while (dtr.Read());

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static TeacherModel SelectOneByUserModel(UserModel userModel)
        //{
        //    TeacherModel output = new TeacherModel(userModel);
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("TeacherIDSelectByUserID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@UserID", userModel.ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.TeacherID = Convert.ToInt32(dtr["ID"]);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //internal static TeacherModel SelectTeacherFromPaper(int paperId)
        //{
        //    TeacherModel output = new TeacherModel();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectOneFromPaper", conn);
        //    cmd.Parameters.AddWithValue("@paperId", paperId);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.TeacherID = Convert.ToInt32(dtr["TeacherID"]);
        //                output.FirstName = dtr["firstName"].ToString();
        //                output.LastName = dtr["lastName"].ToString();
        //                output.Email = dtr["email"].ToString();
        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static List<TeacherModel> selectTeachersUnassignedToRole(int roleId, int districtId, int schoolId)
        //{

        //    List<TeacherModel> output = new List<TeacherModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectAllNotAssignedToRole", conn);
        //    cmd.Parameters.AddWithValue("@roleId", roleId);
        //    cmd.Parameters.AddWithValue("@districtId", districtId);
        //    cmd.Parameters.AddWithValue("@schoolId", schoolId);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    globalRole = dtr["globalRole"].ToString()
        //                });

        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static List<TeacherModel> selectTeachersAssignedToRole(int roleId, int districtId, int schoolId)
        //{
        //    List<TeacherModel> output = new List<TeacherModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherSelectAllAssignedToRole", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@roleId", roleId);
        //    cmd.Parameters.AddWithValue("@districtId", districtId);
        //    cmd.Parameters.AddWithValue("@schoolId", schoolId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    globalRole = dtr["globalRole"].ToString()
        //                });

        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

    }
}