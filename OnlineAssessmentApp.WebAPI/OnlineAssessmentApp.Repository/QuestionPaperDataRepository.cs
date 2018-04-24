using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OnlineAssessmentApp.Repository
{
    public class QuestionPaperDataRepository : IQuestionPaperRepository
    {
        public List<QuestionPaperData> GetQuestionPaperById(int id)
        {
            List<QuestionPaperData> listQuestionPaper = new List<QuestionPaperData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter param1 = new SqlParameter();
            param1.SqlDbType = System.Data.SqlDbType.Int;
            param1.ParameterName = "@id";
            param1.Direction = System.Data.ParameterDirection.Input;
            param1.Value = id;
            
            SqlParameter[] paramArray = new SqlParameter[1];
            paramArray[0] = param1;
            var dt =   objSqlADOHelper.GetData(paramArray,StoredProcedureNameConstants.SPGetQuestionPaper);
            var stringReader = new System.IO.StringReader(Convert.ToString(dt.Rows[0].ItemArray[1]));
            var serializer = new XmlSerializer(typeof(List<QuestionPaperData>));
            listQuestionPaper= serializer.Deserialize(stringReader) as List<QuestionPaperData>;
            return listQuestionPaper;
        }


        private StringBuilder CreateQuestionPaperXMLFromDataTable(DataTable dt)
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
               

                List<QuestionPaperData> listQuestionPaperData = new List<QuestionPaperData>();
                int questionID = 1;

                
                foreach (DataRow row in dt.Rows)
                {
                    QuestionPaperData objQuestionPaperData = new QuestionPaperData();
                    objQuestionPaperData.ID = questionID;
                    objQuestionPaperData.Number = Convert.ToInt32(row.ItemArray[0]);
                    objQuestionPaperData.QuestionText = Convert.ToString(row.ItemArray[1]);
                    objQuestionPaperData.OptionType = Convert.ToString(row.ItemArray[2]);
                    int optionID = 100;///option id starts from 100
                    int optionColumnIndex = 3;
                    while (optionColumnIndex <= 6)
                    {
                        OptionsData option = new OptionsData();
                        option.ID = optionID;
                        option.OptionText = Convert.ToString(row.ItemArray[optionColumnIndex]);
                        objQuestionPaperData.Options.Add(option);
                        optionID++;
                        optionColumnIndex++;
                    }

                    string optionIDText = Convert.ToString(row.ItemArray[7]);
                    if(optionIDText== "Option1")
                    {
                        objQuestionPaperData.RightOptionId = 100;
                    }
                    else if (optionIDText == "Option2")
                    {
                        objQuestionPaperData.RightOptionId = 101;
                    }
                    else if (optionIDText == "Option3")
                    {
                        objQuestionPaperData.RightOptionId = 102;
                    }
                    else if (optionIDText == "Option4")
                    {
                        objQuestionPaperData.RightOptionId = 103;
                    }
                    questionID++;
                    
                    listQuestionPaperData.Add(objQuestionPaperData);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionPaperData>));
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, listQuestionPaperData);
                    strBuilder.Append(textWriter.ToString());
                }

            }
            catch (Exception)
            {

                throw;
            }
            return strBuilder;
        }


        public bool QuestionPaperUpload(Stream questionPaperStream,string description)
        {
            bool isInsertionSuccess = false;
             DataTable dtQuestionPaper =  RepositoryUtility.ConvertCSVStreamToDatable(questionPaperStream);
            string xml = Convert.ToString(CreateQuestionPaperXMLFromDataTable(dtQuestionPaper));

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter param1 = new SqlParameter();
            param1.SqlDbType = System.Data.SqlDbType.Xml;
            param1.ParameterName = "@questionpaperxml";
            param1.Direction = System.Data.ParameterDirection.Input;
            param1.Value = xml;
            SqlParameter param2 = new SqlParameter();
            param2.SqlDbType = System.Data.SqlDbType.VarChar;
            param2.Direction = System.Data.ParameterDirection.Input;
            param2.Value = description;
            param2.ParameterName = "@description";
            SqlParameter[] paramArray = new SqlParameter[2];
            paramArray[0] = param1;
            paramArray[1] = param2;

            objSqlADOHelper.Save(paramArray);
            return isInsertionSuccess;
        }
    }
}
