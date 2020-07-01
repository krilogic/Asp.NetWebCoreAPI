using Asp.NetWebCoreAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetWebCoreAPI.Repository
{
    public interface ISqlHelper
    {
        int ExecuteCurdQuery(string strSql);
        DataTable ExecuteSelectQuery(string strSql);
        Teacher GetTeacherInfoByRow(DataRow dr);
    }
}
