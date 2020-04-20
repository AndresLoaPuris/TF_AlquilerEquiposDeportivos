using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SI656_AlquilerEquipos.Web.Filters
{
    public class AppAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var unauthorized = false;
            try
            {
            }
            catch (Exception)
            {
                unauthorized = true;
            }

            if (unauthorized)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Auth", area = "" }));
            }
        }
    }
}