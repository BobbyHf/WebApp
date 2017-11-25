using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class ContactScheduleHoldViewModel
    {
        public int ContactScheduleHoldID { get; set; }
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
        public string EditType { get; set; }
        public int MemberID { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public IEnumerable<ContactScheduleHoldViewModel> GetAllContactScheduleHolds(int memberCoverageId)
        {
            return (from contacts in ContextPerRequest.CurrentData.ContactScheduleHolds
                    where contacts.MemberCoverageID == memberCoverageId && contacts.ScheduleStatusID != 4
                    orderby contacts.ContactLastName
                    select new ContactScheduleHoldViewModel
                    {
                        ContactEmail = contacts.ContactEmail,
                        ContactFirstName = contacts.ContactFirstName,
                        ContactLastName = contacts.ContactLastName,
                        ContactPhone = contacts.ContactPhone,
                        ContactPhoneExt = contacts.ContactPhoneExt,
                        ContactTitle = contacts.ContactTitle,
                        ContactScheduleID = contacts.ContactScheduleID,
                        ContactScheduleHoldID = contacts.ContactScheduleHoldID,
                        EditType = contacts.EditType,
                        MemberCoverageID = contacts.MemberCoverageID
                    });
        }

        public ContactScheduleHoldViewModel GetAContactScheduleHold(int scheduleHoldId)
        {
            var query = (from contact in ContextPerRequest.CurrentData.ContactScheduleHolds
                         where contact.ContactScheduleHoldID == scheduleHoldId
                         select new ContactScheduleHoldViewModel
                         {
                             ContactEmail = contact.ContactEmail,
                             ContactFirstName = contact.ContactFirstName,
                             ContactLastName = contact.ContactLastName,
                             ContactPhone = contact.ContactPhone,
                             ContactPhoneExt = contact.ContactPhoneExt,
                             ContactTitle = contact.ContactTitle,
                             ContactScheduleID = contact.ContactScheduleID,
                             ContactScheduleHoldID = contact.ContactScheduleHoldID,
                             EditType = contact.EditType,
                             MemberCoverageID = contact.MemberCoverageID
                         }).FirstOrDefault();

            return query;
        }



        public ContactScheduleHoldViewModel ContactScheduleHoldEdit(int contactScheduleHoldId)
        {
            return (from contacts in ContextPerRequest.CurrentData.ContactScheduleHolds
                    where contacts.MemberCoverageID == contactScheduleHoldId
                    select new ContactScheduleHoldViewModel
                    {
                        ContactEmail = contacts.ContactEmail,
                        ContactFirstName = contacts.ContactFirstName,
                        ContactLastName = contacts.ContactLastName,
                        ContactPhone = contacts.ContactPhone,
                        ContactPhoneExt = contacts.ContactPhoneExt,
                        ContactTitle = contacts.ContactTitle,
                        ContactScheduleID = contacts.ContactScheduleID,
                        ContactScheduleHoldID = contacts.ContactScheduleHoldID,
                        MemberCoverageID = contacts.MemberCoverageID
                    }).FirstOrDefault();

        }

        public void ContactScheduleHoldSave(ContactScheduleHoldViewModel model)
        {
            var query = (from contact in ContextPerRequest.CurrentData.ContactScheduleHolds
                         where contact.ContactScheduleHoldID == model.ContactScheduleHoldID
                         select contact).FirstOrDefault();

            query.ContactEmail = model.ContactEmail;
            query.ContactFirstName = model.ContactFirstName;
            query.ContactLastName = model.ContactLastName;
            query.ContactPhone = model.ContactPhone;
            query.ContactPhoneExt = model.ContactPhoneExt;
            query.ContactTitle = model.ContactTitle;

            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void ContactScheduleHoldDelete(int contactScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from contact in ContextPerRequest.CurrentData.ContactScheduleHolds
                         where contact.ContactScheduleHoldID == contactScheduleHoldId
                         select contact).FirstOrDefault();

            if (query != null)
            {
                query.ScheduleStatusID = 4;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void ContactScheduleDelete(int contactScheduleId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from contact in ContextPerRequest.CurrentData.ContactSchedules
                         where contact.ContactScheduleID == contactScheduleId
                         select contact).FirstOrDefault();

            if (query != null)
            {
                ContactScheduleHoldViewModel hold = new ContactScheduleHoldViewModel
                {
                    ContactEmail = query.ContactEmail,
                    ContactFirstName = query.ContactFirstName,
                    ContactLastName = query.ContactLastName,
                    ContactPhone = query.ContactPhone,
                    ContactPhoneExt = query.ContactPhoneExt,
                    ContactTitle = query.ContactTitle,
                    MemberCoverageID = query.MemberCoverageID,
                    ContactScheduleID = query.ContactScheduleID,
                    EditType = "Delete",
                    ScheduleStatusID = 2,
                    MemberID = BHIP.Model.Helper.MemberInformation.GetMemberID(query.MemberCoverageID),
                    UserID = UserId
                };
                ContextPerRequest.CurrentData.ContactSchedules.Remove(query);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void ContactScheduleAdd(ContactScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            ContactScheduleHold contact = new ContactScheduleHold
            {
                ContactEmail = model.ContactEmail,
                ContactFirstName = model.ContactFirstName,
                ContactLastName = model.ContactLastName,
                ContactPhone = model.ContactPhone,
                ContactPhoneExt = model.ContactPhoneExt,
                ContactTitle = model.ContactTitle,
                MemberCoverageID = model.MemberCoverageID,
                ContactScheduleID = model.ContactScheduleID,
                EditType = "Add",
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.ContactScheduleHolds.Add(contact);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void ContactScheduleEdit(ContactScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            ContactScheduleHold hold = new ContactScheduleHold
            {
                ContactEmail = model.ContactEmail,
                ContactFirstName = model.ContactFirstName,
                ContactLastName = model.ContactLastName,
                ContactPhone = model.ContactPhone,
                ContactPhoneExt = model.ContactPhoneExt,
                ContactTitle = model.ContactTitle,
                ContactScheduleID = model.ContactScheduleID,
                EditType = "Edit",
                MemberCoverageID = model.MemberCoverageID,
                ScheduleStatusID = 2,
                UserID = UserId
            };
            ContextPerRequest.CurrentData.ContactScheduleHolds.Add(hold);
            ContextPerRequest.CurrentData.SaveChanges();
        }

    }
}
