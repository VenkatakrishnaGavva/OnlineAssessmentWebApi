using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public interface IQuestionPaperRepository
    {
        bool QuestionPaperUpload(Stream streamQuestionPaper, string description);

        List<QuestionPaperData> GetQuestionPaperById(int id);
    }
}
