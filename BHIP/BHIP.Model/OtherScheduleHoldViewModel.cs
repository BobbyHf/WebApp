using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class OtherScheduleHoldViewModel
    {
        public int OtherScheduleHoldID { get; set; }
        public int OtherScheduleID { get; set; }
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


        public IEnumerable<OtherScheduleHoldViewModel> GetAllOtherScheduleHolds(int memberCoverageId)
        {
            var query = (from otherHold in ContextPerRequest.CurrentData.OtherScheduleHolds
                         join certified in ContextPerRequest.CurrentData.BoardCertifieds on otherHold.BoardCertifiedID equals certified.BoardCertifiedID
                         join eligible in ContextPerRequest.CurrentData.BoardEligibles on otherHold.BoardEligibleID equals eligible.BoardEligibleID
                         join malpractice in ContextPerRequest.CurrentData.Malpractices on otherHold.OwnMalpracticeID equals malpractice.MalpracticeID
                         //join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on otherHold.SpecialtyID equals specialty.SpecialtyTypeID
                         join employment in ContextPerRequest.CurrentData.EmploymentTypes on otherHold.ContractorEmployeeID equals employment.EmploymentTypeID
                         join users in ContextPerRequest.CurrentData.AspNetUsers on otherHold.UserID equals users.Id into uj
                         join status in ContextPerRequest.CurrentData.ScheduleStatus on otherHold.ScheduleStatusID equals status.ScheduleStatusID into sj
                         from users in uj.DefaultIfEmpty()
                         from status in sj.DefaultIfEmpty()
                         where otherHold.MemberCoverageID == memberCoverageId && otherHold.ScheduleStatusID != 4 && otherHold.ScheduleStatusID != 5
                         //orderby specialty.Description, otherHold.LastName
                         orderby otherHold.LastName
                         select new OtherScheduleHoldViewModel
                         {
                             BoardCertifiedDescription = certified.Description,
                             BoardEligibleDescription = eligible.Description,
                             EmploymentName = employment.Description,
                             DateAdded = otherHold.DateAdded,
                             DateRemoved = otherHold.DateRemoved,
                             FirstName = otherHold.FirstName,
                             HoursWorked = otherHold.HoursWorked,
                             LastName = otherHold.LastName,
                             MemberCoverageID = otherHold.MemberCoverageID,
                             OwnMalpracticeDescription = malpractice.Description,
                             OtherScheduleHoldID = otherHold.OtherScheduleHoldID,
                             OtherScheduleID = otherHold.OtherScheduleID,
                             RetroDate = otherHold.RetroDate,
                             //SpecialtyName = specialty.Description,
                             EditType = otherHold.EditType,
                             COI = otherHold.COI,
                             UserName = users.FirstName + " " + users.LastName,
                             UserEmail = users.Email,
                             StatusName = status.Description,
                             SpecialtyOther = otherHold.SpecialtyOther
                         });

            return query;
        }

        public OtherScheduleHoldViewModel GetAOtherScheduleHold(int OtherScheduleHoldId)
        {
            var query = (from other in ContextPerRequest.CurrentData.OtherScheduleHolds
                         where other.OtherScheduleHoldID == OtherScheduleHoldId
                         select new OtherScheduleHoldViewModel
                         {
                             BoardCertifiedID = other.BoardCertifiedID ?? 0,
                             BoardEligibleID = other.BoardEligibleID ?? 0,
                             ContractorEmployeeID = other.ContractorEmployeeID ?? 0,
                             DateAdded = other.DateAdded,
                             DateRemoved = other.DateRemoved,
                             FirstName = other.FirstName,
                             HoursWorked = other.HoursWorked,
                             LastName = other.LastName,
                             MemberCoverageID = other.MemberCoverageID,
                             OwnMalpracticeID = other.OwnMalpracticeID ?? 0,
                             OtherScheduleHoldID = other.OtherScheduleHoldID,
                             OtherScheduleID = other.OtherScheduleID,
                             RetroDate = other.RetroDate,
                             SpecialtyID = other.SpecialtyID ?? 0,
                             EditType = other.EditType,
                             COI = other.COI,
                             SpecialtyOther = other.SpecialtyOther
                         }).FirstOrDefault();

            return query;
        }


        public void OtherScheduleAdd(OtherScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            OtherScheduleHold other = new OtherScheduleHold
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
                OtherScheduleID = model.OtherScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = model.SpecialtyOther
            };

            ContextPerRequest.CurrentData.OtherScheduleHolds.Add(other);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void OtherScheduleEdit(OtherScheduleViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            OtherScheduleHold other = new OtherScheduleHold
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
                OtherScheduleID = model.OtherScheduleID,
                RetroDate = model.RetroDate,
                SpecialtyID = model.SpecialtyID,
                COI = model.COI,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = model.SpecialtyOther
            };

            ContextPerRequest.CurrentData.OtherScheduleHolds.Add(other);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void OtherScheduleDelete(OtherScheduleDeleteViewModel model)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from ot in ContextPerRequest.CurrentData.OtherSchedules
                         where ot.OtherScheduleID == model.OtherScheduleID
                         select ot).FirstOrDefault();

            OtherScheduleHold other = new OtherScheduleHold
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
                OtherScheduleID = query.OtherScheduleID,
                RetroDate = query.RetroDate,
                SpecialtyID = query.SpecialtyID,
                ScheduleStatusID = 2,
                UserID = UserId,
                SpecialtyOther = query.SpecialtyOther
            };

            ContextPerRequest.CurrentData.OtherScheduleHolds.Add(other);
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

        public void OtherScheduleHoldSave(OtherScheduleHoldViewModel model)
        {
            var query = (from other in ContextPerRequest.CurrentData.OtherScheduleHolds
                         where other.OtherScheduleHoldID == model.OtherScheduleHoldID
                         select other).FirstOrDefault();

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
                query.OtherScheduleID = model.OtherScheduleID;
                query.RetroDate = model.RetroDate;
                query.SpecialtyID = model.SpecialtyID;
                query.COI = model.COI;
                query.SpecialtyOther = model.SpecialtyOther;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void OtherScheduleHoldDelete(int otherScheduleScheduleHoldId)
        {
            string UserId = BHIP.Model.Helper.Security.GetLoggedInUserID();

            var query = (from other in ContextPerRequest.CurrentData.OtherScheduleHolds
                         where other.OtherScheduleHoldID == otherScheduleScheduleHoldId
                         select other).FirstOrDefault();

            if (query != null)
            {
                query.DateRemoved = DateTime.Now;
                query.ScheduleStatusID = 4;
                query.UserID = UserId;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        public EmailOtherSchedule OtherSchedulePendingApprove(string scheduleIds)
        {
            EmailOtherSchedule emailModel = new EmailOtherSchedule();
            emailModel.OtherScheduleCOIList = new List<SendingOtherSchedule>();
            emailModel.OtherScheduleAddList = new List<SendingOtherSchedule>();
            emailModel.OtherScheduleDeleteList = new List<SendingOtherSchedule>();
            emailModel.OtherScheduleEditList = new List<SendingOtherSchedule>();

            List<string> listScheduleID = new List<string>();

            listScheduleID = scheduleIds.Split(',').ToList();

            foreach (var item in listScheduleID)
            {
                int scheduleHoldID = Convert.ToInt32(item.ToString());

                var query = (from other in ContextPerRequest.CurrentData.OtherScheduleHolds
                             join certified in ContextPerRequest.CurrentData.BoardCertifieds on other.BoardCertifiedID equals certified.BoardCertifiedID
                             join eligible in ContextPerRequest.CurrentData.BoardEligibles on other.BoardEligibleID equals eligible.BoardEligibleID
                             join malpractice in ContextPerRequest.CurrentData.Malpractices on other.OwnMalpracticeID equals malpractice.MalpracticeID
                             //join specialty in ContextPerRequest.CurrentData.SpecialtyTypes on other.SpecialtyID equals specialty.SpecialtyTypeID
                             join employment in ContextPerRequest.CurrentData.EmploymentTypes on other.ContractorEmployeeID equals employment.EmploymentTypeID
                             where other.OtherScheduleHoldID == scheduleHoldID
                             select new OtherScheduleHoldViewModel
                             {
                                 BoardCertifiedDescription = certified.Description,
                                 BoardEligibleDescription = eligible.Description,
                                 EmploymentName = employment.Description,
                                 DateAdded = other.DateAdded,
                                 DateRemoved = other.DateRemoved,
                                 FirstName = other.FirstName,
                                 HoursWorked = other.HoursWorked,
                                 LastName = other.LastName,
                                 MemberCoverageID = other.MemberCoverageID,
                                 OwnMalpracticeDescription = malpractice.Description,
                                 OtherScheduleHoldID = other.OtherScheduleHoldID,
                                 OtherScheduleID = other.OtherScheduleID,
                                 RetroDate = other.RetroDate,
                                 //SpecialtyName = specialty.Description,
                                 BoardCertifiedID = other.BoardCertifiedID ?? 0,
                                 BoardEligibleID = other.BoardEligibleID ?? 0,
                                 COI = other.COI,
                                 ContractorEmployeeID = other.ContractorEmployeeID ?? 0,
                                 EditType = other.EditType,
                                 OwnMalpracticeID = other.OwnMalpracticeID ?? 0,
                                 ScheduleStatusID = other.ScheduleStatusID,
                                 //SpecialtyID = other.SpecialtyID ?? 0,
                                 SpecialtyOther = other.SpecialtyOther
                             }).FirstOrDefault();

                var queryUpdate = (from oth in ContextPerRequest.CurrentData.OtherScheduleHolds
                                   where oth.OtherScheduleHoldID == scheduleHoldID
                                   select oth).FirstOrDefault<OtherScheduleHold>();

                if (query != null && queryUpdate != null)
                {
                    int statusId = query.ScheduleStatusID;

                    if (statusId == 2 && query.COI == true) // pending and COI is checked.
                    {
                        SendingOtherSchedule coiModel = new SendingOtherSchedule();
                        coiModel.FirstName = query.FirstName;
                        coiModel.LastName = query.LastName;
                        coiModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes select specialty.Description).FirstOrDefault();
                        coiModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                        coiModel.BoardCertified = query.BoardCertifiedDescription;
                        coiModel.BoardEligible = query.BoardEligibleDescription;
                        coiModel.EmploymentType = query.EmploymentName;
                        coiModel.HoursPerWeek = query.HoursWorked.ToString();
                        coiModel.Malpractice = query.OwnMalpracticeDescription;
                        emailModel.OtherScheduleCOIList.Add(coiModel);

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
                        if (query.EditType == "Add" && query.COI)
                        {
                            SendingOtherSchedule addModel = new SendingOtherSchedule();
                            addModel.FirstName = query.FirstName;
                            addModel.LastName = query.LastName;
                            addModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            addModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            addModel.BoardCertified = query.BoardCertifiedDescription;
                            addModel.BoardEligible = query.BoardEligibleDescription;
                            addModel.EmploymentType = query.EmploymentName;
                            addModel.HoursPerWeek = query.HoursWorked.ToString();
                            addModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.OtherScheduleAddList.Add(addModel);
                        }
                        else if (query.EditType == "Edit" && query.COI)
                        {
                            SendingOtherSchedule editModel = new SendingOtherSchedule();
                            editModel.FirstName = query.FirstName;
                            editModel.LastName = query.LastName;
                            editModel.Title = (from specialty in ContextPerRequest.CurrentData.SpecialtyTypes where specialty.SpecialtyTypeID == query.SpecialtyID select specialty.Description).FirstOrDefault();
                            editModel.DateOfHire = (query.RetroDate.HasValue == true ? Convert.ToDateTime(query.RetroDate).ToShortDateString() : string.Empty);
                            editModel.BoardCertified = query.BoardCertifiedDescription;
                            editModel.BoardEligible = query.BoardEligibleDescription;
                            editModel.EmploymentType = query.EmploymentName;
                            editModel.HoursPerWeek = query.HoursWorked.ToString();
                            editModel.Malpractice = query.OwnMalpracticeDescription;
                            emailModel.OtherScheduleEditList.Add(editModel);
                        }
                        else if (query.EditType == "Delete")
                        {
                            SendingOtherSchedule deleteModel = new SendingOtherSchedule();
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
                            emailModel.OtherScheduleDeleteList.Add(deleteModel);
                        }

                        if (queryUpdate.ScheduleStatusID != 3)
                        {
                            queryUpdate.ScheduleStatusID = 5;
                            ContextPerRequest.CurrentData.SaveChanges();
                        }

                        OtherScheduleHold model = new OtherScheduleHold
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
                            OtherScheduleID = query.OtherScheduleID,
                            RetroDate = query.RetroDate,
                            ScheduleStatusID = query.ScheduleStatusID,
                            SpecialtyID = query.SpecialtyID,
                            SpecialtyOther = query.SpecialtyOther,
                            UserID = query.UserID
                        };
                        // need to transfer records.
                        TransferScheduleRecords(model);
                    }
                }
            }

            return emailModel;
        }

        public void TransferScheduleRecords(OtherScheduleHold model)
        {
            if (model.EditType == "Edit")
            {
                var query = (from other in ContextPerRequest.CurrentData.OtherSchedules
                             where other.OtherScheduleID == model.OtherScheduleID
                             select other).FirstOrDefault();

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
                    query.SpecialtyOther = model.SpecialtyOther;
                    query.DateAdded = model.DateAdded;
                    query.DateRemoved = model.DateRemoved;

                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
            else if (model.EditType == "Add")
            {
                OtherSchedule other = new OtherSchedule
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
                    SpecialtyID = model.SpecialtyID,
                    SpecialtyOther = model.SpecialtyOther
                };

                ContextPerRequest.CurrentData.OtherSchedules.Add(other);
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else if (model.EditType == "Delete")
            {
                var deleteQuery = (from other in ContextPerRequest.CurrentData.OtherSchedules
                                   where other.OtherScheduleID == model.OtherScheduleID
                                   select other).FirstOrDefault();
                if (deleteQuery != null)
                {
                    deleteQuery.DateRemoved = model.DateRemoved;
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

    }

    public class EmailOtherSchedule
    {
        public string MemberName { get; set; }
        public List<SendingOtherSchedule> OtherScheduleCOIList { get; set; }
        public List<SendingOtherSchedule> OtherScheduleAddList { get; set; }
        public List<SendingOtherSchedule> OtherScheduleDeleteList { get; set; }
        public List<SendingOtherSchedule> OtherScheduleEditList { get; set; }
    }
    public class SendingOtherSchedule
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