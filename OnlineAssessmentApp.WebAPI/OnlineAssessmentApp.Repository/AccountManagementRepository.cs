using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository
{
    public class AccountManagementRepository : IAccountManagementRepository
    {
        public UserData AccountDetails { get; set; }

        public bool CreateModule(ModuleData moduleData)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[4];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@name", SqlDbType.VarChar, ParameterDirection.Input, moduleData.ModuleName);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@description", SqlDbType.VarChar, ParameterDirection.Input, moduleData.Description);
                 paramArray[2] = RepositoryUtility.AddSQLParameter("@CreatedBy", SqlDbType.VarChar, ParameterDirection.Input, moduleData.CreatedBy);
                   paramArray[3] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPCreateModule);
                string successMessage = Convert.ToString(paramArray[3].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isCreationSucess = false;

            }
            return isCreationSucess;

        }

        

        public bool CreateRole(RoleData roleData)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[4];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@rolename", SqlDbType.VarChar, ParameterDirection.Input, roleData.RoleName);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@roledescription", SqlDbType.VarChar, ParameterDirection.Input, roleData.RoleId);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@CreatedBy", SqlDbType.VarChar, ParameterDirection.Input, roleData.CreatedBy);
                paramArray[3] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPCreateRole);
                string successMessage = Convert.ToString(paramArray[3].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isCreationSucess = false;

            }
            return isCreationSucess;

        }

        public bool CreateUser(UserData userData)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[8];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@username", SqlDbType.VarChar, ParameterDirection.Input, userData.Username);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@password", SqlDbType.VarChar, ParameterDirection.Input, userData.Password);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@EmailAddress", SqlDbType.VarChar, ParameterDirection.Input, userData.EmailAddress );
                paramArray[3] = RepositoryUtility.AddSQLParameter("@FirstName", SqlDbType.VarChar, ParameterDirection.Input, userData.FirstName);
                paramArray[4] = RepositoryUtility.AddSQLParameter("@LastName", SqlDbType.VarChar, ParameterDirection.Input, userData.LastName);
                paramArray[5] = RepositoryUtility.AddSQLParameter("@CreatedBy", SqlDbType.VarChar, ParameterDirection.Input, userData.CreatedBy);
                paramArray[6] = RepositoryUtility.AddSQLParameter("@roleid", SqlDbType.Int, ParameterDirection.Input, (object)userData.Role.RoleId ?? DBNull.Value);
                paramArray[7] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null,500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPCreateUser);
                string successMessage = Convert.ToString(paramArray[7].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isCreationSucess = false;
               
            }
            return isCreationSucess;
        }

        public List<ModuleData> GetAllModules()
        {
            List<ModuleData> listmodules = new List<ModuleData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

          
            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllModules);
            foreach(DataRow row in dt.Rows)
            {
                ModuleData moduleData = new ModuleData();
                moduleData.ModuleName = Convert.ToString(row.ItemArray[1]);
                moduleData.ModuleId       = Convert.ToInt32(row.ItemArray[0]);
                listmodules.Add(moduleData);
            }

            return listmodules;

        }

   

        public List<RoleData> GetAllRoles()
        {
            List<RoleData> listRoles = new List<RoleData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllRoles);
            foreach (DataRow row in dt.Rows)
            {
                RoleData roleData = new RoleData();
                roleData.RoleName = Convert.ToString(row.ItemArray[1]);
                roleData.RoleId = Convert.ToInt32(row.ItemArray[0]);
                listRoles.Add(roleData);
            }

            return listRoles;

        }

        public List<UserData> GetAllUsersData()
        {
            List<UserData> listUsers = new List<UserData>();

            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllUsers);
            foreach (DataRow row in dt.Rows)
            {
                UserData user = new UserData();
                user.UserId = Convert.ToInt32(row.ItemArray[0]);
                user.Username = Convert.ToString(row.ItemArray[1]);
                user.FirstName = Convert.ToString(row.ItemArray[2]);
                user.LastName = Convert.ToString(row.ItemArray[3]);
                user.EmailAddress = Convert.ToString(row.ItemArray[4]);
                user.Role = new RoleData();
                if (!string.IsNullOrEmpty(row.ItemArray[5].ToString()) )
                {
                    user.Role.RoleId = Convert.ToInt32((row.ItemArray[5]));
                }
                if (!string.IsNullOrEmpty(row.ItemArray[6].ToString()))
                {
                    user.Role.RoleName = Convert.ToString((row.ItemArray[6]));
                }
                listUsers.Add(user);
            }

            return listUsers;
        }

        public List<ModulewisePageAccessData> GetModulewiseMenuAccessForRoleData(int roleId)
        {
            List<ModulewisePageAccessData> listModulewisePageAccessData = new List<ModulewisePageAccessData>();
            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[2];
            
                paramArray[0] = RepositoryUtility.AddSQLParameter("@RoleId", SqlDbType.Int, ParameterDirection.Input, roleId, 500);

            paramArray[1] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.Sp_GetAllAccessedMenuPages);
            foreach (DataRow row in dt.Rows)
            {
                ModulewisePageAccessData modulewisePageAccessData = new ModulewisePageAccessData();

               
                
                modulewisePageAccessData.Module = new ModuleData();
                modulewisePageAccessData.Module.ModuleId = Convert.ToInt32(row.ItemArray[0]);
                modulewisePageAccessData.Module.ModuleName = Convert.ToString(row.ItemArray[1]);
                if (listModulewisePageAccessData.Count == 0)
                {
                    PageData pageData = new PageData();
                    pageData.PageId = Convert.ToInt32(row.ItemArray[2]);
                    pageData.PageName = Convert.ToString(row.ItemArray[3]);
                    pageData.PageUrl = Convert.ToString(row.ItemArray[4]);
                    modulewisePageAccessData.pageList.Add(pageData);
                    listModulewisePageAccessData.Add(modulewisePageAccessData);
                }
                else
                {
                    bool IsModuleAlreadyAdded = false;
                    int index = -1;
                    foreach (var moduleWisePage in listModulewisePageAccessData)
                    {
                        index = index + 1;
                        if (moduleWisePage.Module != null)
                        {
                            if (moduleWisePage.Module.ModuleId == modulewisePageAccessData.Module.ModuleId)
                            {
                                IsModuleAlreadyAdded = true;
                                break;
                            }
                        }
                    }

                    if (IsModuleAlreadyAdded)
                    {
                        PageData pageData = new PageData();
                        pageData.PageId = Convert.ToInt32(row.ItemArray[2]);
                        pageData.PageName = Convert.ToString(row.ItemArray[3]);
                        pageData.PageUrl = Convert.ToString(row.ItemArray[4]);
                        listModulewisePageAccessData[index].pageList.Add(pageData);
                        
                    }
                    else
                    {
                        PageData pageData = new PageData();
                        pageData.PageId = Convert.ToInt32(row.ItemArray[2]);
                        pageData.PageName = Convert.ToString(row.ItemArray[3]);
                        pageData.PageUrl = Convert.ToString(row.ItemArray[4]);
                        modulewisePageAccessData.pageList.Add(pageData);
                        listModulewisePageAccessData.Add(modulewisePageAccessData);
                    }

                }

            }



            return listModulewisePageAccessData;
        }

        public List<ModulewisePageAccessData> GetModulewisePermissionList()
        {
            List<ModulewisePageAccessData> listmodulewisePageAccessData = new List<ModulewisePageAccessData>();



            IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
            SqlParameter[] paramArray = new SqlParameter[1];

            paramArray[0] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);


            var dt = objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SpGetAllModulesWisePermissionData);
            foreach (DataRow row in dt.Rows)
            {
                PageData permissionData = new PageData();
                permissionData.PageId = Convert.ToInt32(row.ItemArray[0]);
                permissionData.PageName = Convert.ToString(row.ItemArray[1]);

                ModuleData moduleData = new ModuleData();
                moduleData.ModuleId = Convert.ToInt32(row.ItemArray[2]);
                moduleData.ModuleName = Convert.ToString(row.ItemArray[3]);
                bool isAlreadyModuleaddedd = false;
                foreach (var moduleWisePageAccess in listmodulewisePageAccessData)
                {

                    if (moduleWisePageAccess.Module != null)
                    {
                        if (moduleWisePageAccess.Module.ModuleId == moduleData.ModuleId)
                        {
                            moduleWisePageAccess.pageList.Add(permissionData);
                            isAlreadyModuleaddedd = true;
                        }
                    }


                }

                if (isAlreadyModuleaddedd == false)
                {
                    ModulewisePageAccessData modulewisePageAccessData = new ModulewisePageAccessData();
                    modulewisePageAccessData.Module = moduleData;
                    modulewisePageAccessData.pageList.Add(permissionData);
                    listmodulewisePageAccessData.Add(modulewisePageAccessData);

                }

                


            }
            return listmodulewisePageAccessData;
        }

        public bool IsValidUser(UserData accountDetailsData)
        {
            try
            {
                bool isValidUser = false;
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
               

                SqlParameter[] paramArray = new SqlParameter[3];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@username", SqlDbType.VarChar, ParameterDirection.Input, accountDetailsData.Username);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@password", SqlDbType.VarChar, ParameterDirection.Input, accountDetailsData.Password);
                 
                paramArray[2] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output,null, 500);

                DataTable dtusers =  objSqlADOHelper.GetData(paramArray, StoredProcedureNameConstants.SPIsValidUser);
                string successMessage = Convert.ToString(paramArray[2].Value);
                if(successMessage.Equals("User successfully logged in"))
                    {
                    isValidUser = true;
                    foreach (DataRow row in dtusers.Rows)
                    {
                        accountDetailsData.UserId = Convert.ToInt32(row.ItemArray[0]);
                        accountDetailsData.Username = Convert.ToString(row.ItemArray[1]);
                        accountDetailsData.Role = new RoleData();

                        accountDetailsData.Role.RoleId = Convert.ToInt32(row.ItemArray[2]);
                        accountDetailsData.ProfilePicPath = Convert.ToString(row.ItemArray[3]);

                    }


                }
                else
                {
                    isValidUser = false;
                }

                return isValidUser;
            }


            catch (Exception ex)
            {

                return false;
            }
        }

        public bool MapModuleWisePageAccessWithRole(List<ModulewisePageAccessData> listModulewisePermissionData)
        {
            bool isCreationSucess = false;
            try
            {
                DataTable removePermissionTypeTable = new DataTable("ModuleRolePermisisonType");
                //we create column names as per the type in DB 
                removePermissionTypeTable.Columns.Add("ModuleId", typeof(Int32));
                removePermissionTypeTable.Columns.Add("RoleId", typeof(Int32));
                removePermissionTypeTable.Columns.Add("PermissionId", typeof(Int32));

                DataTable AddPermissionTypeTable = new DataTable("ModuleRolePermisisonType");
                //we create column names as per the type in DB 
                AddPermissionTypeTable.Columns.Add("ModuleId", typeof(Int32));
                AddPermissionTypeTable.Columns.Add("RoleId", typeof(Int32));
                AddPermissionTypeTable.Columns.Add("PermissionId", typeof(Int32));
                int roleid = -1;
                
              
                    foreach (var modulewisePermissionData in listModulewisePermissionData)
                {
                 
                  
                    if (modulewisePermissionData.Role != null)
                    {
                        if (modulewisePermissionData.Role.RoleId != 0)
                        {
                            roleid = modulewisePermissionData.Role.RoleId;
                        }
                    }
                    foreach(var page in modulewisePermissionData.pageList)
                    {
                       
                        if(page.IsPageSelected)
                        {
                            DataRow modulewisePageAccessRow = AddPermissionTypeTable.NewRow();
                            modulewisePageAccessRow[0] = modulewisePermissionData.Module.ModuleId;
                            modulewisePageAccessRow[1] = roleid;
                            modulewisePageAccessRow[2] = page.PageId;
                            AddPermissionTypeTable.Rows.Add(modulewisePageAccessRow);

                        }
                        else
                        {
                            DataRow modulewisePageAccessRow = removePermissionTypeTable.NewRow();
                            modulewisePageAccessRow[0] = modulewisePermissionData.Module.ModuleId;
                            modulewisePageAccessRow[1] = roleid;
                            modulewisePageAccessRow[2] = page.PageId;
                            removePermissionTypeTable.Rows.Add(modulewisePageAccessRow);

                        }
                    }
                   
                }
                SqlParameter parameter = new SqlParameter();
                //The parameter for the SP must be of SqlDbType.Structured 
                parameter.ParameterName = "@RemoveModuleRolePagetype";
                parameter.SqlDbType = System.Data.SqlDbType.Structured;
                parameter.Value = removePermissionTypeTable;
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();

                SqlParameter parameter1 = new SqlParameter();
                //The parameter for the SP must be of SqlDbType.Structured 
                parameter1.ParameterName = "@MapModuleRolepagetype";
                parameter1.SqlDbType = System.Data.SqlDbType.Structured;
                parameter1.Value = AddPermissionTypeTable;
              

                SqlParameter[] paramArray = new SqlParameter[3];

                paramArray[0] = parameter;
                paramArray[1] = parameter1;
                paramArray[2] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPMapModuleWisePageWithRole);
                string successMessage = Convert.ToString(paramArray[2].Value);
                if (successMessage.Equals("Success"))
                {
                    isCreationSucess = true;
                }
                else
                {
                    isCreationSucess = false;
                }


            }
            catch (Exception ex)
            {
                isCreationSucess = false;
            }
            return isCreationSucess;

        }

        public bool UpdateUser(UserData userData)
        {
            bool isUpdationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[9];
                paramArray[0] = RepositoryUtility.AddSQLParameter("@userid", SqlDbType.Int, ParameterDirection.Input, userData.UserId);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@username", SqlDbType.VarChar, ParameterDirection.Input, userData.Username);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@EmailAddress", SqlDbType.VarChar, ParameterDirection.Input, userData.EmailAddress);
                paramArray[3] = RepositoryUtility.AddSQLParameter("@FirstName", SqlDbType.VarChar, ParameterDirection.Input, userData.FirstName);
                paramArray[4] = RepositoryUtility.AddSQLParameter("@LastName", SqlDbType.VarChar, ParameterDirection.Input, userData.LastName);
                paramArray[5] = RepositoryUtility.AddSQLParameter("@ModifiedBy", SqlDbType.VarChar, ParameterDirection.Input, userData.ModifiedBy);
                paramArray[6] = RepositoryUtility.AddSQLParameter("@roleid", SqlDbType.Int, ParameterDirection.Input, (object)userData.Role.RoleId ?? DBNull.Value);
                paramArray[7] = RepositoryUtility.AddSQLParameter("@ProfilePicPath", SqlDbType.VarChar, ParameterDirection.Input, userData.ProfilePicPath);


                paramArray[8] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPUpdateUser);
                string successMessage = Convert.ToString(paramArray[8].Value);
                if (successMessage.Equals("Success"))
                {
                    isUpdationSucess = true;
                }
                else
                {
                    isUpdationSucess = false;
                }

            }
            catch (Exception ex)
            {
                isUpdationSucess = false;

            }
            return isUpdationSucess;
        }
    }
}
