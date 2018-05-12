using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class ModulewisePageAccessData
    {
        public ModulewisePageAccessData()
        {
            this.pageList = new List<PageData>();
        }
      public ModuleData Module { get; set; }
        public RoleData Role { get; set; }

        public List<PageData> pageList { get; set; }

  
 
    }
}
