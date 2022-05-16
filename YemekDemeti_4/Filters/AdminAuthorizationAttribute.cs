using System;
using System.Web.Mvc;
using YemekDemeti_4.Models;

namespace YemekDemeti_4.Controllers
{
    internal class AdminAuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Role { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            RestaurantVM admin = (RestaurantVM)filterContext.HttpContext.Session["admin"];

            if (admin == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                string adminRolu = admin.Role;

                if (Role == adminRolu)
                {

                }
                else
                {
                    filterContext.Result = new RedirectResult("/Account/LogIn");
                }
            }
        }
    }
}