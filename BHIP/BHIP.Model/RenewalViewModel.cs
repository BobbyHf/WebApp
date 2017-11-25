using BHIP.Model.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Model
{
    public class RenewalViewModel
    {
        public int RenewalID { get; set; }
        public int MemberID { get; set; }
        public int MemberCoverageID { get; set; }
        public int CurrentYear { get; set; }

        public bool IsRenewLocked { get; set; }

        // General Information
        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Enter the address")]
        public string MailingAddress { get; set; }
        [Display(Name = "City:")]
        [Required(ErrorMessage = "Enter the city")]
        public string MailingCity { get; set; }
        [Display(Name = "Zip code:")]
        [Required(ErrorMessage = "Enter the zip code")]
        public string MailingZipcode { get; set; }
        [Display(Name = "State:")]
        [Required(ErrorMessage = "Enter the state")]
        public int? MailingStateID { get; set; }

        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Enter the address")]
        public string PhysicalAddress { get; set; }
        [Display(Name = "City:")]
        [Required(ErrorMessage = "Enter the city")]
        public string PhysicalCity { get; set; }
        [Display(Name = "State:")]
        [Required(ErrorMessage = "Enter the state")]
        public int? PhysicalStateID { get; set; }
        [Display(Name = "Zip code:")]
        [Required(ErrorMessage = "Enter the zip code")]
        public string PhysicalZipcode { get; set; }

        [Display(Name = "Phone Number:")]
        [Required(ErrorMessage = "Enter the phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Website:")]
        [Required(ErrorMessage = "Enter the website")]
        public string Website { get; set; }

        // Contact Information
        [Display(Name = "Prefix:")]
        [Required(ErrorMessage = "Enter the prefix")]
        public string ContactPrefix { get; set; }
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Enter the first name")]
        public string ContactFirstName { get; set; }
        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Enter the last name")]
        public string ContactLastName { get; set; }
        [Display(Name = "Title:")]
        [Required(ErrorMessage = "Enter the title")]
        public string ContactTitle { get; set; }
        [Display(Name = "Phone:")]
        [Required(ErrorMessage = "Enter the phone")]
        public string ContactPhone { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Enter the email")]
        public string ContactEmail { get; set; }

        [Display(Name = "Prefix:")]
        [Required(ErrorMessage = "Enter the prefix")]
        public string AuthorizePrefix { get; set; }
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Enter the first name")]
        public string AuthorizeFirstName { get; set; }
        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Enter the last name")]
        public string AuthorizeLastName { get; set; }
        [Display(Name = "Title:")]
        [Required(ErrorMessage = "Enter the title")]
        public string AuthorizeTitle { get; set; }
        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Enter the address")]
        public string AuthorizeAddress1 { get; set; }
        [Display(Name = "City:")]
        [Required(ErrorMessage = "Enter the city")]
        public string AuthorizeCity { get; set; }
        [Display(Name = "Zip Code:")]
        [Required(ErrorMessage = "Enter the zip code")]
        public string AuthorizeZip { get; set; }
        [Display(Name = "Phone:")]
        [Required(ErrorMessage = "Enter the phone")]
        public string AuthorizePhone { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Enter the email")]
        public string AuthorizeEmail { get; set; }
        [Display(Name = "State:")]
        [Required(ErrorMessage = "Select the state")]
        public int? AuthorizeStateID { get; set; }

        // operations
        [Display(Name = "Federal ID #:")]
        [Required(ErrorMessage = "Enter the federal ID #")]
        public string FederalID { get; set; }
        [Display(Name = "Operations Start Date:")]
        [DataType(DataType.Time)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? OperationsStartDate { get; set; }
        [Display(Name = "Operation Type:")]
        public string OperationsType { get; set; }

        // licensing and accreditation
        public bool? LicenseRegs { get; set; }
        public bool? EthicViolations { get; set; }
        public string EthicDesc { get; set; }
        public bool? InspectAgency { get; set; }

        // Financial Information
        [Required(ErrorMessage = "*")]
        public int? CharitableContribLast12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? CharitableContribNext12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? GovFundingLast12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? GovFundingNext12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? FeeServiceLast12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? FeeServiceNext12 { get; set; }
        public string OtherDesc { get; set; }
        [Required(ErrorMessage = "*")]
        public int? OtherLast12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? OtherNext12 { get; set; }
        [Display(Name = "Money:")]
        public int? HoldMoney { get; set; }
        [Display(Name = "Checks Received:")]
        public int? HoldChecks { get; set; }
        [Display(Name = "Negotiable securities:")]
        public int? HoldSecurities { get; set; }
        [Display(Name = "None:")]
        public bool HoldNone { get; set; }


        [Required(ErrorMessage = "Enter the money on premise while open")]
        public int? MoneyOpen { get; set; }
        [Required(ErrorMessage = "Enter the money on premise overnight")]
        public int? MoneyOvernight { get; set; }
        [Required(ErrorMessage = "Enter the money off premise")]
        public int? MoneyOff { get; set; }
        [Required(ErrorMessage = "Enter the checks received on premise while open")]
        public int? ChecksOpen { get; set; }
        [Required(ErrorMessage = "Enter the checks received on premise overnight")]
        public int? ChecksOvernight { get; set; }
        [Required(ErrorMessage = "Enter the checks received off premise")]
        public int? ChecksOff { get; set; }
        [Required(ErrorMessage = "Enter the payroll on premise while open")]
        public int? PayrollOpen { get; set; }
        [Required(ErrorMessage = "Enter the payroll on premise overnight")]
        public int? PayrollOvernight { get; set; }
        [Required(ErrorMessage = "Enter the payroll off premise")]
        public int? PayrollOff { get; set; }
        public int? SecuritiesOpen { get; set; }
        public int? SecuritiesOvernight { get; set; }
        public int? SecuritiesOff { get; set; }
        public bool? TransportFunds { get; set; }

        [Display(Name = "Is there a safe on the premises?")]
        [Required(ErrorMessage = "select if there is a safe or not")]
        public bool? SafePremise { get; set; }
        [Display(Name = "Is there a burglar alarm on the premises?")]
        [Required(ErrorMessage = "Select if there is a burglar alarm")]
        public bool? AlarmPremise { get; set; }
        [Display(Name = "Does the agency's company provide any pension/welfare plans?")]
        [Required(ErrorMessage = "Enter the federal ID #")]
        public bool? AgencyPlans { get; set; }
        [Display(Name = "If \"Yes\", please provide the plan information below:")]
        public string AgencyPlanDesc { get; set; }


        // staff and provider information
        public int? NonunionFulltime { get; set; }
        public int? NonunionParttime { get; set; }
        public int? NonunionSeasonal { get; set; }
        public int? NonunionTemporary { get; set; }
        public int? NonunionIndependent { get; set; }
        public int? UnionFulltime { get; set; }
        public int? UnionParttime { get; set; }
        public int? UnionSeasonal { get; set; }
        public int? UnionTemporary { get; set; }
        public int? UnionIndependent { get; set; }
        public int? AdultDirectStaff { get; set; }
        public int? AdultClient { get; set; }
        public string AdultRatio { get; set; }
        public int? MinorDirectStaff { get; set; }
        public int? MinorClient { get; set; }
        public string MinorRatio { get; set; }
        public int? AnticipatedClient { get; set; }

        // Professional Liability Services
        public int? UnduplicatedSubstanceAbuseEstimated { get; set; }
        public int? UnduplicatedSubstanceAbuseProjected { get; set; }
        public int? UnduplicatedGeneralHealthEstimated { get; set; }
        public int? UnduplicatedGeneralHealthProjected { get; set; }
        public int? UnduplicatedMentallyEstimated { get; set; }
        public int? UnduplicatedMentallyProjected { get; set; }
        public int? UnduplicatedChildrenEstimated { get; set; }
        public int? UnduplicatedChildrenProjected { get; set; }

        public int? BillableSubstanceAbuseEstimated { get; set; }
        public int? BillableSubstanceAbuseProjected { get; set; }
        public int? BillableGeneralHealthEstimated { get; set; }
        public int? BillableGeneralHealthProjected { get; set; }
        public int? BillableMentalEstimated { get; set; }
        public int? BillableMentalProjected { get; set; }
        public int? BillableChildrenEstimated { get; set; }
        public int? BillableChildrenProjected { get; set; }

        public int? PopulationCaseManagementEstimated { get; set; }
        public int? PopulationCaseManagementProjected { get; set; }
        public int? PopulationPsychiatryEstimated { get; set; }
        public int? PopulationPsychiatryProjected { get; set; }
        public int? PopulationMethadoneEstimated { get; set; }
        public int? PopulationMethadoneProjected { get; set; }
        public int? PopulationLivingSkillsEstimated { get; set; }
        public int? PopulationLivingSkillsProjected { get; set; }
        public int? PopulationIndividualEstimated { get; set; }
        public int? PopulationIndividualProjected { get; set; }
        public int? PopulationFamilyEstimated { get; set; }
        public int? PopulationFamilyProjected { get; set; }
        public int? PopulationGroupEstimated { get; set; }
        public int? PopulationGroupProjected { get; set; }

        public int? ServedSubstanceAbuseNumOfBedCurrent { get; set; }
        public int? ServedSubstanceAbuseNumOfBedDayCurrent { get; set; }
        public int? ServedSubstanceAbuseNumOfBedNext { get; set; }
        public int? ServedSubstanceAbuseNumOfBedDayNext { get; set; }
        public int? ServedPsychiatricNumOfBedCurrent { get; set; }
        public int? ServedPsychiatricNumOfBedDayCurrent { get; set; }
        public int? ServedPsychiatricNumOfBedNext { get; set; }
        public int? ServerdPsychiatricNumOfBedDayNext { get; set; }

        public int? StabilizeGeneralHealthNumOfBedsCurrent { get; set; }
        public int? StabilizeGeneralHealthNumofBedDaysCurrent { get; set; }
        public int? StabilizeGeneralHealthNumOfBedsNext { get; set; }
        public int? StabilizeGeneralHealthNumOfBedDaysNext { get; set; }
        public int? StabilizeMentallyNumOfBedsCurrent { get; set; }
        public int? StabilizeMentallyNumOfBedDaysCurrent { get; set; }
        public int? StabilizeMentallyNumOfBedsNext { get; set; }
        public int? StabilizeMetallyNumOfBedDaysNext { get; set; }
        public int? StabilizeChildrenNumOfBedsCurrent { get; set; }
        public int? StabilizeChildrenNumOfBedDaysCurrent { get; set; }
        public int? StabilizeChildrenNumOfBedsNext { get; set; }
        public int? StabilizeChildrenNumOfBedDaysNext { get; set; }

        public int? RevenueOutGeneralMentalCurrent { get; set; }
        public int? RevenueOutGeneralMentalNext { get; set; }
        public int? RevenueOutMentalCurrent { get; set; }
        public int? RevenueOutMentalNext { get; set; }
        public int? RevenueOutChildrenCurrent { get; set; }
        public int? RevenueOutChildrenNext { get; set; }
        public int? RevenueOutOtherCurrent { get; set; }
        public int? RevenueOutOtherNext { get; set; }

        public int? RevenueInGeneralMentalCurrent { get; set; }
        public int? RevenueInGeneralMentalNext { get; set; }
        public int? RevenueInMentalCurrent { get; set; }
        public int? RevenueInMentalNext { get; set; }
        public int? RevenueInChildrentCurrent { get; set; }
        public int? RevenueInChildrentNext { get; set; }
        public int? RevenueInOther1Current { get; set; }
        public int? RevenueInOther1Next { get; set; }
        public int? RevenueInOther2Current { get; set; }
        public int? RevenueInOther2Next { get; set; }


        // Business Interruption
        public int? InPatientServicesYearEnd { get; set; }
        public int? InPatientServicesProjection { get; set; }
        public int? OutPatientServicesYearEnd { get; set; }
        public int? OutPatientServicesProjection { get; set; }
        public int? RentsLeasedYearEnd { get; set; }
        public int? RentsLeasedProjection { get; set; }
        public int? GrantsResearchYearEnd { get; set; }
        public int? GrantsResearchProjection { get; set; }
        public int? DonationsYearEnd { get; set; }
        public int? DonationsProjection { get; set; }
        public int? OtherIncomeYearEnd { get; set; }
        public int? OtherIncomeProjection { get; set; }
        public int? ContractualAdjustmentYearEnd { get; set; }
        public int? ContractualAdjustmentProjection { get; set; }
        public int? BadDeptYearEnd { get; set; }
        public int? BadDeptProjection { get; set; }
        public int? FreeServiceYearEnd { get; set; }
        public int? FreeServiceProjection { get; set; }
        public int? OutsideServiceYearEnd { get; set; }
        public int? OutsideServiceProjection { get; set; }
        public int? AnnualPayrollYearEnd { get; set; }
        public int? AnnualPayrollProjection { get; set; }

        public IEnumerable<BHIP.Model.LicenseViewModel> LicenseList { get; set; }
        public IEnumerable<BHIP.Model.AgencyPlanViewModel> AgencyPlanList { get; set; }
        public string HandleFundsGrid { get; set; }
        public string InspectionBodyGrid { get; set; }


        public IEnumerable<ContactScheduleViewModel> ContactList { get; set; }
        public IEnumerable<ContactScheduleHoldViewModel> ContactHoldList { get; set; }
        public IEnumerable<BHIP.Model.PsychiatryViewModel> PsychiatryList { get; set; }
        public IEnumerable<BHIP.Model.PsychiatryScheduleHoldViewModel> PsychiatryHoldList { get; set; }
        public IEnumerable<PrimaryCareViewModel> PrimaryCareList { get; set; }
        public IEnumerable<PrimaryCareHoldViewModel> PrimaryCareHoldList { get; set; }
        public IEnumerable<VehicleScheduleViewModel> VehicleList { get; set; }
        public IEnumerable<VehicleScheduleHoldViewModel> VehicleHoldList { get; set; }
        public IEnumerable<DriverInfoViewModel> DriverInfoList { get; set; }
        public IEnumerable<DriverInfoHoldViewModel> DriverInfoHoldList { get; set; }
        public IEnumerable<PropertyViewModel> PropertyList { get; set; }
        public IEnumerable<PropertyScheduleHoldViewModel> PropertyHoldList { get; set; }

        public IList<Questions> Operations1 { get; set; }
        public IList<Questions> Operations2 { get; set; }
        public IList<Questions> Operations3 { get; set; }
        public IList<Questions> Licensing1 { get; set; }
        public IList<Questions> Licensing2 { get; set; }
        public IList<Questions> Financial { get; set; }
        public IList<Questions> Staff { get; set; }
        public IList<Questions> Procedures1 { get; set; }
        public IList<Questions> Procedures2 { get; set; }
        public IList<Questions> Procedures3 { get; set; }
        public IList<Questions> ProfLiab1 { get; set; }
        public IList<Questions> PropQ { get; set; }
        public IList<Questions> Auto { get; set; }

        public int TotalBuilding { get; set; }
        public int TotalContent { get; set; }
        public int TotalInsurable { get; set; }
        public int TotalFootage { get; set; }
        public int CostSquareFoot { get; set; }

        public int? TotalAutos { get; set; }
        public int? TotalDrivers { get; set; }

        public bool? VisitAccord1 { get; set; }
        public bool? VisitAccord2 { get; set; }
        public bool? VisitAccord3 { get; set; }
        public bool? VisitAccord4 { get; set; }
        public bool? VisitAccord5 { get; set; }
        public bool? VisitAccord6 { get; set; }
        public bool? VisitAccord7 { get; set; }
        public bool? VisitAccord8 { get; set; }
        public bool? VisitAccord9 { get; set; }
        public bool? VisitAccord10 { get; set; }
        public bool? VisitAccord11 { get; set; }
        public bool? VisitAccord12 { get; set; }
        public bool? VisitAccord13 { get; set; }
        public bool? VisitAccord14 { get; set; }

        public IEnumerable<DocumentViewModel> Attachments { get; set; }

        public bool? Submitted { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string SubmittedUser { get; set; }
        public List<AspNetRole> UserRoles { get; set; }

        public RenewalViewModel()
        {

        }


        public RenewalViewModel(int id)
        {
            this.MemberID = id;

            if (id > 0)
            {
                //this.MemberCoverageID = GetMemberCoverageID(id);

                ContactScheduleViewModel contacts = new ContactScheduleViewModel();
                this.ContactList = contacts.GetContacts(MemberCoverageID);

                ContactScheduleHoldViewModel contactHold = new ContactScheduleHoldViewModel();
                this.ContactHoldList = contactHold.GetAllContactScheduleHolds(MemberCoverageID);

            }
        }

        public List<AspNetRole> GetUserRoles()
        {
            string securedUserId = Security.GetSecuredUserID();
            List<AspNetRole> roles = ContextPerRequest.CurrentData.AspNetRoles.Where(x => x.AspNetUsers.Any(x1 => x1.Id == securedUserId)).ToList();
            if (roles != null && roles.Count > 0)
            {

            }
            else
            {
                roles = new List<AspNetRole>();
            }
            return roles;
        }
        public bool IsLocked(int id, string userId)
        {
            var dataRenew = (from renew in ContextPerRequest.CurrentData.Renewals
                              where renew.RenewalID == id
                                  select renew).FirstOrDefault();

            if (dataRenew != null)
            {
                if ((dataRenew.IsLocked ?? false) == true)
                {
                    DateTime testDate = (dataRenew.LockTime ?? DateTime.Now).AddMinutes(15);
                    if (DateTime.Compare(testDate, DateTime.Now) < 0) // adding 15 minutes to the stored date, that date isn't later than now so the record should be unlocked.
                    {
                        return false; // the time is up so let the record be locked again.
                    }
                    else
                    {
                        if (dataRenew.LockUser == userId)
                        {
                            return false; // the current locked user is coming back so let them in.
                        }
                        else
                        {
                            // the record is still locked because the time isn't up
                            return true;
                        }
                    }
                }
                else
                {
                    // the record isn't locked.
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        public void LockRenewal(int id, string userId)
        {
            var dataRenewal = (from renew in ContextPerRequest.CurrentData.Renewals
                               where renew.RenewalID == id
                               select renew).FirstOrDefault();

            if (dataRenewal != null)
            {
                dataRenewal.LockTime = DateTime.Now;
                dataRenewal.LockUser = userId;
                dataRenewal.IsLocked = true;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void UnlockRenewal(int id)
        {
            var dataRenewal = (from renew in ContextPerRequest.CurrentData.Renewals
                               where renew.RenewalID == id
                               select renew).FirstOrDefault();

            if (dataRenewal != null)
            {
                dataRenewal.LockTime = null;
                dataRenewal.LockUser = null;
                dataRenewal.IsLocked = null;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        public IEnumerable<SelectListItem> GetMemberList(int memberId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataMembers = from tblMember in ContextPerRequest.CurrentData.Members
                              orderby tblMember.Name ascending
                              select tblMember;
            returnValue = dataMembers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.MemberId.ToString(),
                Selected = (u.MemberId == memberId)
            });

            return returnValue;
        }

        public int GetMemberCoverageID(int memberId)
        {
            int memberCoverageId = (from memberInfo in ContextPerRequest.CurrentData.MemberCoverages
                                    where memberInfo.MemberId == memberId
                                    select memberInfo.MemberCoverageID).FirstOrDefault();
            if (memberCoverageId > 0)
            {

                return memberCoverageId;
            }
            else
            {
                return 0;
            }
        }

        public bool CheckRenewalExists(int memberId)
        {
            // check to see if the record already exists

            var data = (from renewal in ContextPerRequest.CurrentData.Renewals
                        where renewal.MemberID == memberId &&
                        renewal.CurrentYear == ProjectGlobals.CurrentYear
                        select renewal);

            if (!data.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GetRenewalRecord(int memberId, int memberCoverageId)
        {
            VehicleScheduleViewModel vehicleModel = new VehicleScheduleViewModel();
            VehicleScheduleHoldViewModel vehicleHoldModel = new VehicleScheduleHoldViewModel();
            ContactScheduleViewModel contactModel = new ContactScheduleViewModel();
            ContactScheduleHoldViewModel contactHoldModel = new ContactScheduleHoldViewModel();
            PrimaryCareViewModel primaryModel = new PrimaryCareViewModel();
            PrimaryCareHoldViewModel primaryHoldModel = new PrimaryCareHoldViewModel();
            PropertyViewModel propertyModel = new PropertyViewModel();
            PropertyScheduleHoldViewModel propertyHoldModel = new PropertyScheduleHoldViewModel();
            PsychiatryScheduleHoldViewModel psychiatryHoldModel = new PsychiatryScheduleHoldViewModel();
            PsychiatryViewModel psychiatryModel = new PsychiatryViewModel();
            DriverInfoHoldViewModel driverHoldModel = new DriverInfoHoldViewModel();
            DriverInfoViewModel driverModel = new DriverInfoViewModel();
            LicenseViewModel licenseModel = new LicenseViewModel();
            AgencyPlanViewModel agencyModel = new AgencyPlanViewModel();

            var data = (from renewal in ContextPerRequest.CurrentData.Renewals
                        where renewal.MemberID == memberId &&
                        renewal.CurrentYear == ProjectGlobals.CurrentYear
                        select renewal).FirstOrDefault();

            this.AgencyPlanDesc = data.AgencyPlanDesc;
            this.AgencyPlanList = agencyModel.GetPlan(memberId);
            this.AgencyPlans = data.AgencyPlans;
            this.AlarmPremise = data.AlarmPremise;
            this.AnnualPayrollProjection = data.AnnualPayrollProjection;
            this.AnnualPayrollYearEnd = data.AnnualPayrollYearEnd;
            this.AnticipatedClient = data.AnticipatedClient;
            this.AuthorizeAddress1 = data.AuthorizeAddress1;
            this.AuthorizeCity = data.AuthorizeCity;
            this.AuthorizeEmail = data.AuthorizeEmail;
            this.AuthorizeFirstName = data.AuthorizeFirstName;
            this.AuthorizeLastName = data.AuthorizeLastName;
            this.AuthorizePhone = data.AuthorizePhone;
            this.AuthorizePrefix = data.AuthorizePrefix;
            this.AuthorizeStateID = data.AuthorizeStateID;
            this.AuthorizeTitle = data.AuthorizeTitle;
            this.AuthorizeZip = data.AuthorizeZip;
            this.BadDeptProjection = data.BadDeptProjection;
            this.BadDeptYearEnd = data.BadDeptYearEnd;
            this.BillableChildrenEstimated = data.BillableChildrenEstimated;
            this.BillableChildrenProjected = data.BillableChildrenProjected;
            this.BillableGeneralHealthEstimated = data.BillableGeneralHealthEstimated;
            this.BillableGeneralHealthProjected = data.BillableGeneralHealthProjected;
            this.BillableMentalEstimated = data.BillableMentalEstimated;
            this.BillableMentalProjected = data.BillableMentalProjected;
            this.BillableSubstanceAbuseEstimated = data.BillableSubstanceAbuseEstimated;
            this.BillableSubstanceAbuseProjected = data.BillableSubstanceAbuseProjected;
            this.CharitableContribLast12 = data.CharitableContribLast12;
            this.CharitableContribNext12 = data.CharitableContribNext12;
            this.ChecksOff = data.ChecksOff;
            this.ChecksOpen = data.ChecksOpen;
            this.ChecksOvernight = data.ChecksOvernight;
            this.ContactEmail = data.ContactEmail;
            this.ContactFirstName = data.ContactFirstName;
            this.ContactHoldList = contactHoldModel.GetAllContactScheduleHolds(memberCoverageId);
            this.ContactLastName = data.ContactLastName;
            this.ContactList = contactModel.GetContacts(memberCoverageId);
            this.ContactPhone = data.ContactPhone;
            this.ContactPrefix = data.ContactPrefix;
            this.ContactTitle = data.ContactTitle;
            this.ContractualAdjustmentProjection = data.ContractualAdjustmentProjection;
            this.ContractualAdjustmentYearEnd = data.ContractualAdjustmentYearEnd;
            this.CurrentYear = data.CurrentYear;
            this.DonationsProjection = data.DonationsProjection;
            this.DonationsYearEnd = data.DonationsYearEnd;
            this.DriverInfoHoldList = driverHoldModel.GetAllDriverInfoScheduleHolds(memberCoverageId);
            this.DriverInfoList = driverModel.GetAllDriverInfo(memberCoverageId);
            this.EthicDesc = data.EthicDesc;
            this.EthicViolations = data.EthicViolations;
            this.FederalID = data.FederalID;
            this.FeeServiceLast12 = data.FeeServiceLast12;
            this.FeeServiceNext12 = data.FeeServiceNext12;
            this.FreeServiceProjection = data.FreeServiceProjection;
            this.FreeServiceYearEnd = data.FreeServiceYearEnd;
            this.GovFundingLast12 = data.GovFundingLast12;
            this.GovFundingNext12 = data.GovFundingNext12;
            this.GrantsResearchProjection = data.GrantsResearchProjection;
            this.GrantsResearchYearEnd = data.GrantsResearchYearEnd;
            this.HoldChecks = data.HoldChecks;
            this.HoldMoney = data.HoldMoney;
            this.HoldNone = data.HoldNone ?? false;
            this.HoldSecurities = data.HoldSecurities;
            this.HandleFundsGrid = null; // need to fix this
            this.InPatientServicesProjection = data.InPatientServicesProjection;
            this.InPatientServicesYearEnd = data.InPatientServicesYearEnd;
            this.InspectAgency = data.InspectAgency;
            this.InspectionBodyGrid = null; // need to fix this
            this.LicenseList = licenseModel.GetLicense(memberId);
            this.MailingAddress = data.MailingAddress;
            this.MailingCity = data.MailingCity;
            this.MailingStateID = data.MailingStateID;
            this.MailingZipcode = data.MailingZipcode;
            this.MoneyOff = data.MoneyOff;
            this.MoneyOpen = data.MoneyOpen;
            this.MoneyOvernight = data.MoneyOvernight;
            this.NonunionFulltime = data.NonunionFulltime;
            this.NonunionIndependent = data.NonunionIndependent;
            this.NonunionParttime = data.NonunionParttime;
            this.NonunionSeasonal = data.NonunionSeasonal;
            this.NonunionTemporary = data.NonunionTemporary;
            this.OperationsStartDate = data.OperationsStartDate;
            this.OperationsType = data.OperationsType;
            this.OtherDesc = data.OtherDesc;
            this.OtherIncomeProjection = data.OtherIncomeProjection;
            this.OtherIncomeYearEnd = data.OtherIncomeYearEnd;
            this.OtherLast12 = data.OtherLast12;
            this.OtherNext12 = data.OtherNext12;
            this.OutPatientServicesProjection = data.OutPatientServicesProjection;
            this.OutPatientServicesYearEnd = data.OutPatientServicesYearEnd;
            this.OutsideServiceProjection = data.OutsideServiceProjection;
            this.OutsideServiceYearEnd = data.OutsideServiceYearEnd;
            this.PayrollOff = data.PayrollOff;
            this.PayrollOpen = data.PayrollOpen;
            this.PayrollOvernight = data.PayrollOvernight;
            this.PhoneNumber = data.PhoneNumber;
            this.PhysicalAddress = data.PhysicalAddress;
            this.PhysicalCity = data.PhysicalCity;
            this.PhysicalStateID = data.PhysicalStateID;
            this.PhysicalZipcode = data.PhysicalZipcode;
            this.PopulationCaseManagementEstimated = data.PopulationCaseManagementEstimated;
            this.PopulationCaseManagementProjected = data.PopulationCaseManagementProjected;
            this.PopulationFamilyEstimated = data.PopulationFamilyEstimated;
            this.PopulationFamilyProjected = data.PopulationFamilyProjected;
            this.PopulationGroupEstimated = data.PopulationGroupEstimated;
            this.PopulationGroupProjected = data.PopulationGroupProjected;
            this.PopulationIndividualEstimated = data.PopulationIndividualEstimated;
            this.PopulationIndividualProjected = data.PopulationIndividualProjected;
            this.PopulationLivingSkillsEstimated = data.PopulationLivingSkillsEstimated;
            this.PopulationLivingSkillsProjected = data.PopulationLivingSkillsProjected;
            this.PopulationMethadoneEstimated = data.PopulationMethadoneEstimated;
            this.PopulationMethadoneProjected = data.PopulationMethadoneProjected;
            this.PopulationPsychiatryEstimated = data.PopulationPsychiatryEstimated;
            this.PopulationPsychiatryProjected = data.PopulationPsychiatryProjected;
            this.PrimaryCareHoldList = primaryHoldModel.GetAllPrimaryCareHolds(memberCoverageId);
            this.PrimaryCareList = primaryModel.GetAllPrimaryCareSchedule(memberCoverageId);
            this.PropertyHoldList = propertyHoldModel.GetAllPropertyScheduleHold(memberCoverageId);
            this.PropertyList = propertyModel.GetAllPropertySchedule(memberCoverageId);
            this.PsychiatryHoldList = psychiatryHoldModel.GetAllPsychiatryScheduleHolds(memberCoverageId);
            this.PsychiatryList = psychiatryModel.GetAllPsychiatrySchedule(memberCoverageId);
            this.RenewalID = data.RenewalID;
            this.RentsLeasedProjection = data.RentsLeasedProjection;
            this.RentsLeasedYearEnd = data.RentsLeasedYearEnd;
            this.RevenueInChildrentCurrent = data.RevenueInChildrentCurrent;
            this.RevenueInChildrentNext = data.RevenueInChildrentNext;
            this.RevenueInGeneralMentalCurrent = data.RevenueInGeneralMentalCurrent;
            this.RevenueInGeneralMentalNext = data.RevenueInGeneralMentalNext;
            this.RevenueInMentalCurrent = data.RevenueInMentalCurrent;
            this.RevenueInMentalNext = data.RevenueInMentalNext;
            this.RevenueInOther1Current = data.RevenueInOther1Current;
            this.RevenueInOther1Next = data.RevenueInOther1Next;
            this.RevenueInOther2Current = data.RevenueInOther2Current;
            this.RevenueInOther2Next = data.RevenueInOther2Next;
            this.RevenueOutChildrenCurrent = data.RevenueOutChildrenCurrent;
            this.RevenueOutChildrenNext = data.RevenueOutChildrenNext;
            this.RevenueOutGeneralMentalCurrent = data.RevenueOutGeneralMentalCurrent;
            this.RevenueOutGeneralMentalNext = data.RevenueOutGeneralMentalNext;
            this.RevenueOutMentalCurrent = data.RevenueOutMentalCurrent;
            this.RevenueOutMentalNext = data.RevenueOutMentalNext;
            this.RevenueOutOtherCurrent = data.RevenueOutOtherCurrent;
            this.RevenueOutOtherNext = data.RevenueOutOtherNext;
            this.SafePremise = data.SafePremise;
            this.ServedPsychiatricNumOfBedCurrent = data.ServedPsychiatricNumOfBedCurrent;
            this.ServedPsychiatricNumOfBedDayCurrent = data.ServedPsychiatricNumOfBedDayCurrent;
            this.ServedPsychiatricNumOfBedNext = data.ServedPsychiatricNumOfBedNext;
            this.ServedSubstanceAbuseNumOfBedCurrent = data.ServedSubstanceAbuseNumOfBedCurrent;
            this.ServedSubstanceAbuseNumOfBedDayCurrent = data.ServedSubstanceAbuseNumOfBedDayCurrent;
            this.ServedSubstanceAbuseNumOfBedDayNext = data.ServedSubstanceAbuseNumOfBedDayNext;
            this.ServedSubstanceAbuseNumOfBedNext = data.ServedSubstanceAbuseNumOfBedNext;
            this.ServerdPsychiatricNumOfBedDayNext = data.ServerdPsychiatricNumOfBedDayNext;
            this.StabilizeChildrenNumOfBedDaysCurrent = data.StabilizeChildrenNumOfBedDaysCurrent;
            this.StabilizeChildrenNumOfBedDaysNext = data.StabilizeChildrenNumOfBedDaysNext;
            this.StabilizeChildrenNumOfBedsCurrent = data.StabilizeChildrenNumOfBedsCurrent;
            this.StabilizeChildrenNumOfBedsNext = data.StabilizeChildrenNumOfBedsNext;
            this.StabilizeGeneralHealthNumofBedDaysCurrent = data.StabilizeGeneralHealthNumofBedDaysCurrent;
            this.StabilizeGeneralHealthNumOfBedDaysNext = data.StabilizeGeneralHealthNumOfBedDaysNext;
            this.StabilizeGeneralHealthNumOfBedsCurrent = data.StabilizeGeneralHealthNumOfBedsCurrent;
            this.StabilizeGeneralHealthNumOfBedsNext = data.StabilizeGeneralHealthNumOfBedsNext;
            this.StabilizeMentallyNumOfBedDaysCurrent = data.StabilizeMentallyNumOfBedDaysCurrent;
            this.StabilizeMentallyNumOfBedsCurrent = data.StabilizeMentallyNumOfBedsCurrent;
            this.StabilizeMentallyNumOfBedsNext = data.StabilizeMentallyNumOfBedsNext;
            this.StabilizeMetallyNumOfBedDaysNext = data.StabilizeMetallyNumOfBedDaysNext;
            this.Submitted = data.Submitted;
            this.SubmittedDate = data.SubmittedDate;
            this.SubmittedUser = data.SubmittedUser;
            this.UnduplicatedChildrenEstimated = data.UnduplicatedChildrenEstimated;
            this.UnduplicatedChildrenProjected = data.UnduplicatedChildrenProjected;
            this.UnduplicatedGeneralHealthEstimated = data.UnduplicatedGeneralHealthEstimated;
            this.UnduplicatedGeneralHealthProjected = data.UnduplicatedGeneralHealthProjected;
            this.UnduplicatedMentallyEstimated = data.UnduplicatedMentallyEstimated;
            this.UnduplicatedMentallyProjected = data.UnduplicatedMentallyProjected;
            this.UnduplicatedSubstanceAbuseEstimated = data.UnduplicatedSubstanceAbuseEstimated;
            this.UnduplicatedSubstanceAbuseProjected = data.UnduplicatedSubstanceAbuseProjected;
            this.UnionFulltime = data.UnionFulltime;
            this.UnionIndependent = data.UnionIndependent;
            this.UnionParttime = data.UnionParttime;
            this.UnionSeasonal = data.UnionSeasonal;
            this.UnionTemporary = data.UnionTemporary;
            this.VehicleHoldList = vehicleHoldModel.GetAllVehicleHolds(memberCoverageId);
            this.VehicleList = vehicleModel.GetVehicles(memberCoverageId);
            this.VisitAccord1 = data.VisitAccord1;
            this.VisitAccord10 = data.VisitAccord10;
            this.VisitAccord11 = data.VisitAccord11;
            this.VisitAccord12 = data.VisitAccord12;
            this.VisitAccord13 = data.VisitAccord13;
            this.VisitAccord14 = data.VisitAccord14;
            this.VisitAccord2 = data.VisitAccord2;
            this.VisitAccord3 = data.VisitAccord3;
            this.VisitAccord4 = data.VisitAccord4;
            this.VisitAccord5 = data.VisitAccord5;
            this.VisitAccord6 = data.VisitAccord6;
            this.VisitAccord7 = data.VisitAccord7;
            this.VisitAccord8 = data.VisitAccord8;
            this.VisitAccord9 = data.VisitAccord9;
            this.Website = data.Website;
            this.AdultDirectStaff = data.AdultDirectStaff;
            this.AdultClient = data.AdultClient;
            this.AdultRatio = data.AdultRatio;
            this.MinorDirectStaff = data.MinorDirectStaff;
            this.MinorClient = data.MinorClient;
            this.MinorRatio = data.MinorRatio;
            this.TotalAutos = data.TotalAutos;
            this.TotalDrivers = data.TotalDrivers;
            this.TransportFunds = data.TransportFunds;
            this.SecuritiesOff = data.SecuritiesOff;
            this.SecuritiesOpen = data.SecuritiesOpen;
            this.SecuritiesOvernight = data.SecuritiesOvernight;
        }

        public int CreateRenewalRecord(int memberId)
        {
            var query = (from member in ContextPerRequest.CurrentData.MemberCoverages
                         where member.MemberId == memberId
                         select member).FirstOrDefault();


            Renewal renew = new Renewal
            {
                AgencyPlanDesc = string.Empty,
                AgencyPlans = null,
                AlarmPremise = null,
                AnnualPayrollProjection = null,
                AnnualPayrollYearEnd = null,
                AnticipatedClient = null,
                AuthorizeAddress1 = (query.AuthorizeAddress1 == null ? string.Empty : query.AuthorizeAddress1),
                AuthorizeCity = (query.AuthorizeCity == null ? string.Empty : query.AuthorizeCity),
                AuthorizeEmail = (query.AuthorizeEmail == null ? string.Empty : query.AuthorizeEmail),
                AuthorizeFirstName = (query.AuthorizeFirstName == null ? string.Empty : query.AuthorizeFirstName),
                AuthorizeLastName = (query.AuthorizeLastName == null ? string.Empty : query.AuthorizeLastName),
                AuthorizePhone = (query.AuthorizePhone == null ? string.Empty : query.AuthorizePhone),
                AuthorizePrefix = (query.AuthorizePrefix == null ? string.Empty : query.AuthorizePrefix),
                AuthorizeStateID = (query.AuthorizeStateID == null ? 0 : query.AuthorizeStateID),
                AuthorizeTitle = (query.AuthorizeTitle == null ? string.Empty : query.AuthorizeTitle),
                AuthorizeZip = (query.AuthorizeZip == null ? string.Empty : query.AuthorizeZip),
                BadDeptProjection = null,
                BadDeptYearEnd = null,
                BillableChildrenEstimated = null,
                BillableChildrenProjected = null,
                BillableGeneralHealthEstimated = null,
                BillableGeneralHealthProjected = null,
                BillableMentalEstimated = null,
                BillableMentalProjected = null,
                BillableSubstanceAbuseEstimated = null,
                BillableSubstanceAbuseProjected = null,
                CharitableContribLast12 = null,
                CharitableContribNext12 = null,
                ChecksOff = null,
                ChecksOpen = null,
                ChecksOvernight = null,
                ContactEmail = (query.ContactEmail == null ? string.Empty : query.ContactEmail),
                ContactFirstName = (query.ContactFirstName == null ? string.Empty : query.ContactFirstName),
                ContactLastName = (query.ContactLastName == null ? string.Empty : query.ContactLastName),
                ContactPhone = (query.ContactPhone == null ? string.Empty : query.ContactPhone),
                ContactPrefix = (query.ContactPrefix == null ? string.Empty : query.ContactPrefix),
                ContactTitle = (query.ContactTitle == null ? string.Empty : query.ContactTitle),
                ContractualAdjustmentProjection = null,
                ContractualAdjustmentYearEnd = null,
                CurrentYear = ProjectGlobals.CurrentYear,
                DonationsProjection = null,
                DonationsYearEnd = null,
                EthicDesc = string.Empty,
                EthicViolations = null,
                FederalID = (query.FederalID == null ? string.Empty : query.FederalID),
                FeeServiceLast12 = null,
                FeeServiceNext12 = null,
                FreeServiceProjection = null,
                FreeServiceYearEnd = null,
                GovFundingLast12 = null,
                GovFundingNext12 = null,
                GrantsResearchProjection = null,
                GrantsResearchYearEnd = null,
                HoldChecks = null,
                HoldMoney = null,
                HoldNone = null,
                HoldSecurities = null,
                InPatientServicesProjection = null,
                InPatientServicesYearEnd = null,
                InspectAgency = null,
                LicenseRegs = null,
                MailingAddress = (query.MailAddress1 == null ? string.Empty : query.MailAddress1),
                MailingCity = (query.MailCity == null ? string.Empty : query.MailCity),
                MailingStateID = (query.MailStateID == null ? 0 : query.MailStateID),
                MailingZipcode = (query.MailZip == null ? string.Empty : query.MailZip),
                MemberID = memberId,
                MoneyOff = null,
                MoneyOpen = null,
                MoneyOvernight = null,
                NonunionFulltime = null,
                NonunionIndependent = null,
                NonunionParttime = null,
                NonunionSeasonal = null,
                NonunionTemporary = null,
                OperationsStartDate = (query.OperationsStartDate == null ? null : query.OperationsStartDate),
                OperationsType = "Non-profit corporation",
                OtherDesc = string.Empty,
                OtherIncomeProjection = null,
                OtherIncomeYearEnd = null,
                OtherLast12 = null,
                OtherNext12 = null,
                OutPatientServicesProjection = null,
                OutPatientServicesYearEnd = null,
                OutsideServiceProjection = null,
                OutsideServiceYearEnd = null,
                PayrollOff = null,
                PayrollOpen = null,
                PayrollOvernight = null,
                PhoneNumber = (query.MemberPhone == null ? string.Empty : query.MemberPhone),
                PhysicalAddress = (query.PrimaryAddress1 == null ? string.Empty : query.PrimaryAddress1),
                PhysicalCity = (query.PrimaryCity == null ? string.Empty : query.PrimaryCity),
                PhysicalStateID = (query.PrimaryStateID == null ? 0 : query.PrimaryStateID),
                PhysicalZipcode = (query.PrimaryZip == null ? string.Empty : query.PrimaryZip),
                PopulationCaseManagementEstimated = null,
                PopulationCaseManagementProjected = null,
                PopulationFamilyEstimated = null,
                PopulationFamilyProjected = null,
                PopulationGroupEstimated = null,
                PopulationGroupProjected = null,
                PopulationIndividualEstimated = null,
                PopulationIndividualProjected = null,
                PopulationLivingSkillsEstimated = null,
                PopulationLivingSkillsProjected = null,
                PopulationMethadoneEstimated = null,
                PopulationMethadoneProjected = null,
                PopulationPsychiatryEstimated = null,
                PopulationPsychiatryProjected = null,
                RentsLeasedProjection = null,
                RentsLeasedYearEnd = null,
                RevenueInChildrentCurrent = null,
                RevenueInChildrentNext = null,
                RevenueInGeneralMentalCurrent = null,
                RevenueInGeneralMentalNext = null,
                RevenueInMentalCurrent = null,
                RevenueInMentalNext = null,
                RevenueInOther1Current = null,
                RevenueInOther1Next = null,
                RevenueInOther2Current = null,
                RevenueInOther2Next = null,
                RevenueOutChildrenCurrent = null,
                RevenueOutChildrenNext = null,
                RevenueOutGeneralMentalCurrent = null,
                RevenueOutGeneralMentalNext = null,
                RevenueOutMentalCurrent = null,
                RevenueOutMentalNext = null,
                RevenueOutOtherCurrent = null,
                RevenueOutOtherNext = null,
                SafePremise = null,
                ServedPsychiatricNumOfBedCurrent = null,
                ServedPsychiatricNumOfBedDayCurrent = null,
                ServedPsychiatricNumOfBedNext = null,
                ServedSubstanceAbuseNumOfBedCurrent = null,
                ServedSubstanceAbuseNumOfBedDayCurrent = null,
                ServedSubstanceAbuseNumOfBedDayNext = null,
                ServedSubstanceAbuseNumOfBedNext = null,
                ServerdPsychiatricNumOfBedDayNext = null,
                StabilizeChildrenNumOfBedDaysCurrent = null,
                StabilizeChildrenNumOfBedDaysNext = null,
                StabilizeChildrenNumOfBedsCurrent = null,
                StabilizeChildrenNumOfBedsNext = null,
                StabilizeGeneralHealthNumofBedDaysCurrent = null,
                StabilizeGeneralHealthNumOfBedDaysNext = null,
                StabilizeGeneralHealthNumOfBedsCurrent = null,
                StabilizeGeneralHealthNumOfBedsNext = null,
                StabilizeMentallyNumOfBedDaysCurrent = null,
                StabilizeMentallyNumOfBedsCurrent = null,
                StabilizeMentallyNumOfBedsNext = null,
                StabilizeMetallyNumOfBedDaysNext = null,
                Submitted = null,
                SubmittedDate = null,
                SubmittedUser = null,
                UnduplicatedChildrenEstimated = null,
                UnduplicatedChildrenProjected = null,
                UnduplicatedGeneralHealthEstimated = null,
                UnduplicatedGeneralHealthProjected = null,
                UnduplicatedMentallyEstimated = null,
                UnduplicatedMentallyProjected = null,
                UnduplicatedSubstanceAbuseEstimated = null,
                UnduplicatedSubstanceAbuseProjected = null,
                UnionFulltime = null,
                UnionIndependent = null,
                UnionParttime = null,
                UnionSeasonal = null,
                UnionTemporary = null,
                VisitAccord1 = null,
                VisitAccord10 = null,
                VisitAccord11 = null,
                VisitAccord12 = null,
                VisitAccord13 = null,
                VisitAccord14 = null,
                VisitAccord2 = null,
                VisitAccord3 = null,
                VisitAccord4 = null,
                VisitAccord5 = null,
                VisitAccord6 = null,
                VisitAccord7 = null,
                VisitAccord8 = null,
                VisitAccord9 = null,
                Website = (query.MemberWebsite == null ? string.Empty : query.MemberWebsite),
                AdultClient = null,
                AdultDirectStaff = null,
                AdultRatio = string.Empty,
                MinorClient = null,
                MinorDirectStaff = null,
                MinorRatio = string.Empty,
                SecuritiesOff = null,
                SecuritiesOpen = null,
                TotalAutos = null,
                SecuritiesOvernight = null,
                TotalDrivers = null,
                TransportFunds = null
            };

            ContextPerRequest.CurrentData.Renewals.Add(renew);
            ContextPerRequest.CurrentData.SaveChanges();

            return renew.RenewalID;
        }

        public void SaveRenewal(RenewalViewModel model)
        {
            var data = (from renew in ContextPerRequest.CurrentData.Renewals
                        where renew.RenewalID == model.RenewalID
                        select renew).FirstOrDefault();

            data.AgencyPlanDesc = model.AgencyPlanDesc;
            data.AgencyPlans = model.AgencyPlans;
            data.AlarmPremise = model.AlarmPremise;
            data.AnnualPayrollProjection = model.AnnualPayrollProjection;
            data.AnnualPayrollYearEnd = model.AnnualPayrollYearEnd;
            data.AuthorizeAddress1 = model.AuthorizeAddress1;
            data.AuthorizeCity = model.AuthorizeCity;
            data.AuthorizeEmail = model.AuthorizeEmail;
            data.AuthorizeFirstName = model.AuthorizeFirstName;
            data.AuthorizeLastName = model.AuthorizeLastName;
            data.AuthorizePhone = model.AuthorizePhone;
            data.AuthorizePrefix = model.AuthorizePrefix;
            data.AuthorizeStateID = model.AuthorizeStateID;
            data.AuthorizeTitle = model.AuthorizeTitle;
            data.AuthorizeZip = model.AuthorizeZip;
            data.BadDeptProjection = model.BadDeptProjection;
            data.BadDeptYearEnd = model.BadDeptYearEnd;
            data.BillableChildrenEstimated = model.BillableChildrenEstimated;
            data.BillableChildrenProjected = model.BillableChildrenProjected;
            data.BillableGeneralHealthEstimated = model.BillableGeneralHealthEstimated;
            data.BillableGeneralHealthProjected = model.BillableGeneralHealthProjected;
            data.BillableMentalEstimated = model.BillableMentalEstimated;
            data.BillableMentalProjected = model.BillableMentalProjected;
            data.BillableSubstanceAbuseEstimated = model.BillableSubstanceAbuseEstimated;
            data.BillableSubstanceAbuseProjected = model.BillableSubstanceAbuseProjected;
            data.CharitableContribLast12 = model.CharitableContribLast12;
            data.CharitableContribNext12 = model.CharitableContribNext12;
            data.ChecksOff = model.ChecksOff;
            data.ChecksOpen = model.ChecksOpen;
            data.ChecksOvernight = model.ChecksOvernight;
            data.ContactEmail = model.ContactEmail;
            data.ContactFirstName = model.ContactFirstName;
            data.ContactLastName = model.ContactLastName;
            data.ContactPhone = model.ContactPhone;
            data.ContactPrefix = model.ContactPrefix;
            data.ContactTitle = model.ContactTitle;
            data.ContractualAdjustmentProjection = model.ContractualAdjustmentProjection;
            data.ContractualAdjustmentYearEnd = model.ContractualAdjustmentYearEnd;
            data.CurrentYear = model.CurrentYear;
            data.DonationsProjection = model.DonationsProjection;
            data.DonationsYearEnd = model.DonationsYearEnd;
            data.EthicDesc = model.EthicDesc;
            data.EthicViolations = model.EthicViolations;
            //data.FederalID = model.FederalID;
            data.FeeServiceLast12 = model.FeeServiceLast12;
            data.FeeServiceNext12 = model.FeeServiceNext12;
            data.FreeServiceProjection = model.FreeServiceProjection;
            data.FreeServiceYearEnd = model.FreeServiceYearEnd;
            data.GovFundingLast12 = model.GovFundingLast12;
            data.GovFundingNext12 = model.GovFundingNext12;
            data.GrantsResearchProjection = model.GrantsResearchProjection;
            data.GrantsResearchYearEnd = model.GrantsResearchYearEnd;
            data.HoldChecks = model.HoldChecks;
            data.HoldMoney = model.HoldMoney;
            data.HoldNone = model.HoldNone;
            data.HoldSecurities = model.HoldSecurities;
            data.InPatientServicesProjection = model.InPatientServicesProjection;
            data.InPatientServicesYearEnd = model.InPatientServicesYearEnd;
            data.InspectAgency = model.InspectAgency;
            data.MailingAddress = model.MailingAddress;
            data.MailingCity = model.MailingCity;
            data.MailingStateID = model.MailingStateID;
            data.MailingZipcode = model.MailingZipcode;
            data.MoneyOff = model.MoneyOff;
            data.MoneyOpen = model.MoneyOpen;
            data.MoneyOvernight = model.MoneyOvernight;
            data.NonunionFulltime = model.NonunionFulltime;
            data.NonunionIndependent = model.NonunionIndependent;
            data.NonunionParttime = model.NonunionParttime;
            data.NonunionSeasonal = model.NonunionSeasonal;
            data.NonunionTemporary = model.NonunionTemporary;
            //data.OperationsStartDate = model.OperationsStartDate;
            //data.OperationsType = model.OperationsType;
            data.OtherDesc = model.OtherDesc;
            data.OtherIncomeProjection = model.OtherIncomeProjection;
            data.OtherIncomeYearEnd = model.OtherIncomeYearEnd;
            data.OtherLast12 = model.OtherLast12;
            data.OtherNext12 = model.OtherNext12;
            data.OutPatientServicesProjection = model.OutPatientServicesProjection;
            data.OutPatientServicesYearEnd = model.OutPatientServicesYearEnd;
            data.OutsideServiceProjection = model.OutsideServiceProjection;
            data.OutsideServiceYearEnd = model.OutsideServiceYearEnd;
            data.PayrollOff = model.PayrollOff;
            data.PayrollOpen = model.PayrollOpen;
            data.PayrollOvernight = model.PayrollOvernight;
            data.PhoneNumber = model.PhoneNumber;
            data.PhysicalAddress = model.PhysicalAddress;
            data.PhysicalCity = model.PhysicalCity;
            data.PhysicalStateID = model.PhysicalStateID;
            data.PhysicalZipcode = model.PhysicalZipcode;
            data.PopulationCaseManagementEstimated = model.PopulationCaseManagementEstimated;
            data.PopulationCaseManagementProjected = model.PopulationCaseManagementProjected;
            data.PopulationFamilyEstimated = model.PopulationFamilyEstimated;
            data.PopulationFamilyProjected = model.PopulationFamilyProjected;
            data.PopulationGroupEstimated = model.PopulationGroupEstimated;
            data.PopulationGroupProjected = model.PopulationGroupProjected;
            data.PopulationIndividualEstimated = model.PopulationIndividualEstimated;
            data.PopulationIndividualProjected = model.PopulationIndividualProjected;
            data.PopulationLivingSkillsEstimated = model.PopulationLivingSkillsEstimated;
            data.PopulationLivingSkillsProjected = model.PopulationLivingSkillsProjected;
            data.PopulationMethadoneEstimated = model.PopulationMethadoneEstimated;
            data.PopulationMethadoneProjected = model.PopulationMethadoneProjected;
            data.PopulationPsychiatryEstimated = model.PopulationPsychiatryEstimated;
            data.PopulationPsychiatryProjected = model.PopulationPsychiatryProjected;
            data.RentsLeasedProjection = model.RentsLeasedProjection;
            data.RentsLeasedYearEnd = model.RentsLeasedYearEnd;
            data.RevenueInChildrentCurrent = model.RevenueInChildrentCurrent;
            data.RevenueInChildrentNext = model.RevenueInChildrentNext;
            data.RevenueInGeneralMentalCurrent = model.RevenueInGeneralMentalCurrent;
            data.RevenueInGeneralMentalNext = model.RevenueInGeneralMentalNext;
            data.RevenueInMentalCurrent = model.RevenueInMentalCurrent;
            data.RevenueInMentalNext = model.RevenueInMentalNext;
            data.RevenueInOther1Current = model.RevenueInOther1Current;
            data.RevenueInOther1Next = model.RevenueInOther1Next;
            data.RevenueInOther2Current = model.RevenueInOther2Current;
            data.RevenueInOther2Next = model.RevenueInOther2Next;
            data.RevenueOutChildrenCurrent = model.RevenueOutChildrenCurrent;
            data.RevenueOutChildrenNext = model.RevenueOutChildrenNext;
            data.RevenueOutGeneralMentalCurrent = model.RevenueOutGeneralMentalCurrent;
            data.RevenueOutGeneralMentalNext = model.RevenueOutGeneralMentalNext;
            data.RevenueOutMentalCurrent = model.RevenueOutMentalCurrent;
            data.RevenueOutMentalNext = model.RevenueOutMentalNext;
            data.RevenueOutOtherCurrent = model.RevenueOutOtherCurrent;
            data.RevenueOutOtherNext = model.RevenueOutOtherNext;
            data.SafePremise = model.SafePremise;
            data.ServedPsychiatricNumOfBedCurrent = model.ServedPsychiatricNumOfBedCurrent;
            data.ServedPsychiatricNumOfBedDayCurrent = model.ServedPsychiatricNumOfBedDayCurrent;
            data.ServedPsychiatricNumOfBedNext = model.ServedPsychiatricNumOfBedNext;
            data.ServedSubstanceAbuseNumOfBedCurrent = model.ServedSubstanceAbuseNumOfBedCurrent;
            data.ServedSubstanceAbuseNumOfBedDayCurrent = model.ServedSubstanceAbuseNumOfBedDayCurrent;
            data.ServedSubstanceAbuseNumOfBedDayNext = model.ServedSubstanceAbuseNumOfBedDayNext;
            data.ServedSubstanceAbuseNumOfBedNext = model.ServedSubstanceAbuseNumOfBedNext;
            data.ServerdPsychiatricNumOfBedDayNext = model.ServerdPsychiatricNumOfBedDayNext;
            data.StabilizeChildrenNumOfBedDaysCurrent = model.StabilizeChildrenNumOfBedDaysCurrent;
            data.StabilizeChildrenNumOfBedDaysNext = model.StabilizeChildrenNumOfBedDaysNext;
            data.StabilizeChildrenNumOfBedsCurrent = model.StabilizeChildrenNumOfBedsCurrent;
            data.StabilizeChildrenNumOfBedsNext = model.StabilizeChildrenNumOfBedsNext;
            data.StabilizeGeneralHealthNumofBedDaysCurrent = model.StabilizeGeneralHealthNumofBedDaysCurrent;
            data.StabilizeGeneralHealthNumOfBedDaysNext = model.StabilizeGeneralHealthNumOfBedDaysNext;
            data.StabilizeGeneralHealthNumOfBedsCurrent = model.StabilizeGeneralHealthNumOfBedsCurrent;
            data.StabilizeGeneralHealthNumOfBedsNext = model.StabilizeGeneralHealthNumOfBedsNext;
            data.StabilizeMentallyNumOfBedDaysCurrent = model.StabilizeMentallyNumOfBedDaysCurrent;
            data.StabilizeMentallyNumOfBedsCurrent = model.StabilizeMentallyNumOfBedsCurrent;
            data.StabilizeMentallyNumOfBedsNext = model.StabilizeMentallyNumOfBedsNext;
            data.StabilizeMetallyNumOfBedDaysNext = model.StabilizeMetallyNumOfBedDaysNext;
            data.Submitted = model.Submitted;
            data.SubmittedDate = model.SubmittedDate;
            data.SubmittedUser = model.SubmittedUser;
            data.UnduplicatedChildrenEstimated = model.UnduplicatedChildrenEstimated;
            data.UnduplicatedChildrenProjected = model.UnduplicatedChildrenProjected;
            data.UnduplicatedGeneralHealthEstimated = model.UnduplicatedGeneralHealthEstimated;
            data.UnduplicatedGeneralHealthProjected = model.UnduplicatedGeneralHealthProjected;
            data.UnduplicatedMentallyEstimated = model.UnduplicatedMentallyEstimated;
            data.UnduplicatedMentallyProjected = model.UnduplicatedMentallyProjected;
            data.UnduplicatedSubstanceAbuseEstimated = model.UnduplicatedSubstanceAbuseEstimated;
            data.UnduplicatedSubstanceAbuseProjected = model.UnduplicatedSubstanceAbuseProjected;
            data.UnionFulltime = model.UnionFulltime;
            data.UnionIndependent = model.UnionIndependent;
            data.UnionParttime = model.UnionParttime;
            data.UnionSeasonal = model.UnionSeasonal;
            data.UnionTemporary = model.UnionTemporary;
            data.VisitAccord1 = model.VisitAccord1;
            data.VisitAccord10 = model.VisitAccord10;
            data.VisitAccord11 = model.VisitAccord11;
            data.VisitAccord12 = model.VisitAccord12;
            data.VisitAccord13 = model.VisitAccord13;
            data.VisitAccord14 = model.VisitAccord14;
            data.VisitAccord2 = model.VisitAccord2;
            data.VisitAccord3 = model.VisitAccord3;
            data.VisitAccord4 = model.VisitAccord4;
            data.VisitAccord5 = model.VisitAccord5;
            data.VisitAccord6 = model.VisitAccord6;
            data.VisitAccord7 = model.VisitAccord7;
            data.VisitAccord8 = model.VisitAccord8;
            data.VisitAccord9 = model.VisitAccord9;
            data.Website = model.Website;
            data.AdultClient = model.AdultClient;
            data.AdultDirectStaff = model.AdultDirectStaff;
            data.AdultRatio = model.AdultRatio;
            data.MinorClient = model.MinorClient;
            data.MinorDirectStaff = model.MinorDirectStaff;
            data.MinorRatio = model.MinorRatio;
            data.AnticipatedClient = model.AnticipatedClient;
            data.TotalAutos = model.TotalAutos;
            data.TotalDrivers = model.TotalDrivers;
            data.SecuritiesOff = model.SecuritiesOff;
            data.SecuritiesOpen = model.SecuritiesOpen;
            data.SecuritiesOvernight = model.SecuritiesOvernight;
            data.TransportFunds = model.TransportFunds;
            data.LockTime = DateTime.Now;

            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void InitializeQuestions(int renewalId, int memberId)
        {
            var data = (from quest in ContextPerRequest.CurrentData.Questions
                        select quest.QuestionID).ToList();

            foreach (var item in data)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer
                {
                    Answer = null,
                    CurrentYear = ProjectGlobals.CurrentYear,
                    MemberID = memberId,
                    RenewalID = renewalId,
                    QuestionID = Convert.ToInt32(item)
                };

                ContextPerRequest.CurrentData.QuestionAnswers.Add(questionAnswer);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        public string GetInpsectionBody(int renewalId)
        {
            if (renewalId > 0)
            {
                var data = (from inspect in ContextPerRequest.CurrentData.InspectionBodies
                            where inspect.RenewalID == renewalId
                            orderby inspect.InspectName
                            select inspect);

                IList<InspectionBodyViewModel> inspectList = new List<InspectionBodyViewModel>();

                foreach (var item in data)
                {
                    InspectionBodyViewModel objInspect = new InspectionBodyViewModel();
                    objInspect.InspectName = item.InspectName;
                    objInspect.InspectType = item.InspectType;
                    inspectList.Add(objInspect);
                    objInspect = null;
                }

                return JsonConvert.SerializeObject(inspectList);
            }
            else
            {
                return JsonConvert.SerializeObject(new InspectionBodyViewModel[0]);
            }
        }

        public void SaveInspectionBody(string inspections, int renewalId)
        {
            ContextPerRequest.CurrentData.InspectionBodies.Where(w => w.RenewalID == renewalId).ToList().ForEach(inspect => ContextPerRequest.CurrentData.InspectionBodies.Remove(inspect));
            ContextPerRequest.CurrentData.SaveChanges();

            IList<InspectionBodyViewModel> inspectList = new List<InspectionBodyViewModel>();
            inspectList = JsonConvert.DeserializeObject<List<InspectionBodyViewModel>>(inspections);

            foreach (var item in inspectList)
            {
                if (item.InspectName != null && item.InspectType != null)
                {
                    InspectionBody inspect = new InspectionBody
                    {
                        DateAdded = DateTime.Now,
                        InspectName = item.InspectName,
                        InspectType = item.InspectType,
                        IsActive = true,
                        RenewalID = renewalId
                    };

                    ContextPerRequest.CurrentData.InspectionBodies.Add(inspect);
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }

        public string GetHandleFunds(int renewalId)
        {
            if (renewalId > 0)
            {
                var data = (from funds in ContextPerRequest.CurrentData.HandleFunds
                            where funds.RenewalID == renewalId
                            orderby funds.JobFunction
                            select funds);

                IList<HandleFundsViewModel> fundList = new List<HandleFundsViewModel>();

                foreach (var item in data)
                {
                    HandleFundsViewModel objFund = new HandleFundsViewModel();
                    objFund.JobFunction = item.JobFunction;
                    objFund.NumOfEmployees = item.NumOfEmployees;
                    fundList.Add(objFund);
                    objFund = null;
                }

                return JsonConvert.SerializeObject(fundList);
            }
            else
            {
                return JsonConvert.SerializeObject(new HandleFundsViewModel[0]);
            }
        }

        public void SaveHandleFunds(string funds, int renewalId)
        {
            ContextPerRequest.CurrentData.HandleFunds.Where(w => w.RenewalID == renewalId).ToList().ForEach(handle => ContextPerRequest.CurrentData.HandleFunds.Remove(handle));
            ContextPerRequest.CurrentData.SaveChanges();

            IList<HandleFundsViewModel> fundList = new List<HandleFundsViewModel>();
            fundList = JsonConvert.DeserializeObject<List<HandleFundsViewModel>>(funds);

            foreach (var item in fundList)
            {
                if (item.JobFunction != null && item.NumOfEmployees != null)
                {
                    HandleFund handleFun = new HandleFund
                    {
                        DateAdded = DateTime.Now,
                        JobFunction = item.JobFunction,
                        NumOfEmployees = item.NumOfEmployees,
                        IsActive = true,
                        RenewalID = renewalId
                    };

                    ContextPerRequest.CurrentData.HandleFunds.Add(handleFun);
                    ContextPerRequest.CurrentData.SaveChanges();
                }
            }
        }
        public void SaveQuestions(RenewalViewModel model)
        {
            foreach (var item in model.Operations1)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Operations2)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Operations3)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Licensing1)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Licensing2)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Financial)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Staff)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Procedures1)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Procedures2)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Procedures3)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.ProfLiab1)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.PropQ)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

            foreach (var item in model.Auto)
            {
                SaveQuestionData(model.RenewalID, model.MemberID, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

            }

        }

        private void SaveQuestionData(int renewalId, int memberId, int questionID, int currentYear, string answer)
        {
            var dataQuestionData = (from QuestionData in ContextPerRequest.CurrentData.QuestionAnswers
                                    where QuestionData.QuestionID == questionID &&
                                    QuestionData.MemberID == memberId &&
                                    QuestionData.CurrentYear == currentYear
                                    select QuestionData).FirstOrDefault();

            if (dataQuestionData != null)
            {
                dataQuestionData.Answer = answer;
                ContextPerRequest.CurrentData.SaveChanges();
            }
            else
            {
                QuestionAnswer question = new QuestionAnswer()
                {
                    Answer = answer,
                    CurrentYear = currentYear,
                    QuestionID = questionID,
                    MemberID = memberId,
                    RenewalID = renewalId
                };
                ContextPerRequest.CurrentData.QuestionAnswers.Add(question);
                ContextPerRequest.CurrentData.SaveChanges();
            }

        }

        public bool SubmitRenewal(int renewalId, string userName, string ip, string userAgent)
        {
            var data = (from renewal in ContextPerRequest.CurrentData.Renewals
                        where renewal.RenewalID == renewalId
                        select renewal).FirstOrDefault();

            if (data != null)
            {
                data.Submitted = true;
                data.SubmittedDate = DateTime.Now;
                data.SubmittedUser = userName;
                data.IPAddress = ip;
                data.UserAgent = userAgent;

                ContextPerRequest.CurrentData.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }


    }
    public class Questions
    {
        public string ControlValue { get; set; }
        public int ControlId { get; set; }
    }
}