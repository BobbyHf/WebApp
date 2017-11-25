using BHIP.Controllers;
using BHIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Areas.Admin.Controllers
{
    public class CustomReportTypeController : BaseController
    {
        // GET: CustomParamType
        public ActionResult Index()
        {
           // LoginCaptureHelper.InsertCaptureDetails("CustomParamType");
            // check to see if the user has logged in. If not get them out of here.
            //if (!Securitay.IsValid("/admin/customreports"))
            //{
            //    return Redirect("~/");
            //}

            CustomReportTypeViewModel model = new CustomReportTypeViewModel();
            model.CustomReportTypeGridList = model.GetCustomReportType(0, 10);
            return View(model);
        }
        public ActionResult AjaxPageGrid(int id, int? page = 0)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            CustomReportTypeViewModel model = new CustomReportTypeViewModel();


            model.CustomReportTypeGridList = model.GetCustomReportType(page ?? 0, 10);

            return PartialView("_Grid", model);
        }

        public ActionResult RefreshCustomReportTypeGrid()
        {
            CustomReportTypeViewModel model = new CustomReportTypeViewModel();

            model.CustomReportTypeGridList = model.GetCustomReportType(0, 10);

            return PartialView("_Grid", model);
        }

        public ActionResult CustomReportTypeAdd()
        {
            CustomReportTypeViewModel model = new CustomReportTypeViewModel();
            model.RolesList = model.GetEditRoles(0);

            return PartialView("_CustomReportTypeAdd", model);

        }

        public ActionResult AddCustomReportType(CustomReportTypeViewModel model)
        {
            model.AddCustomType(model);

            return Json(new { success = true });
        }

        public ActionResult EditCustomReportType(CustomReportTypeViewModel model)
        {
            model.EditParamType(model);

            return Json(new { success = true });
        }
        public ActionResult CustomReportTypeEdit(int id)
        {
            CustomReportTypeViewModel model = new CustomReportTypeViewModel();

            return PartialView("_CustomReportTypeEdit", model.GetACustomReportType(id));
        }

        public ActionResult CustomReportTypeDelete(int id, int? page = 0)
        {
            CustomReportTypeViewModel model = new CustomReportTypeViewModel();
            model.DeleteCustomType(id);

            model.CustomReportTypeGridList = model.GetCustomReportType(page ?? 0, 10);

            return PartialView("_Grid", model);
        }
    }
}
