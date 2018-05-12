using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public interface IQuestionPaperRepository
    {
        bool QuestionPaperUpload(Stream streamQuestionPaper, string description, string questionPaperName);
        List<QuestionpaperDetails> GetAllQuestionPaperDetails();
        List<QuestionPaperData> GetQuestionPaperById(int id);

        bool CreateAssessment(AssessmentData assessmentData);
        bool MapAnAssessmentToUser(int userId, int assessmentId);
        List<AssessmentData> GetAllAssessmentDetails();
    }
}
