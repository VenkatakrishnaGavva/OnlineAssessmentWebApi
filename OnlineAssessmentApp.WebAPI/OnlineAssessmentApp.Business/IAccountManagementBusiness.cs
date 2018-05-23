using OnlineAssessmentApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business
{
    public interface IAccountManagementBusiness
    {
        UserEntity AccountDetails { get; set; }
        bool IsValidUser(UserEntity accountDetails);
        bool CreateUser(UserEntity userEntity);
        bool UpdateUser(UserEntity userEntity );
        bool CreateModule(ModuleEntity moduleEntity);
        bool CreateRole(RoleEntity roleEntity);
        List<ModuleEntity> GetAllModules();
       
        List<RoleEntity> GetAllRoles();
        List<ModuleWisePageAccessEntity> GetAllModulesWisePermissions();
        bool MapModuleWisePageAccessWithRole(List<ModuleWisePageAccessEntity> listModulewisePageAccessEntity);

        List<ModuleWisePageAccessEntity> GetModulewiseMenuAccessForRole(int roleId);
        List<UserEntity> GetAllUsersEntity();

    }
}
