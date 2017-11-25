using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class OtherScheduleViewModel
    {
        public int OtherScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the first name")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Specialty:")]
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        [Required(ErrorMessage = "Enter the retro date")]
        [Display(Name = "Retro Date:")]
        public DateTime? RetroDate { get; set; }
        [Display(Name = "Board Ceritifed:")]
        public int BoardCertifiedID { get; set; }
        public string BoardCertifiedDescription { get; set; }
        [Display(Name = "Board Eligible:")]
        public int BoardEligibleID { get; set; }
        public string BoardEligibleDescription { get; set; }
        [Display(Name = "Hours Worked/Week:")]
        public int? HoursWorked { get; set; }
        [Display(Name = "Contractor or Employee:")]
        public int ContractorEmployeeID { get; set; }
        public string EmploymentName { get; set; }
        [Display(Name = "Own Malpractice:")]
        public int OwnMalpracticeID { get; set; }
        public string OwnMalpracticeDescription { get; set; }
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Removed:")]
        public DateTime? DateRemoved { get; set; }
        [Display(Name = "Request a Certificate of Insurance")]
        public bool COI { get; set; }
        [Display(Name = "Other Specialty:")]
        public string SpecialtyOther { get; set; }


        public IEnumerable<OtherScheduleViewModel> GetAllOtherSchedule(int memberCoverageId)
        {
            var query = (from other in ContextPerRequest.CurrentData.OtherSchedules
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on other.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on other.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on other.OwnMalpracticeID equals malpractice.MalpracticeID
                         //join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on other.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on other.ContractorEmployeeID equals employment.EmploymentTypeID
                         where other.MemberCoverageID == memberCoverageId
                         //&& other.DateRemoved == null
                         //orderby specialty.Description, other.LastName
                         orderby other.LastName
                         select new OtherScheduleViewModel
                         {
                             BoardCertifiedDescription = certified.Description,
                             BoardEligibleDescription = eligible.Description,
                             EmploymentName = employment.Description,
                             DateAdded = other.DateAdded,
                             DateRemoved = other.DateRemoved,
                             FirstName = other.FirstName,
                             HoursWorked = other.HoursWorked,
                             LastName = other.LastName,
                             MemberCoverageID = other.MemberCoverageID,
                             OwnMalpracticeDescription = malpractice.Description,
                             OtherScheduleID = other.OtherScheduleID,
                             RetroDate = other.RetroDate,
                             //SpecialtyName = specialty.Description,
                             SpecialtyOther = other.SpecialtyOther
                         });

            return query;
        }

        public OtherScheduleViewModel GetAOtherSchedule(int otherScheduleId)
        {
            var query = (from other in ContextPerRequest.CurrentData.OtherSchedules
                         where other.OtherScheduleID == otherScheduleId
                         select new OtherScheduleViewModel
                         {
                             DateAdded = other.DateAdded,
                             DateRemoved = other.DateRemoved,
                             FirstName = other.FirstName,
                             HoursWorked = other.HoursWorked,
                             LastName = other.LastName,
                             MemberCoverageID = other.MemberCoverageID,
                             OtherScheduleID = other.OtherScheduleID,
                             RetroDate = other.RetroDate,
                             BoardCertifiedID = other.BoardCertifiedID ?? 0,
                             BoardEligibleID = other.BoardEligibleID ?? 0,
                             ContractorEmployeeID = other.ContractorEmployeeID ?? 0,
                             OwnMalpracticeID = other.OwnMalpracticeID ?? 0,
                             SpecialtyID = other.SpecialtyID ?? 0,
                             SpecialtyOther = other.SpecialtyOther
                         }).FirstOrDefault();

            return query;
        }
    }

    public class OtherScheduleDeleteViewModel
    {
        public int OtherScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Display(Name = "Date Removed:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateRemoved { get; set; }

        public OtherScheduleDeleteViewModel GetAOtherSchedule(int otherScheduleId)
        {
            var query = (from other in ContextPerRequest.CurrentData.OtherSchedules
                         where other.OtherScheduleID == otherScheduleId
                         select new OtherScheduleDeleteViewModel
                         {
                             DateRemoved = other.DateRemoved,
                             MemberCoverageID = other.MemberCoverageID,
                             OtherScheduleID = other.OtherScheduleID,
                         }).FirstOrDefault();

            return query;
        }

    }
}