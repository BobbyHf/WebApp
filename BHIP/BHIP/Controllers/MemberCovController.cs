using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHIP.Model;
using System.Collections;

namespace BHIP.Controllers
{
    public class MemberCovController : BaseController
    {
        public ActionResult Index(int id = 0, int yr = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, yr);

            model.MemberID = id;
            model.PolicyYear = yr;

            if (id == 0)
            {
                model.ContactList = new ContactScheduleViewModel[0];
                model.ContactHoldList = new ContactScheduleHoldViewModel[0];
                model.PsychiatryList = new PsychiatryViewModel[0];
                model.PsychiatryHoldList = new PsychiatryScheduleHoldViewModel[0];
                model.PrimaryCareList = new PrimaryCareViewModel[0];
                model.PrimaryCareHoldList = new PrimaryCareHoldViewModel[0];
                model.DriverInfoList = new DriverInfoViewModel[0];
                model.DriverInfoHoldList = new DriverInfoHoldViewModel[0];
                model.PropertyList = new PropertyViewModel[0];
                model.PropertyHoldList = new PropertyScheduleHoldViewModel[0];
                model.VehicleList = new VehicleScheduleViewModel[0];
                model.VehicleHoldList = new VehicleScheduleHoldViewModel[0];
                model.OtherHoldList = new OtherScheduleHoldViewModel[0];
                model.OtherList = new OtherScheduleViewModel[0];
                model.Premiums = new PremiumsViewModel();
            }

            return View(model);
        }

        public ActionResult SaveMember(MemberCoverageViewModel model)
        {
            model.SaveMemberCoverage(model);
            model.SavePremium(model);

            return RedirectToAction("Index", "MemberCov");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveMemberCoverage(MemberCoverageViewModel model)
        {
            model.SaveMemberCoverage(model);
            model.SavePremium(model);

            return Json(new { success = true });
        }

        public ActionResult ContactAdd(int id)
        {
            ContactScheduleViewModel model = new ContactScheduleViewModel();
            model.MemberCoverageID = id;

            return PartialView("_ContactAdd", model);
        }

        public ActionResult ContactEdit(int id)
        {
            ContactScheduleViewModel model = new ContactScheduleViewModel();

            return PartialView("_ContactEdit", model.GetAContact(id));
        }

        public ActionResult ContactDelete(int id, int memId)
        {
            ContactScheduleViewModel model = new ContactScheduleViewModel();
            model.ContactScheduleDelete(id);
            MemberCoverageViewModel member = new MemberCoverageViewModel(memId, 0);

            return PartialView("_ContactScheduleGrid", member);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddContact(ContactScheduleViewModel model)
        {
            model.ContactScheduleAdd(model);

            return Json(new { success = true });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditContact(ContactScheduleViewModel model)
        {
            ContactScheduleViewModel modelHold = new ContactScheduleViewModel();
            modelHold.ContactScheduleEdit(model);

            return Json(new { success = true });
        }

        public ActionResult EditContactHold(int id)
        {
            ContactScheduleHoldViewModel model = new ContactScheduleHoldViewModel();

            return PartialView("_ContactEditHold", model.GetAContactScheduleHold(id));
        }

        public ActionResult SaveContactHold(ContactScheduleHoldViewModel model)
        {
            model.ContactScheduleHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteContactHold(int id, int covId)
        {
            ContactScheduleHoldViewModel model = new ContactScheduleHoldViewModel();
            model.ContactScheduleHoldDelete(id);

            return PartialView("_ContactScheduleHoldGrid", model.GetAllContactScheduleHolds(covId));
        }
        public ActionResult RefreshContact(int id)
        {
            //int memberId = 0;

            //if (id > 0)
            //{
            //    memberId = ContextPerRequest.CurrentData.MemberCoverages.Where(x => x.MemberCoverageID == id).Select(x => x.MemberId).FirstOrDefault<int>();
            //}
            //ContactScheduleViewModel model = new ContactScheduleViewModel();
            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);

            return PartialView("_ContactScheduleGrid", model.ContactList);
        }
        public ActionResult VehicleAdd(int id)
        {
            VehicleScheduleViewModel model = new VehicleScheduleViewModel();
            model.MemberCoverageID = id;

            return PartialView("_VehicleAdd", model);
        }

        public ActionResult VehicleEdit(int id)
        {
            VehicleScheduleViewModel model = new VehicleScheduleViewModel();

            return PartialView("_VehicleEdit", model.GetAVehicle(id));
        }

        public ActionResult VehicleDelete(int id)
        {
            VehicleDeleteViewModel model = new VehicleDeleteViewModel();

            return PartialView("_VehicleDelete", model.GetAVehicle(id));

        }

        public ActionResult AddVehicle(VehicleScheduleViewModel model)
        {
            VehicleScheduleHoldViewModel modelHold = new VehicleScheduleHoldViewModel();
            modelHold.VehicleScheduleHoldAdd(model);

            return Json(new { success = true });
        }

        public ActionResult EditVehicle(VehicleScheduleViewModel model)
        {
            VehicleScheduleHoldViewModel modelHold = new VehicleScheduleHoldViewModel();
            modelHold.VehicleScheduleHoldEdit(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteVehicle(VehicleDeleteViewModel model)
        {
            VehicleScheduleHoldViewModel modelHold = new VehicleScheduleHoldViewModel();
            modelHold.VehicleScheduleDelete(model);

            return Json(new { success = true });
        }

        public ActionResult EditVehicleHold(int id)
        {
            VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

            return PartialView("_VehicleEditHold", model.GetAVehicleHold(id));
        }
        public ActionResult SaveVehicleHold(VehicleScheduleHoldViewModel model)
        {
            model.VehicleScheduleHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteVehicleHold(int id, int covId)
        {
            VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();
            model.VehicleScheduleHoldDelete(id);

            return PartialView("_VehicleScheduleHoldGrid", model.GetAllVehicleHolds(covId));
        }
        public ActionResult RefreshVehicleHold(int id)
        {
            VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

            return PartialView("_VehicleScheduleHoldGrid", model.GetAllVehicleHolds(id));
        }

        public ActionResult PsychiatryAdd(int id)
        {
            PsychiatryViewModel model = new PsychiatryViewModel();
            model.MemberCoverageID = id;

            return PartialView("_PsychiatryAdd", model);
        }

        public ActionResult PsychiatryEdit(int id)
        {
            PsychiatryViewModel model = new PsychiatryViewModel();

            return PartialView("_PsychiatryEdit", model.GetAPsychiatrySchedule(id));
        }

        public ActionResult PsychiatryDelete(int id)
        {
            PsychiatryDeleteViewModel model = new PsychiatryDeleteViewModel();

            return PartialView("_PsychiatryDelete", model.GetAPsychiatrySchedule(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPsychiatry(PsychiatryViewModel model)
        {
            PsychiatryScheduleHoldViewModel modelHold = new PsychiatryScheduleHoldViewModel();
            modelHold.PsychiatryScheduleAdd(model);

            return Json(new { success = true });
        }

        public ActionResult EditPsychiatry(PsychiatryViewModel model)
        {
            PsychiatryScheduleHoldViewModel modelHold = new PsychiatryScheduleHoldViewModel();
            modelHold.PsychiatryScheduleEdit(model);

            return Json(new { success = true });
        }

        public ActionResult EditOtherSchedule(OtherScheduleViewModel model)
        {
            OtherScheduleHoldViewModel modelHold = new OtherScheduleHoldViewModel();
            modelHold.OtherScheduleEdit(model);

            return Json(new { success = true });
        }

        public ActionResult DeletePsychiatry(PsychiatryDeleteViewModel model)
        {
            PsychiatryScheduleHoldViewModel modelHold = new PsychiatryScheduleHoldViewModel();
            modelHold.PsychiatryScheduleDelete(model);

            return Json(new { success = true });
        }
        public ActionResult EditPsychiatryHold(int id)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

            return PartialView("_PsychiatryEditHold", model.GetAPsychiatryScheduleHold(id));
        }
        public ActionResult SavePsychiatryHold(PsychiatryScheduleHoldViewModel model)
        {
            model.PsychiatryScheduleHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeletePsychiatryHold(int id, int covId)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();
            model.PsychiatryScheduleHoldDelete(id);

            return PartialView("_PsychiatryScheduleHoldGrid", model.GetAllPsychiatryScheduleHolds(covId));
        }
        public ActionResult RefreshPsychiatryHold(int id)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

            return PartialView("_PsychiatryScheduleHoldGrid", model.GetAllPsychiatryScheduleHolds(id));
        }

        #region Other Schedule
        public ActionResult OtherScheduleAdd(int id)
        {
            OtherScheduleViewModel model = new OtherScheduleViewModel();
            model.MemberCoverageID = id;

            return PartialView("_OtherScheduleAdd", model);
        }

        public ActionResult OtherScheduleEdit(int id)
        {
            OtherScheduleViewModel model = new OtherScheduleViewModel();

            return PartialView("_OtherScheduleEdit", model.GetAOtherSchedule(id));
        }

        public ActionResult OtherScheduleDelete(int id)
        {
            OtherScheduleDeleteViewModel model = new OtherScheduleDeleteViewModel();

            return PartialView("_OtherScheduleDelete", model.GetAOtherSchedule(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddOtherSchedule(OtherScheduleViewModel model)
        {
            OtherScheduleHoldViewModel modelHold = new OtherScheduleHoldViewModel();
            modelHold.OtherScheduleAdd(model);

            return Json(new { success = true });
        }



        public ActionResult DeleteOtherSchedule(OtherScheduleDeleteViewModel model)
        {
            OtherScheduleHoldViewModel modelHold = new OtherScheduleHoldViewModel();
            modelHold.OtherScheduleDelete(model);

            return Json(new { success = true });
        }
        public ActionResult EditOtherScheduleHold(int id)
        {
            OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();

            return PartialView("_OtherScheduleEditHold", model.GetAOtherScheduleHold(id));
        }
        public ActionResult SaveOtherScheduleHold(OtherScheduleHoldViewModel model)
        {
            model.OtherScheduleHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteOtherScheduleHold(int id, int covId)
        {
            OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();
            model.OtherScheduleHoldDelete(id);

            return PartialView("_OtherScheduleHoldGrid", model.GetAllOtherScheduleHolds(covId));
        }
        public ActionResult RefreshOtherScheduleHold(int id)
        {
            OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();

            return PartialView("_OtherScheduleHoldGrid", model.GetAllOtherScheduleHolds(id));
        }

        #endregion Other Schedule




        public ActionResult PrimaryCareAdd(int id)
        {
            PrimaryCareViewModel model = new PrimaryCareViewModel();
            model.MemberCoverageID = id;

            return PartialView("_PrimaryCareAdd", model);
        }

        public ActionResult PrimaryCareEdit(int id)
        {
            PrimaryCareViewModel model = new PrimaryCareViewModel();

            return PartialView("_PrimaryCareEdit", model.GetAPrimaryCareSchedule(id));
        }

        public ActionResult PrimaryCareDelete(int id)
        {
            PrimaryCareDeleteViewModel model = new PrimaryCareDeleteViewModel();

            return PartialView("_PrimaryCareDelete", model.GetAPrimaryCareSchedule(id));

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPrimaryCare(PrimaryCareViewModel model)
        {
            PrimaryCareHoldViewModel modelHold = new PrimaryCareHoldViewModel();
            modelHold.PrimaryCareScheduleAdd(model);

            return Json(new { success = true });
        }

        public ActionResult EditPrimaryCare(PrimaryCareViewModel model)
        {
            PrimaryCareHoldViewModel modelHold = new PrimaryCareHoldViewModel();
            modelHold.PrimaryCareScheduleEdit(model);

            return Json(new { success = true });
        }

        public ActionResult DeletePrimaryCare(PrimaryCareDeleteViewModel model)
        {
            PrimaryCareHoldViewModel modelHold = new PrimaryCareHoldViewModel();
            modelHold.PrimaryCareScheduleDelete(model);

            return Json(new { success = true });
        }
        public ActionResult EditPrimaryCareHold(int id)
        {
            PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

            return PartialView("_PrimaryCareEditHold", model.GetAPrimaryCareHold(id));
        }
        public ActionResult SavePrimaryCareHold(PrimaryCareHoldViewModel model)
        {
            model.PrimaryCareScheduleHoldSave(model);

            return Json(new { success = true });
        }
        public ActionResult DeletePrimaryCareHold(int id, int covId)
        {
            PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();
            model.PrimaryCareScheduleHoldDelete(id);

            return PartialView("_PrimaryCareScheduleHoldGrid", model.GetAllPrimaryCareHolds(covId));
        }
        public ActionResult RefreshPrimaryCareHold(int id)
        {
            PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

            return PartialView("_PrimaryCareScheduleHoldGrid", model.GetAllPrimaryCareHolds(id));
        }

        public ActionResult DriverInfoAdd(int id)
        {
            DriverInfoViewModel model = new DriverInfoViewModel();
            model.MemberCoverageID = id;

            return PartialView("_DriverInfoAdd", model);
        }

        public ActionResult DriverInfoEdit(int id)
        {
            DriverInfoViewModel model = new DriverInfoViewModel();

            return PartialView("_DriverInfoEdit", model.GetADriverInfo(id));
        }

        public ActionResult DriverInfoDelete(int id)
        {
            DriverInfoDeleteViewModel model = new DriverInfoDeleteViewModel();

            return PartialView("_DriverInfoDelete", model.GetADriverInfo(id));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDriverInfo(DriverInfoViewModel model)
        {
            DriverInfoHoldViewModel modelHold = new DriverInfoHoldViewModel();
            modelHold.DriverInfoScheduleAdd(model);

            return Json(new { success = true });
        }

        public ActionResult EditDriverInfo(DriverInfoViewModel model)
        {
            DriverInfoHoldViewModel modelHold = new DriverInfoHoldViewModel();
            modelHold.DriverInfoScheduleEdit(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteDriverInfo(DriverInfoDeleteViewModel model)
        {
            DriverInfoHoldViewModel modelHold = new DriverInfoHoldViewModel();
            modelHold.DriverInfoScheduleDelete(model);

            return Json(new { success = true });
        }
        public ActionResult EditDriverInfoHold(int id)
        {
            DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

            return PartialView("_DriverInfoEditHold", model.GetADriverInfoScheduleHold(id));
        }
        public ActionResult SaveDriverInfoHold(DriverInfoHoldViewModel model)
        {
            model.DriverInfoHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeleteDriverInfoHold(int id, int covId)
        {
            DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();
            model.DriverInfoHoldDelete(id);

            return PartialView("_DriverInfoScheduleHoldGrid", model.GetAllDriverInfoScheduleHolds(covId));
        }
        public ActionResult RefreshDriverInfoHold(int id)
        {
            DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

            return PartialView("_DriverInfoScheduleHoldGrid", model.GetAllDriverInfoScheduleHolds(id));
        }

        public ActionResult PropertyAdd(int id)
        {
            PropertyViewModel model = new PropertyViewModel();
            model.MemberCoverageID = id;

            return PartialView("_PropertyAdd", model);
        }

        public ActionResult PropertyEdit(int id)
        {
            PropertyViewModel model = new PropertyViewModel();

            return PartialView("_PropertyEdit", model.GetAPropertySchedule(id));
        }

        public ActionResult PropertyDelete(int id)
        {
            PropertyDeleteViewModel model = new PropertyDeleteViewModel();

            return PartialView("_PropertyDelete", model.GetAPropertyDelete(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddProperty(PropertyViewModel model)
        {
            PropertyScheduleHoldViewModel modelHold = new PropertyScheduleHoldViewModel();
            modelHold.PropertyScheduleAdd(model);

            return Json(new { success = true });
        }

        public ActionResult EditProperty(PropertyViewModel model)
        {
            PropertyScheduleHoldViewModel modelHold = new PropertyScheduleHoldViewModel();
            modelHold.PropertyScheduleEdit(model);

            return Json(new { success = true });

        }

        public ActionResult DeleteProperty(PropertyDeleteViewModel model)
        {
            PropertyScheduleHoldViewModel modelHold = new PropertyScheduleHoldViewModel();
            modelHold.PropertyScheduleDelete(model);

            return Json(new { success = true });
        }

        public ActionResult EditPropertyHold(int id)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

            return PartialView("_PropertyEditHold", model.GetAPropertyScheduleHold(id));
        }

        public ActionResult SavePropertyHold(PropertyScheduleHoldViewModel model)
        {
            model.PropertyScheduleHoldSave(model);

            return Json(new { success = true });
        }

        public ActionResult DeletePropertyHold(int id, int covId)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();
            model.PropertyScheduleHoldDelete(id);

            return PartialView("_PropertyScheduleHoldGrid", model.GetAllPropertyScheduleHold(covId));
        }
        public ActionResult RefreshPropertyHold(int id)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

            return PartialView("_PropertyScheduleHoldGrid", model.GetAllPropertyScheduleHold(id));
        }

        public ActionResult ScheduleContact(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
            if (id == 0)
            {
                model.ContactList = new ContactScheduleViewModel[0];
                model.ContactHoldList = new ContactScheduleHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }

        public ActionResult ScheduleDriverInfo(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.DriverInfoList != null && model.DriverInfoList.Count() > 0)
                    {
                        model.DriverInfoList = model.DriverInfoList.Where(x => x.DateRemoved == null).ToList();
                    }
                    if (model.DriverInfoHoldList != null && model.DriverInfoHoldList.Count() > 0)
                    {
                        model.DriverInfoHoldList = model.DriverInfoHoldList.Where(x => x.DateRemoved == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.DriverInfoList != null && model.DriverInfoList.Count() > 0)
                    {
                        model.DriverInfoList = model.DriverInfoList.Where(x => x.DateRemoved != null).ToList();
                    }
                    if (model.DriverInfoHoldList != null && model.DriverInfoHoldList.Count() > 0)
                    {
                        model.DriverInfoHoldList = model.DriverInfoHoldList.Where(x => x.DateRemoved != null).ToList();
                    }
                }
                else
                {
                    model.DriverInfoList = model.DriverInfoList;
                    model.DriverInfoHoldList = model.DriverInfoHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.DriverInfoList = new DriverInfoViewModel[0];
                    model.DriverInfoHoldList = new DriverInfoHoldViewModel[0];
                }

                model.MemberID = id;
                model.filterTypeId = 3;
                return View(model);
            }
        }

        public ActionResult ScheduleDriverInfoAdv(int id, int filterType)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
            if (id == 0)
            {
                model.DriverInfoList = new DriverInfoViewModel[0];
                model.DriverInfoHoldList = new DriverInfoHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }

        public ActionResult SchedulePrimaryCare(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.PrimaryCareList != null && model.PrimaryCareList.Count() > 0)
                    {
                        model.PrimaryCareList = model.PrimaryCareList.Where(x => x.DateRemoved == null).ToList();
                    }
                    if (model.PrimaryCareHoldList != null && model.PrimaryCareHoldList.Count() > 0)
                    {
                        model.PrimaryCareHoldList = model.PrimaryCareHoldList.Where(x => x.DateRemoved == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.PrimaryCareList != null && model.PrimaryCareList.Count() > 0)
                    {
                        model.PrimaryCareList = model.PrimaryCareList.Where(x => x.DateRemoved != null).ToList();
                    }
                    if (model.PrimaryCareHoldList != null && model.PrimaryCareHoldList.Count() > 0)
                    {
                        model.PrimaryCareHoldList = model.PrimaryCareHoldList.Where(x => x.DateRemoved != null).ToList();
                    }
                }
                else
                {
                    model.PrimaryCareList = model.PrimaryCareList;
                    model.PrimaryCareHoldList = model.PrimaryCareHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.PrimaryCareList = new PrimaryCareViewModel[0];
                    model.PrimaryCareHoldList = new PrimaryCareHoldViewModel[0];
                }

                model.MemberID = id;

                return View(model);
            }
        }


        public ActionResult ScheduleProperty(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.PropertyList != null && model.PropertyList.Count() > 0)
                    {
                        model.PropertyList = model.PropertyList.Where(x => x.DateRemoved == null).ToList();
                    }
                    if (model.PropertyHoldList != null && model.PropertyHoldList.Count() > 0)
                    {
                        model.PropertyHoldList = model.PropertyHoldList.Where(x => x.DateRemoved == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.PropertyList != null && model.PropertyList.Count() > 0)
                    {
                        model.PropertyList = model.PropertyList.Where(x => x.DateRemoved != null).ToList();
                    }
                    if (model.PropertyHoldList != null && model.PropertyHoldList.Count() > 0)
                    {
                        model.PropertyHoldList = model.PropertyHoldList.Where(x => x.DateRemoved != null).ToList();
                    }
                }
                else
                {
                    model.PropertyList = model.PropertyList;
                    model.PropertyHoldList = model.PropertyHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.PropertyList = new PropertyViewModel[0];
                    model.PropertyHoldList = new PropertyScheduleHoldViewModel[0];
                }

                model.MemberID = id;

                return View(model);
            }
        }

        public ActionResult SchedulePsychiatry(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.PsychiatryList != null && model.PsychiatryList.Count() > 0)
                    {
                        model.PsychiatryList = model.PsychiatryList.Where(x => x.DateRemoved == null).ToList();
                    }
                    if (model.PsychiatryHoldList != null && model.PsychiatryHoldList.Count() > 0)
                    {
                        model.PsychiatryHoldList = model.PsychiatryHoldList.Where(x => x.DateRemoved == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.PsychiatryList != null && model.PsychiatryList.Count() > 0)
                    {
                        model.PsychiatryList = model.PsychiatryList.Where(x => x.DateRemoved != null).ToList();
                    }
                    if (model.PsychiatryHoldList != null && model.PsychiatryHoldList.Count() > 0)
                    {
                        model.PsychiatryHoldList = model.PsychiatryHoldList.Where(x => x.DateRemoved != null).ToList();
                    }
                }
                else
                {
                    model.PsychiatryList = model.PsychiatryList;
                    model.PsychiatryHoldList = model.PsychiatryHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.PsychiatryList = new PsychiatryViewModel[0];
                    model.PsychiatryHoldList = new PsychiatryScheduleHoldViewModel[0];
                }

                model.MemberID = id;

                return View(model);
            }
        }

        public ActionResult ScheduleOther(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.OtherList != null && model.OtherList.Count() > 0)
                    {
                        model.OtherList = model.OtherList.Where(x => x.DateRemoved == null).ToList();
                    }
                    if (model.OtherHoldList != null && model.OtherHoldList.Count() > 0)
                    {
                        model.OtherHoldList = model.OtherHoldList.Where(x => x.DateRemoved == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.OtherList != null && model.OtherList.Count() > 0)
                    {
                        model.OtherList = model.OtherList.Where(x => x.DateRemoved != null).ToList();
                    }
                    if (model.OtherHoldList != null && model.OtherHoldList.Count() > 0)
                    {
                        model.OtherHoldList = model.OtherHoldList.Where(x => x.DateRemoved != null).ToList();
                    }
                }
                else
                {
                    model.OtherList = model.OtherList;
                    model.OtherHoldList = model.OtherHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.OtherList = new OtherScheduleViewModel[0];
                    model.OtherHoldList = new OtherScheduleHoldViewModel[0];
                }

                model.MemberID = id;

                return View(model);
            }
        }

        public ActionResult ScheduleVehicle(int id = 0)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                int selectedMemberId = 0;
                int selectedFilterTypeId = 0;
                string[] arrMemberFilter = null;

                if (Request.QueryString["id"] != null)
                {
                    arrMemberFilter = Request.QueryString["id"].Split(':');
                    selectedMemberId = Convert.ToInt32(arrMemberFilter[0]);
                    selectedFilterTypeId = Convert.ToInt32(arrMemberFilter[1]);
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(selectedMemberId, 0);
                if (selectedFilterTypeId == 1)
                {
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList = model.VehicleList.Where(x => x.DateDeleted == null).ToList();
                    }
                    if (model.VehicleHoldList != null && model.VehicleHoldList.Count() > 0)
                    {
                        model.VehicleHoldList = model.VehicleHoldList.Where(x => x.DateDeleted == null).ToList();
                    }
                }
                else if (selectedFilterTypeId == 2)
                {
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList = model.VehicleList.Where(x => x.DateDeleted != null).ToList();
                    }
                    if (model.VehicleHoldList != null && model.VehicleHoldList.Count() > 0)
                    {
                        model.VehicleHoldList = model.VehicleHoldList.Where(x => x.DateDeleted != null).ToList();
                    }
                }
                else
                {
                    model.VehicleList = model.VehicleList;
                    model.VehicleHoldList = model.VehicleHoldList;
                }
                model.MemberID = selectedMemberId;
                model.filterTypeId = selectedFilterTypeId;
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    id = BHIP.Model.Helper.Security.GetMemberID();
                }

                MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
                if (id == 0)
                {
                    model.VehicleList = new VehicleScheduleViewModel[0];
                    model.VehicleHoldList = new VehicleScheduleHoldViewModel[0];
                }

                model.MemberID = id;

                return View(model);
            }
        }


        public ActionResult AjaxPage(int id, string column, string sortOrder = "")
        {
            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
            if (id == 0)
            {
                model.VehicleList = new VehicleScheduleViewModel[0];
                model.VehicleHoldList = new VehicleScheduleHoldViewModel[0];
            }
            //model.MemberID = id;
            if (column == "year")
            {
                if (sortOrder == "asc")
                {
                    model.VehicleList = model.VehicleList.OrderBy(x => x.Year);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderYear = "desc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
                else
                {
                    model.VehicleList = model.VehicleList.OrderByDescending(x => x.Year);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderYear = "asc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
            }
            else if (column == "makeModel")
            {
                if (sortOrder == "asc")
                {
                    model.VehicleList = model.VehicleList.OrderBy(x => x.MakeModel);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderMakeModel = "desc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
                else
                {
                    model.VehicleList = model.VehicleList.OrderByDescending(x => x.MakeModel);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderMakeModel = "asc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
            }

            else if (column == "vinOwnLease")
            {
                if (sortOrder == "asc")
                {
                    model.VehicleList = model.VehicleList.OrderBy(x => x.VIN);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderVINOwnLease = "desc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
                else
                {
                    model.VehicleList = model.VehicleList.OrderByDescending(x => x.VIN);
                    if (model.VehicleList != null && model.VehicleList.Count() > 0)
                    {
                        model.VehicleList.First().SortOrderVINOwnLease = "asc";
                        model.VehicleList.First().MemberID = id;
                    }
                }
            }

            return PartialView("_VehicleScheduleGrid", model.VehicleList);
        }

        public ActionResult SchedulePending()
        {
            PendingScheduleViewModel model = new PendingScheduleViewModel();

            return View(model.GetPendingSchedules());
        }

        public ActionResult PendingVehicles(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
            if (id == 0)
            {
                model.VehicleList = new VehicleScheduleViewModel[0];
                model.VehicleHoldList = new VehicleScheduleHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }

        public ActionResult RefreshPendingVehicleHold(int id)
        {
            VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

            return PartialView("_PendingVehicleGrid", model.GetAllVehicleHolds(id));
        }


        public ActionResult PendingVehicleApprove(string id)
        {
            EmailVehicles emailModel = new EmailVehicles();
            bool isEmailRequired = false;
            if (id.Length > 0)
            {
                VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

                emailModel = model.VehiclePendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                int scheduleHoldId = 0;
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.VehicleScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.VehicleScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }

                if (emailModel != null && (emailModel.VehicleAddList != null && emailModel.VehicleAddList.Count > 0) || (emailModel.VehicleCOIList != null && emailModel.VehicleCOIList.Count > 0) ||
                        (emailModel.VehicleDeleteList != null && emailModel.VehicleDeleteList.Count > 0) || (emailModel.VehicleEditList != null && emailModel.VehicleEditList.Count > 0))
                {
                    isEmailRequired = true;
                }
            }
            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ",  Automobile Update", body = RenderPartialViewToString("_EmailVehicles", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"] , isEmailRequired}, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public ActionResult PendingVehicleRemove(string id)
        {
            if (id.Length > 0)
            {
                VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.VehicleScheduleHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingPsychiatry(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);
            if (id == 0)
            {
                model.PsychiatryList = new PsychiatryViewModel[0];
                model.PsychiatryHoldList = new PsychiatryScheduleHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }

        public ActionResult RefreshPendingPsychiatryHold(int id)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

            return PartialView("_PendingPsychiatryGrid", model.GetAllPsychiatryScheduleHolds(id));
        }

        public ActionResult PendingPsychiatryApprove(string id)
        {
            EmailPsychiatry emailModel = new EmailPsychiatry();
            bool isEmailRequired = false;
            if (id.Length > 0)
            {
                PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

                emailModel = model.PsychiatryPendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                int scheduleHoldId = 0;
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.PsychiatryScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.PsychiatryScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }

                if (emailModel != null && (emailModel.PsychiatryAddList != null && emailModel.PsychiatryAddList.Count > 0) || (emailModel.PsychiatryCOIList != null && emailModel.PsychiatryCOIList.Count > 0) ||
                        (emailModel.PsychiatryDeleteList != null && emailModel.PsychiatryDeleteList.Count > 0) || (emailModel.PsychiatryEditList != null && emailModel.PsychiatryEditList.Count > 0))
                {
                    isEmailRequired = true;
                }
            }

            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ", Behavioral Health Provider Update", body = RenderPartialViewToString("_EmailPsychiatry", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"], isEmailRequired }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingPsychiatryRemove(string id)
        {
            if (id.Length > 0)
            {
                PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.PsychiatryScheduleHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingOtherSchedule(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);

            if (id == 0)
            {
                model.OtherHoldList = new OtherScheduleHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }
        public ActionResult RefreshPendingOtherScheduleHold(int id)
        {
            OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();

            return PartialView("_PendingOtherScheduleGrid", model.GetAllOtherScheduleHolds(id));
        }
        public ActionResult PendingOtherScheduleApprove(string id)
        {
            EmailOtherSchedule emailModel = new EmailOtherSchedule();
            bool isEmailRequired = false;
            if (id.Length > 0)
            {
                OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();

                emailModel = model.OtherSchedulePendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                int scheduleHoldId = 0;
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.OtherScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.OtherScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }
                if (emailModel != null && (emailModel.OtherScheduleAddList != null && emailModel.OtherScheduleAddList.Count > 0) || (emailModel.OtherScheduleCOIList != null && emailModel.OtherScheduleCOIList.Count > 0) ||
                                      (emailModel.OtherScheduleDeleteList != null && emailModel.OtherScheduleDeleteList.Count > 0) || (emailModel.OtherScheduleEditList != null && emailModel.OtherScheduleEditList.Count > 0))
                {
                    isEmailRequired = true;
                }
            }

            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ", Other Provider Update", body = RenderPartialViewToString("_EmailOtherSchedule", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"],isEmailRequired }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingOtherScheduleRemove(string id)
        {
            if (id.Length > 0)
            {
                OtherScheduleHoldViewModel model = new OtherScheduleHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.OtherScheduleHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingProperty(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);

            if (id == 0)
            {
                model.PropertyHoldList = new PropertyScheduleHoldViewModel[0];
            }
            model.MemberID = id;

            return View(model);
        }

        public ActionResult RefreshPendingPropertyHold(int id)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

            return PartialView("_PendingPropertyGrid", model.GetAllPropertyScheduleHold(id));
        }

        public ActionResult PendingPropertyApprove(string id)
        {
            EmailProperty emailModel = new EmailProperty();
            bool isEmailRequired = false;
            if (id.Length > 0)
            {
                PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

                emailModel = model.PropertyPendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                int scheduleHoldId = 0;
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.PropertyScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.PropertyScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }
                if (emailModel != null && (emailModel.PropertyAddList != null && emailModel.PropertyAddList.Count > 0) || (emailModel.PropertyCOIList != null && emailModel.PropertyCOIList.Count > 0) ||
                                                     (emailModel.PropertyDeleteList != null && emailModel.PropertyDeleteList.Count > 0) || (emailModel.PropertyEditList != null && emailModel.PropertyEditList.Count > 0))
                {
                    isEmailRequired = true;
                }
            }

            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ", Property Update", body = RenderPartialViewToString("_EmailProperty", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"],isEmailRequired }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingPropertyRemove(string id)
        {
            if (id.Length > 0)
            {
                PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.PropertyScheduleHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingPrimaryCare(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);

            if (id == 0)
            {
                model.PrimaryCareHoldList = new PrimaryCareHoldViewModel[0];
            }
            model.MemberID = id;

            return View(model);
        }

        public ActionResult RefreshPendingPrimaryCareHold(int id)
        {
            PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

            return PartialView("_PendingPrimaryCareGrid", model.GetAllPrimaryCareHolds(id));
        }

        public ActionResult PendingPrimaryCareApprove(string id)
        {
            int scheduleHoldId = 0;
            bool isEmailRequired = false;
            EmailPrimaryCare emailModel = new EmailPrimaryCare();

            if (id.Length > 0)
            {
                PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

                emailModel = model.PrimaryCarePendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.PrimaryCareScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }
                if (emailModel != null && (emailModel.PrimaryCareAddList != null && emailModel.PrimaryCareAddList.Count > 0) || (emailModel.PrimaryCareCOIList != null && emailModel.PrimaryCareCOIList.Count > 0) ||
                                       (emailModel.PrimaryCareDeleteList != null && emailModel.PrimaryCareDeleteList.Count > 0) || (emailModel.PrimaryCareEditList != null && emailModel.PrimaryCareEditList.Count > 0))
                {
                    isEmailRequired = true;
                }
            }

            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ", Primary Care Provider Update", body = RenderPartialViewToString("_EmailPrimaryCare", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"],isEmailRequired }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingPrimaryCareRemove(string id)
        {
            if (id.Length > 0)
            {
                PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.PrimaryCareScheduleHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingDriverInfo(int id = 0)
        {
            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            MemberCoverageViewModel model = new MemberCoverageViewModel(id, 0);

            if (id == 0)
            {
                model.DriverInfoHoldList = new DriverInfoHoldViewModel[0];
            }

            model.MemberID = id;

            return View(model);
        }



        public ActionResult RefreshPendingDriverInfoHold(int id)
        {
            DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

            return PartialView("_PendingDriverInfoGrid", model.GetAllDriverInfoScheduleHolds(id));
        }

        public ActionResult PendingDriverInfoApprove(string id)
        {
            EmailDriverInfo emailModel = new EmailDriverInfo();

            if (id.Length > 0)
            {
                DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

                emailModel = model.DriverInfoPendingApprove(id);

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                int scheduleHoldId = 0;
                if (listScheduleID.Count() > 0)
                {
                    scheduleHoldId = Convert.ToInt32(listScheduleID[0]);
                }
                else
                {
                    scheduleHoldId = 0;
                }

                int memberId = BHIP.Model.Helper.Security.GetMemberID();

                string qryMember = (from member in ContextPerRequest.CurrentData.Members
                                    join coverage in ContextPerRequest.CurrentData.MemberCoverages on member.MemberId equals coverage.MemberId
                                    join hold in ContextPerRequest.CurrentData.DriverInfoScheduleHolds on coverage.MemberCoverageID equals hold.MemberCoverageID
                                    where hold.DriverInfoScheduleHoldID == scheduleHoldId
                                    select member.Name).FirstOrDefault<string>();

                if (qryMember != null)
                {
                    emailModel.MemberName = qryMember;
                }

            }

            return Json(new { mailto = System.Web.Configuration.WebConfigurationManager.AppSettings["ToEmail"], subject = "BHIP, " + emailModel.MemberName + ", Driver Information Update", body = RenderPartialViewToString("_EmailDriverInfo", emailModel), cc = System.Web.Configuration.WebConfigurationManager.AppSettings["CCEmail"] }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        public ActionResult PendingDriverInfoRemove(string id)
        {
            if (id.Length > 0)
            {
                DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

                List<string> listScheduleID = new List<string>();

                listScheduleID = id.Split(',').ToList();

                foreach (var item in listScheduleID)
                {
                    int scheduleID = Convert.ToInt32(item.ToString());

                    model.DriverInfoHoldDelete(scheduleID);

                }
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }


    }
}