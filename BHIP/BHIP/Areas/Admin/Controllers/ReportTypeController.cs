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
    public class ReportTypeController : BaseController
    {
        // GET: Admin/ReportType
        public ActionResult Index()
        {
            return View(ContextPerRequest.CurrentData.ReportTypes.ToList());
        }

        // GET: Admin/ReportType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = ContextPerRequest.CurrentData.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // GET: Admin/ReportType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReportType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportTypeID,TypeName")] ReportType reportType)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.ReportTypes.Add(reportType);
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportType);
        }

        // GET: Admin/ReportType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = ContextPerRequest.CurrentData.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // POST: Admin/ReportType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportTypeID,TypeName")] ReportType reportType)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Entry(reportType).State = EntityState.Modified;
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportType);
        }

        // GET: Admin/ReportType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = ContextPerRequest.CurrentData.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // POST: Admin/ReportType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportType reportType = ContextPerRequest.CurrentData.ReportTypes.Find(id);
            ContextPerRequest.CurrentData.ReportTypes.Remove(reportType);
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
