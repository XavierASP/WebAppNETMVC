using System.Web;
using System.Web.Mvc;
using WebAppNETMVC.Filters;

namespace WebAppNETMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new UserActionFilter());
            //filters.Add(new UserAuthenticationFilter());
            //filters.Add(new UserAuthorizationFilter());
            //filters.Add(new UserExceptionFilter());
            //filters.Add(new UserResultFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
