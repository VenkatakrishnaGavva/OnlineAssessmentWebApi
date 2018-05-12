using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class ModuleWisePageAccessEntity
    {
        public ModuleWisePageAccessEntity()
        {
            this.pageList = new List<PageEntity>();
        }
        public ModuleEntity Module { get; set; }
        public RoleEntity Role { get; set; }

        public List<PageEntity> pageList { get; set; }
    }
}
