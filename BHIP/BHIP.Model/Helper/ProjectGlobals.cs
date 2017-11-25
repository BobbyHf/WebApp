using System;
using System.Web;
using System.Web.Configuration;

namespace BHIP.Model
{
    public static class ProjectGlobals
    {
        static public int CurrentYear { get; set; }
        static public int NextYear { get; set; }
        static public string SMTPServer { get; set; }

        static ProjectGlobals()
        {
            CurrentYear = Convert.ToInt32(WebConfigurationManager.AppSettings["CurrentYear"]);
            NextYear = Convert.ToInt32(WebConfigurationManager.AppSettings["NextYear"]);

            SMTPServer = WebConfigurationManager.AppSettings["SMTPServer"];

        }

    }
}
