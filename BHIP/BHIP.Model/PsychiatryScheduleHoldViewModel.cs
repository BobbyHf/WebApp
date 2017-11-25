using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PsychiatryScheduleHoldViewModel
    {
        public int PsychiatryScheduleHoldID { get; set; }
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

        public string EditType { get; set; }
        [Display(Name = "Request a Certificate of Insurance:")]
        public bool COI { get; set; }
        public int ScheduleStatusID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string StatusName { get; set; }
        public string SpecialtyOther { get; set; }


        public IEnumerable<PsychiatryScheduleHoldViewModel> GetAllPsychiatryScheduleHolds(int memberCoverageId)
        {
            var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on psychiatry.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on psychiatry.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on psychiatry.OwnMalpracticeID equals malpractice.MalpracticeID
                         join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on psychiatry.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on psychiatry.ContractorEmployeeID equals employment.EmploymentTypeID
                         join users in ContextPerRequest.CurrentData.AspNetUsers on psychiatry.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on psychiatry.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where psychiatry.MemberCoverageID == memberCoverageId && psychiatry.ScheduleStatusID != 4 && psychiatry.ScheduleStatusID != 5
                         orderby specialty.Description, psychiatry.LastName
                         select new PsychiatryScheduleHoldViewModel
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
                             PsychiatryScheduleHoldID = psychiatry.PsychiatryScheduleHoldID,
                             PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                             RetroDate = psychiatry.RetroDate,
                             SpecialtyName = specialty.Description,
                             EditType = psychiatry.EditType,
                             COI = psychiatry.COI,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StatusName = status.Description,
                             SpecialtyOther = psychiatry.SpecialtyOther
                         });

            return query;
        }

        public PsychiatryScheduleHoldViewModel GetAPsychiatryScheduleHold(int psychiatryScheduleHoldId)
        {
            var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                         where psychiatry.PsychiatryScheduleHoldID == psychiatryScheduleHoldId
                         select new PsychiatryScheduleHoldViewModel
                         {
                             BoardCertifiedID = psychiatry.BoardCertifiedID ?? 0,
                             BoardEligibleID = psychiatry.BoardEligibleID ?? 0,
                             ContractorEmployeeID = psychiatry.ContractorEmployeeID ?? 0,
                             DateAdded = psychiatry.DateAdded,
                             DateRemoved = psychiatry.DateRemoved,
                             FirstName = psychiatry.FirstName,
                             HoursWorked = psychiatry.HoursWorked,
                             LastName = psychiatry.LastName,
                             MemberCoverageID = psychiatry.MemberCoverageID,
                             OwnMalpracticeID = psychiatry.OwnMalpracticeID ?? 0,
                             PsychiatryScheduleHoldID = psychiatry.PsychiatryScheduleHoldID,
                             PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                             RetroDate = psychiatry.RetroDate,
                             SpecialtyID = psychiatry.SpecialtyID ?? 0,
                             EditType = psychiatry.EditType,
                             COI = psychiatry.COI,
                             SpecialtyOther = psychiatry.SpecialtyOther
                         }).FirstOrDefault();

            return query;
        }

        public void PsychiatryScheduleAdd(PsychiatryViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PsychiatryScheduleHold psychiatry = new PsychiatryScheduleHold
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
                OwnMalpracticeID = model.OwnMalpracticeID,
                PsychiatryScheduleID = model.PsychiatryScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = model.SpecialtyOther
            };

            ContextPerRequest.CurrentData.PsychiatryScheduleHolds.Add(psychiatry);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PsychiatryScheduleEdit(PsychiatryViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            PsychiatryScheduleHold psychiatry = new PsychiatryScheduleHold
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
                OwnMalpracticeID = model.OwnMalpracticeID,
                PsychiatryScheduleID = model.PsychiatryScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = model.SpecialtyOther
            };

            ContextPerRequest.CurrentData.PsychiatryScheduleHolds.Add(psychiatry);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void PsychiatryScheduleDelete(PsychiatryDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from psych in ContextPerRequest.CurrentData.PsychiatrySchedules
                         where psych.PsychiatryScheduleID == model.PsychiatryScheduleID
                         select psych).FirstOrDefault();

            PsychiatryScheduleHold psychiatry = new PsychiatryScheduleHold
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
                OwnMalpracticeID = query.OwnMalpracticeID,
                PsychiatryScheduleID = query.PsychiatryScheduleID,
                RetroDate = query.RetroDate,
                SpecialtyID = query.SpecialtyID,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = query.SpecialtyOther
            };

            ContextPerRequest.CurrentData.PsychiatryScheduleHolds.Add(psychiatry);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public PsychiatryScheduleHoldViewModel PsychiatryScheduleHoldEdit(int psychiatryScheduleHoldId)
        {
            var query = (from psych in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                         where psych.PsychiatryScheduleHoldID == psychiatryScheduleHoldId
                         select new PsychiatryScheduleHoldViewModel
                         {
                             BoardCertifiedID = psych.BoardCertifiedID ?? 0,
                             BoardEligibleID = psych.BoardEligibleID ?? 0,
                             ContractorEmployeeID = psych.ContractorEmployeeID ?? 0,
                             DateAdded = psych.DateAdded,
                             DateRemoved = psych.DateRemoved,
                             EditType = psych.EditType,
                             FirstName = psych.FirstName,
                             HoursWorked = psych.HoursWorked,
                             LastName = psych.LastName,
                             MemberCoverageID = psych.MemberCoverageID,
                             OwnMalpracticeID = psych.OwnMalpracticeID ?? 0,
                             PsychiatryScheduleHoldID = psych.PsychiatryScheduleHoldID,
                             PsychiatryScheduleID = psych.PsychiatryScheduleID,
                             RetroDate = psych.RetroDate,
                             SpecialtyID = psych.SpecialtyID ?? 0,
                             COI = psych.COI,
                             SpecialtyOther = psych.SpecialtyOther
                         }).FirstOrDefault();

            return query;
        }

        public void PsychiatryScheduleHoldSave(PsychiatryScheduleHoldViewModel model)
        {
            var query = (from psych in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                         where psych.PsychiatryScheduleHoldID == model.PsychiatryScheduleHoldID
                         select psych).FirstOrDefault();

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
                query.OwnMalpracticeID = model.OwnMalpracticeID;
                query.PsychiatryScheduleID = model.PsychiatryScheduleID;
                query.RetroDate = model.RetroDate;
                query.SpecialtyID = model.SpecialtyID;
                query.COI = model.COI;
                query.SpecialtyOther = model.SpecialtyOther;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void PsychiatryScheduleHoldDelete(int psychiatryScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from psych in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                         where psych.PsychiatryScheduleHoldID == psychiatryScheduleHoldId
                         select psych).FirstOrDefault();

            if (query != null)
            {
                query.DateRemoved = DateTime.Now;
                query.ScheduleStatusID = 4;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        public EmailPsychiatry PsychiatryPendingApprove(string scheduleIds)
        {
            EmailPsychiatry emailModel = new EmailPsychiatry();
            emailModel.PsychiatryCOIList = new List<SendingPsychiatry>();
            emailModel.PsychiatryAddList = new List<SendingPsychiatry>();
            emailModel.PsychiatryDeleteList = new List<SendingPsychiatry>();
            emailModel.PsychiatryEditList = new List<SendingPsychiatry>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                             join certified in ContextPerRequest.CurrentData.BoardCertifieds on psychiatry.BoardCertifiedID equals certified.BoardCertifiedID
                             join eligible in ContextPerRequest.CurrentData.BoardEligibles on psychiatry.BoardEligibleID equals eligible.BoardEligibleID
                             join malpractice in ContextPerRequest.CurrentData.Malpractices on psychiatry.OwnMalpracticeID equals malpractice.MalpracticeID
                             join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on psychiatry.SpecialtyID equals specialty.SpecialtyTypeID
                             join employment in ContextPerRequest.CurrentData.EmploymentTypes on psychiatry.ContractorEmployeeID equals employment.EmploymentTypeID
                             where psychiatry.PsychiatryScheduleHoldID == scheduleHoldID
                             select new PsychiatryScheduleHoldViewModel
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
                                 PsychiatryScheduleHoldID = psychiatry.PsychiatryScheduleHoldID,
                                 PsychiatryScheduleID = psychiatry.PsychiatryScheduleID,
                                 RetroDate = psychiatry.RetroDate,
                                 SpecialtyName = specialty.Description,
                                 BoardCertifiedID = psychiatry.BoardCertifiedID ?? 0,
                                 BoardEligibleID = psychiatry.BoardEligibleID ?? 0,
                                 COI = psychiatry.COI,
                                 ContractorEmployeeID = psychiatry.ContractorEmployeeID ?? 0,
                                 EditType = psychiatry.EditType,
                                 OwnMalpracticeID = psychiatry.OwnMalpracticeID ?? 0,
                                 ScheduleStatusID = psychiatry.ScheduleStatusID,
                                 SpecialtyID = psychiatry.SpecialtyID ?? 0,
                                 SpecialtyOther = psychiatry.SpecialtyOther
                             }).FirstOrDefault();

                var queryUpdate = (from psy in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                                   where psy.PsychiatryScheduleHoldID == scheduleHoldID
                                   select psy).FirstOrDefault<PsychiatryScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 && query.COI == true) // pending and COI is checked.
                    {
                        SendingPsychiatry coiModel = new SendingPsychiatry();
                        coiModel.FirstName = query.FirstName;
                        coiModel.LastName = query.LastName;
                        coiModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                        coiModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                        coiModel.BoardCertified = query.BoardCertifiedDescription;
                        coiModel.BoardEligible = query.BoardEligibleDescription;
                        coiModel.EmploymentType = query.EmploymentName;
                        coiModel.HoursPerWeek = query.HoursWorked.ToString();
                        coiModel.Malpractice = query.OwnMalpracticeDescription;
                        emailModel.PsychiatryCOIList.Add(coiModel);

                        queryUpdate.ScheduleStatusID = 3;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }

                    if (statusId == 3)
                    {
                        queryUpdate.ScheduleStatusID = 5;
                        ContextPerRequest.CurrentData.SaveChanges();
                    }
                    else if (statusId == 2) // pending and no COI
                    {
                        if (query.EditType == "Add")
                        {
                            SendingPsychiatry addModel = new SendingPsychiatry();
                            addModel.FirstName = query.FirstName;
                            addModel.LastName = query.LastName;
                            addModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            addModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            addModel.BoardCertified = query.BoardCertifiedDescription;
                            addModel.BoardEligible = query.BoardEligibleDescription;
                            addModel.EmploymentType = query.EmploymentName;
                            addModel.HoursPerWeek = query.HoursWorked.ToString();
                            addModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.PsychiatryAddList.Add(addModel);
                        }
                        else if (query.EditType == "Edit" && query.COI)
                        {
                            SendingPsychiatry editModel = new SendingPsychiatry();
                            editModel.FirstName = query.FirstName;
                            editModel.LastName = query.LastName;
                            editModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            editModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            editModel.BoardCertified = query.BoardCertifiedDescription;
                            editModel.BoardEligible = query.BoardEligibleDescription;
                            editModel.EmploymentType = query.EmploymentName;
                            editModel.HoursPerWeek = query.HoursWorked.ToString();
                            editModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.PsychiatryEditList.Add(editModel);
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingPsychiatry deleteModel = new SendingPsychiatry();
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
                            emailModel.PsychiatryDeleteList.Add(deleteModel);
                        }

                        if (queryUpdate.ScheduleStatusID != 3)
                        {
                            queryUpdate.ScheduleStatusID = 5;
                            ContextPerRequest.CurrentData.SaveChanges();
                        }

                        PsychiatryScheduleHold model = new PsychiatryScheduleHold
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
                            OwnMalpracticeID = query.OwnMalpracticeID,
                            PsychiatryScheduleID = query.PsychiatryScheduleID,
                            RetroDate = query.RetroDate,
                            ScheduleStatusID = query.ScheduleStatusID,
                            SpecialtyID = query.SpecialtyID,
                            UserID = query.UserID
                        };
                        // need to transfer records.
                        TransferScheduleRecords(model);
                    }
                }
            }

            return emailModel;
        }

        public void TransferScheduleRecords(PsychiatryScheduleHold model)
        {
            if (model.EditType == "Edit")
            {
                var query = (from psychiatry in ContextPerRequest.CurrentData.PsychiatrySchedules
                             where psychiatry.PsychiatryScheduleID == model.PsychiatryScheduleID
                             select psychiatry).FirstOrDefault();

                if (query != null)
                {
                    query.BoardCertifiedID = model.BoardCertifiedID;
                    query.BoardEligibleID = model.BoardEligibleID;
                    query.ContractorEmployeeID = model.ContractorEmployeeID;
                    query.FirstName = model.FirstName;
                    query.HoursWorked = model.HoursWorked;
                    query.LastName = model.LastName;
                    query.MemberCoverageID = model.MemberCoverageID;
                    query.OwnMalpracticeID = model.OwnMalpracticeID;
                    query.RetroDate = model.RetroDate;
                    query.SpecialtyID = model.SpecialtyID;

                    query.DateAdded = model.DateAdded;
                    query.DateRemoved = model.DateRemoved;

                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
            else if (model.EditType == "Add")
            {
                PsychiatrySchedule psychiatry = new PsychiatrySchedule
                {
                    BoardCertifiedID = model.BoardCertifiedID,
                    BoardEligibleID = model.BoardEligibleID,
                    ContractorEmployeeID = model.ContractorEmployeeID,
                    DateAdded = model.DateAdded,
                    FirstName = model.FirstName,
                    HoursWorked = model.HoursWorked,
                    LastName = model.LastName,
                    MemberCoverageID = model.MemberCoverageID,
                    OwnMalpracticeID = model.OwnMalpracticeID,
                    RetroDate = model.RetroDate,
                    SpecialtyID = model.SpecialtyID
                };

                ContextPerRequest.CurrentData.PsychiatrySchedules.Add(psychiatry);
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else if (model.EditType == "Delete")
            {
                var deleteQuery = (from psychiatry in ContextPerRequest.CurrentData.PsychiatrySchedules
                                   where psychiatry.PsychiatryScheduleID == model.PsychiatryScheduleID
                                   select psychiatry).FirstOrDefault();
                if (deleteQuery != null)
                {
                    deleteQuery.DateRemoved = model.DateRemoved;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

    }

    public class EmailPsychiatry
    {
        public string MemberName { get; set; }
        public List<SendingPsychiatry> PsychiatryCOIList { get; set; }
        public List<SendingPsychiatry> PsychiatryAddList { get; set; }
        public List<SendingPsychiatry> PsychiatryDeleteList { get; set; }
        public List<SendingPsychiatry> PsychiatryEditList { get; set; }
    }
    public class SendingPsychiatry
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
