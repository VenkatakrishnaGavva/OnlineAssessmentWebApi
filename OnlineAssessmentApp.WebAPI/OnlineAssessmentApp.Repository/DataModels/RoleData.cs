using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Repository.DataModels
{
    public class RoleData
    {
            public int RoleId { get; set; }
            public string RoleName { get; set; }
            public string Description { get; set; }
            public int CreatedBy { get; set; }
            public int ModifedBy { get; set; }
        
    }
}
