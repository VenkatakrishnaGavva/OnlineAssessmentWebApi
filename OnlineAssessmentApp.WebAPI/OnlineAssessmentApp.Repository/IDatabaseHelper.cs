﻿using OnlineAssessmentApp.Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnlineAssessmentApp.Repository
{
    public interface IDatabaseHelper
    {
   
        DataTable GetData(SqlParameter[] parameterArray,string storedprocedureName);
        void  GetOutputParamValue(SqlParameter[] parameterArray, string storedprocedureName);


    }
}
