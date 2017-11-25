using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PropertyDeleteViewModel
    {
        public int PropertyScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Display(Name = "Date Removed:")]
        [Required(ErrorMessage = "Enter the date deleted")]
        public DateTime? DateRemoved { get; set; }

        public PropertyDeleteViewModel GetAPropertyDelete(int propertyScheduleId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertySchedules
                         where property.PropertyScheduleID == propertyScheduleId
                         select new PropertyDeleteViewModel
                         {
                             DateRemoved = property.DateRemoved,
                             MemberCoverageID = property.MemberCoverageID,
                             PropertyScheduleID = property.PropertyScheduleID,
                         }).FirstOrDefault();

            return query;
        }

    }
    public class PropertyViewModel
    {
        public int PropertyScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the location number")]
        [Display(Name = "Location Number:")]
        public string LocationNumber { get; set; }
        [Required(ErrorMessage = "Enter the location name")]
        [Display(Name = "Location Name:")]
        public string LocationName { get; set; }
        [Required(ErrorMessage = "Enter the address")]
        [Display(Name = "Location Address:")]
        public string LocationAddress { get; set; }
        [Required(ErrorMessage = "Enter the city")]
        [Display(Name = "City:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Select the state")]
        [Display(Name = "State:")]
        public int StateID { get; set; }
        public string StateName { get; set; }
        [Required(ErrorMessage = "Enter the zip code")]
        [Display(Name = "Zip Code:")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Select the Type of Construction")]
        [Display(Name = "Type of Construction:")]
        public int ConstructionTypeID { get; set; }
        public string ConstructionName { get; set; }

        [Required(ErrorMessage = "Enter the building value")]
        [Display(Name = "Building Value:")]
        public int? BuildingValue { get; set; }
        [Required(ErrorMessage = "Enter the content value")]
        [Display(Name = "Contents Value:")]
        public int? ContentValue { get; set; }
        [Required(ErrorMessage = "Enter the square feet")]
        [Display(Name = "Square Foot:")]
        public int? SquareFoot { get; set; }
        [Required(ErrorMessage = "Enter the BI & EE")]
        [Display(Name = "BI & EE:")]
        public int? BI_EE { get; set; }
        [Required(ErrorMessage = "Enter if the property is owned or leased")]
        [Display(Name = "Own Or Lease:")]
        public int OwnLeaseID { get; set; }
        public string OwnLeaseName { get; set; }

        [Required(ErrorMessage = "Enter the fire burgler system")]
        [Display(Name = "Fire Burgler System:")]
        public int FireBurglerID { get; set; }
        public string FireName { get; set; }

        //[Required(ErrorMessage = "Enter the date of construction")]
        [Display(Name = "Date of Construction:")]
        public DateTime? ConstructionDate { get; set; }
        [Display(Name = "Date of Last Remodel:")]
        public DateTime? RemodelDate { get; set; }
        [Required(ErrorMessage = "Enter the date added")]
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Removed:")]
        public DateTime? DateRemoved { get; set; }
        [Display(Name = "Request a Certificate of Insurance")]
        public bool COI { get; set; }

        public IEnumerable<PropertyViewModel> GetAllPropertySchedule(int memberCoverageId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertySchedules
                         join construct in ContextPerRequest.CurrentData.ConstructionTypes on property.ConstructionTypeID equals construct.ConstTypeID
                         join fire in ContextPerRequest.CurrentData.FireBurglars on property.FireBurglerID equals fire.FireBurglarID
                         join own in ContextPerRequest.CurrentData.OwnLeases on property.OwnLeaseID equals own.OwnLeaseID
                         join state in ContextPerRequest.CurrentData.States on property.StateID equals state.StateId
                         where property.MemberCoverageID == memberCoverageId
                         && property.DateRemoved == null
                         orderby property.LocationName
                         select new PropertyViewModel
                         {
                             BI_EE = property.BI_EE,
                             BuildingValue = property.BuildingValue,
                             City = property.City,
                             ConstructionDate = property.ConstructionDate,
                             ConstructionName = construct.Description,
                             ContentValue = property.ContentValue,
                             DateAdded = property.DateAdded,
                             DateRemoved = property.DateRemoved,
                             FireName = fire.Description,
                             LocationAddress = property.LocationAddress,
                             LocationName = property.LocationName,
                             LocationNumber = property.LocationNumber,
                             MemberCoverageID = property.MemberCoverageID,
                             OwnLeaseName = own.Description,
                             PropertyScheduleID = property.PropertyScheduleID,
                             RemodelDate = property.RemodelDate,
                             SquareFoot = property.SquareFoot,
                             StateName = state.Name,
                             Zip = property.Zip
                         });

            return query;
        }

        public PropertyViewModel GetAPropertySchedule(int propertyScheduleId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertySchedules
                         where property.PropertyScheduleID == propertyScheduleId
                         select new PropertyViewModel
                         {
                             BI_EE = property.BI_EE,
                             BuildingValue = property.BuildingValue,
                             City = property.City,
                             ConstructionDate = property.ConstructionDate,
                             ConstructionTypeID = property.ConstructionTypeID ?? 0,
                             ContentValue = property.ContentValue,
                             DateAdded = property.DateAdded,
                             DateRemoved = property.DateRemoved,
                             FireBurglerID = property.FireBurglerID ?? 0,
                             OwnLeaseID = property.OwnLeaseID ?? 0,
                             StateID = property.StateID ?? 0,
                             LocationAddress = property.LocationAddress,
                             LocationName = property.LocationName,
                             LocationNumber = property.LocationNumber,
                             MemberCoverageID = property.MemberCoverageID,
                             PropertyScheduleID = property.PropertyScheduleID,
                             RemodelDate = property.RemodelDate,
                             SquareFoot = property.SquareFoot,
                             Zip = property.Zip
                         }).FirstOrDefault();

            return query;
        }

        public int TotalBuildingValue(int memberCoverageId)
        {
            var totalBuilding = ContextPerRequest.CurrentData.PropertySchedules.Where(model => model.MemberCoverageID == memberCoverageId).Sum(model => model.BuildingValue);
            if (totalBuilding != null)
            {
                return (int)totalBuilding;
            }
            else
            {
                return 0;
            }
        }

        public int TotalContentValue(int memberCoverageId)
        {
            var totalContent = ContextPerRequest.CurrentData.PropertySchedules.Where(model => model.MemberCoverageID == memberCoverageId).Sum(model => model.ContentValue);

            if (totalContent != null)
            {
                return (int)totalContent;
            }
            else
            {
                return 0;
            }
        }

        public int TotalSquareFeet(int memberCoverageId)
        {
            var totalSquareFeet = ContextPerRequest.CurrentData.PropertySchedules.Where(model => model.MemberCoverageID == memberCoverageId).Sum(model => model.SquareFoot);

            if (totalSquareFeet != null)
            {
                return (int)totalSquareFeet;
            }
            else
            {
                return 0;
            }
        }


    }
}
