using System;
using System.Web.Mvc;
using YemekDemeti_4.Models;

namespace YemekDemeti_4.Controllers
{
    internal class CustomAuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Role { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            CustomerVM kullanici = (CustomerVM)filterContext.HttpContext.Session["user"];

            if (kullanici == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                string kullaniciRolu = kullanici.Role;

                if (Role == kullaniciRolu)
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