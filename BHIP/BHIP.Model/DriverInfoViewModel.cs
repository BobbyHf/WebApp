using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class DriverInfoDeleteViewModel
    {
        public int DriverInfoScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Display(Name = "Date Removed:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateRemoved { get; set; }

        public DriverInfoDeleteViewModel GetADriverInfo(int driverScheduleID)
        {
            var query = (from driverInfo in ContextPerRequest.CurrentData.DriverInfoSchedules
                         where driverInfo.DriverInfoScheduleID == driverScheduleID
                         select new DriverInfoDeleteViewModel
                         {
                             DateRemoved = driverInfo.DateRemoved,
                             DriverInfoScheduleID = driverInfo.DriverInfoScheduleID,
                             MemberCoverageID = driverInfo.MemberCoverageID,
                         }).FirstOrDefault();
            return query;
        }

    }
    public class DriverInfoViewModel
    {
        public int DriverInfoScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the first name")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter the date of birth")]
        [Display(Name = "Date of Birth:")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Select the state")]
        [Display(Name = "State:")]
        public string StateName { get; set; }
        [Display(Name = "State:")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Enter the license number")]
        [Display(Name = "License Number:")]
        public string LicenseNumber { get; set; }
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Removed:")]
        public DateTime? DateRemoved { get; set; }
        [Display(Name = "Comment:")]
        public string Comments { get; set; }

        public IEnumerable<DriverInfoViewModel> GetAllDriverInfo(int memberCoverageID)
        {
            var query = (from driverInfo in ContextPerRequest.CurrentData.DriverInfoSchedules
                         join states in ContextPerRequest.CurrentData.States on driverInfo.StateID equals states.StateId
                         where driverInfo.MemberCoverageID == memberCoverageID
                         && driverInfo.DateRemoved == null
                         orderby driverInfo.LastName
                         select new DriverInfoViewModel
                         {
                             Comments = driverInfo.Comments,
                             DateAdded = driverInfo.DateAdded,
                             DateRemoved = driverInfo.DateRemoved,
                             DOB = driverInfo.DOB,
                             DriverInfoScheduleID = driverInfo.DriverInfoScheduleID,
                             FirstName = driverInfo.FirstName,
                             LastName = driverInfo.LastName,
                             LicenseNumber = driverInfo.LicenseNumber,
                             MemberCoverageID = driverInfo.MemberCoverageID,
                             StateName = states.Name
                         });
            return query;
        }

        public DriverInfoViewModel GetADriverInfo(int driverScheduleID)
        {
            var query = (from driverInfo in ContextPerRequest.CurrentData.DriverInfoSchedules
                         join states in ContextPerRequest.CurrentData.States on driverInfo.StateID equals states.StateId
                         where driverInfo.DriverInfoScheduleID == driverScheduleID
                         select new DriverInfoViewModel
                         {
                             Comments = driverInfo.Comments,
                             DateAdded = driverInfo.DateAdded,
                             DateRemoved = driverInfo.DateRemoved,
                             DOB = driverInfo.DOB,
                             DriverInfoScheduleID = driverInfo.DriverInfoScheduleID,
                             FirstName = driverInfo.FirstName,
                             LastName = driverInfo.LastName,
                             LicenseNumber = driverInfo.LicenseNumber,
                             MemberCoverageID = driverInfo.MemberCoverageID,
                             StateName = states.Name,
                             StateID = states.StateId
                         }).FirstOrDefault();
            return query;
        }

        public int TotalDrivers(int memberCoverageId)
        {
            var totalDrivers = ContextPerRequest.CurrentData.DriverInfoSchedules.Where(model => model.MemberCoverageID == memberCoverageId && model.DateRemoved == null).Count();

            return (int)totalDrivers;
        }


    }
}
