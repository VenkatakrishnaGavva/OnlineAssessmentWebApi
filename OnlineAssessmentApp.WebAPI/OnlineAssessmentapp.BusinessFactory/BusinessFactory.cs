using OnlineAssessmentApp.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAssessmentapp.BusinessFactory
{
    public class BusinessFactory
    {
        public static IQuestionPaperBuisness CreateQuestionPaperBusinessInstance()
        {
            return new QuestionPaperBuisness();
        }
        public static IAccountManagementBusiness CreateAccountManagementBusinessInstance()
        {
            return new AccountManagementBusiness();
        }
    }
}
