using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OnlineAssessmentApp.DataFactory;
using OnlineAssessmentApp.Business.Entities;

namespace OnlineAssessmentApp.Business
{
    public class QuestionPaperBuisness : IQuestionPaperBuisness
    {
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

       
        public bool QuestionPaperUpload(Stream questionPapeStream, string description)
        {
            bool uploadSuccess = false;
            try
            {
                var questionPaperReposiory = DataFactory.DataFactory.CreateQuestionPaperRepositoryInstance();
                questionPaperReposiory.QuestionPaperUpload(questionPapeStream, description);

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
