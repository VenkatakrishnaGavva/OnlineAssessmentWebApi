using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class AssessmentEntity
    {
        public AssessmentEntity()
        {
            this.QuestionPaper = new List<QuestionEntity>();
        }
        public int AssessmentId { get; set; }
        public int QuestionPaperId { get; set; }
        public string AssessmentName { get; set; }

        public string AssessmentDescription { get; set; }

        public  List<QuestionEntity> QuestionPaper{ get;set; }
        public QuestionPaperDetailsEntity QuestionPaperDetails { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }

    }
}
