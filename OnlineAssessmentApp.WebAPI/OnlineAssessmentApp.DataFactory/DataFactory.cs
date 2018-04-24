using OnlineAssessmentApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAssessmentApp.DataFactory
{
    public class DataFactory
    {
        public static IQuestionPaperRepository  CreateQuestionPaperRepositoryInstance()
        {
            return new QuestionPaperDataRepository();
        }
        public static IAccountManagementRepository CreateAccountmanagementRepositoryInstance()
        {
            return new AccountManagementRepository();
        }
    }
}
