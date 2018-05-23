using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicPath { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public RoleEntity Role { get; set; }

    }
}
