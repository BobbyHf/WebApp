using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHIP.Model;
using BHIP.Model.Helper;

namespace BHIP.Controllers
{
    public class PermanentRedirectResult : ActionResult
    {
        public string Url { get; set; }

        public PermanentRedirectResult(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url is null or empty", "url");
            }
            this.Url = url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
        }

        public void ExecuteResultWithVariables(string userId, string appId, string lob, string districtId)
        {
            HttpContext.Current.Session["UserID"] = userId;
            HttpContext.Current.Session["AppID"] = appId;
            HttpContext.Current.Session["LOB"] = string.Empty;
            HttpContext.Current.Session["DistrictID"] = districtId;
            HttpContext.Current.Response.Redirect(Url);
        }
    }

    public class ReportsController : BaseController
    {
        // GET: Reports
      
        public ActionResult Index(int id, int rptID = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }

            ReportViewModel model = new ReportViewModel(id, rptID);
            model.AgreementNumber = Security.GetMemberID();
            model.ContactName = Security.GetFullName();

            return View(model);
        }

        public ActionResult Viewer(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }
            ReportViewModel model = new ReportViewModel();
            model.GetReport(id);
            model.ParamList = model.GetReportParams(id);
            model.AgreementNumber = Security.GetMemberID();
            model.ContactName = Security.GetFullName();

            return View(model);
        }

        public ActionResult ClaimViewer()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }
            ReportViewModel model = new ReportViewModel();

            model.DistrictInformationSelect = model.CustomDistrictList;

            return View(model);
        }

    }
}
