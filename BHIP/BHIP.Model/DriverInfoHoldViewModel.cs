using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class DriverInfoHoldViewModel
    {
        public int DriverInfoScheduleHoldID { get; set; }
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
        public int StateID { get; set; }
        public string StateName { get; set; }

        [Required(ErrorMessage = "Enter the license number")]
        [Display(Name = "License Number:")]
        public string LicenseNumber { get; set; }
        [Display(Name = "Date Added:")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Date Removed:")]
        public DateTime? DateRemoved { get; set; }
        [Display(Name = "Comment:")]
        public string Comments { get; set; }
        public string EditType { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string StatusName { get; set; }

        public IEnumerable<DriverInfoHoldViewModel> GetAllDriverInfoScheduleHolds(int memberCoverageID)
        {
            var query = (from driverInfo in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                         join states in ContextPerRequest.CurrentData.States on driverInfo.StateID equals states.StateId
                         join users in ContextPerRequest.CurrentData.AspNetUsers on driverInfo.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on driverInfo.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where driverInfo.MemberCoverageID == memberCoverageID && driverInfo.ScheduleStatusID != 4 && driverInfo.ScheduleStatusID != 5
                         orderby driverInfo.LastName
                         select new DriverInfoHoldViewModel
                         {
                             Comments = driverInfo.Comments,
                             DateAdded = driverInfo.DateAdded,
                             DateRemoved = driverInfo.DateRemoved,
                             DOB = driverInfo.DOB,
                             DriverInfoScheduleHoldID = driverInfo.DriverInfoScheduleHoldID,
                             DriverInfoScheduleID = driverInfo.DriverInfoScheduleID,
                             FirstName = driverInfo.FirstName,
                             LastName = driverInfo.LastName,
                             LicenseNumber = driverInfo.LicenseNumber,
                             MemberCoverageID = driverInfo.MemberCoverageID,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StateName = states.Name,
                             EditType = driverInfo.EditType
                         });
            return query;
        }

        public DriverInfoHoldViewModel GetADriverInfoScheduleHold(int driverInfoId)
        {
            var query = (from driverInfo in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                         where driverInfo.DriverInfoScheduleHoldID == driverInfoId
                         select new DriverInfoHoldViewModel
                         {
                             Comments = driverInfo.Comments,
                             DateAdded = driverInfo.DateAdded,
                             DateRemoved = driverInfo.DateRemoved,
                             DOB = driverInfo.DOB,
                             DriverInfoScheduleHoldID = driverInfo.DriverInfoScheduleHoldID,
                             DriverInfoScheduleID = driverInfo.DriverInfoScheduleID,
                             FirstName = driverInfo.FirstName,
                             LastName = driverInfo.LastName,
                             LicenseNumber = driverInfo.LicenseNumber,
                             MemberCoverageID = driverInfo.MemberCoverageID,
                             StateID = driverInfo.StateID ?? 0,
                             EditType = driverInfo.EditType
                         }).FirstOrDefault();
            return query;

        }

        public void DriverInfoScheduleAdd(DriverInfoViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            DriverInfoScheduleHold driver = new DriverInfoScheduleHold
            {
                Comments = model.Comments,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                DOB = model.DOB,
                DriverInfoScheduleID = model.DriverInfoScheduleID,
                EditType = "Add",
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNumber = model.LicenseNumber,
                MemberCoverageID = model.MemberCoverageID,
                StateID = model.StateID,
                UserID = UserId,
                ScheduleStatusID = 2
            };

            ContextPerRequest.CurrentData.DriverInfoScheduleHolds.Add(driver);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void DriverInfoScheduleEdit(DriverInfoViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            DriverInfoScheduleHold driver = new DriverInfoScheduleHold
            {
                Comments = model.Comments,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                DOB = model.DOB,
                DriverInfoScheduleID = model.DriverInfoScheduleID,
                EditType = "Edit",
                FirstName = model.FirstName,
                LastName = model.LastName,
                LicenseNumber = model.LicenseNumber,
                MemberCoverageID = model.MemberCoverageID,
                StateID = model.StateID,
                UserID = UserId,
                ScheduleStatusID = 2
            };

            ContextPerRequest.CurrentData.DriverInfoScheduleHolds.Add(driver);
            ContextPerRequest.CurrentData.SaveChanges();

        }

        public void DriverInfoScheduleDelete(DriverInfoDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from driver in ContextPerRequest.CurrentData.DriverInfoSchedules
                         where driver.DriverInfoScheduleID == model.DriverInfoScheduleID
                         select driver).FirstOrDefault();

            if (query != null)
            {
                DriverInfoScheduleHold driver = new DriverInfoScheduleHold
                {
                    Comments = query.Comments,
                    DateAdded = query.DateAdded,
                    DateRemoved = model.DateRemoved,
                    DOB = query.DOB,
                    DriverInfoScheduleID = query.DriverInfoScheduleID,
                    EditType = "Delete",
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    LicenseNumber = query.LicenseNumber,
                    MemberCoverageID = query.MemberCoverageID,
                    StateID = query.StateID,
                    UserID = UserId,
                    ScheduleStatusID = 2
                };
                ContextPerRequest.CurrentData.DriverInfoScheduleHolds.Add(driver);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public DriverInfoHoldViewModel DriverInfoScheduleHoldEdit(int driverInfoScheduleHoldId)
        {
            var query = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                         where driver.DriverInfoScheduleHoldID == driverInfoScheduleHoldId
                         select new DriverInfoHoldViewModel
                         {
                             Comments = driver.Comments,
                             DateAdded = driver.DateAdded,
                             DateRemoved = driver.DateRemoved,
                             DOB = driver.DOB,
                             DriverInfoScheduleHoldID = driver.DriverInfoScheduleHoldID,
                             DriverInfoScheduleID = driver.DriverInfoScheduleID,
                             EditType = driver.EditType,
                             FirstName = driver.FirstName,
                             LastName = driver.LastName,
                             LicenseNumber = driver.LicenseNumber,
                             MemberCoverageID = driver.MemberCoverageID,
                             StateID = driver.StateID ?? 0
                         }).FirstOrDefault();

            return query;
        }

        public void DriverInfoHoldSave(DriverInfoHoldViewModel model)
        {
            var query = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                         where driver.DriverInfoScheduleHoldID == model.DriverInfoScheduleHoldID
                         select driver).FirstOrDefault();

            query.Comments = model.Comments;
            query.DateAdded = model.DateAdded;
            query.DateRemoved = model.DateRemoved;
            query.DOB = model.DOB;
            query.FirstName = model.FirstName;
            query.LastName = model.LastName;
            query.LicenseNumber = model.LicenseNumber;
            query.StateID = model.StateID;

            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void DriverInfoHoldDelete(int driverInfoScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                         where driver.DriverInfoScheduleHoldID == driverInfoScheduleHoldId
                         select driver).FirstOrDefault();

            if (query != null)
            {
                query.ScheduleStatusID = 4;
                //query.DateRemoved = DateTime.Now;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public EmailDriverInfo DriverInfoPendingApprove(string scheduleIds)
        {
            EmailDriverInfo emailModel = new EmailDriverInfo();
            emailModel.DriverInfoCOIList = new List<SendingDriverInfo>();
            emailModel.DriverInfoAddList = new List<SendingDriverInfo>();
            emailModel.DriverInfoDeleteList = new List<SendingDriverInfo>();
            emailModel.DriverInfoEditList = new List<SendingDriverInfo>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                             join state in ContextPerRequest.CurrentData.States on driver.StateID equals state.StateId
                             where driver.DriverInfoScheduleHoldID == scheduleHoldID
                             select new SendingDriverInfo
                             {
                                 ScheduleStatusID = driver.ScheduleStatusID,
                                 EditType = driver.EditType,
                                 FirstName = driver.FirstName,
                                 LastName = driver.LastName,
                                 DOB = driver.DOB.ToString(),
                                 License = driver.LicenseNumber,
                                 StateName = state.Name,
                                 DateAdded = driver.DateAdded.ToString(),
                                 DateRemoved = driver.DateRemoved.ToString()
                             }).FirstOrDefault();

                var queryUpdate = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                                   where driver.DriverInfoScheduleHoldID == scheduleHoldID
                                   select driver).FirstOrDefault<DriverInfoScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 || statusId == 3) // pending and no COI
                    {
                        if (query.EditType == "Add")
                        {
                            SendingDriverInfo addModel = new SendingDriverInfo();
                            addModel.FirstName = query.FirstName;
                            addModel.LastName = query.LastName;
                            addModel.DOB = (query.DOB != string.Empty ? Convert.ToDateTime(query.DOB).ToShortDateString() : string.Empty);
                            addModel.License = query.License;
                            addModel.StateName = query.StateName;
                            addModel.DateAdded = (query.DateAdded != string.Empty ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            emailModel.DriverInfoAddList.Add(addModel);
                        }
                        else if (query.EditType == "Edit")
                        {
                            SendingDriverInfo editModel = new SendingDriverInfo();
                            editModel.FirstName = query.FirstName;
                            editModel.LastName = query.LastName;
                            editModel.DOB = (query.DOB != string.Empty ? Convert.ToDateTime(query.DOB).ToShortDateString() : string.Empty);
                            editModel.License = query.License;
                            editModel.StateName = query.StateName;
                            editModel.DateAdded = (query.DateAdded != string.Empty ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            emailModel.DriverInfoEditList.Add(editModel);
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingDriverInfo deleteModel = new SendingDriverInfo();
                            deleteModel.FirstName = query.FirstName;
                            deleteModel.LastName = query.LastName;
                            deleteModel.DOB = (query.DOB != string.Empty ? Convert.ToDateTime(query.DOB).ToShortDateString() : string.Empty);
                            deleteModel.License = query.License;
                            deleteModel.StateName = query.StateName;
                            deleteModel.DateAdded = (query.DateAdded != string.Empty ? Convert.ToDateTime(query.DateAdded).ToShortDateString() : string.Empty);
                            deleteModel.DateRemoved = (query.DateRemoved != string.Empty ? Convert.ToDateTime(query.DateRemoved).ToShortDateString() : string.Empty);
                            emailModel.DriverInfoDeleteList.Add(deleteModel);
                        }
                        // need to transfer records.
                        TransferScheduleRecords(queryUpdate);

                        queryUpdate.ScheduleStatusID = 5;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                }
            }

            return emailModel;
        }

        public void TransferScheduleRecords(DriverInfoScheduleHold model)
        {
            if (model.EditType == "Edit")
            {
                var query = (from veh in ContextPerRequest.CurrentData.DriverInfoSchedules
                             where veh.DriverInfoScheduleID == model.DriverInfoScheduleID
                             select veh).FirstOrDefault();

                if (query != null)
                {
                    query.Comments = model.Comments;
                    query.DateAdded = model.DateAdded;
                    query.DateRemoved = model.DateRemoved;
                    query.DOB = model.DOB;
                    query.FirstName = model.FirstName;
                    query.LastName = model.LastName;
                    query.LicenseNumber = model.LicenseNumber;
                    query.MemberCoverageID = model.MemberCoverageID;
                    query.StateID = model.StateID;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
            else if (model.EditType == "Add")
            {
                DriverInfoSchedule driver = new DriverInfoSchedule
                {
                    Comments = model.Comments,
                    DateAdded = model.DateAdded,
                    DateRemoved = model.DateRemoved,
                    DOB = model.DOB,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    LicenseNumber = model.LicenseNumber,
                    MemberCoverageID = model.MemberCoverageID,
                    StateID = model.StateID
                };

                ContextPerRequest.CurrentData.DriverInfoSchedules.Add(driver);
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else if (model.EditType == "Delete")
            {
                var deleteQuery = (from driver in ContextPerRequest.CurrentData.DriverInfoSchedules
                                   where driver.DriverInfoScheduleID == model.DriverInfoScheduleID
                                   select driver).FirstOrDefault();
                if (deleteQuery != null)
                {
                    deleteQuery.DateRemoved = model.DateRemoved;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

    }

    public class EmailDriverInfo
    {
        public string MemberName { get; set; }
        public List<SendingDriverInfo> DriverInfoCOIList { get; set; }
        public List<SendingDriverInfo>DriverInfoAddList { get; set; }
        public List<SendingDriverInfo> DriverInfoDeleteList { get; set; }
        public List<SendingDriverInfo> DriverInfoEditList { get; set; }
    }
    public class SendingDriverInfo
    {
        public int ScheduleStatusID { get; set; }
        public string EditType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string License { get; set; }
        public string StateName { get; set; }
        public string DateAdded { get; set; }
        public string DateRemoved { get; set; }

    }
}
