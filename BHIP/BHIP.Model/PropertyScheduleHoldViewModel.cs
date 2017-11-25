using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PropertyScheduleHoldViewModel
    {
        public int PropertyScheduleHoldID { get; set; }
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
        [Required(ErrorMessage = "Enter the date of construction")]
        [Display(Name = "Date of Construction:")]
        public DateTime? ConstructionDate { get; set; }
        [Display(Name = "Date of Last Remodel:")]
        public DateTime? RemodelDate { get; set; }
        [Required(ErrorMessage = "Enter the date added")]
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Removed:")]
        public DateTime? DateRemoved { get; set; }
        public string EditType { get; set; }
        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string StatusName { get; set; }

        public IEnumerable<PropertyScheduleHoldViewModel> GetAllPropertyScheduleHold(int memberCoverageId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                         join construct in ContextPerRequest.CurrentData.ConstructionTypes on property.ConstructionTypeID equals construct.ConstTypeID
                         join fire in ContextPerRequest.CurrentData.FireBurglars on property.FireBurglerID equals fire.FireBurglarID
                         join own in ContextPerRequest.CurrentData.OwnLeases on property.OwnLeaseID equals own.OwnLeaseID
                         join state in ContextPerRequest.CurrentData.States on property.StateID equals state.StateId
                         join users in ContextPerRequest.CurrentData.AspNetUsers on property.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on property.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where property.MemberCoverageID == memberCoverageId && property.ScheduleStatusID != 4 && property.ScheduleStatusID != 5
                         orderby property.LocationName
                         select new PropertyScheduleHoldViewModel
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
                             PropertyScheduleHoldID = property.PropertyScheduleHoldID,
                             PropertyScheduleID = property.PropertyScheduleID,
                             RemodelDate = property.RemodelDate,
                             SquareFoot = property.SquareFoot,
                             StateName = state.Name,
                             Zip = property.Zip,
                             EditType = property.EditType,
                             COI = property.COI,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StatusName = status.Description
                         });

            return query;
        }

        public PropertyScheduleHoldViewModel GetAPropertyScheduleHold(int propertyScheduleHoldId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                         where property.PropertyScheduleHoldID == propertyScheduleHoldId
                         select new PropertyScheduleHoldViewModel
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
                             LocationAddress = property.LocationAddress,
                             LocationName = property.LocationName,
                             LocationNumber = property.LocationNumber,
                             MemberCoverageID = property.MemberCoverageID,
                             OwnLeaseID = property.OwnLeaseID ?? 0,
                             PropertyScheduleHoldID = property.PropertyScheduleHoldID,
                             PropertyScheduleID = property.PropertyScheduleID,
                             RemodelDate = property.RemodelDate,
                             SquareFoot = property.SquareFoot,
                             StateID = property.StateID ?? 0,
                             Zip = property.Zip,
                             COI = property.COI
                         }).FirstOrDefault();

            return query;
        }

        public void PropertyScheduleAdd(PropertyViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PropertyScheduleHold property = new PropertyScheduleHold
            {
                BI_EE = model.BI_EE,
                BuildingValue = model.BuildingValue,
                City = model.City,
                ConstructionDate = model.ConstructionDate,
                ConstructionTypeID = model.ConstructionTypeID,
                ContentValue = model.ContentValue,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                EditType = "Add",
                FireBurglerID = model.FireBurglerID,
                LocationAddress = model.LocationAddress,
                LocationName = model.LocationName,
                LocationNumber = model.LocationNumber,
                MemberCoverageID = model.MemberCoverageID,
                OwnLeaseID = model.OwnLeaseID,
                PropertyScheduleID = model.PropertyScheduleID,
                RemodelDate = model.RemodelDate,
                SquareFoot = model.SquareFoot,
                StateID = model.StateID,
                Zip = model.Zip,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.PropertyScheduleHolds.Add(property);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PropertyScheduleEdit(PropertyViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PropertyScheduleHold property = new PropertyScheduleHold
            {
                BI_EE = model.BI_EE,
                BuildingValue = model.BuildingValue,
                City = model.City,
                ConstructionDate = model.ConstructionDate,
                ConstructionTypeID = model.ConstructionTypeID,
                ContentValue = model.ContentValue,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                EditType = "Edit",
                FireBurglerID = model.FireBurglerID,
                LocationAddress = model.LocationAddress,
                LocationName = model.LocationName,
                LocationNumber = model.LocationNumber,
                MemberCoverageID = model.MemberCoverageID,
                OwnLeaseID = model.OwnLeaseID,
                PropertyScheduleID = model.PropertyScheduleID,
                RemodelDate = model.RemodelDate,
                SquareFoot = model.SquareFoot,
                StateID = model.StateID,
                Zip = model.Zip,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.PropertyScheduleHolds.Add(property);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PropertyScheduleDelete(PropertyDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from prop in ContextPerRequest.CurrentData.PropertySchedules
                         where prop.PropertyScheduleID == model.PropertyScheduleID
                         select prop).FirstOrDefault();

            PropertyScheduleHold property = new PropertyScheduleHold
            {
                BI_EE = query.BI_EE,
                BuildingValue = query.BuildingValue,
                City = query.City,
                ConstructionDate = query.ConstructionDate,
                ConstructionTypeID = query.ConstructionTypeID,
                ContentValue = query.ContentValue,
                DateAdded = query.DateAdded,
                DateRemoved = model.DateRemoved,
                EditType = "Delete",
                FireBurglerID = query.FireBurglerID,
                LocationAddress = query.LocationAddress,
                LocationName = query.LocationName,
                LocationNumber = query.LocationNumber,
                MemberCoverageID = query.MemberCoverageID,
                OwnLeaseID = query.OwnLeaseID,
                PropertyScheduleID = query.PropertyScheduleID,
                RemodelDate = query.RemodelDate,
                SquareFoot = query.SquareFoot,
                StateID = query.StateID,
                Zip = query.Zip,
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.PropertyScheduleHolds.Add(property);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public PropertyScheduleHoldViewModel PropertyScheduleHoldEdit(int propertyScheduleHoldId)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                         where property.PropertyScheduleHoldID == propertyScheduleHoldId
                         select new PropertyScheduleHoldViewModel
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
                             LocationAddress = property.LocationAddress,
                             LocationName = property.LocationName,
                             LocationNumber = property.LocationNumber,
                             MemberCoverageID = property.MemberCoverageID,
                             OwnLeaseID = property.OwnLeaseID ?? 0,
                             PropertyScheduleHoldID = property.PropertyScheduleHoldID,
                             PropertyScheduleID = property.PropertyScheduleID,
                             RemodelDate = property.RemodelDate,
                             SquareFoot = property.SquareFoot,
                             StateID = property.StateID ?? 0,
                             Zip = property.Zip,
                             COI = property.COI
                         }).FirstOrDefault();

            return query;
        }

        public void PropertyScheduleHoldSave(PropertyScheduleHoldViewModel model)
        {
            var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                         where property.PropertyScheduleHoldID == model.PropertyScheduleHoldID
                         select property).FirstOrDefault();

            if (query != null)
            {
                query.BI_EE = model.BI_EE;
                query.BuildingValue = model.BuildingValue;
                query.City = model.City;
                query.ConstructionDate = model.ConstructionDate;
                query.ConstructionTypeID = model.ConstructionTypeID;
                query.ContentValue = model.ContentValue;
                query.DateAdded = model.DateAdded;
                query.DateRemoved = model.DateRemoved;
                query.FireBurglerID = model.FireBurglerID;
                query.LocationAddress = model.LocationAddress;
                query.LocationName = model.LocationName;
                query.LocationNumber = model.LocationNumber;
                query.MemberCoverageID = model.MemberCoverageID;
                query.OwnLeaseID = model.OwnLeaseID;
                query.PropertyScheduleID = model.PropertyScheduleID;
                query.RemodelDate = model.RemodelDate;
                query.SquareFoot = model.SquareFoot;
                query.StateID = model.StateID;
                query.Zip = model.Zip;
                query.COI = model.COI;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void PropertyScheduleHoldDelete(int propertyScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                         where property.PropertyScheduleHoldID == propertyScheduleHoldId
                         select property).FirstOrDefault();

            if (query != null)
            {
                query.ScheduleStatusID = 4;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public EmailProperty PropertyPendingApprove(string scheduleIds)
        {
            EmailProperty emailModel = new EmailProperty();
            emailModel.PropertyCOIList = new List<SendingProperty>();
            emailModel.PropertyAddList = new List<SendingProperty>();
            emailModel.PropertyDeleteList = new List<SendingProperty>();
            emailModel.PropertyEditList = new List<SendingProperty>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                             join construct in ContextPerRequest.CurrentData.ConstructionTypes on property.ConstructionTypeID equals construct.ConstTypeID
                             join fire in ContextPerRequest.CurrentData.FireBurglars on property.FireBurglerID equals fire.FireBurglarID
                             join own in ContextPerRequest.CurrentData.OwnLeases on property.OwnLeaseID equals own.OwnLeaseID
                             join state in ContextPerRequest.CurrentData.States on property.StateID equals state.StateId
                             where property.PropertyScheduleHoldID == scheduleHoldID
                             select new PropertyScheduleHoldViewModel
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
                                 PropertyScheduleHoldID = property.PropertyScheduleHoldID,
                                 PropertyScheduleID = property.PropertyScheduleID,
                                 RemodelDate = property.RemodelDate,
                                 SquareFoot = property.SquareFoot,
                                 StateName = state.Name,
                                 Zip = property.Zip,
                                 EditType = property.EditType,
                                 COI = property.COI,
                                 ConstructionTypeID = property.ConstructionTypeID ?? 0,
                                 FireBurglerID = property.FireBurglerID ?? 0,
                                 OwnLeaseID = property.OwnLeaseID ?? 0,
                                 ScheduleStatusID = property.ScheduleStatusID,
                                 StateID = property.StateID ?? 0
                             }).FirstOrDefault();

                var queryUpdate = (from prop in ContextPerRequest.CurrentData.PropertyScheduleHolds
                                   where prop.PropertyScheduleHoldID == scheduleHoldID
                                   select prop).FirstOrDefault<PropertyScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 && query.COI == true) // pending and COI is checked.
                    {
                        SendingProperty coiModel = new SendingProperty();
                        coiModel.Address = query.LocationAddress;
                        coiModel.City = query.City;
                        coiModel.PropertyName = query.LocationName;
                        coiModel.Zip = query.Zip;
                        coiModel.TypeOfConstruction = query.ConstructionName;
                        coiModel.Cost = string.Format("{0:C}", query.SquareFoot == 0 ? 0 : (query.BuildingValue + query.ContentValue) / query.SquareFoot);
                        coiModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                        coiModel.DateContruction = (query.ConstructionDate.HasValue == true ? Convert.ToDateTime(query.ConstructionDate).ToShortDateString() : string.Empty);
                        coiModel.FireBurglar = query.FireName;
                        coiModel.OwnLease = query.OwnLeaseName;
                        coiModel.SquareFootage = query.SquareFoot.ToString();
                        coiModel.State = query.StateName;
                        emailModel.PropertyCOIList.Add(coiModel);

                        queryUpdate.ScheduleStatusID = 3;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }

                    if (statusId == 3)
                    {
                        queryUpdate.ScheduleStatusID = 5;
                        ContextPerRequest.CurrentData.SaveChanges();
                    } else if (statusId == 2) // pending and no COI
                    {
                        if (query.EditType == "Add")
                        {
                            SendingProperty addModel = new SendingProperty();
                            addModel.Address = query.LocationAddress;
                            addModel.City = query.City;
                            addModel.PropertyName = query.LocationName;
                            addModel.Zip = query.Zip;
                            addModel.TypeOfConstruction = query.ConstructionName;
                            addModel.Cost = string.Format("{0:C}", query.SquareFoot == 0 ? 0 : (query.BuildingValue + query.ContentValue) / query.SquareFoot);
                            addModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            addModel.DateContruction = (query.ConstructionDate.HasValue == true ? Convert.ToDateTime(query.ConstructionDate).ToShortDateString() : string.Empty);
                            addModel.FireBurglar = query.FireName;
                            addModel.OwnLease = query.OwnLeaseName;
                            addModel.SquareFootage = query.SquareFoot.ToString();
                            addModel.BuildingValue = string.Format("{0:C}", query.BuildingValue);
                            addModel.ContentValue = string.Format("{0:C}", query.ContentValue);
                            addModel.State = query.StateName;
                            emailModel.PropertyAddList.Add(addModel);
                        }
                        else if (query.EditType == "Edit" && query.COI)
                        {
                            SendingProperty editModel = new SendingProperty();
                            editModel.Address = query.LocationAddress;
                            editModel.City = query.City;
                            editModel.PropertyName = query.LocationName;
                            editModel.Zip = query.Zip;
                            editModel.TypeOfConstruction = query.ConstructionName;
                            editModel.Cost = string.Format("{0:C}", query.SquareFoot == 0 ? 0 : (query.BuildingValue + query.ContentValue) / query.SquareFoot);
                            editModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            editModel.DateContruction = (query.ConstructionDate.HasValue == true ? Convert.ToDateTime(query.ConstructionDate).ToShortDateString() : string.Empty);
                            editModel.FireBurglar = query.FireName;
                            editModel.OwnLease = query.OwnLeaseName;
                            editModel.SquareFootage = query.SquareFoot.ToString();
                            editModel.State = query.StateName;
                            editModel.BuildingValue = string.Format("{0:C}", query.BuildingValue);
                            editModel.ContentValue = string.Format("{0:C}", query.ContentValue);
                            emailModel.PropertyEditList.Add(editModel);
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingProperty deleteModel = new SendingProperty();
                            deleteModel.Address = query.LocationAddress;
                            deleteModel.City = query.City;
                            deleteModel.PropertyName = query.LocationName;
                            deleteModel.Zip = query.Zip;
                            deleteModel.TypeOfConstruction = query.ConstructionName;
                            deleteModel.Cost = string.Format("{0:C}", query.SquareFoot == 0 ? 0 : (query.BuildingValue + query.ContentValue) / query.SquareFoot);
                            deleteModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            deleteModel.DateContruction = (query.ConstructionDate.HasValue == true ? Convert.ToDateTime(query.ConstructionDate).ToShortDateString() : string.Empty);
                            deleteModel.FireBurglar = query.FireName;
                            deleteModel.OwnLease = query.OwnLeaseName;
                            deleteModel.SquareFootage = query.SquareFoot.ToString();
                            deleteModel.State = query.StateName;
                            deleteModel.BuildingValue = string.Format("{0:C}", query.BuildingValue);
                            deleteModel.ContentValue = string.Format("{0:C}", query.ContentValue);
                            deleteModel.DateRemoved = (query.DateRemoved.HasValue == true ? Convert.ToDateTime(query.DateRemoved).ToShortDateString() : string.Empty);
                            emailModel.PropertyDeleteList.Add(deleteModel);
                        }

                        PropertyScheduleHold model = new PropertyScheduleHold
                        {
                            BI_EE = query.BI_EE,
                            BuildingValue = query.BuildingValue,
                            City = query.City,
                            COI = query.COI,
                            ConstructionDate = query.ConstructionDate,
                            ConstructionTypeID = query.ConstructionTypeID,
                            ContentValue = query.ContentValue,
                            DateAdded = query.DateAdded,
                            DateRemoved = query.DateRemoved,
                            EditType = query.EditType,
                            FireBurglerID = query.FireBurglerID,
                            LocationAddress = query.LocationAddress,
                            LocationName = query.LocationName,
                            LocationNumber = query.LocationNumber,
                            MemberCoverageID =  query.MemberCoverageID,
                            OwnLeaseID = query.OwnLeaseID,
                            PropertyScheduleID = query.PropertyScheduleID,
                            RemodelDate = query.RemodelDate,
                            ScheduleStatusID = query.ScheduleStatusID,
                            SquareFoot = query.SquareFoot,
                            StateID = query.StateID,
                            Zip = query.Zip
                        };
                        // need to transfer records.
                        TransferScheduleRecords(model);

                        if (queryUpdate.ScheduleStatusID != 3)
                        {
                            queryUpdate.ScheduleStatusID = 5;
                        }
                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                }
            }

            return emailModel;
        }

        public void TransferScheduleRecords(PropertyScheduleHold model)
        {
            if (model.EditType == "Edit")
            {
                var query = (from property in ContextPerRequest.CurrentData.PropertySchedules
                             where property.PropertyScheduleID == model.PropertyScheduleID
                             select property).FirstOrDefault();

                if (query != null)
                {
                    query.BI_EE = model.BI_EE;
                    query.BuildingValue = model.BuildingValue;
                    query.City = model.City;
                    query.ConstructionDate = model.ConstructionDate;
                    query.ConstructionTypeID = model.ConstructionTypeID;
                    query.ContentValue = model.ContentValue;
                    query.FireBurglerID = model.FireBurglerID;
                    query.LocationAddress = model.LocationAddress;
                    query.LocationName = model.LocationName;
                    query.LocationNumber = model.LocationNumber;
                    query.MemberCoverageID = model.MemberCoverageID;
                    query.OwnLeaseID = model.OwnLeaseID;
                    query.RemodelDate = model.RemodelDate;
                    query.SquareFoot = model.SquareFoot;
                    query.StateID = model.StateID;
                    query.Zip = model.Zip;
                    query.DateAdded = model.DateAdded;
                    query.DateRemoved = model.DateRemoved;

                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
            else if (model.EditType == "Add")
            {
                PropertySchedule vehicle = new PropertySchedule
                {
                    BI_EE = model.BI_EE,
                    BuildingValue = model.BuildingValue,
                    City = model.City,
                    ConstructionDate = model.ConstructionDate,
                    ConstructionTypeID = model.ConstructionTypeID,
                    ContentValue = model.ContentValue,
                    DateAdded = model.DateAdded,
                    FireBurglerID = model.FireBurglerID,
                    LocationAddress = model.LocationAddress,
                    LocationName = model.LocationName,
                    LocationNumber = model.LocationNumber,
                    MemberCoverageID = model.MemberCoverageID,
                    OwnLeaseID = model.OwnLeaseID,
                    RemodelDate = model.RemodelDate,
                    SquareFoot = model.SquareFoot,
                    StateID = model.StateID,
                    Zip = model.Zip
                };

                ContextPerRequest.CurrentData.PropertySchedules.Add(vehicle);
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else if (model.EditType == "Delete")
            {
                var deleteQuery = (from property in ContextPerRequest.CurrentData.PropertySchedules
                                   where property.PropertyScheduleID == model.PropertyScheduleID
                                   select property).FirstOrDefault();
                if (deleteQuery != null)
                {
                    deleteQuery.DateRemoved = model.DateRemoved;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

    }

    public class EmailProperty
    {
        public string MemberName { get; set; }
        public List<SendingProperty> PropertyCOIList { get; set; }
        public List<SendingProperty> PropertyAddList { get; set; }
        public List<SendingProperty> PropertyDeleteList { get; set; }
        public List<SendingProperty> PropertyEditList { get; set; }
    }
    public class SendingProperty
    {
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string TypeOfConstruction { get; set; }
        public string Cost { get; set; }
        public string SquareFootage { get; set; }
        public string OwnLease { get; set; }
        public string FireBurglar { get; set; }
        public string DateContruction { get; set; }
        public string DateAdded { get; set; }
        public string BuildingValue { get; set; }
        public string ContentValue { get; set; }
        public string DateRemoved { get; set; }


    }
}
