using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssessmentApp.Business.Entities;
using OnlineAssessmentApp.Repository.DataModels;
using OnlineAssessmentApp.Repository;

namespace OnlineAssessmentApp.Business
{
    public class AccountManagementBusiness : IAccountManagementBusiness
    {
        public AccountDetailEntity AccountDetails { get; set; }

        public bool CreateModule(ModuleEntity moduleEntity)
        {
            try
            {
                ModuleData moduleData = new ModuleData();
                moduleData.ModuleName = moduleEntity.ModuleName;
                moduleData.Description = moduleEntity.Description;
                moduleData.CreatedBy = moduleEntity.CreatedBy;

                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.CreateModule(moduleData);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

      

        public bool CreateRole(RoleEntity roleEntity)
        {
            try
            {
                RoleData roleData = new RoleData();
                roleData.RoleName = roleEntity.RoleName;
                roleData.Description = roleEntity.Description;
                roleData.CreatedBy = roleEntity.CreatedBy;

                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.CreateRole(roleData);
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool CreateUser(UserEntity userEntity)
        {
            try
            {
                UserData userData = new UserData();
                userData.Username = userEntity.Username;
                userData.Password = userEntity.Password;
                userData.EmailAddress = userEntity.EmailAddress;
                userData.FirstName = userEntity.FirstName;
                userData.LastName = userEntity.LastName;
                userData.CreatedBy = userEntity.CreatedBy;
                userData.Role = new RoleData();
                
                userData.Role.RoleId = userEntity.Role.RoleId;
                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.CreateUser(userData);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<ModuleEntity> GetAllModules()
        {
            List<ModuleEntity> listModulesEntity = new List<ModuleEntity>();

            IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
            var AllModulesData = accountRepository.GetAllModules();
            foreach(var moduleData in AllModulesData)
            {
                ModuleEntity moduleEntity = new ModuleEntity();
                moduleEntity.ModuleId = moduleData.ModuleId;
                moduleEntity.ModuleName = moduleData.ModuleName;
                listModulesEntity.Add(moduleEntity);
            }
            return listModulesEntity;
        }

        public List<ModuleWisePageAccessEntity> GetAllModulesWisePermissions()
        {
            List<ModuleWisePageAccessEntity> listModuleswisePageAccessEntity = new List<ModuleWisePageAccessEntity>();

            IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
            var AllModulesData = accountRepository.GetModulewisePermissionList();
            foreach (var moduleWisePermissionData in AllModulesData)
            {
                ModuleWisePageAccessEntity modulwisePageAccessEntity = new ModuleWisePageAccessEntity();
                modulwisePageAccessEntity.Module = new ModuleEntity();
                modulwisePageAccessEntity.Module.ModuleId = moduleWisePermissionData.Module.ModuleId;
                modulwisePageAccessEntity.Module.ModuleName = moduleWisePermissionData.Module.ModuleName;
                List<PageEntity> listPageEntity = new List<PageEntity>();
               foreach (var permissionData in moduleWisePermissionData.pageList)
                {
                    PageEntity pageEntity = new PageEntity();
                    pageEntity.PageId = permissionData.PageId;
                    pageEntity.PageName = permissionData.PageName;
                    listPageEntity.Add(pageEntity);
                }
                modulwisePageAccessEntity.pageList = listPageEntity;
                listModuleswisePageAccessEntity.Add(modulwisePageAccessEntity);
            }
            

            return listModuleswisePageAccessEntity;
        }

    

        public List<RoleEntity> GetAllRoles()
        {
            List<RoleEntity> listRoleEntity = new List<RoleEntity>();

            IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
            var AllRolesData = accountRepository.GetAllRoles();
            foreach (var roleData in AllRolesData)
            {
                RoleEntity roleEntity = new RoleEntity();
                roleEntity.RoleId = roleData.RoleId;
                roleEntity.RoleName = roleData.RoleName;
                listRoleEntity.Add(roleEntity);
            }
            return listRoleEntity;
        }

        public List<UserEntity> GetAllUsersEntity()
        {
            List<UserEntity> listUserntity = new List<UserEntity>();

            IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
            var AllUsersData = accountRepository.GetAllUsersData();
            foreach (var userData in AllUsersData)
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Username = userData.Username;
                userEntity.FirstName = userData.FirstName;
                userEntity.LastName = userData.LastName;
                userEntity.UserId = userData.UserId;
                userEntity.EmailAddress = userData.EmailAddress;
                userEntity.Role = new RoleEntity();

                userEntity.Role.RoleId = userData.Role.RoleId;
                userEntity.Role.RoleName = userData.Role.RoleName;
                listUserntity.Add(userEntity);
            }
            return listUserntity;
        }

        public List<ModuleWisePageAccessEntity> GetModulewiseMenuAccessForRole(int roleId)
        {
            List<ModuleWisePageAccessEntity> listModuleWisePageAccessEntity = new List<ModuleWisePageAccessEntity>();
            IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
            var listModulewiseMenuAccessForRoleData = accountRepository.GetModulewiseMenuAccessForRoleData(roleId);
            foreach(var modulewiseMenuAccessForRoleData in listModulewiseMenuAccessForRoleData)
            {
                ModuleWisePageAccessEntity moduleWisePageAccessEntity = new ModuleWisePageAccessEntity();
                moduleWisePageAccessEntity.Module = new ModuleEntity();
                moduleWisePageAccessEntity.Module.ModuleId= modulewiseMenuAccessForRoleData.Module.ModuleId;
                moduleWisePageAccessEntity.Module.ModuleName = modulewiseMenuAccessForRoleData.Module.ModuleName;
                foreach (var pageData in modulewiseMenuAccessForRoleData.pageList)
                {
                    PageEntity page = new PageEntity();

                    page.PageId = pageData.PageId;
                    page.PageName = pageData.PageName;
                    page.PageUrl = pageData.PageUrl;
                    moduleWisePageAccessEntity.pageList.Add(page);
                }
                listModuleWisePageAccessEntity.Add(moduleWisePageAccessEntity);
            }
            return listModuleWisePageAccessEntity;
        }

        public bool IsValidUser(AccountDetailEntity accountDetails)
        {
            bool isValidUser = false;
            try
            {
                AccountDetailsData accountdetaailsData = new AccountDetailsData();
                accountdetaailsData.UserName = accountDetails.UserName;
                accountdetaailsData.Password = accountDetails.Password;
                accountdetaailsData.AccessCode = accountDetails.AccessCode;
                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                if (accountRepository.IsValidUser(accountdetaailsData))
                {
                    //accountDetails.UserID = accountRepository.AccountDetails.UserID;
                    accountDetails.UserID = accountdetaailsData.UserID;
                    accountDetails.RoleId = accountdetaailsData.RoleId;
                    isValidUser = true;
                }
                else
                {
                    isValidUser = false;
                }
                return isValidUser ;
            }
            catch (Exception ex)
            {

                throw;
            }
            


        }

        public bool MapModuleWisePageAccessWithRole(List<ModuleWisePageAccessEntity> listModulewisePermissionEntity)
        {
            try
            {
                List<ModulewisePageAccessData> listModulewisePermissionData = new List<ModulewisePageAccessData>();



                foreach (var modulewisePermissionEntity in listModulewisePermissionEntity)
                {
                    ModulewisePageAccessData modulewisePermissionData = new ModulewisePageAccessData();
                    modulewisePermissionData.Module = new ModuleData();
                    modulewisePermissionData.Module.ModuleId = modulewisePermissionEntity.Module.ModuleId;
                    modulewisePermissionData.Module.ModuleName = modulewisePermissionEntity.Module.ModuleName;
                    modulewisePermissionData.Role = new RoleData();
                    if (modulewisePermissionEntity.Role != null)
                    {
                        if (modulewisePermissionEntity.Role.RoleId != 0)
                        {
                            modulewisePermissionData.Role.RoleId = modulewisePermissionEntity.Role.RoleId;
                        }
                    }
                    foreach (var permissionEntity in modulewisePermissionEntity.pageList)
                    {
                        PageData permissionData = new PageData();
                        permissionData.PageId = permissionEntity.PageId;
                        permissionData.PageName = permissionEntity.PageName;
                        permissionData.IsPageSelected = permissionEntity.IsPageSelected;
                        modulewisePermissionData.pageList.Add(permissionData);

                    }
                    listModulewisePermissionData.Add(modulewisePermissionData);
                }
                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.MapModuleWisePageAccessWithRole(listModulewisePermissionData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool UpdateUser(UserEntity userEntity)
        {
            try
            {
                UserData userData = new UserData();
                userData.UserId = userEntity.UserId;
                userData.Username = userEntity.Username;
                userData.Password = userEntity.Password;
                userData.EmailAddress = userEntity.EmailAddress;
                userData.FirstName = userEntity.FirstName;
                userData.LastName = userEntity.LastName;
                userData.ModifiedBy = userEntity.ModifiedBy;
                userData.Role = new RoleData();

                userData.Role.RoleId = userEntity.Role.RoleId;
                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.UpdateUser(userData);

            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }

}
