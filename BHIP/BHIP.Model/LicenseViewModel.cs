using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class LicenseViewModel
    {
        public int LicenseID { get; set; }
        [Display(Name = "License:")]
        [Required(ErrorMessage = "Enter the license.")]
        public string License { get; set; }
        [Display(Name = "State Agency:")]
        [Required(ErrorMessage = "Enter the state agency.")]
        public string StateAgency { get; set; }
        [Display(Name = "License Type:")]
        [Required(ErrorMessage = "Enter the license type.")]
        public string LicenseType { get; set; }
        [Display(Name = "Expiration Date:")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Enter the expiration date.")]
        public DateTime? ExpirationDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int MemberID { get; set; }
        public bool IsActive { get; set; }


        public IEnumerable<LicenseViewModel> GetLicense(int memberId)
        {
            return (from licenseSchedule in ContextPerRequest.CurrentData.LicenseSchedules
                    where licenseSchedule.MemberID == memberId
                    select new LicenseViewModel
                    {
                        DateAdded = licenseSchedule.DateAdded,
                        DateDeleted = licenseSchedule.DateDeleted,
                        ExpirationDate = licenseSchedule.ExpirationDate,
                        License = licenseSchedule.License,
                        LicenseID = licenseSchedule.LicenseID,
                        LicenseType = licenseSchedule.LicenseType,
                        MemberID = licenseSchedule.MemberID,
                        StateAgency = licenseSchedule.StateAgency,
                        IsActive = licenseSchedule.IsActive
                    });
        }

        public LicenseViewModel GetALicense(int licenseId)
        {
            return (from licenseSchedule in ContextPerRequest.CurrentData.LicenseSchedules
                    where licenseSchedule.LicenseID == licenseId
                    select new LicenseViewModel
                        {
                            DateAdded = licenseSchedule.DateAdded,
                            DateDeleted = licenseSchedule.DateDeleted,
                            ExpirationDate = licenseSchedule.ExpirationDate,
                            License = licenseSchedule.License,
                            LicenseID = licenseSchedule.LicenseID,
                            LicenseType = licenseSchedule.LicenseType,
                            MemberID = licenseSchedule.MemberID,
                            StateAgency = licenseSchedule.StateAgency,
                            IsActive = licenseSchedule.IsActive
                        }).FirstOrDefault();
        }

        public void EditLicense(LicenseViewModel model)
        {
            var data = (from license in ContextPerRequest.CurrentData.LicenseSchedules
                        where license.LicenseID == model.LicenseID
                        select license).FirstOrDefault();

            data.License = model.License;
            data.LicenseType = model.LicenseType;
            data.ExpirationDate = model.ExpirationDate;
            data.StateAgency = model.StateAgency;
            //data.IsActive = model.IsActive;
            ContextPerRequest.CurrentData.SaveChanges();

        }

        public void AddLicense(LicenseViewModel model)
        {
            LicenseSchedule license = new LicenseSchedule
            {
                DateAdded = DateTime.Now,
                ExpirationDate = model.ExpirationDate,
                IsActive = true,
                License = model.License,
                LicenseType = model.LicenseType,
                MemberID = model.MemberID,
                StateAgency = model.StateAgency
            };
            ContextPerRequest.CurrentData.LicenseSchedules.Add(license);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void DeleteLicense(int licenseId)
        {
            var data = (from license in ContextPerRequest.CurrentData.LicenseSchedules
                        where license.LicenseID == licenseId
                        select license).FirstOrDefault();

            ContextPerRequest.CurrentData.LicenseSchedules.Remove(data);
            ContextPerRequest.CurrentData.SaveChanges();
        }
    }

    public class InspectionBodyViewModel
    {
        public int? InspectBodyID { get; set; }
        public int? RenewalID { get; set; }
        public string InspectName { get; set; }
        public string InspectType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}