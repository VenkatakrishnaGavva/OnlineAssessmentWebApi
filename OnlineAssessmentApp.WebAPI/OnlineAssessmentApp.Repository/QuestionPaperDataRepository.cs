﻿using OnlineAssessmentApp.Repository.DataModels;
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
        public List<QuestionpaperDetails> GetAllQuestionPaperDetails()
        {
            List<QuestionpaperDetails> listQuestionpaperDetails = new List<QuestionpaperDetails>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllQuestionPapers);
            foreach (DataRow row in dt.Rows)
            {
                QuestionpaperDetails questionPaperDetailData = new QuestionpaperDetails();
                questionPaperDetailData.Id = Convert.ToInt32(row.ItemArray[0]);
                questionPaperDetailData.QuestionPaperName = Convert.ToString(row.ItemArray[1]);
                listQuestionpaperDetails.Add(questionPaperDetailData);
            }

            return listQuestionpaperDetails;

        }

        public List<QuestionPaperData> GetQuestionPaperById(int id)
        {
            List<QuestionPaperData> listQuestionPaper = new List<QuestionPaperData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
           
           
            SqlParameter[] paramArray = new SqlParameter[2];
            paramArray[0] = RepositoryUtility.AddSQLParameter("@id", SqlDbType.VarChar, ParameterDirection.Input, id);
              paramArray[1] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

            var dt =   objSqlADOHelper.GetData(paramArray,StoredProcedureNameConstants.SPGetQuestionPaper);
            var stringReader = new System.IO.StringReader(Convert.ToString(dt.Rows[0].ItemArray[0]));
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
                    if (row.ItemArray[0].ToString()!=string.Empty)
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
                        if (optionIDText == "Option1")
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


        public bool QuestionPaperUpload(Stream questionPaperStream,string description, string questionPaperName)
        {
            bool isInsertionSuccess = false;
            try
            {
               
                DataTable dtQuestionPaper = RepositoryUtility.ConvertCSVStreamToDatable(questionPaperStream);
                string xml = Convert.ToString(CreateQuestionPaperXMLFromDataTable(dtQuestionPaper));

                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
                SqlParameter[] paramArray = new SqlParameter[4];
                paramArray[0] = RepositoryUtility.AddSQLParameter("@QuestionPaperName", SqlDbType.VarChar, ParameterDirection.Input, questionPaperName);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@description", SqlDbType.VarChar, ParameterDirection.Input, description);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@questionpaperxml", SqlDbType.Xml, ParameterDirection.Input, xml);
                paramArray[3] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPQuestionPaperUpload);
                string successMessage = Convert.ToString(paramArray[3].Value);
                if (successMessage.Equals("Success"))
                {
                    isInsertionSuccess = true;
                }
                else
                {
                    isInsertionSuccess = false;
                }
            }
            catch(Exception ex)
            {
                isInsertionSuccess = false;
            }
            return isInsertionSuccess;
        }

        public bool CreateAssessment(AssessmentData assessmentData)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[7];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@AssessmentName", SqlDbType.VarChar, ParameterDirection.Input, assessmentData.AssessmentName);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@AssessmentDescription", SqlDbType.VarChar, ParameterDirection.Input, assessmentData.AssessmentDescription);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@QuestionPaperId", SqlDbType.VarChar, ParameterDirection.Input, assessmentData.QuestionPaperData.Id);
                paramArray[3] = RepositoryUtility.AddSQLParameter("@StartTime", SqlDbType.DateTime, ParameterDirection.Input, assessmentData.StartTime);
                paramArray[4] = RepositoryUtility.AddSQLParameter("@EndTime", SqlDbType.DateTime, ParameterDirection.Input, assessmentData.EndTime);
                paramArray[5] = RepositoryUtility.AddSQLParameter("@CreatedBy", SqlDbType.VarChar, ParameterDirection.Input, assessmentData.CreatedBy);
                paramArray[6] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPCreateAssessment);
                string successMessage = Convert.ToString(paramArray[6].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isCreationSucess = false;

            }
            return isCreationSucess;

        }

        public List<AssessmentData> GetAllAssessmentDetails()
        {
            List<AssessmentData> listAssessmentData = new List<AssessmentData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllAssessments);
            foreach (DataRow row in dt.Rows)
            {
                AssessmentData assessmentData = new AssessmentData();
                assessmentData.Id = Convert.ToInt32(row.ItemArray[0]);
                assessmentData.AssessmentName = Convert.ToString(row.ItemArray[1]);
                listAssessmentData.Add(assessmentData);
            }

            return listAssessmentData;

        }

        public bool MapAnAssessmentToUser(int userId, int assessmentId)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[3];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@userid", SqlDbType.Int, ParameterDirection.Input, userId);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@assessmentid", SqlDbType.Int, ParameterDirection.Input, assessmentId);
             
                paramArray[2] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.MapAnAssessmentToUser);
                string successMessage = Convert.ToString(paramArray[2].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isCreationSucess = false;

            }
            return isCreationSucess;

        }
    }
}
