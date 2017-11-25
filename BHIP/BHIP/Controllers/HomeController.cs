using BHIP.Model;
using BHIP.Model.Extenstions;
using BHIP.Model.Helper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BHIP.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            ContactViewModel model = new ContactViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult ContactUs(ContactViewModel model)
        {
            EmailSystem emailFollowUp = new EmailSystem();
            emailFollowUp.EmailIt(emailFollowUp.RenderViewToString(this.ControllerContext, "_ContactForm", model), "AdminBHIP@BHIPAZ.org", System.Web.Configuration.WebConfigurationManager.AppSettings["ContactEmail"], "Contact Us", null);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Board()
        {
            return View();
        }

        public ActionResult CoverageInfo()
        {
            return View();
        }

        public ActionResult Claims()
        {
            return View();
        }

        public ActionResult ClaimAuto()
        {
            return View();
        }

        public ActionResult ClaimProperty()
        {
            return View();
        }

        public ActionResult ClaimAnother()
        {
            return View();
        }
        public ActionResult Schedules()
        {
            return View();
        }

        public ActionResult SchedulesPrimary()
        {
            return View();
        }

        public ActionResult Certificate()
        {
            return View();
        }

        public ActionResult CertificatePrimary()
        {
            return View();
        }

        public ActionResult LossReports()
        {
            return View();
        }

        public ActionResult Resources()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAutoClaim()
        {


            var file = new FileCollectionEventArgs(this.Request);
            var response = new List<string>();
            int uploadedFiles = 0;
            string Type = "A";
            HttpFileCollectionBase oHttpFileCollection = file.PostedFiles;
            HttpPostedFileBase oHttpPostedFile = null;
            MailMessage mm = new MailMessage();
            if (file.HasFiles)
            {
                for (int n = 0; n < file.Count; n++)
                {
                    oHttpPostedFile = oHttpFileCollection[n];
                    if (oHttpPostedFile.ContentLength <= 0)
                        continue;
                    else
                    {
                        uploadedFiles++;
                        var fileName = String.Format("{0}\\{1}", Server.MapPath("~/uploads"), System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                        oHttpPostedFile.SaveAs(fileName);
                        response.Add(System.IO.Path.GetFileName(fileName));

                       //Attachment att = new Attachment( oHttpPostedFile.InputStream, oHttpPostedFile.ContentType);
                        Attachment att = new Attachment(oHttpPostedFile.InputStream, Path.GetFileName(oHttpPostedFile.FileName), oHttpPostedFile.ContentType);
                       mm.Attachments.Add(att);
                    }
                }
            }
            if (uploadedFiles > 0)
            {
                EmailItAlert(mm, Type);
            }
               

              return RedirectToAction("Index", "Home"); 

        }
        public ActionResult SavePropertyClaim()
        {
            var file = new FileCollectionEventArgs(this.Request);
            var response = new List<string>();
            int uploadedFiles = 0;
            string Type = "P";
            HttpFileCollectionBase oHttpFileCollection = file.PostedFiles;
            HttpPostedFileBase oHttpPostedFile = null;
            MailMessage mm = new MailMessage();
            if (file.HasFiles)
            {
                for (int n = 0; n < file.Count; n++)
                {
                    oHttpPostedFile = oHttpFileCollection[n];
                    if (oHttpPostedFile.ContentLength <= 0)
                        continue;
                    else
                    {
                        uploadedFiles++;
                        var fileName = String.Format("{0}\\{1}", Server.MapPath("~/uploads"), System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                        oHttpPostedFile.SaveAs(fileName);
                        response.Add(System.IO.Path.GetFileName(fileName));

                        //Attachment att = new Attachment( oHttpPostedFile.InputStream, oHttpPostedFile.ContentType);
                        Attachment att = new Attachment(oHttpPostedFile.InputStream, Path.GetFileName(oHttpPostedFile.FileName), oHttpPostedFile.ContentType);
                        mm.Attachments.Add(att);
                    }
                }
            }
            if (uploadedFiles > 0)
            {
                EmailItAlert(mm,Type);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SaveOtherClaim()
        {
            var file = new FileCollectionEventArgs(this.Request);
            var response = new List<string>();
            int uploadedFiles = 0;
            string Type = "O";
            HttpFileCollectionBase oHttpFileCollection = file.PostedFiles;
            HttpPostedFileBase oHttpPostedFile = null;
            MailMessage mm = new MailMessage();
            if (file.HasFiles)
            {
                for (int n = 0; n < file.Count; n++)
                {
                    oHttpPostedFile = oHttpFileCollection[n];
                    if (oHttpPostedFile.ContentLength <= 0)
                        continue;
                    else
                    {
                        uploadedFiles++;
                        var fileName = String.Format("{0}\\{1}", Server.MapPath("~/uploads"), System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                        oHttpPostedFile.SaveAs(fileName);
                        response.Add(System.IO.Path.GetFileName(fileName));

                        //Attachment att = new Attachment( oHttpPostedFile.InputStream, oHttpPostedFile.ContentType);
                        Attachment att = new Attachment(oHttpPostedFile.InputStream, Path.GetFileName(oHttpPostedFile.FileName), oHttpPostedFile.ContentType);
                        mm.Attachments.Add(att);
                    }
                }
            }
            if (uploadedFiles > 0)
            {
                EmailItAlert(mm, Type);
            }
            return RedirectToAction("Index", "Home");
        }
        public bool EmailItAlert(MailMessage mm1, string type)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["ContactEmail"]);
            if (type == "A")
            {
                mm.Subject = "Auto Claim - " + User.Identity.GetMemberName(User.Identity.GetUserId());
                mm.Body = "The below user has submitted an Auto Claim for the Member mentioned Below \n" + "UserName: " + User.Identity.GetUserName() + "\n" + "MemberName: " + User.Identity.GetMemberName(User.Identity.GetUserId());
            }
            else if (type == "P")
            {
                mm.Subject = "Property Claim - " + User.Identity.GetMemberName(User.Identity.GetUserId());
                mm.Body = "The below user has submitted an Property Claim for the Member mentioned Below \n" + "UserName: " + User.Identity.GetUserName() + "\n" + "MemberName: " + User.Identity.GetMemberName(User.Identity.GetUserId());
            }
            else
            {
                mm.Subject = "Other Claim - " + User.Identity.GetMemberName(User.Identity.GetUserId());
                mm.Body = "The below user has submitted an Other Claim for the Member Mentioned Below \n" + "UserName: " + User.Identity.GetUserName() + "\n" + "MemberName: " + User.Identity.GetMemberName(User.Identity.GetUserId());
            }
            mm.IsBodyHtml = true;
            SmtpClient server = new SmtpClient();
            mm.To.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["ContactEmail"]);
            if (WebConfigurationManager.AppSettings["EmailSystem"] != "Testing")
            {
                server.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            }
            if (mm1.Attachments != null && mm1.Attachments.Count > 0)
            {
                foreach (Attachment att in mm1.Attachments)
                    mm.Attachments.Add(att);
            }
            //mm.CC.Add("manideep@techmileage.com");
            server.Send(mm);
            return true;
        }


    }
}