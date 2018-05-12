using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class ModuleRolePermissionModel
    {
        public int ModuleId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsRemove { get; set; }
    }
}