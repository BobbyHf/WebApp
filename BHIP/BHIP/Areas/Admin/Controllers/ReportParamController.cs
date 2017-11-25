using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BHIP.Model;
using BHIP.Controllers;

namespace BHIP.Areas.Admin.Controllers
{
    public class ReportParamController : BaseController
    {
        // GET: Admin/ReportParam
        public ActionResult Index()
        {
            return View(ContextPerRequest.CurrentData.ReportParams.ToList());
        }

        // GET: Admin/ReportParam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParam reportParam = ContextPerRequest.CurrentData.ReportParams.Find(id);
            if (reportParam == null)
            {
                return HttpNotFound();
            }
            return View(reportParam);
        }

        // GET: Admin/ReportParam/Create
        public ActionResult Create(int id)
        {
            ReportParamViewModel model = new ReportParamViewModel();
            model.ReportID = id;
            model.ReportParamTypeID = 0;

            return View(model);
        }

        // POST: Admin/ReportParam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportParamID,ReportID,ReportParamTypeID,ParamName,ParamTitle,ParamWidth,DisplayOrder,DropSQL")] ReportParamViewModel reportParam)
        {
            if (ModelState.IsValid)
            {
                ReportParam param = new ReportParam
                {
                    DisplayOrder = reportParam.DisplayOrder,
                    DropSQL = reportParam.DropSQL,
                    ParamName = reportParam.ParamName,
                    ParamTitle = reportParam.ParamTitle,
                    ParamWidth = reportParam.ParamWidth,
                    ReportID = reportParam.ReportID,
                    ReportParamTypeID = reportParam.ReportParamTypeID
                };
                ContextPerRequest.CurrentData.ReportParams.Add(param);
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Edit", "Report", new { id = reportParam.ReportID });
            }

            return View(reportParam);
        }

        // GET: Admin/ReportParam/Edit/5
        public ActionResult Edit(int? id, int rptId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParam reportParam = ContextPerRequest.CurrentData.ReportParams.Find(id);
            ReportParamViewModel model = new ReportParamViewModel();
            if (reportParam == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.DisplayOrder = reportParam.DisplayOrder ?? 0;
                model.DropSQL = reportParam.DropSQL;
                model.ParamDescription = string.Empty;
                model.ParamName = reportParam.ParamName;
                model.ParamTitle = reportParam.ParamTitle;
                model.ParamTypeList = null;
                model.ParamWidth = reportParam.ParamWidth ?? 0;
                model.ReportID = reportParam.ReportID;
                model.ReportParamID = reportParam.ReportParamID;
                model.ReportParamTypeID = reportParam.ReportParamTypeID;
            }
            return View(model);
        }

        // POST: Admin/ReportParam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportParamID,ReportID,ReportParamTypeID,ParamName,ParamTitle,ParamWidth,DisplayOrder,DropSQL")] ReportParam reportParam)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Entry(reportParam).State = EntityState.Modified;
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", "Report", new { id = reportParam.ReportID });
//            return View(reportParam);
        }

        // GET: Admin/ReportParam/Delete/5
        public ActionResult Delete(int? id, int rptId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParam reportParam = ContextPerRequest.CurrentData.ReportParams.Find(id);
            ReportParamViewModel model = new ReportParamViewModel();
            if (reportParam == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.DisplayOrder = reportParam.DisplayOrder ?? 0;
                model.DropSQL = reportParam.DropSQL;
                model.ParamDescription = string.Empty;
                model.ParamName = reportParam.ParamName;
                model.ParamTitle = reportParam.ParamTitle;
                model.ParamTypeList = null;
                model.ParamWidth = reportParam.ParamWidth ?? 0;
                model.ReportID = reportParam.ReportID;
                model.ReportParamID = reportParam.ReportParamID;
                model.ReportParamTypeID = reportParam.ReportParamTypeID;
            }

            return View(model);
        }

        // POST: Admin/ReportParam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int rptId)
        {
            ReportParam reportParam = ContextPerRequest.CurrentData.ReportParams.Find(id);
            ContextPerRequest.CurrentData.ReportParams.Remove(reportParam);
            ContextPerRequest.CurrentData.SaveChanges();
            return RedirectToAction("Edit", "Report", new { id = reportParam.ReportID });
//            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ContextPerRequest.CurrentData.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
