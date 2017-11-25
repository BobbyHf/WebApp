using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHIP.Model;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using BHIP.Model.Helper;

namespace BHIP.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string pageURL = HttpContext.Request.RawUrl;
          

            if (pageURL != "/" && pageURL.ToLower() != "/home/contactus" && pageURL.ToLower() != "/home/board")
            {
                if (HttpContext.Request.IsAuthenticated)
                {
                    string userId = Security.GetLoggedInUserID();

                    var dataRoles = (from bhipMenu in ContextPerRequest.CurrentData.Menus
                                     join bhipMenuRole in ContextPerRequest.CurrentData.MenuRoles on bhipMenu.MenuID equals bhipMenuRole.MenuId
                                     where ((from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == bhipMenuRole.RoleId) select user.Id).Contains(userId))
                                     select bhipMenuRole);


                    if (dataRoles == null || dataRoles.Count() == 0)
                    {

                        //filterContext.Result = new RedirectResult(Url.Action("Index", "Home"));
                        filterContext.Result = new RedirectResult("~/");


                    }
                }
                else
                {
                    //filterContext.Result = new RedirectResult(Url.Action("Index", "Home"));
                    filterContext.Result = new RedirectResult("~/");
                }
            }
        }
    }
}