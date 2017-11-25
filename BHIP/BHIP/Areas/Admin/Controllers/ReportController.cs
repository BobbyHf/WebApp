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
    public class ReportController : BaseController
    {
        // GET: Admin/Report
        public ActionResult Index()
        {
            ReportViewModel model = new ReportViewModel();

            return View(model.GetReports());
            //return View(db.ReportTrusts.ToList());
        }

        // GET: Admin/Report/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTrust reportTrust = ContextPerRequest.CurrentData.ReportTrusts.Find(id);
            if (reportTrust == null)
            {
                return HttpNotFound();
            }
            return View(reportTrust);
        }

        // GET: Admin/Report/Create
        public ActionResult Create()
        {
            ReportViewModel model = new ReportViewModel();

            return View(model);
        }

        // POST: Admin/Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,ReportTypeID,ReportName,ReportTitle,Description")] ReportTrust reportTrust, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.ReportTrusts.Add(reportTrust);
                ContextPerRequest.CurrentData.SaveChanges();
                ReportViewModel model = new ReportViewModel();

                if (selectedRoles != null)
                {
                    model.SaveEditReportRoles(reportTrust.ReportID, selectedRoles);
                }

                return RedirectToAction("Edit", "Report", new { id = reportTrust.ReportID });
//                return RedirectToAction("Index");
            }

            return View(reportTrust);
        }

        // GET: Admin/Report/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ReportViewModel model = new ReportViewModel();
            model.ReportID = id ?? 0;
            model = model.GetReport(model);

            if (model == null)
            {
                return HttpNotFound();
            }

            model.RolesList = model.GetEditRoles(id ?? 0);
            model.ParamList = model.GetReportParams(id ?? 0);
            return View(model);
        }

        // POST: Admin/Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,ReportTypeID,ReportName,ReportTitle,Description")] ReportTrust reportTrust, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Entry(reportTrust).State = EntityState.Modified;
                ContextPerRequest.CurrentData.SaveChanges();
                ReportViewModel model = new ReportViewModel();

                if (selectedRoles != null)
                {
                    model.SaveEditReportRoles(reportTrust.ReportID, selectedRoles);
                } 
                
                return RedirectToAction("Index");
            }
            return View(reportTrust);
        }

        // GET: Admin/Report/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTrust reportTrust = ContextPerRequest.CurrentData.ReportTrusts.Find(id);
            if (reportTrust == null)
            {
                return HttpNotFound();
            }
            return View(reportTrust);
        }

        // POST: Admin/Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportTrust reportTrust = ContextPerRequest.CurrentData.ReportTrusts.Find(id);
            ContextPerRequest.CurrentData.ReportTrusts.Remove(reportTrust);
            ContextPerRequest.CurrentData.SaveChanges();
            return RedirectToAction("Index");
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
