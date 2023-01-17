using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class DistrictModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "District Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "Superintendent Name")]
        public string SuperintendentName { get; set; }
        [Required]
        [Display(Name = "Superintendent Email")]
        public string SuperintendentEmail { get; set; }
        [Required]
        [Display(Name = "Superintendent Phone Number")]
        public string SuperintendentPhone { get; set; }
        [Display(Name = "Ast. Superintendent Name")]
        public string AstSuperintendentName { get; set; }
        [Display(Name = "Ast. Superintendent Email")]
        public string AstSuperintendentEmail { get; set; }
        [Display(Name = "Ast. Superintendent Phone")]
        public string AstSuperintendentPhone { get; set; }
        [Display(Name = "Curriculum Coordinator Name")]
        public string CurriculumCoordinatorName { get; set; }
        [Display(Name = "Curriculum Coordinator Email")]
        public string CurriculumCooridnatorEmail { get; set; }
        [Display(Name = "Curriculum Coordinator Phone")]
        public string CurriculumCoordinatorPhone { get; set; }
        [Display(Name = "Accounts Payable To")]
        public string AccountsPayableName { get; set; }
        [Display(Name = "Accounts Payable Email")]
        public string AccountsPayableEmail { get; set; }
        [Display(Name = "Accounts Payable Phone")]
        public string AccountsPayablePhone { get; set; }
        [Display(Name = "Elementary School Phone")]
        public string ElemSchoolNumber { get; set; }
        [Display(Name = "Middle School Phone")]
        public string MidSchoolNumber { get; set; }
        [Display(Name = "High School Phone")]
        public string HighSchoolNumber { get; set; }
        [Display(Name = "Website")]
        public string Website { get; set; }
        [Required]
        [Display(Name = "Licenses Purchased")]
        public string LicensesPurchased { get; set; }
    }
    public static class DistrictModelDb
    {
        //public static List<DistrictModel> SelectAll()
        //{
        //    List<DistrictModel> output = new List<DistrictModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("DistrictSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new DistrictModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    DistrictName = dtr["DistrictName"].ToString(),
        //                    Country = dtr["Country"].ToString(),
        //                    State = dtr["State"].ToString(),
        //                    Street = dtr["Street"].ToString(),
        //                    City = dtr["City"].ToString(),
        //                    ZipCode = dtr["ZipCode"].ToString(),
        //                    Code = dtr["Code"].ToString(),
        //                    SuperintendentName = dtr["SuperintendentName"].ToString(),
        //                    SuperintendentEmail = dtr["SuperintendentEmail"].ToString(),
        //                    SuperintendentPhone = dtr["SuperintendentPhone"].ToString(),
        //                    AstSuperintendentName = dtr["AstSuperintendentName"].ToString(),
        //                    AstSuperintendentEmail = dtr["AstSuperintendentEmail"].ToString(),
        //                    AstSuperintendentPhone = dtr["AstSuperintendentPhone"].ToString(),
        //                    CurriculumCoordinatorName = dtr["CurriculumCoordinatorName"].ToString(),
        //                    CurriculumCooridnatorEmail = dtr["CurriculumCoordinatorEmail"].ToString(),
        //                    CurriculumCoordinatorPhone = dtr["CurriculumCoordinatorPhone"].ToString(),
        //                    AccountsPayableName = dtr["AccountsPayableName"].ToString(),
        //                    AccountsPayableEmail = dtr["AccountsPayableEmail"].ToString(),
        //                    AccountsPayablePhone = dtr["AccountsPayablePhone"].ToString(),
        //                    ElemSchoolNumber = dtr["ElemSchoolNumber"].ToString(),
        //                    MidSchoolNumber = dtr["MidSchoolNumber"].ToString(),
        //                    HighSchoolNumber = dtr["HighSchoolNumber"].ToString(),
        //                    Website = dtr["Website"].ToString(),
        //                    LicensesPurchased = dtr["LicensesPurchased"].ToString()

        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
        //public static List<DistrictModel> SelectIndividualDistrict(int DistrictID)
        //{
        //    List<DistrictModel> output = new List<DistrictModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("DistrictSelectByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@districtID", DistrictID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new DistrictModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    DistrictName = dtr["DistrictName"].ToString(),
        //                    Country = dtr["Country"].ToString(),
        //                    State = dtr["State"].ToString(),
        //                    Street = dtr["Street"].ToString(),
        //                    City = dtr["City"].ToString(),
        //                    ZipCode = dtr["ZipCode"].ToString(),
        //                    Code = dtr["Code"].ToString(),
        //                    SuperintendentName = dtr["SuperintendentName"].ToString(),
        //                    SuperintendentEmail = dtr["SuperintendentEmail"].ToString(),
        //                    SuperintendentPhone = dtr["SuperintendentPhone"].ToString(),
        //                    AstSuperintendentName = dtr["AstSuperintendentName"].ToString(),
        //                    AstSuperintendentEmail = dtr["AstSuperintendentEmail"].ToString(),
        //                    AstSuperintendentPhone = dtr["AstSuperintendentPhone"].ToString(),
        //                    CurriculumCoordinatorName = dtr["CurriculumCoordinatorName"].ToString(),
        //                    CurriculumCooridnatorEmail = dtr["CurriculumCoordinatorEmail"].ToString(),
        //                    CurriculumCoordinatorPhone = dtr["CurriculumCoordinatorPhone"].ToString(),
        //                    AccountsPayableName = dtr["AccountsPayableName"].ToString(),
        //                    AccountsPayableEmail = dtr["AccountsPayableEmail"].ToString(),
        //                    AccountsPayablePhone = dtr["AccountsPayablePhone"].ToString(),
        //                    ElemSchoolNumber = dtr["ElemSchoolNumber"].ToString(),
        //                    MidSchoolNumber = dtr["MidSchoolNumber"].ToString(),
        //                    HighSchoolNumber = dtr["HighSchoolNumber"].ToString(),
        //                    Website = dtr["Website"].ToString(),
        //                    LicensesPurchased = dtr["LicensesPurchased"].ToString()

        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
        //public static void Insert(DistrictModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("DistrictInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@DistrictName", model.DistrictName);
        //    cmd.Parameters.AddWithValue("@Country", model.Country);
        //    cmd.Parameters.AddWithValue("@State", model.State);
        //    cmd.Parameters.AddWithValue("@SuperintendentName", model.SuperintendentName);
        //    cmd.Parameters.AddWithValue("@SuperintendentEmail", model.SuperintendentEmail);
        //    cmd.Parameters.AddWithValue("@SuperintendentPhone", model.SuperintendentPhone);
        //    cmd.Parameters.AddWithValue("@AstSuperintendentName", model.AstSuperintendentName);
        //    cmd.Parameters.AddWithValue("@AstSuperintendentEmail", model.AstSuperintendentEmail);
        //    cmd.Parameters.AddWithValue("@AstSuperintendentPhone", model.AstSuperintendentPhone);
        //    cmd.Parameters.AddWithValue("@CurriculumCoordinatorName", model.CurriculumCoordinatorName);
        //    cmd.Parameters.AddWithValue("@CurriculumCoordinatorEmail", model.CurriculumCooridnatorEmail);
        //    cmd.Parameters.AddWithValue("@CurriculumCoordinatorPhone", model.CurriculumCoordinatorPhone);
        //    cmd.Parameters.AddWithValue("@AccountsPayableName", model.AccountsPayableName);
        //    cmd.Parameters.AddWithValue("@AccountsPayableEmail", model.AccountsPayableEmail);
        //    cmd.Parameters.AddWithValue("@AccountsPayablePhone", model.AccountsPayablePhone);
        //    cmd.Parameters.AddWithValue("@ElemSchoolNumber", model.ElemSchoolNumber);
        //    cmd.Parameters.AddWithValue("@MidSchoolNumber", model.MidSchoolNumber);
        //    cmd.Parameters.AddWithValue("@HighSchoolNumber", model.HighSchoolNumber);
        //    cmd.Parameters.AddWithValue("@Website", model.Website);
        //    cmd.Parameters.AddWithValue("@LicensesPurchased", model.LicensesPurchased);
        //    cmd.Parameters.AddWithValue("@Street", model.Street);
        //    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }

        //}
    }
    public static class DistrictModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<DistrictModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (DistrictModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.DistrictName,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<DistrictModel> models, bool hasSelect)
        {
            var output = GetSelectListItems(models);
            if (hasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                if (hasSelect)
                {
                    output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
                }
            }
            return output;
        }
    }
}