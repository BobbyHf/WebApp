using BHIP.Controllers;
using BHIP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Areas.Admin.Controllers
{
    public class CustomParamTypeController : BaseController
    {
        public ActionResult Index()
        {
            //LoginCaptureHelper.InsertCaptureDetails("CustomParamType");
            // check to see if the user has logged in. If not get them out of here.
            //if (!Securitay.IsValid("/admin/customreports"))
            //{
            //    return Redirect("~/");
            //}

            CustomParamTypeViewModel model = new CustomParamTypeViewModel();
            model.CustomParamTypeGridList = model.GetCustomParamType(0, 10);
            return View(model);
        }
        public ActionResult AjaxPageGrid(int id, int? page = 0)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            CustomParamTypeViewModel model = new CustomParamTypeViewModel();


            model.CustomParamTypeGridList = model.GetCustomParamType(page ?? 0, 10);

            return PartialView("_Grid", model);
        }

        public ActionResult RefreshCustomParamTypeGrid()
        {
            CustomParamTypeViewModel model = new CustomParamTypeViewModel();

            model.CustomParamTypeGridList = model.GetCustomParamType(0, 10);

            return PartialView("_Grid", model);
        }

        public ActionResult CustomParamTypeAdd()
        {
            CustomParamTypeViewModel model = new CustomParamTypeViewModel();
            return PartialView("_CustomParamTypeAdd", model);

        }

        public ActionResult AddCustomParamType(CustomParamTypeViewModel model)
        {
            model.AddParamType(model);

            return Json(new { success = true });
        }

        public ActionResult EditCustomParamType(CustomParamTypeViewModel model)
        {
            model.EditParamType(model);

            return Json(new { success = true });
        }
        public ActionResult CustomParamTypeEdit(int id)
        {
            CustomParamTypeViewModel model = new CustomParamTypeViewModel();

            return PartialView("_CustomParamTypeEdit", model.GetACustomParamType(id));
        }

        public ActionResult CustomParamTypeDelete(int id, int? page = 0)
        {
            CustomParamTypeViewModel model = new CustomParamTypeViewModel();
            model.DeleteParamType(id);

            model.CustomParamTypeGridList = model.GetCustomParamType(page ?? 0, 10);

            return PartialView("_Grid", model);
        }
    }
}