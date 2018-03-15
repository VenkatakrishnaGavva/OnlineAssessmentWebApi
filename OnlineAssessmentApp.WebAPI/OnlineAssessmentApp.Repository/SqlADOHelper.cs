using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using OnlineAssessmentApp.Repository.DataModels;
using System.Data;

namespace OnlineAssessmentApp.Repository
{
    public class SqlADOHelper : IDatabaseHelper
    {
        public const string ConnectionString = @"Server=tcp:onlineassessmentapp.database.windows.net,1433;Initial Catalog=OnlineAssessmentApp;Persist Security Info=False;User ID=vasu;Password=Sangitha@490;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DataTable GetData(SqlParameter[] parameterArray)
        {
             SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedureConstants.SPGetQuestionPaper;
                    for (int i = 0; i < parameterArray.Length; i++)
                    {
                        cmd.Parameters.Add(parameterArray[i]);
                    }
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    return dataTable;
                }

                
            }
            catch (Exception ex)
            {
                return new DataTable();
                
            }
            finally
            {
                con.Close();
            }

           
        
        }

        public void Save(SqlParameter[] parameterArray)
        {
            SqlConnection con = null;
            try
            {
                // StoredProcedureConstants.SPQuestionPaperUpload
                con = new SqlConnection(ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                { 
                    con.Open();
                cmd.Connection = con;
                cmd.CommandText = StoredProcedureConstants.SPQuestionPaperUpload;
                for (int i = 0; i < parameterArray.Length; i++)
                {
                    cmd.Parameters.Add(parameterArray[i]);
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                con.Close();
            }
        }


    }
}
