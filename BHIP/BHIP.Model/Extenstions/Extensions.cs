using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Microsoft.Owin;
using System.Web.Mvc;


namespace BHIP.Model
{
    public static class Extensions
    {
        public static string GetFullName(this IIdentity value, string userID)
        {
            string userName = (from userRec in ContextPerRequest.CurrentData.AspNetUsers
                               where userRec.Id == userID
                               select userRec.FirstName + " " + userRec.LastName).FirstOrDefault();

            return userName;
        }

        public static string GetMemberName(this IIdentity value, string userID)
        {
            string userName = (from userRec in ContextPerRequest.CurrentData.AspNetUsers
                               join member in ContextPerRequest.CurrentData.Members on userRec.MemberID equals member.MemberId
                               where userRec.Id == userID
                               select member.Name).FirstOrDefault();
            return userName;
        }

        public static MvcHtmlString OutputText(this HtmlHelper helper, string text)
        {
            return new MvcHtmlString(text);
        }
    }
}
