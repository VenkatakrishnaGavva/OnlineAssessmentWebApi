using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Models
{
    public class PageModel
    {
        public string PageUrl { get; set; }
        public string Description { get; set; }
            public int CreatedBy { get; set; }
            public int ModifedBy { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }

        public bool IsPageSelected { get; set; }

    }
}