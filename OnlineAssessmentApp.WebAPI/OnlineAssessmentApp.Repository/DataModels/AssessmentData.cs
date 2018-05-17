using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class AssessmentData
    {

        public AssessmentData()
        {
            this.QuestionPaper = new List<QuestionPaperData>();
        }
        public int Id { get; set; }
        public int QuestionPaperId { get; set; }
        public string AssessmentName { get; set; }

        public string AssessmentDescription { get; set; }

        public QuestionpaperDetails QuestionPaperData { get; set; }

        public List<QuestionPaperData> QuestionPaper {get;set;}
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }



    }
}
