//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BHIP.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgencyPlanSchedule
    {
        public int AgencyPlanID { get; set; }
        public int MemberID { get; set; }
        public string PlanName { get; set; }
        public string PlanType { get; set; }
        public Nullable<int> PlanAssetsCurrent { get; set; }
        public Nullable<int> PlanAssetsPrior { get; set; }
        public Nullable<int> NumberParticipants { get; set; }
        public System.DateTime DateAdded { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}