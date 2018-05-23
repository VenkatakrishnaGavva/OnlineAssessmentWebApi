using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class AssessmentResultData
    {
        public AssessmentResultData()
        {
            this.AnsweredSheet = new List<QuestionPaperData>();

        }
        public int AssessmentId { get; set; }

        public int QuestionPaperId { get; set; }

        public List<QuestionPaperData> AnsweredSheet { get; set; }
        public int UserId { get; set; }

        public int TotalQuestionsCount { get; set; }

        public int RightAnsweredCount { get; set; }
        public bool CanInsertAssessmentResult { get; set; }

        public bool IsWriteAssessmentLater { get; set; }
    }
}
