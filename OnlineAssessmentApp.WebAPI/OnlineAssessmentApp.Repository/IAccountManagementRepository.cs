using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository
{
   public  interface IAccountManagementRepository
    {
        bool IsValidUser(AccountDetailsData accountMangementData);
        AccountDetailsData AccountDetails { get; set; }
        bool CreateUser(UserData userData);
        
        bool CreateModule(ModuleData moduleData);
        bool CreateRole(RoleData roleData);
        List<ModulewisePageAccessData> GetModulewisePermissionList();
        List<ModuleData> GetAllModules();
        List<RoleData> GetAllRoles();
      
        bool MapModuleWisePageAccessWithRole(List<ModulewisePageAccessData> listModulewisePermissionData);
        bool UpdateUser(UserData userData);
        List<UserData> GetAllUsersData();
      

        List<ModulewisePageAccessData> GetModulewiseMenuAccessForRoleData(int roleId);
    }
}
