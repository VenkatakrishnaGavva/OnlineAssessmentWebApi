using OnlineAssessmentApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineAssessmentApp.Business
{
   public interface IQuestionPaperBuisness
    {
        bool QuestionPaperUpload(Stream questionpaper,string description);

        List<QuestionEntity> GetQuestionPaperById(int id);


    }
}
