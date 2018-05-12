using OnlineAssessmentapp.BusinessFactory;
using OnlineAssessmentApp.Business.Entities;
using OnlineAssessmentApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace OnlineAssessmentApp.WebAPI.Controllers
{
    public class AccountMangementController : ApiController
    {
        [HttpGet]
        [Route("api/GetModulewisePages")]
        public async Task<HttpResponseMessage> GetModulewisePages()
        {
           
            try
            {
              var AllModulesData =  BusinessFactory.CreateAccountManagementBusinessInstance().GetAllModulesWisePermissions();
                List<ModuleWisePageAccessModel> listModuleWisePageAccessModel = new List<ModuleWisePageAccessModel>();

                foreach (var moduleWisePageAccessData in AllModulesData)
                {
                    ModuleWisePageAccessModel moduleWisePageAccess = new ModuleWisePageAccessModel();
                    moduleWisePageAccess.Module = new ModuleModel();
                    moduleWisePageAccess.Module.ModuleId = moduleWisePageAccessData.Module.ModuleId;
                    moduleWisePageAccess.Module.ModuleName = moduleWisePageAccessData.Module.ModuleName;
                    List<PageModel> listPageModel = new List<PageModel>();
                    foreach (var pageData in moduleWisePageAccessData.pageList)
                    {
                        PageModel pageModel = new PageModel();
                        pageModel.PageId = pageData.PageId;
                        pageModel.PageName = pageData.PageName;
                        listPageModel.Add(pageModel);
                    }
                    moduleWisePageAccess.pageList = listPageModel;
                    listModuleWisePageAccessModel.Add(moduleWisePageAccess);
                }

                return Request.CreateResponse<List<ModuleWisePageAccessModel>>(HttpStatusCode.OK,listModuleWisePageAccessModel);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/GetAllModules")]
        public async Task<HttpResponseMessage> GetAllModules()
        {

            try
            {
                List<ModuleModel> listModuleModel = new List<ModuleModel>();

               var moduleListEntity = BusinessFactory.CreateAccountManagementBusinessInstance().GetAllModules();

                foreach (var moduleEntity in moduleListEntity)
                {
                    ModuleModel module = new ModuleModel();
                    module.ModuleId = moduleEntity.ModuleId;
                    module.ModuleName = moduleEntity.ModuleName;
                    listModuleModel.Add(module);
                }
                return Request.CreateResponse<List<ModuleModel>>(HttpStatusCode.OK, listModuleModel);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }


        [HttpGet]
        [Route("api/GetAllMenuPagesForRole")]
        public async Task<HttpResponseMessage> GetAllMenuPagesForRole(int roleId)
        {

            try
            {
                List<ModuleWisePageAccessModel> listModuleWisePageAccessModel = new List<ModuleWisePageAccessModel>();
                var menuPages = BusinessFactory.CreateAccountManagementBusinessInstance().GetModulewiseMenuAccessForRole(roleId);

                foreach (var menupage in menuPages)
                {
                    ModuleWisePageAccessModel moduleWisePageAccessModel = new ModuleWisePageAccessModel();
                    moduleWisePageAccessModel.Module = new ModuleModel();
                    moduleWisePageAccessModel.Module.ModuleId = menupage.Module.ModuleId;
                    moduleWisePageAccessModel.Module.ModuleName = menupage.Module.ModuleName;
                    foreach (var pageEntity in menupage.pageList)
                    {
                        PageModel page = new PageModel();

                        page.PageId = pageEntity.PageId;
                        page.PageName = pageEntity.PageName;
                        page.PageUrl = pageEntity.PageUrl;
                        moduleWisePageAccessModel.pageList.Add(page);
                    }
                    listModuleWisePageAccessModel.Add(moduleWisePageAccessModel);

                }
                return Request.CreateResponse<List<ModuleWisePageAccessModel>>(HttpStatusCode.OK, listModuleWisePageAccessModel);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/GetAllRoles")]
        public async Task<HttpResponseMessage> GetAllRoles()
        {

            try
            {
                List<RoleModel> listRoleModel = new List<RoleModel>();

                var rolesListEntity = BusinessFactory.CreateAccountManagementBusinessInstance().GetAllRoles();

                foreach (var roleEntity in rolesListEntity)
                {
                    RoleModel role = new RoleModel();
                    role.RoleId = roleEntity.RoleId;
                    role.RoleName = roleEntity.RoleName;
                    listRoleModel.Add(role);
                }
                return Request.CreateResponse<List<RoleModel>>(HttpStatusCode.OK, listRoleModel);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("api/GetAllUsers")]
        public async Task<HttpResponseMessage> GetAllUsers()
        {

            try
            {
                List<UserModel> listUserModel = new List<UserModel>();

                var users = BusinessFactory.CreateAccountManagementBusinessInstance().GetAllUsersEntity();

                foreach (var userenity in users)
                {
                    UserModel user = new UserModel();
                    user.UserId = userenity.UserId;
                    user.Username = userenity.Username;
                    user.FirstName = userenity.FirstName;
                    user.LastName = userenity.LastName;

                    user.EmailAddress = userenity.EmailAddress;
                    user.Role = new RoleModel();
                    user.Role.RoleId = userenity.Role.RoleId;
                    
                    user.Role.RoleName = userenity.Role.RoleName;
                    listUserModel.Add(user);
                }
                return Request.CreateResponse<List<UserModel>>(HttpStatusCode.OK, listUserModel);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/CreateModule")]
        public async Task<HttpResponseMessage> CreateModule(ModuleModel moduleModel)
        {

            try
            {
                ModuleEntity moduleEntity = new ModuleEntity();

                moduleEntity.ModuleName = moduleModel.ModuleName;
                moduleEntity.Description = moduleModel.Description;
                moduleEntity.CreatedBy = moduleModel.CreatedBy;
               

                BusinessFactory.CreateAccountManagementBusinessInstance().CreateModule(moduleEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }


        [HttpPost]
        [Route("api/CreateRole")]
        public async Task<HttpResponseMessage> CreateRole(RoleModel roleModel)
        {

            try
            {
                RoleEntity roleEntity = new RoleEntity();

                roleEntity.RoleName = roleModel.RoleName;
                roleEntity.Description = roleModel.Description;
                roleEntity.CreatedBy = roleModel.CreatedBy;


                BusinessFactory.CreateAccountManagementBusinessInstance().CreateRole(roleEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

           [HttpPost]
        [Route("api/UpdateUser")]
        public async Task<HttpResponseMessage> UpdateUser(UserModel user)
        {

            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.UserId = user.UserId;
                userEntity.Username = user.Username;
                userEntity.Password = user.Password;
                userEntity.EmailAddress = user.EmailAddress;
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.ModifiedBy = user.ModifiedBy;
                userEntity.Role = new RoleEntity();

                userEntity.Role.RoleId =  user.Role.RoleId;

                BusinessFactory.CreateAccountManagementBusinessInstance().UpdateUser(userEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<HttpResponseMessage> CreateUser(UserModel user)
        {

            try
            {
                UserEntity userEntity = new UserEntity();

                userEntity.Username = user.Username;
                userEntity.Password = user.Password;
                userEntity.EmailAddress = user.EmailAddress;
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.CreatedBy = user.CreatedBy;
                userEntity.Role = new RoleEntity();

                userEntity.Role.RoleId = user.Role.RoleId;

                BusinessFactory.CreateAccountManagementBusinessInstance().CreateUser(userEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("api/MapModuleWisePageAccessWithRole")]
        public async Task<HttpResponseMessage> MapModuleWisePageAccessWithRole(List<ModuleWisePageAccessModel> moduleWisePageAccessModelList)
        {

            try
            {
                List<ModuleWisePageAccessEntity> listModulewisepageAccessEntity = new List<ModuleWisePageAccessEntity>();
            

                
                foreach (var moduleWisePageAccessModel in moduleWisePageAccessModelList)
                {
                    ModuleWisePageAccessEntity moduleWisePageAccessEntity = new ModuleWisePageAccessEntity();
                    moduleWisePageAccessEntity.Module = new ModuleEntity();
                    moduleWisePageAccessEntity.Module.ModuleId = moduleWisePageAccessModel.Module.ModuleId;
                    moduleWisePageAccessEntity.Module.ModuleName = moduleWisePageAccessModel.Module.ModuleName;
                    moduleWisePageAccessEntity.Role = new RoleEntity();
                    if (moduleWisePageAccessModel.Role != null)
                    {
                        if (moduleWisePageAccessModel.Role.RoleId != 0)
                        {
                            moduleWisePageAccessEntity.Role.RoleId = moduleWisePageAccessModel.Role.RoleId;
                        }
                    }

                    foreach (var pageModel in moduleWisePageAccessModel.pageList)
                    {
                        PageEntity pageEntity = new PageEntity();
                       
                        pageEntity.PageId = pageModel.PageId;
                        pageEntity.PageName = pageModel.PageName;
                        pageEntity.IsPageSelected = pageModel.IsPageSelected;
                        moduleWisePageAccessEntity.pageList.Add(pageEntity);

                    }
                    listModulewisepageAccessEntity.Add(moduleWisePageAccessEntity);
                }
                BusinessFactory.CreateAccountManagementBusinessInstance().MapModuleWisePageAccessWithRole(listModulewisepageAccessEntity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}