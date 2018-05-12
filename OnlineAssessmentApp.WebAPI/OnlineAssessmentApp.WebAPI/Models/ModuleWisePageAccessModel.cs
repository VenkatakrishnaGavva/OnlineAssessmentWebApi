using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class ModuleWisePageAccessModel
    {
        public ModuleWisePageAccessModel()
        {
            this.pageList = new List<PageModel>();
        }
        public RoleModel Role { get; set; }
        public ModuleModel Module { get; set; }

        public List<PageModel> pageList { get; set; }


    }
}