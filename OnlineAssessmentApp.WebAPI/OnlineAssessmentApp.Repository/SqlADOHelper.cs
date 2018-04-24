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
        // public const string ConnectionString = @"Server=tcp:onlineassessmentappnew.database.windows.net,1433;Initial Catalog=OnlineAssessmentApp;Persist Security Info=False;User ID=vasu;Password=Sangitha@490;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //// public const string ConnectionString = @"Server=.;Database=OnlineAssessmentApp;Trusted_Connection=True;";
        public const string ConnectionString =  @"Data Source = SQL5031.site4now.net; Initial Catalog = DB_A393D9_OnlineAssessment; User Id = DB_A393D9_OnlineAssessment_admin; Password=Sangitha@490";

        public void GetOutputParamValue(SqlParameter[] parameterArray, string storedprocedureName)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = storedprocedureName;
                    

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


        public DataTable GetData(SqlParameter[] parameterArray,string storedprocedurename)
        {
             SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = storedprocedurename;
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
                cmd.CommandText = StoredProcedureNameConstants.SPQuestionPaperUpload;
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
