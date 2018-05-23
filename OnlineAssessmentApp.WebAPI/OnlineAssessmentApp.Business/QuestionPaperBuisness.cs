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
        public AssessmentEntity GetAssessmentById(int id)
        {
            AssessmentEntity assessmentEntity = new AssessmentEntity();
            List<QuestionEntity> listQuestionEntity = new List<QuestionEntity>();
            try
            {
                var result = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance().GetAssessmentById(id);
                assessmentEntity.QuestionPaperId = result.QuestionPaperId;
                assessmentEntity.AssessmentId = result.Id;
                foreach (var questiondata in result.QuestionPaper)
                {
                    QuestionEntity quesEntity = new QuestionEntity();
                    quesEntity.ID = questiondata.ID;
                    quesEntity.Number = questiondata.Number;
                    quesEntity.OptionType = questiondata.OptionType;
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
                    quesEntity.WrittenAnswer = questiondata.WrittenAnswer;
                    listQuestionEntity.Add(quesEntity);
                }

            }
            catch (Exception ex)
            {

                
            }
            assessmentEntity.QuestionPaper = listQuestionEntity;
         

            return assessmentEntity;
        }

        public List<UserEntity> GetUsersForAssessmentForEvaluation(int assessement)
        {
            List<UserEntity> listusers = new List<UserEntity>();

            IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
            var usersData = questionPaperRepository.GetUsersForAssessmentForEvaluation(assessement);
            foreach (var userData in usersData)
            {
                UserEntity userEntity = new UserEntity();
                userEntity.UserId = userData.UserId;
                userEntity.Username = userData.Username;

                listusers.Add(userEntity);
            }


            return listusers;
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

        public bool SaveAssessmentResultAndAnsweredSheet(AssessmentResultEntity assessmentResultEntity)
        {
            try
            {
                AssessmentResultData assessmentResultData = new AssessmentResultData();
                assessmentResultData.UserId = assessmentResultEntity.UserId;
                assessmentResultData.AssessmentId = assessmentResultEntity.AssessmentId;
                assessmentResultData.QuestionPaperId = assessmentResultEntity.QuestionPaperId;
                assessmentResultData.CanInsertAssessmentResult = assessmentResultEntity.CanInsertAssessmentResult;
                assessmentResultData.IsWriteAssessmentLater = assessmentResultEntity.IsWriteAssessmentLater;
                int rightAnsweredCount = 0;
                foreach(var answer in assessmentResultEntity.AnsweredSheet)
                {
                   if(answer.SelectedOptionId==answer.RightOptionId)
                    {
                        rightAnsweredCount = rightAnsweredCount + 1;
                    }
                }
                assessmentResultData.TotalQuestionsCount = assessmentResultEntity.AnsweredSheet.Count;
                assessmentResultData.RightAnsweredCount = rightAnsweredCount;
               
                List<QuestionPaperData> listQuestionPaperData = new List<QuestionPaperData>();

                 foreach (var questionEntity in assessmentResultEntity.AnsweredSheet)
                {
                    QuestionPaperData questionPaperData= new QuestionPaperData();
                    questionPaperData.ID = questionEntity.ID;
                    questionPaperData.Number = questionEntity.Number;
                    questionPaperData.OptionType = questionEntity.OptionType;
                    questionPaperData.Options = new List<OptionsData>();
                    questionPaperData.SelectedOptionId = questionEntity.SelectedOptionId;
                    questionPaperData.WrittenAnswer = questionEntity.WrittenAnswer;

                    foreach (var optionEntity in questionEntity.Options)
                    {
                        OptionsData optionData = new OptionsData();
                        optionData.ID = optionEntity.ID;
                        optionData.OptionText = optionEntity.OptionText;
                        questionPaperData.Options.Add(optionData);
                    }
                    questionPaperData.QuestionText = questionEntity.QuestionText;
                    questionPaperData.RightOptionId = questionEntity.RightOptionId;
                    listQuestionPaperData.Add(questionPaperData);


                }
                assessmentResultData.AnsweredSheet = listQuestionPaperData;


               IQuestionPaperRepository questionPaperRepository = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
                return questionPaperRepository.SaveAssessmentResultAndAnsweredSheet(assessmentResultData);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public AssessmentEntity GetAssessmentForEvaluation(int assessmentId, int userid)
        {
            AssessmentEntity assessmentEntity = new AssessmentEntity();
            List<QuestionEntity> listQuestionEntity = new List<QuestionEntity>();
            try
            {
                var result = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance().GetAssessmentForEvaluation(assessmentId, userid);
                assessmentEntity.QuestionPaperId = result.QuestionPaperId;
                assessmentEntity.AssessmentId = result.Id;
                foreach (var questiondata in result.QuestionPaper)
                {
                    QuestionEntity quesEntity = new QuestionEntity();
                    quesEntity.ID = questiondata.ID;
                    quesEntity.Number = questiondata.Number;
                    quesEntity.OptionType = questiondata.OptionType;
                    quesEntity.WrittenAnswer = questiondata.WrittenAnswer;
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
            assessmentEntity.QuestionPaper = listQuestionEntity;


            return assessmentEntity;

        }
    }
}
