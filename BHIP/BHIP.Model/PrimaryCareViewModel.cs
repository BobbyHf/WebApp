using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PrimaryCareDeleteViewModel
    {
        public int PrimaryCareScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Display(Name = "Date Removed:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateRemoved { get; set; }

        public PrimaryCareDeleteViewModel GetAPrimaryCareSchedule(int primaryCareSheduleId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                         where primary.PrimaryCareScheduleID == primaryCareSheduleId
                         select new PrimaryCareDeleteViewModel
                         {
                             DateRemoved = primary.DateRemoved,
                             MemberCoverageID = primary.MemberCoverageID,
                             PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                         }).FirstOrDefault();


            return query;
        }

    }
    public class PrimaryCareViewModel
    {
        public int PrimaryCareScheduleID { get; set; }
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
        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }

        public IEnumerable<PrimaryCareViewModel> GetAllPrimaryCareSchedule(int memberCoverageId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on primary.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on primary.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on primary.OwnMalPracticeID equals malpractice.MalpracticeID
                         join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on primary.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on primary.ContractorEmployeeID equals employment.EmploymentTypeID
                         where primary.MemberCoverageID == memberCoverageId
                         && primary.DateRemoved == null
                         orderby specialty.Description, primary.LastName
                         select new PrimaryCareViewModel
                         {
                             BoardCertifiedDescription = certified.Description,
                             BoardEligibleDescription = eligible.Description,
                             EmploymentName = employment.Description,
                             DateAdded = primary.DateAdded,
                             DateRemoved = primary.DateRemoved,
                             FirstName = primary.FirstName,
                             HoursWorked = primary.HoursWorked,
                             LastName = primary.LastName,
                             MemberCoverageID = primary.MemberCoverageID,
                             OwnMalpracticeDescription = malpractice.Description,
                             PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                             RetroDate = primary.RetroDate,
                             SpecialtyName = specialty.Description
                         });


            return query;
        }

        public PrimaryCareViewModel GetAPrimaryCareSchedule(int primaryCareSheduleId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                         where primary.PrimaryCareScheduleID == primaryCareSheduleId
                         select new PrimaryCareViewModel
                         {
                             DateAdded = primary.DateAdded,
                             DateRemoved = primary.DateRemoved,
                             FirstName = primary.FirstName,
                             HoursWorked = primary.HoursWorked,
                             LastName = primary.LastName,
                             MemberCoverageID = primary.MemberCoverageID,
                             PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                             RetroDate = primary.RetroDate,
                             BoardCertifiedID = primary.BoardCertifiedID ?? 0,
                             BoardEligibleID = primary.BoardEligibleID ?? 0,
                             ContractorEmployeeID = primary.ContractorEmployeeID ?? 0,
                             OwnMalpracticeID = primary.OwnMalPracticeID ?? 0,
                             SpecialtyID = primary.SpecialtyID ?? 0
                         }).FirstOrDefault();


            return query;
        }
    }
}
