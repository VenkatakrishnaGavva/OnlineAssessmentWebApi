using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class AssessmentResultModel
    {

            public AssessmentResultModel()
            {
                this.QuestionPaper = new List<QuestionModel>();

            }
            public int AssessmentId { get; set; }

            public int QuestionPaperId { get; set; }

            public List<QuestionModel> QuestionPaper { get; set; }
            public int UserId { get; set; }

            public int TotalQuestionsCount { get; set; }

            public int RightAnsweredCount { get; set; }
            public bool CanInsertAssessmentResult { get; set; }
        
    }
}