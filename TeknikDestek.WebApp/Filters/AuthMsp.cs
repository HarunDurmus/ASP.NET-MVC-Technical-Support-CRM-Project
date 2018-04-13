using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikDestek.WebApp.Models;

namespace TeknikDestek.WebApp.Filters
{
    public class AuthMsp : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User != null && CurrentSession.User.userName != "msp")
            {
                filterContext.Result = new RedirectResult("/Home/AccessDenied");
            }
        }
    }
}