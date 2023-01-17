using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Source.Models
{
    public class BulkInsertModel
    {

    }
    public static class BulkInsertModelDb
    {
        public static DataTable ProcessCSV(string fileName) //Function to parse through an excel spreadsheet and create a datatable. It's dynamic, so however many rows and columns are in the file will be the rows and column in the table.
        {
            string Feedback = string.Empty;
            string line = string.Empty;
            string[] strArray;
            DataTable dt = new DataTable();
            DataRow row;
            Regex r = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            StreamReader sr = new StreamReader(fileName);
            //Read firs line and split the string at ","
            line = sr.ReadLine();
            strArray = r.Split(line);
            //build our data columns from the csv
            Array.ForEach(strArray, s => dt.Columns.Add(new DataColumn()));
            //Read each line in the csv until it's empty.
            while ((line = sr.ReadLine()) != null)
            {
                row = dt.NewRow();
                //add current value to data row
                row.ItemArray = r.Split(line);
                dt.Rows.Add(row);
            }
            sr.Dispose();
            return dt;

        }
        public static void StudentBulkInsertDistrict(DataTable dt, int districtID)
        {
            //student variables
            string firstname = "";
            string middlename = "";
            string lastname = "";
            string suffix = "";
            string studentnumber = "";
            string studentemail = "";
            //parent 1 variables
            string parent1prefix = "";
            string parent1firstname = "";
            string parent1lastname = "";
            string parent1suffix = "";
            string parent1email = "";
            //parent 2
            string parent2prefix = "";
            string parent2firstname = "";
            string parent2lastname = "";
            string parent2suffix = "";
            string parent2email = "";
            //parent3
            string parent3prefix = "";
            string parent3firstname = "";
            string parent3lastname = "";
            string parent3suffix = "";
            string parent3email = "";
            int studentID = 0;
            //Declare all the commands that might be used in the insert.
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("StudentInsertDistrict", conn);
            SqlCommand cmd1 = new SqlCommand("ParentInsert", conn);
            SqlCommand cmd2 = new SqlCommand("ParentSelectIDByEmail", conn);
            SqlCommand cmd3 = new SqlCommand("ParentStudentInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction;
            conn.Open();
            using (transaction = conn.BeginTransaction())
                try
                {
                    cmd.Transaction = transaction;
                    cmd1.Transaction = transaction;
                    cmd2.Transaction = transaction;
                    cmd3.Transaction = transaction;
                    foreach (DataRow row in dt.Rows)
                    {
                        //student info
                        firstname = row[0].ToString();
                        middlename = row[1].ToString();
                        lastname = row[2].ToString();
                        suffix = row[3].ToString();
                        studentnumber = row[4].ToString();
                        studentemail = row[5].ToString();
                        //parent(s) info
                        parent1prefix = row[6].ToString();
                        parent1firstname = row[7].ToString();
                        parent1lastname = row[8].ToString();
                        parent1suffix = row[9].ToString();
                        parent1email = row[10].ToString();
                        parent2prefix = row[11].ToString();
                        parent2firstname = row[12].ToString();
                        parent2lastname = row[13].ToString();
                        parent2suffix = row[14].ToString();
                        parent2email = row[15].ToString();
                        parent3prefix = row[16].ToString();
                        parent3firstname = row[17].ToString();
                        parent3lastname = row[18].ToString();
                        parent3suffix = row[19].ToString();
                        parent3email = row[20].ToString();
                        if (firstname == "N/A" & lastname == "N/A") //Basically, if there's no student. I doubt this will ever happen, but who knows.
                        {
                            continue;
                        }
                        string StudentSalt = BCryptHelper.GenerateSalt();
                        string StudentHash = BCryptHelper.HashPassword("iLoveWriting!", StudentSalt);//Set default Password to iLoveWriting!
                        cmd.Parameters.AddWithValue("@firstName", firstname);
                        cmd.Parameters.AddWithValue("@middleName", middlename);
                        cmd.Parameters.AddWithValue("@lastName", lastname);
                        cmd.Parameters.AddWithValue("@studentNumber", studentnumber);
                        cmd.Parameters.AddWithValue("@districtID", districtID);
                        cmd.Parameters.AddWithValue("@suffix", suffix);
                        cmd.Parameters.AddWithValue("@email", studentemail);
                        cmd.Parameters.AddWithValue("@salt", StudentSalt);
                        cmd.Parameters.AddWithValue("@passwordHash", StudentHash);
                        studentID = (int)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();

                        //Parent insert.
                        if (parent1firstname != "N/A" & parent1lastname != "N/A") //If there's data insert it, else go to parent 2
                        {
                            //Check to see if parent already exists, if they do just insert them in the parent student table
                            int parentID = -1;
                            cmd2.Parameters.AddWithValue("@email", parent1email);
                            try
                            {
                                parentID = (int)cmd2.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd2.Parameters.Clear();
                            if (parentID != -1) // parent already exisits.
                            {
                                cmd3.Parameters.AddWithValue("@parentID", parentID);
                                cmd3.Parameters.AddWithValue("@studentID", studentID);
                                try
                                {
                                    cmd3.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd3.Parameters.Clear();
                            }
                            else
                            {
                                string ParentOneSalt = BCryptHelper.GenerateSalt();
                                string ParentOneHash = BCryptHelper.HashPassword("iLoveWriting!", ParentOneSalt);//Set default Password to iLoveWriting!
                                cmd1.Parameters.AddWithValue("@prefix", parent1prefix);
                                cmd1.Parameters.AddWithValue("@firstName", parent1firstname);
                                cmd1.Parameters.AddWithValue("@lastName", parent1lastname);
                                cmd1.Parameters.AddWithValue("@email", parent1email);
                                cmd1.Parameters.AddWithValue("@suffix", parent1suffix);
                                cmd1.Parameters.AddWithValue("@studentID", studentID);
                                cmd1.Parameters.AddWithValue("@salt", ParentOneSalt);
                                cmd1.Parameters.AddWithValue("@passwordHash", ParentOneHash);
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd1.Parameters.Clear();
                            }
                        }
                        if (parent2firstname != "N/A" & parent2lastname != "N/A")// If there's data for parent 2 insert it, else go to parent 3
                        {
                            //Check to see if parent already exists, if they do just insert them in the parent student table
                            int parentID = -1;
                            cmd2.Parameters.AddWithValue("@email", parent1email);
                            try
                            {
                                parentID = (int)cmd2.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd2.Parameters.Clear();
                            if (parentID != -1) // parent already exisits.
                            {
                                cmd3.Parameters.AddWithValue("@parentID", parentID);
                                cmd3.Parameters.AddWithValue("@studentID", studentID);
                                try
                                {
                                    cmd3.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd3.Parameters.Clear();
                            }
                            else
                            {
                                string ParentTwoSalt = BCryptHelper.GenerateSalt();
                                string ParentTwoHash = BCryptHelper.HashPassword("iLoveWriting!", ParentTwoSalt);//Set default Password to iLoveWriting!
                                cmd1.Parameters.AddWithValue("@prefix", parent2prefix);
                                cmd1.Parameters.AddWithValue("@firstName", parent2firstname);
                                cmd1.Parameters.AddWithValue("@lastName", parent2lastname);
                                cmd1.Parameters.AddWithValue("@suffix", parent2suffix);
                                cmd1.Parameters.AddWithValue("@email", parent2email);
                                cmd1.Parameters.AddWithValue("@studentID", studentID);
                                cmd1.Parameters.AddWithValue("@salt", ParentTwoSalt);
                                cmd1.Parameters.AddWithValue("@passwordHash", ParentTwoHash);
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd1.Parameters.Clear();
                            }
                        }
                        if (parent3firstname != "N/A" & parent3lastname != "N/A")  //If there's data for parent 3 insert it, else go to the next row.
                        {
                            string ParentThreeSalt = BCryptHelper.GenerateSalt();
                            string ParentThreeHash = BCryptHelper.HashPassword("iLoveWriting!", ParentThreeSalt);//Set default Password to iLoveWriting!
                            cmd1.Parameters.AddWithValue("@prefix", parent3prefix);
                            cmd1.Parameters.AddWithValue("@firstName", parent3firstname);
                            cmd1.Parameters.AddWithValue("@lastName", parent3lastname);
                            cmd1.Parameters.AddWithValue("@suffix", parent3suffix);
                            cmd1.Parameters.AddWithValue("@email", parent3email);
                            cmd1.Parameters.AddWithValue("@studentID", studentID);
                            cmd1.Parameters.AddWithValue("@salt", ParentThreeSalt);
                            cmd1.Parameters.AddWithValue("@passwordHash", ParentThreeHash);
                            try
                            {
                                cmd1.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd1.Parameters.Clear();
                        }
                        else
                        {
                            continue;
                        }

                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    ErrorModelDb.InsertSqlError(ex.Message.ToString());
                }
            conn.Close();
        }
        public static void StudentBulkInsert(DataTable dt, int schoolID, int districtID)
        {
            //student variables
            string firstname = "";
            string middlename = "";
            string lastname = "";
            string suffix = "";
            string studentnumber = "";
            string studentemail = "";
            //parent 1 variables
            string parent1prefix = "";
            string parent1firstname = "";
            string parent1lastname = "";
            string parent1suffix = "";
            string parent1email = "";
            //parent 2
            string parent2prefix = "";
            string parent2firstname = "";
            string parent2lastname = "";
            string parent2suffix = "";
            string parent2email = "";
            //parent3
            string parent3prefix = "";
            string parent3firstname = "";
            string parent3lastname = "";
            string parent3suffix = "";
            string parent3email = "";
            int studentID = 0;
            //Declare all the commands that might be used in the insert.
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("StudentInsert", conn);
            SqlCommand cmd1 = new SqlCommand("ParentInsert", conn);
            SqlCommand cmd2 = new SqlCommand("ParentSelectIDByEmail", conn);
            SqlCommand cmd3 = new SqlCommand("ParentStudentInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction;
            conn.Open();
            using (transaction = conn.BeginTransaction())
                try
                {
                    cmd.Transaction = transaction;
                    cmd1.Transaction = transaction;
                    cmd2.Transaction = transaction;
                    cmd3.Transaction = transaction;
                    foreach (DataRow row in dt.Rows)
                    {
                        //student info
                        firstname = row[0].ToString();
                        middlename = row[1].ToString();
                        lastname = row[2].ToString();
                        suffix = row[3].ToString();
                        studentnumber = row[4].ToString();
                        studentemail = row[5].ToString();
                        //parent(s) info
                        parent1prefix = row[6].ToString();
                        parent1firstname = row[7].ToString();
                        parent1lastname = row[8].ToString();
                        parent1suffix = row[9].ToString();
                        parent1email = row[10].ToString();
                        parent2prefix = row[11].ToString();
                        parent2firstname = row[12].ToString();
                        parent2lastname = row[13].ToString();
                        parent2suffix = row[14].ToString();
                        parent2email = row[15].ToString();
                        parent3prefix = row[16].ToString();
                        parent3firstname = row[17].ToString();
                        parent3lastname = row[18].ToString();
                        parent3suffix = row[19].ToString();
                        parent3email = row[20].ToString();
                        if (firstname == "N/A" & lastname == "N/A") //Basically, if there's no student. I doubt this will ever happen, but who knows.
                        {
                            continue;
                        }
                        string StudentSalt = BCryptHelper.GenerateSalt();
                        string StudentHash = BCryptHelper.HashPassword("iLoveWriting!", StudentSalt);//Set default Password to iLoveWriting!
                        cmd.Parameters.AddWithValue("@firstName", firstname);
                        cmd.Parameters.AddWithValue("@middleName", middlename);
                        cmd.Parameters.AddWithValue("@lastName", lastname);
                        cmd.Parameters.AddWithValue("@studentNumber", studentnumber);
                        cmd.Parameters.AddWithValue("@schoolID", schoolID);
                        cmd.Parameters.AddWithValue("@districtID", districtID);
                        cmd.Parameters.AddWithValue("@suffix", suffix);
                        cmd.Parameters.AddWithValue("@email", studentemail);
                        cmd.Parameters.AddWithValue("@salt", StudentSalt);
                        cmd.Parameters.AddWithValue("@passwordHash", StudentHash);
                        studentID = (int)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();

                        //Parent insert.
                        if (parent1firstname != "N/A" & parent1lastname != "N/A") //If there's data insert it, else go to parent 2
                        {
                            //Check to see if parent already exists, if they do just insert them in the parent student table
                            int parentID = -1;
                            cmd2.Parameters.AddWithValue("@email", parent1email);
                            try
                            {
                                parentID = (int)cmd2.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd2.Parameters.Clear();
                            if (parentID != -1) // parent already exisits.
                            {
                                cmd3.Parameters.AddWithValue("@parentID", parentID);
                                cmd3.Parameters.AddWithValue("@studentID", studentID);
                                try
                                {
                                    cmd3.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd3.Parameters.Clear();
                            }
                            else
                            {
                                string ParentOneSalt = BCryptHelper.GenerateSalt();
                                string ParentOneHash = BCryptHelper.HashPassword("iLoveWriting!", ParentOneSalt);//Set default Password to iLoveWriting!
                                cmd1.Parameters.AddWithValue("@prefix", parent1prefix);
                                cmd1.Parameters.AddWithValue("@firstName", parent1firstname);
                                cmd1.Parameters.AddWithValue("@lastName", parent1lastname);
                                cmd1.Parameters.AddWithValue("@email", parent1email);
                                cmd1.Parameters.AddWithValue("@suffix", parent1suffix);
                                cmd1.Parameters.AddWithValue("@studentID", studentID);
                                cmd1.Parameters.AddWithValue("@salt", ParentOneSalt);
                                cmd1.Parameters.AddWithValue("@passwordHash", ParentOneHash);
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd1.Parameters.Clear();
                            }
                        }
                        if (parent2firstname != "N/A" & parent2lastname != "N/A")// If there's data for parent 2 insert it, else go to parent 3
                        {
                            //Check to see if parent already exists, if they do just insert them in the parent student table
                            int parentID = -1;
                            cmd2.Parameters.AddWithValue("@email", parent1email);
                            try
                            {
                                parentID = (int)cmd2.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd2.Parameters.Clear();
                            if (parentID != -1) // parent already exisits.
                            {
                                cmd3.Parameters.AddWithValue("@parentID", parentID);
                                cmd3.Parameters.AddWithValue("@studentID", studentID);
                                try
                                {
                                    cmd3.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd3.Parameters.Clear();
                            }
                            else
                            {
                                string ParentTwoSalt = BCryptHelper.GenerateSalt();
                                string ParentTwoHash = BCryptHelper.HashPassword("iLoveWriting!", ParentTwoSalt);//Set default Password to iLoveWriting!
                                cmd1.Parameters.AddWithValue("@prefix", parent2prefix);
                                cmd1.Parameters.AddWithValue("@firstName", parent2firstname);
                                cmd1.Parameters.AddWithValue("@lastName", parent2lastname);
                                cmd1.Parameters.AddWithValue("@suffix", parent2suffix);
                                cmd1.Parameters.AddWithValue("@email", parent2email);
                                cmd1.Parameters.AddWithValue("@studentID", studentID);
                                cmd1.Parameters.AddWithValue("@salt", ParentTwoSalt);
                                cmd1.Parameters.AddWithValue("@passwordHash", ParentTwoHash);
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    ErrorModelDb.InsertSqlError(ex.ToString());
                                }
                                cmd1.Parameters.Clear();
                            }
                        }
                        if (parent3firstname != "N/A" & parent3lastname != "N/A")  //If there's data for parent 3 insert it, else go to the next row.
                        {
                            string ParentThreeSalt = BCryptHelper.GenerateSalt();
                            string ParentThreeHash = BCryptHelper.HashPassword("iLoveWriting!", ParentThreeSalt);//Set default Password to iLoveWriting!
                            cmd1.Parameters.AddWithValue("@prefix", parent3prefix);
                            cmd1.Parameters.AddWithValue("@firstName", parent3firstname);
                            cmd1.Parameters.AddWithValue("@lastName", parent3lastname);
                            cmd1.Parameters.AddWithValue("@suffix", parent3suffix);
                            cmd1.Parameters.AddWithValue("@email", parent3email);
                            cmd1.Parameters.AddWithValue("@studentID", studentID);
                            cmd1.Parameters.AddWithValue("@salt", ParentThreeSalt);
                            cmd1.Parameters.AddWithValue("@passwordHash", ParentThreeHash);
                            try
                            {
                                cmd1.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                ErrorModelDb.InsertSqlError(ex.ToString());
                            }
                            cmd1.Parameters.Clear();
                        }
                        else
                        {
                            continue;
                        }

                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    ErrorModelDb.InsertSqlError(ex.Message.ToString());
                }
            conn.Close();
        }
        public static void DistrictBulkInsert(DataTable dt, int districtID)
        {
            Random rand = new Random(); //For school code.
            int min = 1000;
            int max = 9999;
            string schoolName = "";
            string street1 = "";
            string street2 = "";
            string city = "";
            string state = "";
            string country = "";
            string zip = "";
            string phone = "";
            string schoolCode = rand.Next(min, max).ToString();
            string period = "";
            string schoolAdminFirstName = "";
            string schoolAdminLastName = "";
            string schoolAdminEmail = "";
            string schoolAdminPhone = "";
            string schoolAdminExt = "";
            string admin2LastName = "";
            string admin2FirstName = "";
            string admin2Email = "";
            string admin2Phone = "";
            string admin2Ext = "";
            string secretaryLastName = "";
            string secretaryFirstName = "";
            string gradeLevels = "";
            string numberOfLiscenses = "";
            string salt = BCryptHelper.GenerateSalt();
            string salt2 = BCryptHelper.GenerateSalt();
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("InsertSchool", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction;
            conn.Open();
            using (transaction = conn.BeginTransaction())
                try
                {
                    cmd.Transaction = transaction;
                    foreach (DataRow row in dt.Rows)
                    {
                        schoolName = row[0].ToString();
                        street1 = row[1].ToString();
                        street2 = row[2].ToString();
                        city = row[3].ToString();
                        state = row[4].ToString();
                        country = row[5].ToString();
                        zip = row[6].ToString();
                        phone = row[7].ToString();
                        period = row[8].ToString();
                        schoolAdminLastName = row[9].ToString();
                        schoolAdminFirstName = row[10].ToString();
                        schoolAdminEmail = row[11].ToString();
                        schoolAdminPhone = row[12].ToString();
                        schoolAdminExt = row[13].ToString();
                        admin2LastName = row[14].ToString();
                        admin2FirstName = row[15].ToString();
                        admin2Email = row[16].ToString();
                        admin2Phone = row[17].ToString();
                        admin2Ext = row[18].ToString();
                        secretaryLastName = row[19].ToString();
                        secretaryFirstName = row[20].ToString();
                        gradeLevels = row[21].ToString();
                        numberOfLiscenses = row[22].ToString();
                        cmd.Parameters.AddWithValue("@street1", street1);
                        cmd.Parameters.AddWithValue("@street2", street2);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@state", state);
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@zip", zip);
                        cmd.Parameters.AddWithValue("@schoolName", schoolName);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@schoolCode", schoolCode);
                        cmd.Parameters.AddWithValue("@schoolAdminFirstName", schoolAdminFirstName);
                        cmd.Parameters.AddWithValue("@schoolAdminLastName", schoolAdminLastName);
                        cmd.Parameters.AddWithValue("@schoolAdminEmail", schoolAdminEmail);
                        cmd.Parameters.AddWithValue("@schoolAdminPhone", schoolAdminPhone);
                        cmd.Parameters.AddWithValue("@salt", salt);
                        cmd.Parameters.AddWithValue("@passwordHash", BCryptHelper.HashPassword("writing1", salt));
                        cmd.Parameters.AddWithValue("@totalNumberofCodes", numberOfLiscenses);
                        cmd.Parameters.AddWithValue("@schoolAdminExt", schoolAdminExt);
                        cmd.Parameters.AddWithValue("@admin2LastName", admin2LastName);
                        cmd.Parameters.AddWithValue("@admin2FirstName", admin2FirstName);
                        cmd.Parameters.AddWithValue("@admin2Email", admin2Email);
                        cmd.Parameters.AddWithValue("@admin2Phone", admin2Phone);
                        cmd.Parameters.AddWithValue("@admin2Ext", admin2Ext);
                        cmd.Parameters.AddWithValue("@secretaryLastName", secretaryLastName);
                        cmd.Parameters.AddWithValue("@secretaryFirstName", secretaryFirstName);
                        cmd.Parameters.AddWithValue("@gradeLevels", gradeLevels);
                        cmd.Parameters.AddWithValue("@admin2salt", salt2);
                        cmd.Parameters.AddWithValue("@admin2passwordHash", BCryptHelper.HashPassword("writing1", salt2));
                        if (period == "block")
                        {
                            cmd.Parameters.AddWithValue("@period", true);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@period", false);
                        }
                        cmd.Parameters.AddWithValue("@districtID", districtID);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    ErrorModelDb.InsertSqlError(ex.Message.ToString());
                }
            conn.Close();
        }
    }

}