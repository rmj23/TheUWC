namespace Source.Models
{
    public class ParentModel : UserModel
    {
        public int ParentID { get; set; }
        public ParentModel()
        {

        }
        public ParentModel(UserModel model)
        {
            this.Active = model.Active;
            this.DistrictID = model.DistrictID;
            this.Email = model.Email;
            this.FirstName = model.FirstName;
            this.Gender = model.Gender;
            this.ID = model.ID;
            this.LastName = model.LastName;
            this.MiddleName = model.MiddleName;
            this.Participate = model.Participate;
            this.Password = model.Password;
            this.PhoneNumber = model.PhoneNumber;
            this.RoleID = model.RoleID;
            this.SchoolID = model.SchoolID;
            this.TestAccount = model.TestAccount;
        }
    }

    // delete all
    public static class ParentModelDb
    {
        //public static List<ParentModel> SelectAllByStudent(int StudentID)
        //{
        //    List<ParentModel> output = new List<ParentModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ParentSelectAllByStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", StudentID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ParentModel()
        //                {
        //                    ParentID = Convert.ToInt32(dtr["ID"]),
        //                    ID = Convert.ToInt32(dtr["UserID"]),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    MiddleName = dtr["middleName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    Email = dtr["email"].ToString(),
        //                    Password = dtr["pwd"].ToString(),
        //                    PhoneNumber = dtr["phoneNumber"].ToString(),
        //                    Gender = dtr["Gender"].ToString(),
        //                    Prefix = dtr["prefix"].ToString(),
        //                    Suffix = dtr["suffix"].ToString()
        //                });
        //                if (dtr["roleID"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].RoleID = Convert.ToInt32(dtr["roleID"]);
        //                }
        //                if (dtr["schoolID"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].SchoolID = Convert.ToInt32(dtr["schoolID"]);
        //                }
        //                if (dtr["districtID"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].DistrictID = Convert.ToInt32(dtr["districtID"]);
        //                }
        //                if (dtr["active"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].Active = Convert.ToBoolean(dtr["active"]);
        //                }
        //                if (dtr["participate"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].Participate = Convert.ToBoolean(dtr["participate"]);
        //                }
        //                if (dtr["testAccount"] != DBNull.Value)
        //                {
        //                    output[output.Count - 1].TestAccount = Convert.ToBoolean(dtr["testAccount"]);
        //                }
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
        //public static ParentModel SelectOneByUserID(int userID)
        //{
        //    ParentModel output = new ParentModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ParentSelectOneByUserID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@userID", userID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = new ParentModel()
        //            {
        //                ParentID = Convert.ToInt32(dtr["ID"]),
        //                ID = Convert.ToInt32(dtr["UserID"]),
        //                FirstName = dtr["firstName"].ToString(),
        //                MiddleName = dtr["middleName"].ToString(),
        //                LastName = dtr["lastName"].ToString(),
        //                Email = dtr["email"].ToString(),
        //                Password = dtr["pwd"].ToString(),
        //                PhoneNumber = dtr["phoneNumber"].ToString(),
        //                Gender = dtr["Gender"].ToString(),
        //                Prefix = dtr["prefix"].ToString(),
        //                Suffix = dtr["suffix"].ToString()
        //            };
        //            if (dtr["roleID"] != DBNull.Value)
        //            {
        //                output.RoleID = Convert.ToInt32(dtr["roleID"]);
        //            }
        //            if (dtr["schoolID"] != DBNull.Value)
        //            {
        //                output.SchoolID = Convert.ToInt32(dtr["schoolID"]);
        //            }
        //            if (dtr["districtID"] != DBNull.Value)
        //            {
        //                output.DistrictID = Convert.ToInt32(dtr["districtID"]);
        //            }
        //            if (dtr["active"] != DBNull.Value)
        //            {
        //                output.Active = Convert.ToBoolean(dtr["active"]);
        //            }
        //            if (dtr["participate"] != DBNull.Value)
        //            {
        //                output.Participate = Convert.ToBoolean(dtr["participate"]);
        //            }
        //            if (dtr["testAccount"] != DBNull.Value)
        //            {
        //                output.TestAccount = Convert.ToBoolean(dtr["testAccount"]);
        //            }
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
        //public static void Insert(ParentModel model, int studentID)
        //{
        //    //Create Login Info
        //    LoginModel login = new LoginModel();
        //    login.NewUserParent(model.Email, "iLoveWriting!", model);
        //    //check all the fields that could be left null.
        //    if (model.Prefix == null)
        //    {
        //        model.Prefix = "N/A";
        //    }
        //    if (model.MiddleName == null)
        //    {
        //        model.MiddleName = "N/A";
        //    }
        //    if (model.Suffix == null)
        //    {
        //        model.Suffix = "N/A";
        //    }
        //    if (model.PhoneNumber == null)
        //    {
        //        model.PhoneNumber = "N/A";
        //    }
        //    var salt = BCryptHelper.GenerateSalt();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ParentInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
        //    cmd.Parameters.AddWithValue("@lastName", model.LastName);
        //    cmd.Parameters.AddWithValue("@middleName", model.MiddleName);
        //    cmd.Parameters.AddWithValue("@email", model.Email);
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    cmd.Parameters.AddWithValue("@prefix", model.Prefix);
        //    cmd.Parameters.AddWithValue("@suffix", model.Suffix);
        //    cmd.Parameters.AddWithValue("@salt", salt);
        //    cmd.Parameters.AddWithValue("@passwordHash", BCryptHelper.HashPassword("iLoveWriting1!", salt));
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //        //System.Diagnostics.Debug.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static void RemoveAssociationToStudent(int pUserID, int studentID)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ParentRemoveAssociationToStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@pUserID", pUserID);
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static void UpdateContactInfo(ParentModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ParentUpdateContactInfo", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (model.Prefix == null)
        //    {
        //        model.Prefix = "N/A";
        //    }
        //    if (model.Suffix == null)
        //    {
        //        model.Suffix = "N/A";
        //    }
        //    cmd.Parameters.AddWithValue("@email", model.Email);
        //    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
        //    cmd.Parameters.AddWithValue("@lastName", model.LastName);
        //    cmd.Parameters.AddWithValue("@prefix", model.Prefix);
        //    cmd.Parameters.AddWithValue("@suffix", model.Suffix);
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //    public static ParentModel SelectOneByUserModel(UserModel userModel)
        //    {
        //        ParentModel output = new ParentModel(userModel);
        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("ParentSelectOneByUserID", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserID", userModel.ID);
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader dtr = cmd.ExecuteReader();
        //            if (dtr.Read())
        //            {
        //                output.ParentID = Convert.ToInt32(dtr["ID"]);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            ErrorModelDb.InsertSqlError(ex.ToString());
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //        return output;
        //    }
    }
}