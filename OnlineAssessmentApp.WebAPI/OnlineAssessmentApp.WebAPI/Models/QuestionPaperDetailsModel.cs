using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class QuestionPaperDetailsModel
    {
        public QuestionModel QuestionPaper { get; set; }
        public int Id { get; set; }
        public string QuestionPaperName { get; set; }
        public string Description { get; set; }

    }
}