using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class UserModel
    {
        public string FullName { get; set; }
        public  int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicPath { get; set; }
        public HttpPostedFileBase file { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public RoleModel Role { get; set; }

    }
}