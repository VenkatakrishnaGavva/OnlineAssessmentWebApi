using OnlineAssessmentApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business
{
    public interface IAccountManagementBusiness
    {
        AccountDetailEntity AccountDetails { get; set; }
        bool IsValidUser(AccountDetailEntity accountDetails);
        bool CreateUser(UserEntity userEntity);

    }
}
