using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHIP.Model;
using BHIP.Controllers;

namespace BHIP.Areas.Admin.Controllers
{
    public class MembersController : BaseController
    {
        // GET: Admin/Members
        public ActionResult Index()
        {
            return View(ContextPerRequest.CurrentData.Members.ToList());
        }

        public ActionResult Create()
        {
            Member model = new Member();
            model.StatusId = 0;
            model.EntityTypeID = 0;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Member model)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Members.Add(model);
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Member model = ContextPerRequest.CurrentData.Members.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Member model)
        {
            if (ModelState.IsValid)
            {
                ContextPerRequest.CurrentData.Entry(model).State = System.Data.Entity.EntityState.Modified;
                ContextPerRequest.CurrentData.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }


            Member model = ContextPerRequest.CurrentData.Members.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Member model = ContextPerRequest.CurrentData.Members.Find(id);
            ContextPerRequest.CurrentData.Members.Remove(model);
            ContextPerRequest.CurrentData.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}