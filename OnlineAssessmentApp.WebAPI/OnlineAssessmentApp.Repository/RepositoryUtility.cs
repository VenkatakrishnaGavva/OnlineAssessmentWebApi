using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public static class RepositoryUtility
    {

        public static SqlParameter AddSQLParameter(string paramName, SqlDbType dbdataType, ParameterDirection paramDirection, object paramvalue=null,int size=0)
        {
            try
            {
                SqlParameter param1 = new SqlParameter();
                param1.SqlDbType = dbdataType;
                param1.ParameterName = paramName;
                param1.Direction = paramDirection;
                if(size!=0)
                {
                    param1.Size = size;
                }
                if (paramvalue != null)
                    param1.Value = paramvalue;
                return param1;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataTable ConvertCSVStreamToDatable(Stream csvStream)
        {
            DataTable csvTable = new DataTable();
             try
            {
                  using (CsvReader csvReader =
                    new CsvReader(new StreamReader(csvStream), true))
                {
                    csvTable.Load(csvReader);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return csvTable;
        }
    }
}
