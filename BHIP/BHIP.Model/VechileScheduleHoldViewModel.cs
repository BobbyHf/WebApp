using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class VehicleScheduleHoldViewModel
    {
        public int VehicleScheduleHoldID { get; set; }
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
        [Required(ErrorMessage = "Enter the date added")]
        [Display(Name = "Date Deleted:")]
        public DateTime? DateDeleted { get; set; }
        [Display(Name = "Notes:")]
        public string Notes { get; set; }
        public string EditType { get; set; }
        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string StatusName { get; set; }

        public IEnumerable<VehicleScheduleHoldViewModel> GetAllVehicleHolds(int memberCoverageId)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleScheduleHolds
                         join state in ContextPerRequest.CurrentData.States on vehicle.StateID equals state.StateId
                         join own in ContextPerRequest.CurrentData.OwnLeases on vehicle.OwnLeaseID equals own.OwnLeaseID
                         join users in ContextPerRequest.CurrentData.AspNetUsers on vehicle.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on vehicle.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where vehicle.MemberCoverageID == memberCoverageId && vehicle.ScheduleStatusID != 4 && vehicle.ScheduleStatusID != 5
                         orderby vehicle.Year, vehicle.MakeModel
                         select new VehicleScheduleHoldViewModel
                         {
                             City = vehicle.City,
                             DateAdded = vehicle.DateAdded,
                             DateDeleted = vehicle.DateDeleted,
                             EditType = vehicle.EditType,
                             MakeModel = vehicle.MakeModel,
                             MemberCoverageID = vehicle.MemberCoverageID,
                             Notes = vehicle.Notes,
                             OwnLeaseDescription = own.Description,
                             StateName = state.Name,
                             VehicleScheduleHoldID = vehicle.VehicleScheduleHoldID,
                             VehicleScheduleID = vehicle.VehicleScheduleID,
                             VIN = vehicle.VIN,
                             Year = vehicle.Year ?? 0,
                             Zipcode = vehicle.Zipcode,
                             COI = vehicle.COI,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StatusName = status.Description
                         });
            return query;
        }

        public VehicleScheduleHoldViewModel GetAVehicleHold(int vehicleScheduleHoldId)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleScheduleHolds
                         where vehicle.VehicleScheduleHoldID == vehicleScheduleHoldId
                         select new VehicleScheduleHoldViewModel
                         {
                             City = vehicle.City,
                             DateAdded = vehicle.DateAdded,
                             DateDeleted = vehicle.DateDeleted,
                             EditType = vehicle.EditType,
                             MakeModel = vehicle.MakeModel,
                             MemberCoverageID = vehicle.MemberCoverageID,
                             Notes = vehicle.Notes,
                             OwnLeaseID = vehicle.OwnLeaseID ?? 0,
                             StateID = vehicle.StateID ?? 0,
                             VehicleScheduleHoldID = vehicle.VehicleScheduleHoldID,
                             VehicleScheduleID = vehicle.VehicleScheduleID,
                             VIN = vehicle.VIN,
                             Year = vehicle.Year ?? 0,
                             Zipcode = vehicle.Zipcode,
                             COI = vehicle.COI
                         }).FirstOrDefault();
            return query;
        }

        public void VehicleScheduleHoldAdd(VehicleScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            VehicleScheduleHold vehicle = new VehicleScheduleHold
            {
                City = model.City,
                DateAdded = model.DateAdded,
                DateDeleted = model.DateDeleted,
                EditType = "Add",
                MakeModel = model.MakeModel,
                MemberCoverageID = model.MemberCoverageID,
                Notes = model.Notes,
                OwnLeaseID = model.OwnLeaseID,
                StateID = model.StateID,
                VehicleScheduleID = model.VehicleScheduleID,
                VIN = model.VIN,
                Year = model.Year,
                Zipcode = model.Zipcode,
                COI = model.COI,
                ScheduleStatusID = 2, // make the status pending
                UserID = UserId
            };

            ContextPerRequest.CurrentData.VehicleScheduleHolds.Add(vehicle);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void VehicleScheduleDelete(VehicleDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleSchedules
                         where vehicle.VehicleScheduleID == model.VehicleScheduleID
                         select vehicle).FirstOrDefault();

            if (query != null)
            {
                VehicleScheduleHold veh = new VehicleScheduleHold
                {
                    City = query.City,
                    DateAdded = query.DateAdded,
                    DateDeleted = model.DateDeleted,
                    MakeModel = query.MakeModel,
                    Notes = query.Notes,
                    OwnLeaseID = query.OwnLeaseID,
                    StateID = query.StateID,
                    VehicleScheduleID = query.VehicleScheduleID,
                    VIN = query.VIN,
                    Year = query.Year,
                    Zipcode = query.Zipcode,
                    MemberCoverageID = query.MemberCoverageID,
                    EditType = "Delete",
                    UserID = UserId,
                    ScheduleStatusID = 2 // pending status
                };

                ContextPerRequest.CurrentData.VehicleScheduleHolds.Add(veh);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }


        public void VehicleScheduleHoldEdit(VehicleScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            VehicleScheduleHold vehicle = new VehicleScheduleHold
            {
                City = model.City,
                DateAdded = model.DateAdded,
                DateDeleted = model.DateDeleted,
                EditType = "Edit",
                MakeModel = model.MakeModel,
                MemberCoverageID = model.MemberCoverageID,
                Notes = model.Notes,
                OwnLeaseID = model.OwnLeaseID,
                StateID = model.StateID,
                VehicleScheduleID = model.VehicleScheduleID,
                VIN = model.VIN,
                Year = model.Year,
                Zipcode = model.Zipcode,
                COI = model.COI,
                UserID = UserId,
                ScheduleStatusID = 2 // pending status
            };

            ContextPerRequest.CurrentData.VehicleScheduleHolds.Add(vehicle);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void VehicleScheduleHoldSave(VehicleScheduleHoldViewModel model)
        {
            var query = (from vehicle in ContextPerRequest.CurrentData.VehicleScheduleHolds
                         where vehicle.VehicleScheduleHoldID == model.VehicleScheduleHoldID
                         select vehicle).FirstOrDefault();

            if (query != null)
            {
                query.City = model.City;
                query.DateAdded = model.DateAdded;
                query.DateDeleted = model.DateDeleted;
                query.MakeModel = model.MakeModel;
                query.MemberCoverageID = model.MemberCoverageID;
                query.Notes = model.Notes;
                query.OwnLeaseID = model.OwnLeaseID;
                query.StateID = model.StateID;
                query.VehicleScheduleID = model.VehicleScheduleID;
                query.VIN = model.VIN;
                query.Year = model.Year;
                query.Zipcode = model.Zipcode;
                query.COI = model.COI;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        
        public void VehicleScheduleHoldDelete(int vehicleScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from veh in ContextPerRequest.CurrentData.VehicleScheduleHolds
                         where veh.VehicleScheduleHoldID == vehicleScheduleHoldId
                         select veh).FirstOrDefault();

            if (query != null)
            {
                query.ScheduleStatusID = 4; // removed
                query.DateDeleted = DateTime.Now;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public EmailVehicles VehiclePendingApprove(string scheduleIds)
        {
            EmailVehicles emailModel = new EmailVehicles();
            emailModel.VehicleCOIList = new List<SendingVehicleInfo>();
            emailModel.VehicleAddList = new List<SendingVehicleInfo>();
            emailModel.VehicleDeleteList = new List<SendingVehicleInfo>();
            emailModel.VehicleEditList = new List<SendingVehicleInfo>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from vehicle in ContextPerRequest.CurrentData.VehicleScheduleHolds
                             join state in ContextPerRequest.CurrentData.States on vehicle.StateID equals state.StateId
                             join own in ContextPerRequest.CurrentData.OwnLeases on vehicle.OwnLeaseID equals own.OwnLeaseID
                             where vehicle.VehicleScheduleHoldID == scheduleHoldID
                             select new VehicleScheduleHoldViewModel
                             {
                                 City = vehicle.City,
                                 DateAdded = vehicle.DateAdded,
                                 DateDeleted = vehicle.DateDeleted,
                                 EditType = vehicle.EditType,
                                 MakeModel = vehicle.MakeModel,
                                 MemberCoverageID = vehicle.MemberCoverageID,
                                 Notes = vehicle.Notes,
                                 OwnLeaseDescription = own.Description,
                                 StateName = state.Name,
                                 VehicleScheduleHoldID = vehicle.VehicleScheduleHoldID,
                                 VehicleScheduleID = vehicle.VehicleScheduleID,
                                 VIN = vehicle.VIN,
                                 Year = vehicle.Year ?? 0,
                                 Zipcode = vehicle.Zipcode,
                                 COI = vehicle.COI,
                                 OwnLeaseID = vehicle.OwnLeaseID ?? 0,
                                 ScheduleStatusID = vehicle.ScheduleStatusID,
                                 StateID = vehicle.StateID ?? 0
                             }).FirstOrDefault();

                var queryUpdate = (from veh in ContextPerRequest.CurrentData.VehicleScheduleHolds
                                   where veh.VehicleScheduleHoldID == scheduleHoldID
                                   select veh).FirstOrDefault<VehicleScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 && query.COI == true) // pending and COI is checked.
                    {
                        SendingVehicleInfo coiModel = new SendingVehicleInfo();
                        coiModel.MakeModel = query.MakeModel;
                        coiModel.VIN = query.VIN;
                        coiModel.Year = query.Year ?? 0;
                        coiModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                        coiModel.City = query.City;
                        coiModel.State = query.StateName;
                        coiModel.Zip = query.Zipcode;
                        emailModel.VehicleCOIList.Add(coiModel);

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
                            SendingVehicleInfo addModel = new SendingVehicleInfo();
                            addModel.MakeModel = query.MakeModel;
                            addModel.VIN = query.VIN;
                            addModel.Year = query.Year ?? 0;
                            addModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            addModel.City = query.City;
                            addModel.State = query.StateName;
                            addModel.Zip = query.Zipcode;
                            addModel.OwnLease = query.OwnLeaseDescription;
                            emailModel.VehicleAddList.Add(addModel);
                            ContextPerRequest.CurrentData.SaveChanges();
                        }
                        else if (query.EditType == "Edit" && query.COI)
                        {
                            SendingVehicleInfo editModel = new SendingVehicleInfo();
                            editModel.MakeModel = query.MakeModel;
                            editModel.VIN = query.VIN;
                            editModel.Year = query.Year ?? 0;
                            editModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            editModel.City = query.City;
                            editModel.State = query.StateName;
                            editModel.Zip = query.Zipcode;
                            editModel.OwnLease = query.OwnLeaseDescription;
                            emailModel.VehicleEditList.Add(editModel);
                            ContextPerRequest.CurrentData.SaveChanges();
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingVehicleInfo deleteModel = new SendingVehicleInfo();
                            deleteModel.MakeModel = query.MakeModel;
                            deleteModel.VIN = query.VIN;
                            deleteModel.Year = query.Year ?? 0;
                            deleteModel.DateAdded = (query.DateAdded.HasValue == true ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            deleteModel.DateRemoved = (query.DateDeleted.HasValue == true ? Convert.ToDateTime(query.DateDeleted).ToShortDateString() : string.Empty);
                            deleteModel.City = query.City;
                            deleteModel.State = query.StateName;
                            deleteModel.Zip = query.Zipcode;
                            emailModel.VehicleDeleteList.Add(deleteModel);
                            ContextPerRequest.CurrentData.SaveChanges();
                        }

                        VehicleScheduleHold model = new VehicleScheduleHold
                        {
                            City = query.City,
                            COI = query.COI,
                            DateAdded = query.DateAdded,
                            DateDeleted = query.DateDeleted,
                            EditType = query.EditType,
                            MakeModel = query.MakeModel,
                            MemberCoverageID = query.MemberCoverageID,
                            Notes = query.Notes,
                            OwnLeaseID = query.OwnLeaseID,
                            ScheduleStatusID = query.ScheduleStatusID,
                            StateID = query.StateID,
                            VehicleScheduleID = query.VehicleScheduleID,
                            VehicleScheduleHoldID = query.VehicleScheduleHoldID,
                            VehicleValue = 0,
                            VIN = query.VIN,
                            Year = query.Year,
                            Zipcode = query.Zipcode
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

        public void TransferScheduleRecords(VehicleScheduleHold model)
        {
                if (model.EditType == "Edit")
                {
                    var query = (from veh in ContextPerRequest.CurrentData.VehicleSchedules
                                 where veh.VehicleScheduleID == model.VehicleScheduleID
                                 select veh).FirstOrDefault();

                    if (query != null)
                    {
                        query.City = model.City;
                        query.DateAdded = model.DateAdded;
                        query.DateDeleted = model.DateDeleted;
                        query.MakeModel = model.MakeModel;
                        query.MemberCoverageID = model.MemberCoverageID;
                        query.Notes = model.Notes;
                        query.OwnLeaseID = model.OwnLeaseID;
                        query.StateID = model.StateID;
                        query.VehicleValue = model.VehicleValue;
                        query.VIN = model.VIN;
                        query.Year = model.Year;
                        query.Zipcode = model.Zipcode;

                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                } else if (model.EditType == "Add")
                {
                    VehicleSchedule vehicle = new VehicleSchedule
                    {
                        City = model.City,
                        DateAdded = model.DateAdded,
                        MakeModel = model.MakeModel,
                        MemberCoverageID = model.MemberCoverageID,
                        Notes = model.Notes,
                        OwnLeaseID = model.OwnLeaseID,
                        StateID = model.StateID,
                        VIN = model.VIN,
                        Year = model.Year,
                        Zipcode = model.Zipcode
                    };

                    ContextPerRequest.CurrentData.VehicleSchedules.Add(vehicle);
                    ContextPerRequest.CurrentData.SaveChanges();
                } else if (model.EditType == "Delete")
                {
                    var deleteQuery = (from veh in ContextPerRequest.CurrentData.VehicleSchedules
                                       where veh.VehicleScheduleID == model.VehicleScheduleID
                                       select veh).FirstOrDefault();
                    if (deleteQuery != null)
                    {
                        deleteQuery.DateDeleted = model.DateDeleted;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                }
        }
    }

    public class EmailVehicles
    {
        public string MemberName { get; set; }
        public List<SendingVehicleInfo> VehicleCOIList { get; set; }
        public List<SendingVehicleInfo> VehicleAddList { get; set; }
        public List<SendingVehicleInfo> VehicleDeleteList { get; set; }
        public List<SendingVehicleInfo> VehicleEditList { get; set; }
    }
    public class SendingVehicleInfo
    {
        public int Year { get; set; }
        public string MakeModel { get; set; }
        public string VIN { get; set; }
        public string DateAdded { get; set; }
        public string DateRemoved { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string OwnLease { get; set; }
    }
}
