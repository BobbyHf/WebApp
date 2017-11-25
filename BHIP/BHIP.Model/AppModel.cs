using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BHIP.Model
{
    static public class UserInfo
    {
        public static int Id { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }

        public static string DistrictName { get; set; }
        public static int AgreementNumber { get; set; }
        public static int UserRole { get; set; }
        public static int UserID { get; set; }
        public static int EmployeeID { get; set; }
        public static string UserName { get; set; }
    }
}