using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BHIP.Model.Helper
{
    public static class MemberInformation
    {

        public static IEnumerable<SelectListItem> GetStateList(int StateId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataState = from states in ContextPerRequest.CurrentData.States
                            orderby states.Name ascending
                            select states;
            returnValue = dataState.ToList().Select(u => new SelectListItem
            {
                Text = u.Abbr,
                Value = u.StateId.ToString(),
                Selected = (u.StateId == StateId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetEntityType(int entityId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataEntity = from entity in ContextPerRequest.CurrentData.EntityTypes
                             where entity.IsActive == true
                            orderby entity.Description ascending
                            select entity;
            returnValue = dataEntity.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.EntityTypeID.ToString(),
                Selected = (u.EntityTypeID == entityId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetMemberStatus(int statusId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataStatus = from status in ContextPerRequest.CurrentData.MemberStatus
                             where status.IsActive == true
                             orderby status.Description ascending
                             select status;
            returnValue = dataStatus.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.StatusID.ToString(),
                Selected = (u.StatusID == statusId)
            });

            return returnValue;
        }
        public static IEnumerable<SelectListItem> GetOwnLease(int ownLeaseId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataOwn = from own in ContextPerRequest.CurrentData.OwnLeases
                             where own.IsActive == true
                             orderby own.Description ascending
                             select own;
            returnValue = dataOwn.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.OwnLeaseID.ToString(),
                Selected = (u.OwnLeaseID == ownLeaseId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetContructionType(int constTypeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataConst = from constType in ContextPerRequest.CurrentData.ConstructionTypes
                          where constType.IsActive == true
                          orderby constType.Description ascending
                          select constType;
            returnValue = dataConst.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.ConstTypeID.ToString(),
                Selected = (u.ConstTypeID == constTypeId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetFireBurglar(int fireBurglarId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataFire = from fire in ContextPerRequest.CurrentData.FireBurglars
                          where fire.IsActive == true
                          orderby fire.Description ascending
                          select fire;
            returnValue = dataFire.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.FireBurglarID.ToString(),
                Selected = (u.FireBurglarID == fireBurglarId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetSpecialty(int specialtyId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataSpecialty = from specialty in ContextPerRequest.CurrentData.SpecialtyTypes
                           where specialty.IsActive == true
                           orderby specialty.Description ascending
                           select specialty;
            returnValue = dataSpecialty.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.SpecialtyTypeID.ToString(),
                Selected = (u.SpecialtyTypeID == specialtyId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetBoardCertified(int certifiedId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataCertified = from certified in ContextPerRequest.CurrentData.BoardCertifieds
                           where certified.IsActive == true
                           orderby certified.Description ascending
                           select certified;
            returnValue = dataCertified.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.BoardCertifiedID.ToString(),
                Selected = (u.BoardCertifiedID == certifiedId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetBoardEligible(int eligibleId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataEligible = from eligible in ContextPerRequest.CurrentData.BoardEligibles
                               where eligible.IsActive == true
                               orderby eligible.Description ascending
                               select eligible;
            returnValue = dataEligible.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.BoardEligibleID.ToString(),
                Selected = (u.BoardEligibleID == eligibleId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetEmployeeType(int employeeTypeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataEmployee = from employee in ContextPerRequest.CurrentData.EmploymentTypes
                               where employee.IsActive == true
                               orderby employee.Description ascending
                               select employee;
            returnValue = dataEmployee.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.EmploymentTypeID.ToString(),
                Selected = (u.EmploymentTypeID == employeeTypeId)
            });

            return returnValue;
        }

        public static IEnumerable<SelectListItem> GetMalpractice(int malpracticeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataMalpractice = from malpractice in ContextPerRequest.CurrentData.Malpractices
                                  where malpractice.IsActive == true
                                  orderby malpractice.Description ascending
                                  select malpractice;
            returnValue = dataMalpractice.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.MalpracticeID.ToString(),
                Selected = (u.MalpracticeID == malpracticeId)
            });

            return returnValue;
        }
        public static string GetAutoCard()
        {
            int memberId = BHIP.Model.Helper.Security.GetMemberID();

            string docName = (from member in ContextPerRequest.CurrentData.Members
                              where member.MemberId == memberId
                              select member.AutoCard).FirstOrDefault<string>();

            return docName;
        }

        public static string GetMemberName()
        {
            int memberId = BHIP.Model.Helper.Security.GetMemberID();

            string docName = (from member in ContextPerRequest.CurrentData.Members
                              where member.MemberId == memberId
                              select member.AutoCard).FirstOrDefault<string>();

            return docName;
        }

        public static string GetMemberNameByID(int memberId)
        {
            string docName = (from member in ContextPerRequest.CurrentData.Members
                              where member.MemberId == memberId
                              select member.AutoCard).FirstOrDefault<string>();

            return docName;
        }

        public static int GetMemberID(int memberCoverageId)
        {

            return (from member in ContextPerRequest.CurrentData.MemberCoverages
                              where member.MemberCoverageID == memberCoverageId
                              select member.MemberId).FirstOrDefault<int>();

        }

        public static string GetMemberNameByRenewalID(int renewalId)
        {
            return (from mem in ContextPerRequest.CurrentData.Members
                        join renew in ContextPerRequest.CurrentData.Renewals on mem.MemberId equals renew.MemberID
                    where renew.RenewalID == renewalId
                        select mem.Name).FirstOrDefault<string>();
        }

        public static string GetAuthorizeRepEmail(int memberCoverageId)
        {

            return (from member in ContextPerRequest.CurrentData.MemberCoverages
                    where member.MemberCoverageID == memberCoverageId
                    select member.AuthorizeEmail).FirstOrDefault<string>();

        }
        public static string GetContactEmail(int memberCoverageId)
        {

            return (from member in ContextPerRequest.CurrentData.MemberCoverages
                    where member.MemberCoverageID == memberCoverageId
                    select member.ContactEmail).FirstOrDefault<string>();

        }

        public static int GetMemberCoverageIDByRenewalID(int renewalId)
        {
            int memberCoverageId = 0;

            int? memberId = (from renewal in ContextPerRequest.CurrentData.Renewals
                            where renewal.RenewalID == renewalId
                            select renewal.MemberID).FirstOrDefault<int?>();
            if (memberId != null)
            {
                memberCoverageId = (from member in ContextPerRequest.CurrentData.MemberCoverages
                        where member.MemberId == memberId
                        select member.MemberCoverageID).FirstOrDefault<int>();

            }

            return memberCoverageId;
        }
    }
}
