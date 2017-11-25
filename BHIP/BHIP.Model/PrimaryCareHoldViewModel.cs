using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PrimaryCareHoldViewModel
    {
        public int PrimaryCareScheduleHoldID { get; set; }
        public int PrimaryCareScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        [Required(ErrorMessage = "Enter the first name")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Specialty:")]
        public int? SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        [Required(ErrorMessage = "Enter the retro date")]
        [Display(Name = "Retro Date:")]
        public DateTime? RetroDate { get; set; }
        [Display(Name = "Board Ceritifed:")]
        public int? BoardCertifiedID { get; set; }
        public string BoardCertifiedDescription { get; set; }
        [Display(Name = "Board Eligible:")]
        public int? BoardEligibleID { get; set; }
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
        public string EditType { get; set; }

        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string StatusName { get; set; }

        public IEnumerable<PrimaryCareHoldViewModel> GetAllPrimaryCareHolds(int memberCoverageId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on primary.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on primary.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on primary.OwnMalPracticeID equals malpractice.MalpracticeID
                         join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on primary.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on primary.ContractorEmployeeID equals employment.EmploymentTypeID
                         join users in ContextPerRequest.CurrentData.AspNetUsers on primary.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on primary.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where primary.MemberCoverageID == memberCoverageId && primary.ScheduleStatusID != 4 && primary.ScheduleStatusID != 5
                         orderby specialty.Description, primary.LastName
                         select new PrimaryCareHoldViewModel
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
                             PrimaryCareScheduleHoldID = primary.PrimaryCareScheduleHoldID,
                             RetroDate = primary.RetroDate,
                             SpecialtyName = specialty.Description,
                             COI = primary.COI,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StatusName = status.Description
                         });
            return query;
        }

        public PrimaryCareHoldViewModel GetAPrimaryCareHold(int primaryCareSceduleHoldId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                         where primary.PrimaryCareScheduleHoldID == primaryCareSceduleHoldId
                         select new PrimaryCareHoldViewModel
                         {
                             BoardCertifiedID = primary.BoardCertifiedID,
                             BoardEligibleID = primary.BoardEligibleID,
                             ContractorEmployeeID = primary.ContractorEmployeeID ?? 0,
                             DateAdded = primary.DateAdded,
                             DateRemoved = primary.DateRemoved,
                             FirstName = primary.FirstName,
                             HoursWorked = primary.HoursWorked,
                             LastName = primary.LastName,
                             MemberCoverageID = primary.MemberCoverageID,
                             OwnMalpracticeID = primary.OwnMalPracticeID ?? 0,
                             PrimaryCareScheduleHoldID = primary.PrimaryCareScheduleHoldID,
                             PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                             RetroDate = primary.RetroDate,
                             SpecialtyID = primary.SpecialtyID,
                             EditType = primary.EditType,
                             COI = primary.COI
                         }).FirstOrDefault();

            return query;

        }

        public void PrimaryCareScheduleAdd(PrimaryCareViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PrimaryCareScheduleHold primary = new PrimaryCareScheduleHold
            {
                BoardCertifiedID = model.BoardCertifiedID,
                BoardEligibleID = model.BoardEligibleID,
                ContractorEmployeeID = model.ContractorEmployeeID,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                EditType = "Add",
                FirstName = model.FirstName,
                HoursWorked = model.HoursWorked,
                LastName = model.LastName,
                MemberCoverageID = model.MemberCoverageID,
                OwnMalPracticeID = model.OwnMalpracticeID,
                PrimaryCareScheduleID = model.PrimaryCareScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.PrimaryCareScheduleHolds.Add(primary);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PrimaryCareScheduleEdit(PrimaryCareViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PrimaryCareScheduleHold primary = new PrimaryCareScheduleHold
            {
                BoardCertifiedID = model.BoardCertifiedID,
                BoardEligibleID = model.BoardEligibleID,
                ContractorEmployeeID = model.ContractorEmployeeID,
                DateAdded = model.DateAdded,
                DateRemoved = model.DateRemoved,
                EditType = "Edit",
                FirstName = model.FirstName,
                HoursWorked = model.HoursWorked,
                LastName = model.LastName,
                MemberCoverageID = model.MemberCoverageID,
                OwnMalPracticeID = model.OwnMalpracticeID,
                PrimaryCareScheduleID = model.PrimaryCareScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId
            };

            ContextPerRequest.CurrentData.PrimaryCareScheduleHolds.Add(primary);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PrimaryCareScheduleDelete(PrimaryCareDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                         where primary.PrimaryCareScheduleID == model.PrimaryCareScheduleID
                         select primary).FirstOrDefault();

            if (query != null)
            {
                PrimaryCareScheduleHold primary = new PrimaryCareScheduleHold
                {
                    BoardCertifiedID = query.BoardCertifiedID,
                    BoardEligibleID = query.BoardEligibleID,
                    ContractorEmployeeID = query.ContractorEmployeeID,
                    DateAdded = query.DateAdded,
                    DateRemoved = model.DateRemoved,
                    EditType = "Delete",
                    FirstName = query.FirstName,
                    HoursWorked = query.HoursWorked,
                    LastName = query.LastName,
                    MemberCoverageID = query.MemberCoverageID,
                    OwnMalPracticeID = query.OwnMalPracticeID,
                    PrimaryCareScheduleID = query.PrimaryCareScheduleID,
                    RetroDate = query.RetroDate,
                    SpecialtyID = query.SpecialtyID,
                    ScheduleStatusID = 2,
                    UserID = UserId
                };
                ContextPerRequest.CurrentData.PrimaryCareScheduleHolds.Add(primary);
                ContextPerRequest.CurrentData.SaveChanges();
            }

        }

        public PrimaryCareHoldViewModel PrimaryCareScheduleHoldEdit(int primaryCareScheduleHoldId)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                             where primary.PrimaryCareScheduleHoldID == PrimaryCareScheduleHoldID
                             select new PrimaryCareHoldViewModel
                             {
                                 BoardCertifiedID = primary.BoardCertifiedID,
                                 BoardEligibleID = primary.BoardEligibleID,
                                 ContractorEmployeeID = primary.ContractorEmployeeID ?? 0,
                                 DateAdded = primary.DateAdded,
                                 DateRemoved = primary.DateRemoved,
                                 FirstName = primary.FirstName,
                                 HoursWorked = primary.HoursWorked,
                                 LastName = primary.LastName,
                                 MemberCoverageID = primary.MemberCoverageID,
                                 OwnMalpracticeID = primary.OwnMalPracticeID ?? 0,
                                 PrimaryCareScheduleHoldID = primary.PrimaryCareScheduleHoldID,
                                 PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                                 RetroDate = primary.RetroDate,
                                 SpecialtyID = primary.SpecialtyID,
                                 COI = primary.COI
                             }).FirstOrDefault();

            return query;
        }

        public void PrimaryCareScheduleHoldSave(PrimaryCareHoldViewModel model)
        {
            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                         where primary.PrimaryCareScheduleHoldID == model.PrimaryCareScheduleHoldID
                         select primary).FirstOrDefault();

            if (query != null)
            {
                query.BoardCertifiedID = model.BoardCertifiedID;
                query.BoardEligibleID = model.BoardEligibleID;
                query.ContractorEmployeeID = model.ContractorEmployeeID;
                query.DateAdded = model.DateAdded;
                query.DateRemoved = model.DateRemoved;
                //query.EditType = model.EditType;
                query.FirstName = model.FirstName;
                query.HoursWorked = model.HoursWorked;
                query.LastName = model.LastName;
                query.MemberCoverageID = model.MemberCoverageID;
                query.OwnMalPracticeID = model.OwnMalpracticeID;
                query.PrimaryCareScheduleHoldID = model.PrimaryCareScheduleHoldID;
                query.PrimaryCareScheduleID = model.PrimaryCareScheduleID;
                query.RetroDate = model.RetroDate;
                query.SpecialtyID = model.SpecialtyID;
                query.COI = model.COI;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void PrimaryCareScheduleHoldDelete(int primaryCareScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                         where primary.PrimaryCareScheduleHoldID == primaryCareScheduleHoldId
                         select primary).FirstOrDefault();

            if (query != null)
            {
                query.ScheduleStatusID = 4;
                query.UserID = UserId;
                query.DateRemoved = DateTime.Now;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public EmailPrimaryCare PrimaryCarePendingApprove(string scheduleIds)
        {
            EmailPrimaryCare emailModel = new EmailPrimaryCare();
            emailModel.PrimaryCareCOIList = new List<SendingPrimaryCare>();
            emailModel.PrimaryCareAddList = new List<SendingPrimaryCare>();
            emailModel.PrimaryCareDeleteList = new List<SendingPrimaryCare>();
            emailModel.PrimaryCareEditList = new List<SendingPrimaryCare>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                             join certified in ContextPerRequest.CurrentData.BoardCertifieds on primary.BoardCertifiedID equals certified.BoardCertifiedID
                             join eligible in ContextPerRequest.CurrentData.BoardEligibles on primary.BoardEligibleID equals eligible.BoardEligibleID
                             join malpractice in ContextPerRequest.CurrentData.Malpractices on primary.OwnMalPracticeID equals malpractice.MalpracticeID
                             join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on primary.SpecialtyID equals specialty.SpecialtyTypeID
                             join employment in ContextPerRequest.CurrentData.EmploymentTypes on primary.ContractorEmployeeID equals employment.EmploymentTypeID
                             where primary.PrimaryCareScheduleHoldID == scheduleHoldID
                             select new PrimaryCareHoldViewModel
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
                                 PrimaryCareScheduleHoldID = primary.PrimaryCareScheduleHoldID,
                                 PrimaryCareScheduleID = primary.PrimaryCareScheduleID,
                                 RetroDate = primary.RetroDate,
                                 SpecialtyName = specialty.Description,
                                 BoardCertifiedID = primary.BoardCertifiedID,
                                 BoardEligibleID = primary.BoardEligibleID,
                                 COI = primary.COI,
                                 ContractorEmployeeID = primary.ContractorEmployeeID ?? 0,
                                 EditType = primary.EditType,
                                 OwnMalpracticeID = primary.OwnMalPracticeID ?? 0,
                                 ScheduleStatusID = primary.ScheduleStatusID,
                                 SpecialtyID = primary.SpecialtyID
                             }).FirstOrDefault();

                var queryUpdate = (from prim in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                                   where prim.PrimaryCareScheduleHoldID == scheduleHoldID
                                   select prim).FirstOrDefault<PrimaryCareScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 && query.COI == true) // pending and COI is checked.
                    {
                        SendingPrimaryCare coiModel = new SendingPrimaryCare();
                        coiModel.FirstName = query.FirstName;
                        coiModel.LastName = query.LastName;
                        coiModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                        emailModel.PrimaryCareCOIList.Add(coiModel);

                        queryUpdate.ScheduleStatusID = 3;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                    if (statusId == 3)
                    {
                        queryUpdate.ScheduleStatusID = 5;
                        ContextPerRequest.CurrentData.SaveChanges();
                    } else if (query.ScheduleStatusID == 2) // pending and no COI
                    {
                        if (query.EditType == "Add")
                        {
                            SendingPrimaryCare addModel = new SendingPrimaryCare();
                            addModel.FirstName = query.FirstName;
                            addModel.LastName = query.LastName;
                            addModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            addModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            addModel.BoardCertified = query.BoardCertifiedDescription;
                            addModel.BoardEligible = query.BoardEligibleDescription;
                            addModel.EmploymentType = query.EmploymentName;
                            addModel.HoursPerWeek = query.HoursWorked.ToString();
                            addModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.PrimaryCareAddList.Add(addModel);
                        }
                        else if (query.EditType == "Edit" && query.COI)
                        {
                            SendingPrimaryCare editModel = new SendingPrimaryCare();
                            editModel.FirstName = query.FirstName;
                            editModel.LastName = query.LastName;
                            editModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            editModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            editModel.BoardCertified = query.BoardCertifiedDescription;
                            editModel.BoardEligible = query.BoardEligibleDescription;
                            editModel.EmploymentType = query.EmploymentName;
                            editModel.HoursPerWeek = query.HoursWorked.ToString();
                            editModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.PrimaryCareEditList.Add(editModel);
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingPrimaryCare deleteModel = new SendingPrimaryCare();
                            deleteModel.FirstName = query.FirstName;
                            deleteModel.LastName = query.LastName;
                            deleteModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            deleteModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            deleteModel.BoardCertified = query.BoardCertifiedDescription;
                            deleteModel.BoardEligible = query.BoardEligibleDescription;
                            deleteModel.EmploymentType = query.EmploymentName;
                            deleteModel.HoursPerWeek = query.HoursWorked.ToString();
                            deleteModel.Malpractice = query.OwnMalpracticeDescription;
                            deleteModel.DateRemoved = (query.DateRemoved.HasValue == true ? Convert.ToDateTime(query.DateRemoved).ToShortDateString() : string.Empty);
                            emailModel.PrimaryCareDeleteList.Add(deleteModel);
                        }

                        PrimaryCareScheduleHold model = new PrimaryCareScheduleHold
                        {
                            BoardCertifiedID = query.BoardCertifiedID,
                            BoardEligibleID = query.BoardEligibleID,
                            COI = query.COI,
                            ContractorEmployeeID = query.ContractorEmployeeID,
                            DateAdded = query.DateAdded,
                            DateRemoved = query.DateRemoved,
                            EditType = query.EditType,
                            FirstName = query.FirstName,
                            HoursWorked = query.HoursWorked,
                            LastName = query.LastName,
                            MemberCoverageID = query.MemberCoverageID,
                            OwnMalPracticeID = query.OwnMalpracticeID,
                            PrimaryCareScheduleID = query.PrimaryCareScheduleID,
                            RetroDate = query.RetroDate,
                            ScheduleStatusID = query.ScheduleStatusID,
                            SpecialtyID = query.SpecialtyID,
                            UserID = query.UserID
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

        public void TransferScheduleRecords(PrimaryCareScheduleHold model)
        {
            if (model.EditType == "Edit")
            {
                var query = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                             where primary.PrimaryCareScheduleID == model.PrimaryCareScheduleID
                             select primary).FirstOrDefault();

                if (query != null)
                {
                    query.BoardCertifiedID = model.BoardCertifiedID;
                    query.BoardEligibleID = model.BoardEligibleID;
                    query.ContractorEmployeeID = model.ContractorEmployeeID;
                    query.DateAdded = model.DateAdded;
                    query.DateRemoved = model.DateRemoved;
                    query.FirstName = model.FirstName;
                    query.HoursWorked = model.HoursWorked;
                    query.LastName = model.LastName;
                    query.MemberCoverageID = model.MemberCoverageID;
                    query.OwnMalPracticeID = model.OwnMalPracticeID;
                    query.RetroDate = model.RetroDate;
                    query.SpecialtyID = model.SpecialtyID;

                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
            else if (model.EditType == "Add")
            {
                PrimaryCareSchedule vehicle = new PrimaryCareSchedule
                {
                    BoardCertifiedID = model.BoardCertifiedID,
                    BoardEligibleID = model.BoardEligibleID,
                    ContractorEmployeeID = model.ContractorEmployeeID,
                    DateAdded = model.DateAdded,
                    DateRemoved = model.DateRemoved,
                    FirstName = model.FirstName,
                    HoursWorked = model.HoursWorked,
                    LastName = model.LastName,
                    MemberCoverageID = model.MemberCoverageID,
                    OwnMalPracticeID = model.OwnMalPracticeID,
                    RetroDate = model.RetroDate,
                    SpecialtyID = model.SpecialtyID
                };

                ContextPerRequest.CurrentData.PrimaryCareSchedules.Add(vehicle);
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else if (model.EditType == "Delete")
            {
                var deleteQuery = (from primary in ContextPerRequest.CurrentData.PrimaryCareSchedules
                                   where primary.PrimaryCareScheduleID == model.PrimaryCareScheduleID
                                   select primary).FirstOrDefault();
                if (deleteQuery != null)
                {
                    deleteQuery.DateRemoved = model.DateRemoved;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

    }

    public class EmailPrimaryCare
    {
        public string MemberName { get; set; }
        public List<SendingPrimaryCare> PrimaryCareCOIList { get; set; }
        public List<SendingPrimaryCare> PrimaryCareAddList { get; set; }
        public List<SendingPrimaryCare> PrimaryCareDeleteList { get; set; }
        public List<SendingPrimaryCare> PrimaryCareEditList { get; set; }
    }
    public class SendingPrimaryCare
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string DateOfHire { get; set; }
        public string BoardCertified { get; set; }
        public string BoardEligible { get; set; }
        public string HoursPerWeek { get; set; }
        public string EmploymentType { get; set; }
        public string Malpractice { get; set; }
        public string DateRemoved { get; set; }

    }
}
