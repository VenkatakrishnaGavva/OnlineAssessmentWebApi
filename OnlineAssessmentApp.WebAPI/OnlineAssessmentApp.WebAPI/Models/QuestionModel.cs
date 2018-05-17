using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class QuestionModel
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string QuestionText { get; set; }
        public List<OptionsModel> Options { get; set; }
        public int RightOptionId { get; set; }
        public string OptionType { get; set; }

        public string WrittenAnswer { get; set; }
        public int SelectedOptionId { get; set; }
        public QuestionModel()
        {
            this.Options = new List<OptionsModel>();
        }
    }
}