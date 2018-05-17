using OnlineAssessmentApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Business
{
   public interface IQuestionPaperBuisness
    {
        bool QuestionPaperUpload(Stream questionpaper,string description, string questionPaperName);

        AssessmentEntity GetAssessmentById(int id);

        List<QuestionPaperDetailsEntity> GetAllQuestionPapersDetails();

        List<AssessmentEntity> GetAllAsseementsDetails();

        List<UserEntity> GetUsersForAssessmentForEvaluation(int assessement);
        bool CreateAssessment(AssessmentEntity assessmentEntity);
        bool MapAnAssessmentToUser(int userId, int assessmentId);
        bool SaveAssessmentResultAndAnsweredSheet(AssessmentResultEntity assessmentResultEntity);
         AssessmentEntity GetAssessmentForEvaluation(int assessmentId, int userid);

    }
}
