using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source.Data;

namespace Source.Models
{
    public class ContinuumLookupModel
    {
        private FullContinuumModel theContinuum;
        private static ContinuumLookupModel self;
        private ContinuumLookupModel()
        {
            theContinuum = FullContinuumModelDb.SelectAll();
        }
        public static ContinuumLookupModel getInstance()
        {
            if (self == null)
            {
                self = new ContinuumLookupModel();
            }
            return self;
        }
        public ContinuumChunkModel[,] getChunks(int paperTypeID)
        {
            int numberOfEvalTypes = 10;
            int numberOfProficiencies = 14;
            ContinuumChunkModel[,] output = new ContinuumChunkModel[numberOfEvalTypes, numberOfProficiencies];
            for (int evals = 0; evals < numberOfEvalTypes; evals++)
            {
                for (int profs = 0; profs < numberOfProficiencies; profs++)
                {
                    output[evals, profs] = theContinuum.chunks[profs, paperTypeID, evals];
                }
            }
            return output;
        }
    }
    //public static class ContinuumLookupModelDb
    //{
    //    public static int SelectProficiencyLevelByMonthAndGrade(int monthID, int gradeID)
    //    {
    //        int output = 0;
    //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        SqlCommand cmd = new SqlCommand("SelectProficiencyLevelByMonthAndGrade", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@monthID", monthID);
    //        cmd.Parameters.AddWithValue("@gradeID", gradeID);
    //        try
    //        {
    //            conn.Open();
    //            output = Convert.ToInt32(cmd.ExecuteScalar());
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorModelDb.InsertSqlError(ex.Message.ToString());
    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }
    //        return output;
    //    }
    //}
    [TestClass]
    public class ContinuumLookupModelTest
    {
        [TestMethod]
        public void TestSelectProficiencyLevelByMonthAndGrade()
        {
            Repository repo = new Repository();

            int a = repo.ContinuumSelectProficiencyLevelByMonthAndGrade(1, 1);
            Assert.AreEqual(2, a);
        }
    }
}