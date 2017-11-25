using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHIP
{
    public partial class viewer : System.Web.UI.Page
    {
        string rptName = string.Empty;
        string strCF = string.Empty;
        string strPF = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(Request.QueryString["values"]))
            //{
            //    Response.Redirect("~/");
            //}
            //else
            //{
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 5600;

            if (!Page.IsPostBack)
            {
                DisplayReport(GetReportName(), GetParameters());
            }
            //}
        }

        private string GetReportName()
        {
            if (String.IsNullOrEmpty(Request.QueryString["rptName"]))
            {
                return string.Empty;
            }
            else
            {
                return Request.QueryString["rptName"];
            }
        }

        private string[] GetParameters()
        {
            string passQuery = Request.QueryString["values"];
            string[] parameterValues = passQuery.Split('~');

            return parameterValues;
        }

        private void DisplayReport(string reportName, string[] parameterValues)
        {
            string[] nameValue;
            bool isPDF = false;

            rv.ShowCredentialPrompts = false;
            rv.ServerReport.ReportServerUrl = new Uri("http://192.168.5.11/reportserver");
            rv.KeepSessionAlive = false;
            rv.AsyncRendering = false;
            rv.ShowParameterPrompts = false;
            rv.ShowPromptAreaButton = false;
            rv.ServerReport.Timeout = -1;
            string userName = System.Web.Configuration.WebConfigurationManager.AppSettings["SSRSUserName"];
            string password = System.Web.Configuration.WebConfigurationManager.AppSettings["SSRSPassword"];

            CustomReportCredentials creds = new CustomReportCredentials(userName, password, "");
            rv.ServerReport.ReportServerCredentials = creds;

            List<Microsoft.Reporting.WebForms.ReportParameter> p = new List<Microsoft.Reporting.WebForms.ReportParameter>();

            rv.ServerReport.ReportPath = "/trust/" + reportName;
            rv.LocalReport.EnableExternalImages = true;

            if (parameterValues[0] != "")
            {
                foreach (string paramValue in parameterValues)
                {
                    nameValue = paramValue.Split('^');
                    if (@nameValue[0] == "PDF" && @nameValue[1] == "Y")
                    {
                        isPDF = true;
                    }
                    else
                    {
                        p.Add(new Microsoft.Reporting.WebForms.ReportParameter(@nameValue[0], @nameValue[1]));
                    }
                }
            }
            rv.ServerReport.SetParameters(p);
            rv.ServerReport.Refresh();
            string mimeType, encoding, extension, deviceInfo;
            string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
            Response.Clear();
            if (isPDF)
            {
                deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
                byte[] bytes = rv.ServerReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
                Response.ContentType = "application/PDF";
                Response.AddHeader("Content-disposition", "filename=output.pdf");
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                Response.Flush();
                Response.Close();
            }
            //==>>Response.BinaryWrite(bytes);
        }
    }
    [Serializable]
    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        // local variable for network credential.
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        private System.Net.Cookie _authCookie;

        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }

        public CustomReportCredentials(System.Net.Cookie authCookie)
        {
            _authCookie = authCookie;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // not using ImpersonationUser
            }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                // use NetworkCredentials
                return new System.Net.NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }

        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }

    }

}