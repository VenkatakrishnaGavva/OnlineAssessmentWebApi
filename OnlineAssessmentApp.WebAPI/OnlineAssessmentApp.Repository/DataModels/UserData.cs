﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class UserData
    {
        public int UserId { get; set; }

        public string ProfilePicPath { get; set; }

        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public RoleData Role { get; set; }
        

    }
}
