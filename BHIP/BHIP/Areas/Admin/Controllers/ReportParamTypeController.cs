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
    public class ReportParamTypeController : BaseController
    {

        // GET: Admin/ReportParamType
        public ActionResult Index()
        {
            return View(ContextPerRequest.CurrentData.ReportParamTypes.ToList());
        }

        // GET: Admin/ReportParamType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParamType reportParamType = ContextPerRequest.CurrentData.ReportParamTypes.Find(id);
            if (reportParamType == null)
            {
                return HttpNotFound();
            }
            return View(reportParamType);
        }

        // GET: Admin/ReportParamType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReportParamType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportParamTypeID,Description")] ReportParamType reportParamType)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.ReportParamTypes.Add(reportParamType);
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportParamType);
        }

        // GET: Admin/ReportParamType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParamType reportParamType = ContextPerRequest.CurrentData.ReportParamTypes.Find(id);
            if (reportParamType == null)
            {
                return HttpNotFound();
            }
            return View(reportParamType);
        }

        // POST: Admin/ReportParamType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportParamTypeID,Description")] ReportParamType reportParamType)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Entry(reportParamType).State = EntityState.Modified;
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportParamType);
        }

        // GET: Admin/ReportParamType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportParamType reportParamType = ContextPerRequest.CurrentData.ReportParamTypes.Find(id);
            if (reportParamType == null)
            {
                return HttpNotFound();
            }
            return View(reportParamType);
        }

        // POST: Admin/ReportParamType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportParamType reportParamType = ContextPerRequest.CurrentData.ReportParamTypes.Find(id);
            ContextPerRequest.CurrentData.ReportParamTypes.Remove(reportParamType);
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
