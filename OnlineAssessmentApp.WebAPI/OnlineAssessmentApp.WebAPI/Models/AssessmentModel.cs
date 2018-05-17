using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class AssessmentModel
    {

        public AssessmentModel()
        {
            this.QuestionPaper = new List<QuestionModel>();
        }
        public int AssessmentId { get; set; }
        public string AssessmentName { get; set; }

        public string AssessmentDescription { get; set; }

        public int QuestionPaperId { get; set; }

        public List<QuestionModel> QuestionPaper { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }
    }
}