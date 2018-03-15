using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public static class RepositoryUtility
    {

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
