using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class AssessmentData
    {
        public int Id { get; set; }
        public string AssessmentName { get; set; }

        public string AssessmentDescription { get; set; }

        public QuestionpaperDetails QuestionPaperData { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }



    }
}
