using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class VehicleDeleteViewModel
    {
        public int VehicleScheduleID { get; set; }
        public int MemberCoverageID { get; set; }

        [Display(Name = "Date Deleted:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateDeleted { get; set; }

        public VehicleDeleteViewModel GetAVehicle(int vehicleScheduleId)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleSchedules
                         where vehicle.VehicleScheduleID == vehicleScheduleId
                         select new VehicleDeleteViewModel
                         {
                             DateDeleted = vehicle.DateDeleted,
                             MemberCoverageID = vehicle.MemberCoverageID,
                             VehicleScheduleID = vehicle.VehicleScheduleID,
                         }).FirstOrDefault();
            return query;
        }

    }
    public class VehicleScheduleViewModel
    {
        public int VehicleScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the automobile year")]
        [Display(Name = "Automobile Year:")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Enter the vehcile Make/Model")]
        [Display(Name = "Make/Model:")]
        public string MakeModel { get; set; }
        [Display(Name = "City:")]
        public string City { get; set; }
        [Display(Name = "State:")]
        public int StateID { get; set; }
        public string StateName { get; set; }
        [Display(Name = "Zip:")]
        public string Zipcode { get; set; }
        [Display(Name = "VIN:")]
        public string VIN { get; set; }
        [Display(Name = "Own or Lease:")]
        public int OwnLeaseID { get; set; }
        public string OwnLeaseDescription { get; set; }
        [Required(ErrorMessage = "Enter the date added")]
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Deleted:")]
        public DateTime? DateDeleted { get; set; }
        [Display(Name = "Notes:")]
        public string Notes { get; set; }
        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }
        public int MemberID { get; set; }
        public string SortOrderYear { get; set; }
        public string SortOrderMakeModel { get; set; }
        public string SortOrderVINOwnLease { get; set; }

        public IEnumerable<VehicleScheduleViewModel> GetVehicles(int memberCoverageId)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleSchedules
                         join state in ContextPerRequest.CurrentData.States on vehicle.StateID equals state.StateId
                         join own in ContextPerRequest.CurrentData.OwnLeases on vehicle.OwnLeaseID equals own.OwnLeaseID
                         where vehicle.MemberCoverageID == memberCoverageId
                         && vehicle.DateDeleted == null
                         orderby vehicle.Year, vehicle.MakeModel
                         select new VehicleScheduleViewModel
                         {
                             City = vehicle.City,
                             DateAdded = vehicle.DateAdded,
                             DateDeleted = vehicle.DateDeleted,
                             MakeModel = vehicle.MakeModel,
                             MemberCoverageID = vehicle.MemberCoverageID,
                             Notes = vehicle.Notes,
                             OwnLeaseDescription = own.Description,
                             StateName = state.Name,
                             VehicleScheduleID = vehicle.VehicleScheduleID,
                             VIN = vehicle.VIN,
                             Year = vehicle.Year ?? 0,
                             Zipcode = vehicle.Zipcode
                         });
            return query;
        }

        public VehicleScheduleViewModel GetAVehicle(int vehicleScheduleId)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleSchedules
                         join state in ContextPerRequest.CurrentData.States on vehicle.StateID equals state.StateId
                         join own in ContextPerRequest.CurrentData.OwnLeases on vehicle.OwnLeaseID equals own.OwnLeaseID
                         where vehicle.VehicleScheduleID == vehicleScheduleId
                         select new VehicleScheduleViewModel
                         {
                             City = vehicle.City,
                             DateAdded = vehicle.DateAdded,
                             DateDeleted = vehicle.DateDeleted,
                             MakeModel = vehicle.MakeModel,
                             MemberCoverageID = vehicle.MemberCoverageID,
                             Notes = vehicle.Notes,
                             OwnLeaseDescription = own.Description,
                             OwnLeaseID = own.OwnLeaseID,
                             StateName = state.Name,
                             StateID = state.StateId,
                             VehicleScheduleID = vehicle.VehicleScheduleID,
                             VIN = vehicle.VIN,
                             Year = vehicle.Year ?? 0,
                             Zipcode = vehicle.Zipcode
                         }).FirstOrDefault();
            return query;
        }

        public int TotalAutos(int memberCoverageId)
        {
            var totalAutos = ContextPerRequest.CurrentData.VehicleSchedules.Where(model => model.MemberCoverageID == memberCoverageId && model.DateDeleted == null).Count();

            return (int)totalAutos;
        }


    }
}
