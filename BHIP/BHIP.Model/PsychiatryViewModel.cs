using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PsychiatryDeleteViewModel
    {
        public int PsychiatryScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Display(Name = "Date Removed:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateRemoved { get; set; }

        public PsychiatryDeleteViewModel GetAPsychiatrySchedule(int psychiatryScheduleId)
        {
            var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatrySchedules
                         where psychiatry.PsychiatryScheduleID == psychiatryScheduleId
                         select new PsychiatryDeleteViewModel
                         {
                             DateRemoved = psychiatry.DateRemoved,
                             MemberCoverageID = psychiatry.MemberCoverageID,
                             PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                         }).FirstOrDefault();

            return query;
        }

    }
    public class PsychiatryViewModel
    {
        public int PsychiatryScheduleID { get; set; }
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


        public IEnumerable<PsychiatryViewModel> GetAllPsychiatrySchedule(int memberCoverageId)
        {
            var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatrySchedules
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on psychiatry.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on psychiatry.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on psychiatry.OwnMalpracticeID equals malpractice.MalpracticeID
                         join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on psychiatry.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on psychiatry.ContractorEmployeeID equals employment.EmploymentTypeID
                         where psychiatry.MemberCoverageID == memberCoverageId
                         && psychiatry.DateRemoved == null
                         orderby specialty.Description, psychiatry.LastName
                         select new PsychiatryViewModel
                         {
                             BoardCertifiedDescription = certified.Description,
                             BoardEligibleDescription = eligible.Description,
                             EmploymentName = employment.Description,
                             DateAdded = psychiatry.DateAdded,
                             DateRemoved = psychiatry.DateRemoved,
                             FirstName = psychiatry.FirstName,
                             HoursWorked = psychiatry.HoursWorked,
                             LastName = psychiatry.LastName,
                             MemberCoverageID = psychiatry.MemberCoverageID,
                             OwnMalpracticeDescription = malpractice.Description,
                             PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                             RetroDate = psychiatry.RetroDate,
                             SpecialtyName = specialty.Description,
                             SpecialtyOther = psychiatry.SpecialtyOther
                         });

            return query;
        }

        public PsychiatryViewModel GetAPsychiatrySchedule(int psychiatryScheduleId)
        {
            var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatrySchedules
                         where psychiatry.PsychiatryScheduleID == psychiatryScheduleId
                         select new PsychiatryViewModel
                         {
                             DateAdded = psychiatry.DateAdded,
                             DateRemoved = psychiatry.DateRemoved,
                             FirstName = psychiatry.FirstName,
                             HoursWorked = psychiatry.HoursWorked,
                             LastName = psychiatry.LastName,
                             MemberCoverageID = psychiatry.MemberCoverageID,
                             PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                             RetroDate = psychiatry.RetroDate,
                             BoardCertifiedID = psychiatry.BoardCertifiedID ?? 0,
                             BoardEligibleID = psychiatry.BoardEligibleID ?? 0,
                             ContractorEmployeeID = psychiatry.ContractorEmployeeID ?? 0,
                             OwnMalpracticeID = psychiatry.OwnMalpracticeID ?? 0,
                             SpecialtyID = psychiatry.SpecialtyID ?? 0,
                             SpecialtyOther = psychiatry.SpecialtyOther
                         }).FirstOrDefault();

            return query;
        }
    }
}
