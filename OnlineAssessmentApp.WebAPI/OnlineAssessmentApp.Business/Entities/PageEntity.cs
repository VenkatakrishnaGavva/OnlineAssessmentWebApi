﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssessmentApp.Business.Entities
{
    public class PageEntity
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string Description { get; set; }
        public int Createdby { get; set; }
       
        public bool IsPageSelected { get; set; }
    }
}
