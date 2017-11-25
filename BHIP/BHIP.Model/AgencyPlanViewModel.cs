using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class AgencyPlanViewModel
    {
        public int AgencyPlanID { get; set; }
        public int MemberID { get; set; }

        [Display(Name = "Plan Name:")]
        [Required(ErrorMessage = "Enter the plan name.")]
        public string PlanName { get; set; }
        [Display(Name = "Plan Type:")]
        [Required(ErrorMessage = "Enter the plan type.")]
        public string PlanType { get; set; }
        [Display(Name = "Plan Assets (Current Year):")]
        [Required(ErrorMessage = "Enter the plan assets (current year).")]
        public int? PlanAssetsCurrent { get; set; }
        [Display(Name = "Plan Assets (Prior Year):")]
        [Required(ErrorMessage = "Enter the plan assets (prior year).")]
        public int? PlanAssetsPrior { get; set; }
        [Display(Name = "Number Of Plan Participants:")]
        [Required(ErrorMessage = "Enter the number of plan participants.")]
        public int? NumberParticipants { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateDeleted { get; set; }
        public bool IsActive { get; set; }


        public IEnumerable<AgencyPlanViewModel> GetPlan(int memberId)
        {
            return (from plans in ContextPerRequest.CurrentData.AgencyPlanSchedules
                    where plans.MemberID == memberId && plans.IsActive == true
                    select new AgencyPlanViewModel
                    {
                        AgencyPlanID = plans.AgencyPlanID,
                        NumberParticipants = plans.NumberParticipants,
                        PlanAssetsCurrent = plans.PlanAssetsCurrent,
                        PlanAssetsPrior = plans.PlanAssetsPrior,
                        PlanName = plans.PlanName,
                        PlanType = plans.PlanType,
                        MemberID = plans.MemberID
                    });
        }

        public AgencyPlanViewModel GetAPlan(int agencyPlanId)
        {
            return (from plan in ContextPerRequest.CurrentData.AgencyPlanSchedules
                    where plan.AgencyPlanID == agencyPlanId && plan.IsActive == true
                    select new AgencyPlanViewModel
                    {
                        AgencyPlanID = plan.AgencyPlanID,
                        NumberParticipants = plan.NumberParticipants,
                        PlanAssetsCurrent = plan.PlanAssetsCurrent,
                        PlanAssetsPrior = plan.PlanAssetsPrior,
                        PlanName = plan.PlanName,
                        PlanType = plan.PlanType,
                        MemberID = plan.MemberID
                    }).FirstOrDefault();
        }

        public void EditAgencyPlan(AgencyPlanViewModel model)
        {
            var data = (from plan in ContextPerRequest.CurrentData.AgencyPlanSchedules
                        where plan.AgencyPlanID == model.AgencyPlanID
                        select plan).FirstOrDefault();

            data.NumberParticipants = model.NumberParticipants;
            data.PlanAssetsCurrent = model.PlanAssetsCurrent;
            data.PlanAssetsPrior = model.PlanAssetsPrior;
            data.PlanName = model.PlanName;
            data.PlanType = model.PlanType;

            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void AddAgencyPlan(AgencyPlanViewModel model)
        {
            AgencyPlanSchedule plan = new AgencyPlanSchedule
            {
                DateAdded = DateTime.Now,
                IsActive = true,
                MemberID = model.MemberID,
                NumberParticipants = model.NumberParticipants,
                PlanAssetsCurrent = model.PlanAssetsCurrent,
                PlanAssetsPrior = model.PlanAssetsPrior,
                PlanName = model.PlanName,
                PlanType = model.PlanType
            };

            ContextPerRequest.CurrentData.AgencyPlanSchedules.Add(plan);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void DeleteAgencyPlan(int agencyPlanId)
        {
            var data = (from plan in ContextPerRequest.CurrentData.AgencyPlanSchedules
                        where plan.AgencyPlanID == agencyPlanId
                        select plan).FirstOrDefault();

            ContextPerRequest.CurrentData.AgencyPlanSchedules.Remove(data);
            ContextPerRequest.CurrentData.SaveChanges();
        }
    }

    public class HandleFundsViewModel
    {
        public int? HandleFundsID { get; set; }
        public int? RenewalID { get; set; }
        public string JobFunction { get; set; }
        public int? NumOfEmployees { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}