using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BHIP.Model
{
    public class MemberCoverageViewModel
    {
        public int MemberCoverageID { get; set; }
        public int MemberID { get; set; }
        public int filterTypeId { get; set; }
        public int PolicyYear { get; set; }
        public int RenewalID { get; set; }
        [Required]
        [Display(Name = "Member Name:")]
        public string MemberName { get; set; }
        [Display(Name = "Short Name:")]
        public string MemberNameAbbr { get; set; }
        [Display(Name = "Phone Number:")]
        public string MemberPhone { get; set; }
        [Display(Name = "Ext:")]
        public string MemberPhoneExt { get; set; }
        [Display(Name = "Website:")]
        public string MemberWebsite { get; set; }
        [Display(Name = "Federal ID#")]
        public string FederalID { get; set; }
        [Display(Name = "Entity Type:")]
        public int EntityTypeID { get; set; }
        [Display(Name = "Joined BHIP:")]
        public DateTime? JoinedBHIP { get; set; }
        [Display(Name = "Terminated:")]
        public DateTime? TerminatedBHIP { get; set; }
        [Display(Name = "Status:")]
        public int CurrentStatusID { get; set; }
        [Display(Name = "Address1:")]
        public string PrimaryAddress1 { get; set; }
        [Display(Name = "Address2:")]
        public string PrimaryAddress2 { get; set; }
        [Display(Name = "City:")]
        public string PrimaryCity { get; set; }
        [Display(Name = "Zip code:")]
        public string PrimaryZip { get; set; }
        [Display(Name = "State:")]
        public int PrimaryStateID { get; set; }
        [Display(Name = "Address1:")]
        public string MailAddress1 { get; set; }
        [Display(Name = "Address2:")]
        public string MailAddress2 { get; set; }
        [Display(Name = "City:")]
        public string MailCity { get; set; }
        [Display(Name = "State:")]
        public int MailStateID { get; set; }
        [Display(Name = "Zip code:")]
        public string MailZip { get; set; }

        [Display(Name = "Prefix:")]
        public string ContactPrefix { get; set; }
        [Display(Name = "First Name:")]
        public string ContactFirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string ContactLastName { get; set; }
        [Display(Name = "Title:")]
        public string ContactTitle { get; set; }
        [Display(Name = "Phone:")]
        public string ContactPhone { get; set; }
        [Display(Name = "Ext:")]
        public string ContactPhoneExt { get; set; }
        [Display(Name = "Email:")]
        public string ContactEmail { get; set; }
        [Display(Name = "Board Member:")]
        public bool IsBoardMember { get; set; }

        [Display(Name = "Prefix:")]
        public string AuthorizePrefix { get; set; }
        [Display(Name = "First Name:")]
        public string AuthorizeFirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string AuthorizeLastName { get; set; }
        [Display(Name = "Title:")]
        public string AuthorizeTitle { get; set; }
        [Display(Name = "Address1:")]
        public string AuthorizeAddress1 { get; set; }
        [Display(Name = "Address2:")]
        public string AuthorizeAddress2 { get; set; }
        [Display(Name = "City:")]
        public string AuthorizeCity { get; set; }
        [Display(Name = "State:")]
        public int AuthorizeStateID { get; set; }
        [Display(Name = "Zip code:")]
        public string AuthorizeZip { get; set; }
        [Display(Name = "Phone Number:")]
        public string AuthorizePhone { get; set; }
        [Display(Name = "Ext:")]
        public string AuthorizePhoneExt { get; set; }
        [Display(Name = "Email Address:")]
        public string AuthorizeEmail { get; set; }
        //public string SortOrderYear { get; set; }
        //public string SortOrderMakeModel { get; set; }
        //public string SortOrderVINOwnLease { get; set; }

        public int TotalBuilding { get; set; }
        public int TotalContent { get; set; }
        public int TotalInsurable { get; set; }
        public int TotalFootage { get; set; }
        public int CostSquareFoot { get; set; }

        public int? TotalAutos { get; set; }
        public int? TotalDrivers { get; set; }

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

        // operations
        [Display(Name = "Operations Start Date:")]
        [DataType(DataType.Time)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? OperationsStartDate { get; set; }
        [Display(Name = "Operation Type:")]
        public string OperationsType { get; set; }

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
        public bool? HoldNone { get; set; }

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

        public IEnumerable<ContactScheduleViewModel> ContactList { get; set; }
        public IEnumerable<ContactScheduleHoldViewModel> ContactHoldList { get; set; }
        public IEnumerable<VehicleScheduleViewModel> VehicleList { get; set; }
        public IEnumerable<VehicleScheduleHoldViewModel> VehicleHoldList { get; set; }
        public IEnumerable<PsychiatryViewModel> PsychiatryList { get; set; }
        public IEnumerable<PsychiatryScheduleHoldViewModel> PsychiatryHoldList { get; set; }
        public IEnumerable<PrimaryCareViewModel> PrimaryCareList { get; set; }
        public IEnumerable<PrimaryCareHoldViewModel> PrimaryCareHoldList { get; set; }
        public IEnumerable<DriverInfoViewModel> DriverInfoList { get; set; }
        public IEnumerable<DriverInfoHoldViewModel> DriverInfoHoldList { get; set; }
        public IEnumerable<PropertyViewModel> PropertyList { get; set; }
        public IEnumerable<PropertyScheduleHoldViewModel> PropertyHoldList { get; set; }
        public IEnumerable<OtherScheduleViewModel> OtherList { get; set; }
        public IEnumerable<OtherScheduleHoldViewModel> OtherHoldList { get; set; }
        public PremiumsViewModel Premiums { get; set; }

        public IEnumerable<DocumentViewModel> Attachments { get; set; }

        public MemberCoverageViewModel()
        {

        }
        public MemberCoverageViewModel(int memberId, int year)
        {
            if (memberId > 0)
            {
                GetMemberInformation(memberId, year);

                ContactScheduleViewModel contacts = new ContactScheduleViewModel();
                this.ContactList = contacts.GetContacts(MemberCoverageID);

                ContactScheduleHoldViewModel contactHold = new ContactScheduleHoldViewModel();
                this.ContactHoldList = contactHold.GetAllContactScheduleHolds(MemberCoverageID);

                VehicleScheduleViewModel vehicles = new VehicleScheduleViewModel();
                this.VehicleList = vehicles.GetVehicles(MemberCoverageID);
                if (this.VehicleList != null && this.VehicleList.Count() > 0)
                {
                    List<VehicleScheduleViewModel> lstVehicle = this.VehicleList.ToList();
                    lstVehicle[0].MemberID = memberId;
                    this.VehicleList = lstVehicle.ToList();
                }

                VehicleScheduleHoldViewModel vehicleHolds = new VehicleScheduleHoldViewModel();
                this.VehicleHoldList = vehicleHolds.GetAllVehicleHolds(MemberCoverageID);

                PsychiatryViewModel psychiatry = new PsychiatryViewModel();
                this.PsychiatryList = psychiatry.GetAllPsychiatrySchedule(MemberCoverageID);

                PsychiatryScheduleHoldViewModel psychiatryHold = new PsychiatryScheduleHoldViewModel();
                this.PsychiatryHoldList = psychiatryHold.GetAllPsychiatryScheduleHolds(MemberCoverageID);

                PrimaryCareViewModel primary = new PrimaryCareViewModel();
                this.PrimaryCareList = primary.GetAllPrimaryCareSchedule(MemberCoverageID);

                PrimaryCareHoldViewModel primaryHold = new PrimaryCareHoldViewModel();
                this.PrimaryCareHoldList = primaryHold.GetAllPrimaryCareHolds(MemberCoverageID);

                DriverInfoViewModel driver = new DriverInfoViewModel();
                this.DriverInfoList = driver.GetAllDriverInfo(MemberCoverageID);

                DriverInfoHoldViewModel driverHold = new DriverInfoHoldViewModel();
                this.DriverInfoHoldList = driverHold.GetAllDriverInfoScheduleHolds(MemberCoverageID);

                PropertyViewModel property = new PropertyViewModel();
                this.PropertyList = property.GetAllPropertySchedule(MemberCoverageID);

                PropertyScheduleHoldViewModel propertyHold = new PropertyScheduleHoldViewModel();
                this.PropertyHoldList = propertyHold.GetAllPropertyScheduleHold(MemberCoverageID);

                OtherScheduleHoldViewModel otherHold = new OtherScheduleHoldViewModel();
                this.OtherHoldList = otherHold.GetAllOtherScheduleHolds(MemberCoverageID);

                OtherScheduleViewModel other = new OtherScheduleViewModel();
                this.OtherList = other.GetAllOtherSchedule(MemberCoverageID);
            }
        }

        public IEnumerable<ContactScheduleViewModel> GetContactSchedule(int memberCoverageId)
        {
            var query = (from contacts in ContextPerRequest.CurrentData.ContactSchedules
                         where contacts.MemberCoverageID == memberCoverageId
                         select new ContactScheduleViewModel
                         {
                             ContactEmail = contacts.ContactEmail,
                             ContactFirstName = contacts.ContactFirstName,
                             ContactLastName = contacts.ContactLastName,
                             ContactPhone = contacts.ContactPhone,
                             ContactPhoneExt = contacts.ContactPhoneExt,
                             ContactScheduleID = contacts.ContactScheduleID,
                             ContactTitle = contacts.ContactTitle,
                             MemberCoverageID = contacts.MemberCoverageID
                         });

            return query;
        }


        public void GetMemberInformation(int memberId, int policyYear)
        {
            try
            {
                PropertyViewModel propertyModel = new PropertyViewModel();
                RenewalViewModel model = new RenewalViewModel(memberId);

                if (policyYear < 1)
                {
                    policyYear = BHIP.Model.ProjectGlobals.CurrentYear;
                }

                var query = (from memberInfo in ContextPerRequest.CurrentData.MemberCoverages
                             where memberInfo.MemberId == memberId
                             select memberInfo).FirstOrDefault();
                if (query == null)
                {
                    MemberCoverageID = InsertMemberInformation(memberId);
                    PolicyYear = policyYear;
                }
                else
                {
                    var data = (from renewal in ContextPerRequest.CurrentData.Renewals
                                where renewal.MemberID == memberId &&
                                renewal.CurrentYear == ProjectGlobals.CurrentYear
                                select renewal).FirstOrDefault();
                    this.AuthorizeAddress1 = query.AuthorizeAddress1;
                    this.AuthorizeAddress2 = query.AuthorizeAddress2;
                    this.AuthorizeCity = query.AuthorizeCity;
                    this.AuthorizeEmail = query.AuthorizeEmail;
                    this.AuthorizeFirstName = query.AuthorizeFirstName;
                    this.AuthorizeLastName = query.AuthorizeLastName;
                    this.AuthorizePhone = query.AuthorizePhone;
                    this.AuthorizePhoneExt = query.AuthorizePhoneExt;
                    this.AuthorizePrefix = query.AuthorizePrefix;
                    this.AuthorizeStateID = query.AuthorizeStateID ?? 0;
                    this.AuthorizeTitle = query.AuthorizeTitle;
                    this.AuthorizeZip = query.AuthorizeZip;
                    this.ContactEmail = query.ContactEmail;
                    this.ContactFirstName = query.ContactFirstName;
                    this.ContactLastName = query.ContactLastName;
                    this.ContactPhone = query.ContactPhone;
                    this.ContactPhoneExt = query.ContactPhoneExt;
                    this.ContactPrefix = query.ContactPrefix;
                    this.ContactTitle = query.ContactTitle;
                    this.CurrentStatusID = query.CurrentStatusID ?? 0;
                    this.EntityTypeID = query.EntityTypeID ?? 0;
                    this.FederalID = query.FederalID;
                    this.IsBoardMember = query.IsBoardMember ?? false;
                    this.JoinedBHIP = query.JoinedBHIP;
                    this.MailAddress1 = query.MailAddress1;
                    this.MailAddress2 = query.MailAddress2;
                    this.MailCity = query.MailCity;
                    this.MailStateID = query.MailStateID ?? 0;
                    this.MailZip = query.MailZip;
                    this.MemberCoverageID = query.MemberCoverageID;
                    this.MemberID = query.MemberId;
                    this.MemberName = query.MemberName;
                    this.MemberNameAbbr = query.MemberNameAbbr;
                    this.MemberPhone = query.MemberPhone;
                    this.MemberPhoneExt = query.MemberPhoneExt;
                    this.MemberWebsite = query.MemberWebsite;
                    this.PolicyYear = data.CurrentYear;
                    this.PrimaryAddress1 = query.PrimaryAddress1;
                    this.PrimaryAddress2 = query.PrimaryAddress2;
                    this.PrimaryCity = query.PrimaryCity;
                    this.PrimaryStateID = query.PrimaryStateID ?? 0;
                    this.PrimaryZip = query.PrimaryZip;
                    this.TerminatedBHIP = query.TerminatedBHIP;

                    this.TotalBuilding = propertyModel.TotalBuildingValue(model.GetMemberCoverageID(memberId));
                    this.TotalContent = propertyModel.TotalContentValue(model.GetMemberCoverageID(memberId));
                    this.TotalFootage = propertyModel.TotalSquareFeet(model.GetMemberCoverageID(memberId));

                    this.NonunionFulltime = data.NonunionFulltime;
                    this.NonunionParttime = data.NonunionParttime;
                    this.NonunionSeasonal = data.NonunionSeasonal;
                    this.NonunionTemporary = data.NonunionTemporary;
                    this.NonunionIndependent = data.NonunionIndependent;
                    this.UnionFulltime = data.UnionFulltime;
                    this.UnionParttime = data.UnionParttime;
                    this.UnionSeasonal = data.UnionSeasonal;
                    this.UnionTemporary = data.UnionTemporary;
                    this.UnionIndependent = data.UnionIndependent;
                    this.AdultDirectStaff = data.AdultDirectStaff;
                    this.AdultClient = data.AdultClient;
                    this.AdultRatio = data.AdultRatio;
                    this.MinorDirectStaff = data.MinorDirectStaff;
                    this.MinorClient = data.MinorClient;
                    this.MinorRatio = data.MinorRatio;
                    this.AnticipatedClient = data.AnticipatedClient;

                    if (this.TotalFootage > 0)
                    {
                        this.CostSquareFoot = (this.TotalBuilding + this.TotalContent) / this.TotalFootage;
                    }
                    else
                    {
                        this.CostSquareFoot = 0;
                    }
                    this.TotalInsurable = this.TotalBuilding + this.TotalContent;


                    this.TotalAutos = data.TotalAutos;
                    this.TotalDrivers = data.TotalDrivers;

                    this.OperationsStartDate = data.OperationsStartDate;
                    this.OperationsType = data.OperationsType;

                    this.MoneyOpen = data.MoneyOpen;
                    this.MoneyOvernight = data.MoneyOvernight;
                    this.MoneyOff = data.MoneyOff;
                    this.ChecksOpen = data.ChecksOpen;
                    this.ChecksOvernight = data.ChecksOvernight;
                    this.ChecksOff = data.ChecksOff;
                    this.PayrollOpen = data.PayrollOpen;
                    this.PayrollOvernight = data.PayrollOvernight;
                    this.PayrollOff = data.PayrollOff;
                    this.SecuritiesOpen = data.SecuritiesOpen;
                    this.SecuritiesOvernight = data.SecuritiesOvernight;
                    this.SecuritiesOff = data.SecuritiesOff;
                    this.TransportFunds = data.TransportFunds;

                    this.CharitableContribLast12 = data.CharitableContribLast12;
                    this.CharitableContribNext12 = data.CharitableContribNext12;
                    this.GovFundingLast12 = data.GovFundingLast12;
                    this.GovFundingNext12 = data.GovFundingNext12;
                    this.FeeServiceLast12 = data.FeeServiceLast12;
                    this.FeeServiceNext12 = data.FeeServiceNext12;
                    this.OtherLast12 = data.OtherLast12;
                    this.OtherNext12 = data.OtherNext12;
                    this.HoldMoney = data.HoldMoney;
                    this.HoldChecks = data.HoldChecks;
                    this.HoldSecurities = data.HoldSecurities;
                    this.HoldNone = data.HoldNone;

                    this.UnduplicatedSubstanceAbuseEstimated = data.UnduplicatedSubstanceAbuseEstimated;
                    this.UnduplicatedSubstanceAbuseProjected = data.UnduplicatedSubstanceAbuseProjected;
                    this.UnduplicatedGeneralHealthEstimated = data.UnduplicatedGeneralHealthEstimated;
                    this.UnduplicatedGeneralHealthProjected = data.UnduplicatedGeneralHealthProjected;
                    this.UnduplicatedMentallyEstimated = data.UnduplicatedMentallyEstimated;
                    this.UnduplicatedMentallyProjected = data.UnduplicatedMentallyProjected;
                    this.UnduplicatedChildrenEstimated = data.UnduplicatedChildrenEstimated;
                    this.UnduplicatedChildrenProjected = data.UnduplicatedChildrenProjected;

                    this.BillableSubstanceAbuseEstimated = data.BillableSubstanceAbuseEstimated;
                    this.BillableSubstanceAbuseProjected = data.BillableSubstanceAbuseProjected;
                    this.BillableGeneralHealthEstimated = data.BillableGeneralHealthEstimated;
                    this.BillableGeneralHealthProjected = data.BillableGeneralHealthProjected;
                    this.BillableMentalEstimated = data.BillableMentalEstimated;
                    this.BillableMentalProjected = data.BillableMentalProjected;
                    this.BillableChildrenEstimated = data.BillableChildrenEstimated;
                    this.BillableChildrenProjected = data.BillableChildrenProjected;

                    this.PopulationCaseManagementEstimated = data.PopulationCaseManagementEstimated;
                    this.PopulationCaseManagementProjected = data.PopulationCaseManagementProjected;
                    this.PopulationPsychiatryEstimated = data.PopulationPsychiatryEstimated;
                    this.PopulationPsychiatryProjected = data.PopulationPsychiatryProjected;
                    this.PopulationMethadoneEstimated = data.PopulationMethadoneEstimated;
                    this.PopulationMethadoneProjected = data.PopulationMethadoneProjected;
                    this.PopulationLivingSkillsEstimated = data.PopulationLivingSkillsEstimated;
                    this.PopulationLivingSkillsProjected = data.PopulationLivingSkillsProjected;
                    this.PopulationIndividualEstimated = data.PopulationIndividualEstimated;
                    this.PopulationIndividualProjected = data.PopulationIndividualProjected;
                    this.PopulationFamilyEstimated = data.PopulationFamilyEstimated;
                    this.PopulationFamilyProjected = data.PopulationFamilyProjected;
                    this.PopulationGroupEstimated = data.PopulationGroupEstimated;
                    this.PopulationGroupProjected = data.PopulationGroupProjected;

                    this.ServedSubstanceAbuseNumOfBedCurrent = data.ServedSubstanceAbuseNumOfBedCurrent;
                    this.ServedSubstanceAbuseNumOfBedDayCurrent = data.ServedSubstanceAbuseNumOfBedDayCurrent;
                    this.ServedSubstanceAbuseNumOfBedNext = data.ServedSubstanceAbuseNumOfBedNext;
                    this.ServedSubstanceAbuseNumOfBedDayNext = data.ServedSubstanceAbuseNumOfBedDayNext;
                    this.ServedPsychiatricNumOfBedCurrent = data.ServedPsychiatricNumOfBedCurrent;
                    this.ServedPsychiatricNumOfBedDayCurrent = data.ServedPsychiatricNumOfBedDayCurrent;
                    this.ServedPsychiatricNumOfBedNext = data.ServedPsychiatricNumOfBedNext;
                    this.ServerdPsychiatricNumOfBedDayNext = data.ServerdPsychiatricNumOfBedDayNext;

                    this.StabilizeGeneralHealthNumOfBedsCurrent = data.StabilizeGeneralHealthNumOfBedsCurrent;
                    this.StabilizeGeneralHealthNumofBedDaysCurrent = data.StabilizeGeneralHealthNumofBedDaysCurrent;
                    this.StabilizeGeneralHealthNumOfBedsNext = data.StabilizeGeneralHealthNumOfBedsNext;
                    this.StabilizeGeneralHealthNumOfBedDaysNext = data.StabilizeGeneralHealthNumOfBedDaysNext;
                    this.StabilizeMentallyNumOfBedsCurrent = data.StabilizeMentallyNumOfBedsCurrent;
                    this.StabilizeMentallyNumOfBedDaysCurrent = data.StabilizeMentallyNumOfBedDaysCurrent;
                    this.StabilizeMentallyNumOfBedsNext = data.StabilizeMentallyNumOfBedsNext;
                    this.StabilizeMetallyNumOfBedDaysNext = data.StabilizeMetallyNumOfBedDaysNext;
                    this.StabilizeChildrenNumOfBedsCurrent = data.StabilizeChildrenNumOfBedsCurrent;
                    this.StabilizeChildrenNumOfBedDaysCurrent = data.StabilizeChildrenNumOfBedDaysCurrent;
                    this.StabilizeChildrenNumOfBedsNext = data.StabilizeChildrenNumOfBedsNext;
                    this.StabilizeChildrenNumOfBedDaysNext = data.StabilizeChildrenNumOfBedDaysNext;

                    this.RevenueOutGeneralMentalCurrent = data.RevenueOutGeneralMentalCurrent;
                    this.RevenueOutGeneralMentalNext = data.RevenueOutGeneralMentalNext;
                    this.RevenueOutMentalCurrent = data.RevenueOutMentalCurrent;
                    this.RevenueOutMentalNext = data.RevenueOutMentalNext;
                    this.RevenueOutChildrenCurrent = data.RevenueOutChildrenCurrent;
                    this.RevenueOutChildrenNext = data.RevenueOutChildrenNext;
                    this.RevenueOutOtherCurrent = data.RevenueOutOtherCurrent;
                    this.RevenueOutOtherNext = data.RevenueOutOtherNext;

                    this.RevenueInGeneralMentalCurrent = data.RevenueInGeneralMentalCurrent;
                    this.RevenueInGeneralMentalNext = data.RevenueInGeneralMentalNext;
                    this.RevenueInMentalCurrent = data.RevenueInMentalCurrent;
                    this.RevenueInMentalNext = data.RevenueInMentalNext;
                    this.RevenueInChildrentCurrent = data.RevenueInChildrentCurrent;
                    this.RevenueInChildrentNext = data.RevenueInChildrentNext;
                    this.RevenueInOther1Current = data.RevenueInOther1Current;
                    this.RevenueInOther1Next = data.RevenueInOther1Next;
                    this.RevenueInOther2Current = data.RevenueInOther2Current;
                    this.RevenueInOther2Next = data.RevenueInOther2Next;

                    this.InPatientServicesYearEnd = data.InPatientServicesYearEnd;
                    this.InPatientServicesProjection = data.InPatientServicesProjection;
                    this.OutPatientServicesYearEnd = data.OutPatientServicesYearEnd;
                    this.OutPatientServicesProjection = data.OutPatientServicesProjection;
                    this.RentsLeasedYearEnd = data.RentsLeasedYearEnd;
                    this.RentsLeasedProjection = data.RentsLeasedProjection;
                    this.GrantsResearchYearEnd = data.GrantsResearchYearEnd;
                    this.GrantsResearchProjection = data.GrantsResearchProjection;
                    this.DonationsYearEnd = data.DonationsYearEnd;
                    this.DonationsProjection = data.DonationsProjection;
                    this.OtherIncomeYearEnd = data.OtherIncomeYearEnd;
                    this.OtherIncomeProjection = data.OtherIncomeProjection;
                    this.ContractualAdjustmentYearEnd = data.ContractualAdjustmentYearEnd;
                    this.ContractualAdjustmentProjection = data.ContractualAdjustmentProjection;
                    this.BadDeptYearEnd = data.BadDeptYearEnd;
                    this.BadDeptProjection = data.BadDeptProjection;
                    this.FreeServiceYearEnd = data.FreeServiceYearEnd;
                    this.FreeServiceProjection = data.FreeServiceProjection;
                    this.OutsideServiceYearEnd = data.OutsideServiceYearEnd;
                    this.OutsideServiceProjection = data.OutsideServiceProjection;
                    this.AnnualPayrollYearEnd = data.AnnualPayrollYearEnd;
                    this.AnnualPayrollProjection = data.AnnualPayrollProjection;

                    DocumentViewModel docModel = new DocumentViewModel();
                    this.Attachments = docModel.GetDocuments(data.RenewalID);
                    this.RenewalID = data.RenewalID;
                }

                var premQuery = (from prem in ContextPerRequest.CurrentData.Premiums
                                 where prem.MemberCoverageID == MemberCoverageID &&
                                 prem.PolicyYearID == policyYear
                                 select prem).FirstOrDefault();

                this.Premiums = new PremiumsViewModel();

                if (premQuery == null)
                {
                    int premiumId = InsertPremiumInformation(MemberCoverageID, policyYear);

                    this.Premiums.Property = 0;
                    this.Premiums.Auto = 0;
                    this.Premiums.Crime = 0;
                    this.Premiums.Cyber = 0;
                    this.Premiums.D_O = 0;
                    this.Premiums.EmployeedLawyers = 0;
                    this.Premiums.Fiduciary = 0;
                    this.Premiums.Kidnap = 0;
                    this.Premiums.MemberCoverageID = MemberCoverageID;
                    this.Premiums.PL_GL = 0;
                    this.Premiums.PolicyYearID = policyYear;
                    this.Premiums.Pollution = 0;
                    this.Premiums.PremiumID = premiumId;
                    this.Premiums.PrimaryCare = 0;
                    this.Premiums.Property = 0;
                    this.Premiums.Umbrella = 0;
                }
                else
                {
                    this.Premiums.Property = premQuery.Property;
                    this.Premiums.Auto = premQuery.Auto;
                    this.Premiums.Crime = premQuery.Crime;
                    this.Premiums.Cyber = premQuery.Cyber;
                    this.Premiums.D_O = premQuery.D_O;
                    this.Premiums.EmployeedLawyers = premQuery.EmployedLawyers;
                    this.Premiums.Fiduciary = premQuery.Fiduciary;
                    this.Premiums.Kidnap = premQuery.Kidnap;
                    this.Premiums.MemberCoverageID = premQuery.MemberCoverageID;
                    this.Premiums.PL_GL = premQuery.PL_GL;
                    this.Premiums.PolicyYearID = premQuery.PolicyYearID;
                    this.Premiums.Pollution = premQuery.Pollution;
                    this.Premiums.PremiumID = premQuery.PremiumID;
                    this.Premiums.PrimaryCare = premQuery.PrimaryCare;
                    this.Premiums.Property = premQuery.Property;
                    this.Premiums.Umbrella = premQuery.Umbrella;
                }

            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new System.Diagnostics.StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                String innerMessage = (ex.InnerException != null)
                      ? ex.InnerException.Message
                      : "";
                LogError(ex.Message + " Line Number = " + line.ToString(), innerMessage);

                throw;
            }
        }

        public void SaveMemberCoverage(MemberCoverageViewModel model)
        {
            var query = (from member in ContextPerRequest.CurrentData.MemberCoverages
                         where member.MemberCoverageID == model.MemberCoverageID
                         select member).FirstOrDefault();

            if (query != null)
            {
                query.AuthorizeAddress1 = model.AuthorizeAddress1;
                query.AuthorizeAddress2 = model.AuthorizeAddress2;
                query.AuthorizeCity = model.AuthorizeCity;
                query.AuthorizeEmail = model.AuthorizeEmail;
                query.AuthorizeFirstName = model.AuthorizeFirstName;
                query.AuthorizeLastName = model.AuthorizeLastName;
                query.AuthorizePhone = model.AuthorizePhone;
                query.AuthorizePhoneExt = model.AuthorizePhoneExt;
                query.AuthorizePrefix = model.AuthorizePrefix;
                query.AuthorizeStateID = model.AuthorizeStateID;
                query.AuthorizeTitle = model.AuthorizeTitle;
                query.AuthorizeZip = model.AuthorizeZip;
                query.ContactEmail = model.ContactEmail;
                query.ContactFirstName = model.ContactFirstName;
                query.ContactLastName = model.ContactLastName;
                query.ContactPhone = model.ContactPhone;
                query.ContactPhoneExt = model.ContactPhoneExt;
                query.ContactPrefix = model.ContactPrefix;
                query.ContactTitle = model.ContactTitle;
                query.CurrentStatusID = model.CurrentStatusID;
                query.EntityTypeID = model.EntityTypeID;
                query.FederalID = model.FederalID;
                query.IsBoardMember = model.IsBoardMember;
                query.JoinedBHIP = model.JoinedBHIP;
                query.MailAddress1 = model.MailAddress1;
                query.MailAddress2 = model.MailAddress2;
                query.MailCity = model.MailCity;
                query.MailStateID = model.MailStateID;
                query.MailZip = model.MailZip;
                query.MemberCoverageID = model.MemberCoverageID;
                query.MemberId = model.MemberID;
                query.MemberName = model.MemberName;
                query.MemberPhone = model.MemberPhone;
                query.MemberPhoneExt = model.MemberPhoneExt;
                query.MemberWebsite = model.MemberWebsite;
                query.PrimaryAddress1 = model.PrimaryAddress1;
                query.PrimaryAddress2 = model.PrimaryAddress2;
                query.PrimaryCity = model.PrimaryCity;
                query.PrimaryStateID = model.PrimaryStateID;
                query.PrimaryZip = model.PrimaryZip;
                query.TerminatedBHIP = model.TerminatedBHIP;
                query.MemberNameAbbr = model.MemberNameAbbr;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void SavePremium(MemberCoverageViewModel model)
        {
            var query = (from premium in ContextPerRequest.CurrentData.Premiums
                         where premium.MemberCoverageID == model.MemberCoverageID
                         && premium.PolicyYearID == model.PolicyYear
                         select premium).FirstOrDefault();

            if (query != null)
            {
                query.Property = model.Premiums.Property;
                query.Auto = model.Premiums.Auto;
                query.Crime = model.Premiums.Crime;
                query.Cyber = model.Premiums.Cyber;
                query.D_O = model.Premiums.D_O;
                query.EmployedLawyers = model.Premiums.EmployeedLawyers;
                query.Fiduciary = model.Premiums.Fiduciary;
                query.Kidnap = model.Premiums.Kidnap;
                query.PL_GL = model.Premiums.PL_GL;
                query.Pollution = model.Premiums.Pollution;
                query.PrimaryCare = model.Premiums.PrimaryCare;
                query.Umbrella = model.Premiums.Umbrella;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
        public int InsertMemberInformation(int memberId)
        {
            MemberCoverage member = new MemberCoverage
            {
                MemberName = string.Empty,
                MemberId = memberId
            };

            ContextPerRequest.CurrentData.MemberCoverages.Add(member);
            ContextPerRequest.CurrentData.SaveChanges();

            return member.MemberCoverageID;
        }

        public int InsertPremiumInformation(int memberId, int policyYearID)
        {
            Premium prem = new Premium
            {
                Auto = 0,
                Crime = 0,
                Cyber = 0,
                D_O = 0,
                EmployedLawyers = 0,
                Fiduciary = 0,
                Kidnap = 0,
                MemberCoverageID = memberId,
                PL_GL = 0,
                PolicyYearID = policyYearID,
                Pollution = 0,
                PrimaryCare = 0,
                Property = 0,
                Umbrella = 0
            };

            ContextPerRequest.CurrentData.Premiums.Add(prem);
            ContextPerRequest.CurrentData.SaveChanges();

            return prem.PremiumID;
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

        public IEnumerable<SelectListItem> GetScheduleFilterTypeList()
        {
            return (Enum.GetValues(typeof(ScheduleDriverFilterType)).Cast<ScheduleDriverFilterType>().Select(
                enu => new SelectListItem() { Text = enu.ToString(), Value = ((int)enu).ToString() })).ToList();
        }

        public IEnumerable<SelectListItem> GetPolicyYears(int policyYear)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataPolicy = from PolicyInfo in ContextPerRequest.CurrentData.PolicyYears
                             orderby PolicyInfo.Year
                             select PolicyInfo;
            returnValue = dataPolicy.ToList().Select(u => new SelectListItem
            {
                Text = u.Year.ToString(),
                Value = u.Year.ToString(),
                Selected = (u.Year == policyYear)
            });

            return returnValue;
        }

        public void LogError(string errorMessage, string innerException)
        {
            // C:\inetpub\wwwroot\trust3\log.txt
            using (System.IO.StreamWriter sw = File.AppendText(@"C:\temp\bhiplog.txt"))
            {
                sw.Write("\r\nLog Entry : ");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                sw.WriteLine("  :");
                sw.WriteLine("Error Message: {0}", errorMessage);
                sw.WriteLine("Inner Exception: {0}", innerException);
                sw.WriteLine("-------------------------------");
            }
        }
    }

    public enum ScheduleDriverFilterType
    {
        Current = 1,
        Deleted = 2,
        All = 3
    }

}
