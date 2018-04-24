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
        public AccountDetailsData AccountDetails { get; set; }

        public bool CreateUser(UserData userData)
        {
            bool isCreationSucess = true;
            try
            {
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();


                SqlParameter[] paramArray = new SqlParameter[7];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@username", SqlDbType.VarChar, ParameterDirection.Input, userData.Username);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@password", SqlDbType.VarChar, ParameterDirection.Input, userData.Password);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@EmailAddress", SqlDbType.VarChar, ParameterDirection.Input, userData.EmailAddress );
                paramArray[3] = RepositoryUtility.AddSQLParameter("@FirstName", SqlDbType.VarChar, ParameterDirection.Input, userData.FirstName);
                paramArray[4] = RepositoryUtility.AddSQLParameter("@LastName", SqlDbType.VarChar, ParameterDirection.Input, userData.LastName);
                paramArray[5] = RepositoryUtility.AddSQLParameter("@roleid", SqlDbType.Int, ParameterDirection.Input, userData.RoleId);
                paramArray[6] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output, null,500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPCreateUser);
                string successMessage = Convert.ToString(paramArray[6].Value);
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

        public bool IsValidUser(AccountDetailsData accountDetailsData)
        {
            try
            {
                bool isValidUser = false;
                IDatabaseHelper objSqlADOHelper = new SqlADOHelper();
               

                SqlParameter[] paramArray = new SqlParameter[4];

                paramArray[0] = RepositoryUtility.AddSQLParameter("@username", SqlDbType.VarChar, ParameterDirection.Input, accountDetailsData.UserName);
                paramArray[1] = RepositoryUtility.AddSQLParameter("@password", SqlDbType.VarChar, ParameterDirection.Input, accountDetailsData.Password);
                paramArray[2] = RepositoryUtility.AddSQLParameter("@userid", SqlDbType.Int, ParameterDirection.Output);

                paramArray[3] = RepositoryUtility.AddSQLParameter("@responsemessage", SqlDbType.VarChar, ParameterDirection.Output,null, 500);

                objSqlADOHelper.GetOutputParamValue(paramArray, StoredProcedureNameConstants.SPIsValidUser);
                string successMessage = Convert.ToString(paramArray[3].Value);
                if(successMessage.Equals("User successfully logged in"))
                    {
                    accountDetailsData.UserID =Convert.ToInt32(paramArray[2].Value);
                    isValidUser = true;
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
    }
}
