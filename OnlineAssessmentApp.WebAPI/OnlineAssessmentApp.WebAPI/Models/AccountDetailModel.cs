using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class AccountDetailModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string AccessCode { get; set; }
    }
}