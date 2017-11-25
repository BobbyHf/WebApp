using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHIP.Model;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace BHIP.Model.Helper
{
    public class Security
    {
        public static bool IsValid(string pageURL)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userId = HttpContext.Current.User.Identity.GetUserId();

                var dataRoles = (from trustMenu in ContextPerRequest.CurrentData.Menus
                                 join trustMenuRole in ContextPerRequest.CurrentData.MenuRoles on trustMenu.MenuID equals trustMenuRole.MenuId
                                 where ((from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == trustMenuRole.RoleId) select user.Id).Contains(userId)
                                 && trustMenu.Link == pageURL)
                                 select trustMenuRole);


                if (dataRoles == null)
                {
                    // user record found so they  have access to this page.
                    return false;
                }
                else if (dataRoles.Count() > 0)
                {
                    return true;
                }
                else
                {
                    // user record wasn't found so the user isn't valid for this page.
                    return false;
                }
            }
            else
            {
                // the user isn't authenticated
                return false;
            }
        }

        public static string GetFullName()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            return HttpContext.Current.User.Identity.GetFullName(userId);
        }

        public static string GetSecuredUserID()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
        public static string GetFirstName()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            string firstName = (from users in ContextPerRequest.CurrentData.AspNetUsers
                                   where users.Id == userId
                                   select users.FirstName).FirstOrDefault<string>();

            return firstName;

        }
        public static string GetLastName()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            string lastName = (from users in ContextPerRequest.CurrentData.AspNetUsers
                                where users.Id == userId
                                select users.LastName).FirstOrDefault<string>();

            return lastName;

        }
        public static string GetEMail()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            string email = (from users in ContextPerRequest.CurrentData.AspNetUsers
                               where users.Id == userId
                               select users.Email).FirstOrDefault<string>();

            return email;

        }

        //public static string GetUserEMail(int userId)
        //{
        //    string email = (from users in ContextPerRequest.CurrentData.AspNetUsers
        //                    where users.UserId == userId
        //                    select users.Email).FirstOrDefault<string>();

        //    return email;

        //}

        public static string GetUserEMailByID(string Id)
        {
            string email = (from users in ContextPerRequest.CurrentData.AspNetUsers
                            where users.Id == Id
                            select users.Email).FirstOrDefault<string>();

            return email;

        }

        //public static int GetUserID()
        //{
        //    string userId = HttpContext.Current.User.Identity.GetUserId();

        //    int returnUserID = (from users in ContextPerRequest.CurrentData.AspNetUsers
        //                    where users.Id == userId
        //                    select users.UserId).FirstOrDefault<int>();

        //    return returnUserID;

        //}

        public static string GetUserName()
        {
            return HttpContext.Current.User.Identity.GetUserName();
        }

        public static string GetLoggedInUserID()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        public static int GetMemberID()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            int memberId = (from users in ContextPerRequest.CurrentData.AspNetUsers
                                where users.Id == userId
                                select users.MemberID).FirstOrDefault<int?>() ?? 0;

            return memberId;

        }
    }
}