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
        AssessmentData GetAssessmentById(int id);

        bool CreateAssessment(AssessmentData assessmentData);
        bool MapAnAssessmentToUser(int userId, int assessmentId);
        List<AssessmentData> GetAllAssessmentDetails();

        bool SaveAssessmentResultAndAnsweredSheet(AssessmentResultData assessmentResultData);
        List<UserData> GetUsersForAssessmentForEvaluation(int assessement);
        AssessmentData GetAssessmentForEvaluation(int assessmentId, int userid);


    }
}
