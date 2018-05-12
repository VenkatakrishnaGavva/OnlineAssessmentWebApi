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

        List<QuestionEntity> GetQuestionPaperById(int id);

        List<QuestionPaperDetailsEntity> GetAllQuestionPapersDetails();

        List<AssessmentEntity> GetAllAsseementsDetails();


        bool CreateAssessment(AssessmentEntity assessmentEntity);
        bool MapAnAssessmentToUser(int userId, int assessmentId);
    }
}
