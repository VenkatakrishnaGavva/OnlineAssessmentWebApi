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

    }
}
