using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class QuestionPaperDetailsEntity
    {

            public int Id { get; set; }
            public string QuestionPaperName { get; set; }
            public string Description { get; set; }
            public QuestionEntity QuestionPaper { get; set; }
    
    }
}
