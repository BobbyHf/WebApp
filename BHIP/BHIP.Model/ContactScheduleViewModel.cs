using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class ContactScheduleViewModel
    {
        public int ContactScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the first name")]
        [Display(Name = "First Name:")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        [Display(Name = "Last Name:")]
        public string ContactLastName { get; set; }
        [Display(Name = "Title:")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }
        [Display(Name = "Phone:")]
        public string ContactPhone { get; set; }
        [Display(Name = "Ext:")]
        public string ContactPhoneExt { get; set; }

        public IEnumerable<ContactScheduleViewModel> GetContacts(int memberCoverageID)
        {
            return (from contacts in ContextPerRequest.CurrentData.ContactSchedules
                    where contacts.MemberCoverageID == memberCoverageID
                    orderby contacts.ContactLastName
                    select new ContactScheduleViewModel
                    {
                        ContactEmail = contacts.ContactEmail,
                        ContactFirstName = contacts.ContactFirstName,
                        ContactLastName = contacts.ContactLastName,
                        ContactPhone = contacts.ContactPhone,
                        ContactPhoneExt = contacts.ContactPhoneExt,
                        ContactTitle = contacts.ContactTitle,
                        ContactScheduleID = contacts.ContactScheduleID,
                        MemberCoverageID = contacts.MemberCoverageID
                    });
        }

        public ContactScheduleViewModel GetAContact(int contactScheduleId)
        {
            return (from contacts in ContextPerRequest.CurrentData.ContactSchedules
                    where contacts.ContactScheduleID == contactScheduleId
                    select new ContactScheduleViewModel
                    {
                        ContactEmail = contacts.ContactEmail,
                        ContactFirstName = contacts.ContactFirstName,
                        ContactLastName = contacts.ContactLastName,
                        ContactPhone = contacts.ContactPhone,
                        ContactPhoneExt = contacts.ContactPhoneExt,
                        ContactTitle = contacts.ContactTitle,
                        ContactScheduleID = contacts.ContactScheduleID,
                        MemberCoverageID = contacts.MemberCoverageID
                    }).FirstOrDefault();
        }
        public void ContactScheduleDelete(int contactScheduleId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from contact in ContextPerRequest.CurrentData.ContactSchedules
                         where contact.ContactScheduleID == contactScheduleId
                         select contact).FirstOrDefault();

            if (query != null)
            {
                ContextPerRequest.CurrentData.ContactSchedules.Remove(query);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void ContactScheduleAdd(ContactScheduleViewModel model)
        {

            ContactSchedule contact = new ContactSchedule
            {
                ContactEmail = model.ContactEmail,
                ContactFirstName = model.ContactFirstName,
                ContactLastName = model.ContactLastName,
                ContactPhone = model.ContactPhone,
                ContactPhoneExt = model.ContactPhoneExt,
                ContactTitle = model.ContactTitle,
                MemberCoverageID = model.MemberCoverageID
            };

            ContextPerRequest.CurrentData.ContactSchedules.Add(contact);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void ContactScheduleEdit(ContactScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from contact in ContextPerRequest.CurrentData.ContactSchedules
                         where contact.ContactScheduleID == model.ContactScheduleID
                         select contact).FirstOrDefault<ContactSchedule>();

            if (query != null)
            {
                query.ContactEmail = model.ContactEmail;
                query.ContactFirstName = model.ContactFirstName;
                query.ContactLastName = model.ContactLastName;
                query.ContactPhone = model.ContactPhone;
                query.ContactPhoneExt = model.ContactPhoneExt;
                query.ContactTitle = model.ContactTitle;
                query.MemberCoverageID = model.MemberCoverageID;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

    }
}
