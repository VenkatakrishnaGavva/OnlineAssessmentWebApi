using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
 
        public class AssessmentResultEntity
        {
            public AssessmentResultEntity()
            {
                this.AnsweredSheet = new List<QuestionEntity>();

            }
            public int AssessmentId { get; set; }
        public bool IsWriteAssessmentLater { get; set; }

        public int QuestionPaperId { get; set; }

            public List<QuestionEntity> AnsweredSheet { get; set; }
            public int UserId { get; set; }

            public int TotalQuestionsCount { get; set; }

            public int RightAnsweredCount { get; set; }
            public bool CanInsertAssessmentResult { get; set; }
        }
    }

