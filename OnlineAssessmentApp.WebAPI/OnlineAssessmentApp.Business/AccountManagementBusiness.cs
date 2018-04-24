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
                userData.RoleId = userEntity.RoleId;
                IAccountManagementRepository accountRepository = DataFactory.DataFactory.CreateAccountmanagementRepositoryInstance();
                return accountRepository.CreateUser(userData);

            }
            catch (Exception ex)
            {

                return false;
            }
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
    }

}
