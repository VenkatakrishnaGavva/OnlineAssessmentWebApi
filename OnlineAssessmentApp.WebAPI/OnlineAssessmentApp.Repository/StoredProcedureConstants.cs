using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public static class StoredProcedureNameConstants
    {
        public  const string SPQuestionPaperUpload = "SP_InsertQuestionPaper        ";
        public const string SPGetQuestionPaper = "SP_GetQuestionPaper";
        public const string SPIsValidUser = "SP_LoginCheck";
        public const string SPCreateUser = "Sp_CreateUser";

    }
}
