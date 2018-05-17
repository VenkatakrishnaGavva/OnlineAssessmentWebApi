using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class QuestionPaperData
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string QuestionText { get; set; }
        public List<OptionsData> Options { get; set; }
        public int RightOptionId { get; set; }
        public string OptionType { get; set; }
        public string WrittenAnswer { get; set; }
        public int SelectedOptionId { get; set; }
        public QuestionPaperData()
        {
            this.Options = new List<OptionsData>();
        }


    }
}
