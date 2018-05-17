using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class QuestionEntity
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string QuestionText { get; set; }
        public List<OptionsEntity> Options { get; set; }
        public int RightOptionId { get; set; }
        public int SelectedOptionId { get; set; }
        public string OptionType { get; set; }

        public string WrittenAnswer { get; set; }
        public QuestionEntity()
        {
            this.Options = new List<OptionsEntity>();
        }

    }
}
