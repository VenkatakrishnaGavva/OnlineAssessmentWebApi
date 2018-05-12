using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OnlineAssessmentApp.DataFactory;
using OnlineAssessmentApp.Business.Entities;
using OnlineAssessmentApp.Repository;
using OnlineAssessmentApp.Repository.DataModels;

namespace OnlineAssessmentApp.Business
{
    public class QuestionPaperBuisness : IQuestionPaperBuisness
    {
        public bool CreateAssessment(AssessmentEntity assessmentEntity)
        {
            try
            {
                AssessmentData assessmentData = new AssessmentData();
                assessmentData.AssessmentName = assessmentEntity.AssessmentName;
                assessmentData.AssessmentDescription = assessmentEntity.AssessmentDescription;
                assessmentData.QuestionPaperData = new QuestionpaperDetails();
                assessmentData.QuestionPaperData.Id = assessmentEntity.QuestionPaperDetails.Id;
                assessmentData.StartTime = assessmentEntity.StartTime;
                assessmentData.EndTime = assessmentEntity.EndTime;
                assessmentData.CreatedBy = assessmentEntity.CreatedBy;
               

               
                IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
                return questionPaperRepository.CreateAssessment(assessmentData);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<AssessmentEntity> GetAllAsseementsDetails()
        {
            List<AssessmentEntity> listAssessmentDetailsEntity = new List<AssessmentEntity>();

            IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
            var AllAssessmentsData = questionPaperRepository.GetAllAssessmentDetails();
            foreach (var assessmentData in AllAssessmentsData)
            {
                AssessmentEntity assessmentEntity = new AssessmentEntity();
                assessmentEntity.AssessmentId = assessmentData.Id;
                assessmentEntity.AssessmentName = assessmentData.AssessmentName;
                listAssessmentDetailsEntity.Add(assessmentEntity);
            }
         
          
            return listAssessmentDetailsEntity;
        }

        public List<QuestionPaperDetailsEntity> GetAllQuestionPapersDetails()
        {
            List<QuestionPaperDetailsEntity> listQuestionPaperDetailsEntity = new List<QuestionPaperDetailsEntity>();

            IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
            var AllQuestionPapersData = questionPaperRepository.GetAllQuestionPaperDetails();
            foreach (var questionPaperData in AllQuestionPapersData)
            {
                QuestionPaperDetailsEntity questionPaperEntity = new QuestionPaperDetailsEntity();
                questionPaperEntity.Id = questionPaperData.Id;
                questionPaperEntity.QuestionPaperName = questionPaperData.QuestionPaperName;
                listQuestionPaperDetailsEntity.Add(questionPaperEntity);
            }
            return listQuestionPaperDetailsEntity;
        }
        public List<QuestionEntity> GetQuestionPaperById(int id)
        {
            List<QuestionEntity> listQuestionEntity = new List<QuestionEntity>();
            try
            {
                var result = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance().GetQuestionPaperById(id);
               
                foreach (var questiondata in result)
                {
                    QuestionEntity quesEntity = new QuestionEntity();
                    quesEntity.ID = questiondata.ID;
                    quesEntity.Number = questiondata.Number;
                    quesEntity.Options = new List<OptionsEntity>();
                    int optionID = 100;///option id starts from 100
                    foreach (var optionData in questiondata.Options)
                    {
                        OptionsEntity optionEntity = new OptionsEntity();
                        optionEntity.ID = optionData.ID;
                        optionEntity.OptionText = optionData.OptionText;
                        quesEntity.Options.Add(optionEntity);
                    }
                    quesEntity.QuestionText = questiondata.QuestionText;
                    quesEntity.RightOptionId = questiondata.RightOptionId;
                    listQuestionEntity.Add(quesEntity);
                }

            }
            catch (Exception ex)
            {

                
            }
            
            return listQuestionEntity;
        }

        public bool MapAnAssessmentToUser(int userId, int assessmentId)
        {
            try
            {
              

                IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
                return questionPaperRepository.MapAnAssessmentToUser(userId, assessmentId);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool QuestionPaperUpload(Stream questionPapeStream, string description, string questionPaperName)
        {
            bool uploadSuccess = false;
            try
            {
                var questionPaperReposiory = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
                questionPaperReposiory.QuestionPaperUpload(questionPapeStream, description,questionPaperName);

                uploadSuccess = true;
            }
            catch (Exception ex)
            {
                uploadSuccess = false;
                
            }
            return uploadSuccess;
        }
    }
}
