﻿using System.Web;
using System.Web.Mvc;

namespace HW_DEPT_EMP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
