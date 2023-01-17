using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Source.Models
{
    public class FullContinuumModel
    {
        public ContinuumChunkModel[,,] chunks;
        public FullContinuumModel()
        {
            int proficiencyLevels = 14;
            int paperTypes = 7;
            int evalTypes = 10;
            chunks = new ContinuumChunkModel[proficiencyLevels, paperTypes, evalTypes];
        }
    }
    public class FullContinuumModel2
    {
        public List<ContinuumChunkModel> chunks;
        public FullContinuumModel2()
        {
            this.chunks = new List<ContinuumChunkModel>();
        }
    }
    public static class FullContinuumModelDb
    {
        public static FullContinuumModel SelectAll()
        {
            FullContinuumModel model = new FullContinuumModel();
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("ContinuumSelectAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read())
                {
                    do
                    {
                        int proficiencyLevel = Convert.ToInt32(dtr["evaluationTypeID"]) - 1;
                        int paperType = Convert.ToInt32(dtr["paperTypeID"]);
                        int evaltype = Convert.ToInt32(dtr["detailsID"]) - 1;
                        paperType = paperType == 99 ? 0 : paperType;
                        model.chunks[proficiencyLevel, paperType, evaltype] = new ContinuumChunkModel()
                        {
                            Contents = HttpUtility.HtmlDecode(dtr["guideline"].ToString()),
                            ProficiencyLevel = proficiencyLevel,
                            PaperType = paperType,
                            EvaluationType = evaltype
                        };
                    }
                    while (dtr.Read());
                }
            }
            catch (Exception ex)
            {
                ErrorModelDb.InsertSqlError(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return model;
        }
        public static FullContinuumModel2 SelectAll2()
        {
            FullContinuumModel2 model = new FullContinuumModel2();
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("ContinuumSelectAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read())
                {
                    do
                    {
                        model.chunks.Add(new ContinuumChunkModel()
                        {
                            Contents = HttpUtility.HtmlDecode(dtr["guideline"].ToString()),
                            ProficiencyLevel = Convert.ToInt32(dtr["evaluationTypeID"]),
                            PaperType = Convert.ToInt32(dtr["paperTypeID"]),
                            EvaluationType = Convert.ToInt32(dtr["detailsID"])
                        });
                    }
                    while (dtr.Read());
                }
            }
            catch (Exception ex)
            {
                ErrorModelDb.InsertSqlError(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return model;
        }
    }
}