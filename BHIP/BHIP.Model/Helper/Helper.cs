using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BHIP.Model.Helper
{
    public class NamePhone
    {
        public string FullName {get; set;}
        public string PhoneNumber {get; set;}
    }
    public class Helper
    {
        public static void LogError(string errorMessage, string innerException)
        {
            using (StreamWriter sw = File.AppendText(@"C:\temp\log.txt"))
            {
                sw.Write("\r\nLog Entry : ");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                sw.WriteLine("  :");
                sw.WriteLine("Error Message: {0}", errorMessage);
                sw.WriteLine("Inner Exception: {0}", innerException);
                sw.WriteLine("-------------------------------");
            }
        }

        public static int GetCurrentYear()
        {
            DateTime currentDate = DateTime.Now;

            int currentYear = 0;

            if (int.Parse(currentDate.Month.ToString()) < 7)
            {
                currentYear = (int.Parse(currentDate.Year.ToString())) - 1;
            }
            else
            {
                currentYear = int.Parse(currentDate.Year.ToString());
            }

            return currentYear;

        }
    }
}