﻿using System.Web.Mvc;

namespace LibraryManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
