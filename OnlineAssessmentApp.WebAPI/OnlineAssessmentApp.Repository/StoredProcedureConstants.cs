using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public static class StoredProcedureNameConstants
    {
        public  const string SPQuestionPaperUpload = "Sp_UploadQuestionPaper";
        public const string SPGetQuestionPaper = "SP_GetQuestionPaper";
        public const string SPGetQuestionPaperForEvaluate = "SP_GetQuestionPaperForEvaluate";
        public const string SPSaveResultAndAnsweredSheet = "Sp_SaveResultAndAnsweredSheet";
      
        public const string SPIsValidUser = "SP_LoginCheck";
        public const string SPCreateUser = "Sp_CreateUser";
        public const string MapAnAssessmentToUser = "Sp_MapAnAssessmentToUser";
        public const string SPCreateAssessment = "Sp_CreateAssessment";
        public const string SPUpdateUser = "Sp_UpdateUser";
        public const string SPCreateModule = "Sp_CreateModule";
        public const string SPMapModuleWisePageWithRole = "Sp_MapModulewisePagesForRole";
        public const string SPCreateRole = "Sp_CreateRole";
        public const string SpGetAllModules = "Sp_GetModules";
        public const string SpGetAllQuestionPapers = "Sp_GetAllQuestionPapers";

        public const string SpGetAllAssessments = "Sp_GetAllAssessments";

        public const string SpGetUsersByAssessmentId = "Sp_GetUsersByAssessmentId";
  

        public const string SpGetAllUsers = "Sp_GetAllUsers";
        public const string SpGetAllRoles = "Sp_GetRoles";
        public const string SpGetAllModulesWisePermissionData = "Sp_GetModulewisePagesList";
        public const string Sp_GetAllAccessedMenuPages = "Sp_GetAllMenuPagesForRole";
       
        public const string SpCreatePermission = "Sp_CreatePermision";
    }
}
