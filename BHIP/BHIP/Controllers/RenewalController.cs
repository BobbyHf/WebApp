using BHIP.Helper;
using BHIP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BHIP.Controllers
{
    public class RenewalController : BaseController
    {
        // GET: Renewal
        public ActionResult Index(int id = 0)
        {
            int renewalId = 0;
            HttpContext.Server.ScriptTimeout = 60;

            if (id == 0)
            {
                id = BHIP.Model.Helper.Security.GetMemberID();
            }

            RenewalViewModel model = new RenewalViewModel(id);
            PropertyViewModel propertyModel = new PropertyViewModel();
            VehicleScheduleViewModel vehicleModel = new VehicleScheduleViewModel();
            DriverInfoViewModel driverModel = new DriverInfoViewModel();
            DocumentViewModel docModel = new DocumentViewModel();

            if (model.CheckRenewalExists(id))
            {
                model.GetRenewalRecord(id, model.GetMemberCoverageID(id));

                if (model.IsLocked(model.RenewalID, BHIP.Model.Helper.Security.GetLoggedInUserID()))
                {
                    Response.Redirect("/Renewal/Locked");
                }
                else
                {
                    model.LockRenewal(model.RenewalID, BHIP.Model.Helper.Security.GetLoggedInUserID());
                }
                model.MemberCoverageID = model.GetMemberCoverageID(id);
                model.TotalBuilding = propertyModel.TotalBuildingValue(model.GetMemberCoverageID(id));
                model.TotalContent = propertyModel.TotalContentValue(model.GetMemberCoverageID(id));
                model.TotalFootage = propertyModel.TotalSquareFeet(model.GetMemberCoverageID(id));
                model.InspectionBodyGrid = model.GetInpsectionBody(model.RenewalID);
                model.HandleFundsGrid = model.GetHandleFunds(model.RenewalID);

                model.Attachments = docModel.GetDocuments(model.RenewalID);

                if (model.TotalFootage > 0)
                {
                    model.CostSquareFoot = (model.TotalBuilding + model.TotalContent) / model.TotalFootage;
                }
                else
                {
                    model.CostSquareFoot = 0;
                }
                model.TotalInsurable = model.TotalBuilding + model.TotalContent;
            }
            else
            {
                if (id > 0)
                {
                    renewalId = model.CreateRenewalRecord(id);
                    model.MemberCoverageID = model.GetMemberCoverageID(id);
                    model.GetRenewalRecord(id, model.GetMemberCoverageID(id));
                    model.InitializeQuestions(renewalId, id);
                    model.InspectionBodyGrid = model.GetInpsectionBody(0);
                    model.HandleFundsGrid = model.GetHandleFunds(0);
                    model.TotalAutos = vehicleModel.TotalAutos(model.GetMemberCoverageID(id));
                    model.TotalDrivers = driverModel.TotalDrivers(model.GetMemberCoverageID(id));

                    model.TotalBuilding = propertyModel.TotalBuildingValue(model.GetMemberCoverageID(id));
                    model.TotalContent = propertyModel.TotalContentValue(model.GetMemberCoverageID(id));
                    model.TotalFootage = propertyModel.TotalSquareFeet(model.GetMemberCoverageID(id));
                    if (model.TotalFootage > 0)
                    {
                        model.CostSquareFoot = (model.TotalBuilding + model.TotalContent) / model.TotalFootage;
                    }
                    else
                    {
                        model.CostSquareFoot = 0;
                    }
                    model.TotalInsurable = model.TotalBuilding + model.TotalContent;
                    model.Attachments = new DocumentViewModel[0];
                }
                else
                {
                    model.MemberID = id;
                    model.ContactList = new ContactScheduleViewModel[0];
                    model.ContactHoldList = new ContactScheduleHoldViewModel[0];
                    model.LicenseList = new LicenseViewModel[0];
                    model.AgencyPlanList = new AgencyPlanViewModel[0];
                    model.HandleFundsGrid = model.GetHandleFunds(0);
                    model.InspectionBodyGrid = model.GetInpsectionBody(0);
                    model.PsychiatryList = new PsychiatryViewModel[0];
                    model.PsychiatryHoldList = new PsychiatryScheduleHoldViewModel[0];
                    model.PrimaryCareList = new PrimaryCareViewModel[0];
                    model.PrimaryCareHoldList = new PrimaryCareHoldViewModel[0];
                    model.VehicleList = new VehicleScheduleViewModel[0];
                    model.VehicleHoldList = new VehicleScheduleHoldViewModel[0];
                    model.DriverInfoList = new DriverInfoViewModel[0];
                    model.DriverInfoHoldList = new DriverInfoHoldViewModel[0];
                    model.PropertyList = new PropertyViewModel[0];
                    model.PropertyHoldList = new PropertyScheduleHoldViewModel[0];
                    model.Attachments = new DocumentViewModel[0];
                }
            }

            if (model.Submitted == true && User.IsInRole("Administrator") != true)
            {
                model.IsRenewLocked = true;
            }
            model.UserRoles = model.GetUserRoles();
            return View(model);
        }

        public ActionResult Locked()
        {
            return View();
        }

        public ActionResult Unlock(int id)
        {
            RenewalViewModel model = new RenewalViewModel();
            model.UnlockRenewal(id);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KeepLocked(int id)
        {
            RenewalViewModel model = new RenewalViewModel();
            model.LockRenewal(id, BHIP.Model.Helper.Security.GetLoggedInUserID());

            return Json(new { success = true });
        }
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult SaveRenewal(RenewalViewModel model)
        {
           model.SaveRenewal(model);

           model.SaveQuestions(model);
           model.SaveInspectionBody(model.InspectionBodyGrid, model.RenewalID);
           model.SaveHandleFunds(model.HandleFundsGrid, model.RenewalID);

            return Json(new { success = true });
        }

        public ActionResult AddLicense(int id)
        {
            LicenseViewModel model = new LicenseViewModel();
            model.MemberID = id;

            return PartialView("_LicenseAdd", model);
        }
        public ActionResult EditLicense(int id)
        {
            LicenseViewModel model = new LicenseViewModel();

            return PartialView("_LicenseEdit", model.GetALicense(id));
        }

        public ActionResult LicenseAdd(LicenseViewModel model)
        {
            model.AddLicense(model);

            return Json(new { success = true });
        }
        public ActionResult LicenseEdit(LicenseViewModel model)
        {
            model.EditLicense(model);
            return Json(new { success = true });
        }

        public ActionResult LicenseDelete(int licenseId)
        {
            LicenseViewModel model = new LicenseViewModel();

            if (licenseId > 0)
            {
                model.DeleteLicense(licenseId);
            }

            return PartialView("_LicenseSchedule");
        }

        public ActionResult RefreshLicense(int id)
        {
            LicenseViewModel licenseModel = new LicenseViewModel();

            return PartialView("_LicenseSchedule", licenseModel.GetLicense(id));
        }
        public ActionResult DeleteLicense(int id, int mid)
        {
            LicenseViewModel model = new LicenseViewModel();
            model.DeleteLicense(id);

            return PartialView("_LicenseSchedule", model.GetLicense(mid));
        }
        //============================================
        public ActionResult AddPlan(int id)
        {
            AgencyPlanViewModel model = new AgencyPlanViewModel();
            model.MemberID = id;

            return PartialView("_AgencyPlanAdd", model);
        }
        public ActionResult EditPlan(int id)
        {
            AgencyPlanViewModel model = new AgencyPlanViewModel();

            return PartialView("_AgencyPlanEdit", model.GetAPlan(id));
        }

        public ActionResult PlanAdd(AgencyPlanViewModel model)
        {
            model.AddAgencyPlan(model);

            return Json(new { success = true });
        }
        public ActionResult PlanEdit(AgencyPlanViewModel model)
        {
            model.EditAgencyPlan(model);
            return Json(new { success = true });
        }

        public ActionResult DeletePlan(int id, int mid)
        {
            AgencyPlanViewModel model = new AgencyPlanViewModel();

            if (id > 0)
            {
                model.DeleteAgencyPlan(id);
            }

            return PartialView("_AgencyPlanSchedule", model.GetPlan(mid));
        }
        public ActionResult RefreshPlan(int id)
        {
            AgencyPlanViewModel model = new AgencyPlanViewModel();

            return PartialView("_AgencyPlanSchedule", model.GetPlan(id));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetJobList()
        {
           // var data = ContextPerRequest.CurrentData.JobFunctions.Select(model => new { JobFunction = model.JobFunction1 });

            return Json(ContextPerRequest.CurrentData.JobFunctions.Select(model => new { JobFunction = model.JobFunction1 }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RefreshPropertyHold(int id)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();

            return PartialView("~/Views/MemberCov/_PropertyScheduleHoldGrid.cshtml", model.GetAllPropertyScheduleHold(id));
        }
        public ActionResult DeletePropertyHold(int id, int covId)
        {
            PropertyScheduleHoldViewModel model = new PropertyScheduleHoldViewModel();
            model.PropertyScheduleHoldDelete(id);

            return PartialView("~/Views/MemberCov/_PropertyScheduleHoldGrid.cshtml", model.GetAllPropertyScheduleHold(covId));
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

            return PartialView("~/Views/MemberCov/_PropertyEditHold.cshtml", model.GetAPropertyScheduleHold(id));
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

            return PartialView("~/Views/MemberCov/_VehicleEdit.cshtml", model.GetAVehicle(id));
        }

        public ActionResult VehicleDelete(int id)
        {
            VehicleDeleteViewModel model = new VehicleDeleteViewModel();

            return PartialView("~/Views/MemberCov/_VehicleDelete.cshtml", model.GetAVehicle(id));

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

            return PartialView("~/Views/MemberCov/_VehicleEditHold.cshtml", model.GetAVehicleHold(id));
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

            return PartialView("~/Views/MemberCov/_VehicleScheduleHoldGrid.cshtml", model.GetAllVehicleHolds(covId));
        }
        public ActionResult RefreshVehicleHold(int id)
        {
            VehicleScheduleHoldViewModel model = new VehicleScheduleHoldViewModel();

            return PartialView("~/Views/MemberCov/_VehicleScheduleHoldGrid.cshtml", model.GetAllVehicleHolds(id));
        }

        public ActionResult PsychiatryAdd(int id)
        {
            PsychiatryViewModel model = new PsychiatryViewModel();
            model.MemberCoverageID = id;

            return PartialView("~/Views/MemberCov/_PsychiatryAdd.cshtml", model);
        }

        public ActionResult PsychiatryEdit(int id)
        {
            PsychiatryViewModel model = new PsychiatryViewModel();

            return PartialView("~/Views/MemberCov/_PsychiatryEdit.cshtml", model.GetAPsychiatrySchedule(id));
        }

        public ActionResult PsychiatryDelete(int id)
        {
            PsychiatryDeleteViewModel model = new PsychiatryDeleteViewModel();

            return PartialView("~/Views/MemberCov/_PsychiatryDelete.cshtml", model.GetAPsychiatrySchedule(id));
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

        public ActionResult DeletePsychiatry(PsychiatryDeleteViewModel model)
        {
            PsychiatryScheduleHoldViewModel modelHold = new PsychiatryScheduleHoldViewModel();
            modelHold.PsychiatryScheduleDelete(model);

            return Json(new { success = true });
        }
        public ActionResult EditPsychiatryHold(int id)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

            return PartialView("~/Views/MemberCov/_PsychiatryEditHold.cshtml", model.GetAPsychiatryScheduleHold(id));
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

            return PartialView("~/Views/MemberCov/_PsychiatryScheduleHoldGrid.cshtml", model.GetAllPsychiatryScheduleHolds(covId));
        }
        public ActionResult RefreshPsychiatryHold(int id)
        {
            PsychiatryScheduleHoldViewModel model = new PsychiatryScheduleHoldViewModel();

            return PartialView("~/Views/MemberCov/_PsychiatryScheduleHoldGrid.cshtml", model.GetAllPsychiatryScheduleHolds(id));
        }

        public ActionResult PrimaryCareAdd(int id)
        {
            PrimaryCareViewModel model = new PrimaryCareViewModel();
            model.MemberCoverageID = id;

            return PartialView("~/Views/MemberCov/_PrimaryCareAdd.cshtml", model);
        }

        public ActionResult PrimaryCareEdit(int id)
        {
            PrimaryCareViewModel model = new PrimaryCareViewModel();

            return PartialView("~/Views/MemberCov/_PrimaryCareEdit.cshtml", model.GetAPrimaryCareSchedule(id));
        }

        public ActionResult PrimaryCareDelete(int id)
        {
            PrimaryCareDeleteViewModel model = new PrimaryCareDeleteViewModel();

            return PartialView("~/Views/MemberCov/_PrimaryCareDelete.cshtml", model.GetAPrimaryCareSchedule(id));

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

            return PartialView("~/Views/MemberCov/_PrimaryCareEditHold.cshtml", model.GetAPrimaryCareHold(id));
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

            return PartialView("~/Views/MemberCov/_PrimaryCareScheduleHoldGrid.cshtml", model.GetAllPrimaryCareHolds(covId));
        }
        public ActionResult RefreshPrimaryCareHold(int id)
        {
            PrimaryCareHoldViewModel model = new PrimaryCareHoldViewModel();

            return PartialView("~/Views/MemberCov/_PrimaryCareScheduleHoldGrid.cshtml", model.GetAllPrimaryCareHolds(id));
        }

        public ActionResult DriverInfoAdd(int id)
        {
            DriverInfoViewModel model = new DriverInfoViewModel();
            model.MemberCoverageID = id;

            return PartialView("~/Views/MemberCov/_DriverInfoAdd.cshtml", model);
        }

        public ActionResult DriverInfoEdit(int id)
        {
            DriverInfoViewModel model = new DriverInfoViewModel();

            return PartialView("~/Views/MemberCov/_DriverInfoEdit.cshtml", model.GetADriverInfo(id));
        }

        public ActionResult DriverInfoDelete(int id)
        {
            DriverInfoDeleteViewModel model = new DriverInfoDeleteViewModel();

            return PartialView("~/Views/MemberCov/_DriverInfoDelete.cshtml", model.GetADriverInfo(id));
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

            return PartialView("~/Views/MemberCov/_DriverInfoEditHold.cshtml", model.GetADriverInfoScheduleHold(id));
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

            return PartialView("~/Views/MemberCov/_DriverInfoScheduleHoldGrid.cshtml", model.GetAllDriverInfoScheduleHolds(covId));
        }
        public ActionResult RefreshDriverInfoHold(int id)
        {
            DriverInfoHoldViewModel model = new DriverInfoHoldViewModel();

            return PartialView("~/Views/MemberCov/_DriverInfoScheduleHoldGrid.cshtml", model.GetAllDriverInfoScheduleHolds(id));
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
            ContactScheduleHoldViewModel model = new ContactScheduleHoldViewModel();
            model.ContactScheduleDelete(id);
            MemberCoverageViewModel member = new MemberCoverageViewModel(memId, 0);

            return PartialView("_ContactScheduleGrid", member);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddContact(ContactScheduleViewModel model)
        {
            ContactScheduleHoldViewModel hold = new ContactScheduleHoldViewModel();
            hold.ContactScheduleAdd(model);

            return Json(new { success = true });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditContact(ContactScheduleViewModel model)
        {
            ContactScheduleHoldViewModel modelHold = new ContactScheduleHoldViewModel();
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
            RenewalViewModel model = new RenewalViewModel();
            ContactScheduleHoldViewModel hold = new ContactScheduleHoldViewModel();


            return PartialView("_ContactScheduleHoldGrid", hold.GetAllContactScheduleHolds(model.GetMemberCoverageID(id)));
        }

        public ActionResult AddDocument(int renewalId)
        {
            DocumentViewModel model = new DocumentViewModel();
            model.RenewalId = renewalId;

            return PartialView("_DocumentAdd", model);
        }

        public ActionResult DocumentType()
        {
            DocumentTypeViewModel model = new DocumentTypeViewModel();

            return PartialView("_DocumentTypeAdd", model);
        }

        public ActionResult SaveAddDocumentType(DocumentTypeViewModel model)
        {
            if (model != null)
            {
                model.SaveDocumentType(model);
            }

            return Json(new { success = true });

        }

        public ActionResult SaveAddDocument(int RenewalId, string EffectiveDate, string ddlDocumentType, string fileName, HttpPostedFileBase UploadedImage)
        {
            byte[] file = null;
            BinaryReader rdr = new BinaryReader(UploadedImage.InputStream);
            file = rdr.ReadBytes((int)UploadedImage.ContentLength);

            DocumentViewModel model = new DocumentViewModel();
            model.RenewalId = RenewalId;
            model.Action = false;
            model.DocTypeId = Convert.ToInt32(ddlDocumentType.ToString());
            model.EffectiveDate = Convert.ToDateTime(EffectiveDate);
            model.Extension = Path.GetExtension(UploadedImage.FileName).Replace(".", "");
            model.FileName = UploadedImage.FileName;
            model.FileUpload = file;
            model.Media = UploadedImage.ContentType;
            model.Name = UploadedImage.FileName;

            model.AddDocument(model);

            return Json(new { success = true });
        }

        public ActionResult RefreshAddDocument(int id)
        {
            DocumentViewModel model = new DocumentViewModel();


            return PartialView("_Document", model.GetDocuments(id));

        }

        public ActionResult DeleteDocument(int id, int rid)
        {
            DocumentViewModel model = new DocumentViewModel();
            model.DeleteDocument(id);

            return PartialView("_Document", model.GetDocuments(rid));
        }

        public ActionResult EditDocument(int id)
        {
            DocumentViewModel model = new DocumentViewModel();

            return PartialView("_DocumentEdit", model.EditDocument(id));
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveEditDocument(int DocumentId, int RenewalId, string EffectiveDate, string ddlDocumentType, string fileName, HttpPostedFileBase UploadedImage)
        {
            byte[] file = null;
            BinaryReader rdr = new BinaryReader(UploadedImage.InputStream);
            file = rdr.ReadBytes((int)UploadedImage.ContentLength);

            DocumentViewModel model = new DocumentViewModel();
            model.RenewalId = RenewalId;
            model.Action = false;
            model.DocumentId = DocumentId;
            model.DocTypeId = Convert.ToInt32(ddlDocumentType.ToString());
            model.EffectiveDate = Convert.ToDateTime(EffectiveDate);
            model.Extension = Path.GetExtension(UploadedImage.FileName).Replace(".", "");
            model.FileName = UploadedImage.FileName;
            model.FileUpload = file;
            model.Media = UploadedImage.ContentType;
            model.Name = UploadedImage.FileName;
            model.SaveEditDocument(model);

            return Json(new { success = true });
        }
        public FileContentResult GetDocument(int docId)
        {
            DocumentViewModel model = new DocumentViewModel();

            model = model.GetDocument(docId);

            byte[] byteInfo = model.FileUpload;
            string fileName = model.FileName;
            string fileType = model.Extension.ToLower();
            string mediaType = model.Media;

            return File(byteInfo, mediaType, fileName);
        }
        [HttpPost]
        public ActionResult SubmitRenewal(int id)
        {
            string ip = Request.UserHostAddress;
            string userAgent = Request.UserAgent;
            RenewalViewModel model = new RenewalViewModel();

            if (model.SubmitRenewal(id, BHIP.Model.Helper.Security.GetUserName(), ip, userAgent))
            {

                EmailSystem objEmail = new EmailSystem();
                if (WebConfigurationManager.AppSettings["EmailSystem"] == "Testing")
                {

                    objEmail.EmailIt(objEmail.RenderViewToString(this.ControllerContext, "_Email", null), "wes.gates@ashtontiffany.com", "Angie.Vandenburgh@ashtontiffany.com", "adminBHIP@BHIPAZ.org", BHIP.Model.ProjectGlobals.NextYear.ToString() + " Renewal Application - " + BHIP.Model.Helper.MemberInformation.GetMemberNameByRenewalID(id), null);
                }
                else
                {
                    objEmail.EmailIt(objEmail.RenderViewToString(this.ControllerContext, "_Email", null), "adminbhip@bhipaz.org", BHIP.Model.Helper.MemberInformation.GetAuthorizeRepEmail(BHIP.Model.Helper.MemberInformation.GetMemberCoverageIDByRenewalID(id)) + "; " + BHIP.Model.Helper.MemberInformation.GetContactEmail(BHIP.Model.Helper.MemberInformation.GetMemberCoverageIDByRenewalID(id)), "adminbhip@bhipaz.org", BHIP.Model.ProjectGlobals.NextYear.ToString() + " Renewal Application - " + BHIP.Model.Helper.MemberInformation.GetMemberNameByRenewalID(id), null);
                }
            }

            return Json(new { success = true });
        }
    }
}