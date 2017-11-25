using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BHIP.Model.Extenstions
{
    public class EmailSystem
    {
        public bool EmailIt(string message, string emailFrom, string emailAddress, string emailSubject, List<string> FileNames)
        {
            MailMessage mm = new MailMessage();

            mm.From = new MailAddress(emailFrom);  // note: this user must be able to authenticate through SMTP on Exchange

            mm.Subject = emailSubject;
            mm.To.Add(emailAddress);

            mm.Body = message;
            mm.IsBodyHtml = true;

            SmtpClient server = new SmtpClient();
            if (WebConfigurationManager.AppSettings["EmailSystem"] != "Testing")
            {
                server.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            }

            if (FileNames != null)
            {
                foreach (string filePath in FileNames)
                {
                    Attachment attachment = new Attachment(WebConfigurationManager.AppSettings["FileUpload"] + filePath);
                    mm.Attachments.Add(attachment);
                }
            }

            try
            {
                server.Send(mm);
                return true;
            }
            catch (SmtpFailedRecipientException error)
            {
                string innerMessage = (error.InnerException != null) ? error.InnerException.Message : "";
                BHIP.Model.Helper.Helper.LogError(error.Message, innerMessage);
                return false;
            }
            catch (Exception ex)
            {
                String innerMessage = (ex.InnerException != null)
                      ? ex.InnerException.Message
                      : "";
                BHIP.Model.Helper.Helper.LogError(ex.Message, innerMessage);
                return false;

            }
            finally
            {
                mm.Dispose();
                server.Dispose();
            }

        }
        public string RenderViewToString(ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            ViewDataDictionary viewData = new ViewDataDictionary(model);

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                ViewContext viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}