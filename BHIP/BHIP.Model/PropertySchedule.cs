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
    
    public partial class PropertySchedule
    {
        public int PropertyScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        public string LocationNumber { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Zip { get; set; }
        public Nullable<int> ConstructionTypeID { get; set; }
        public Nullable<int> BuildingValue { get; set; }
        public Nullable<int> ContentValue { get; set; }
        public Nullable<int> SquareFoot { get; set; }
        public Nullable<int> BI_EE { get; set; }
        public Nullable<int> OwnLeaseID { get; set; }
        public Nullable<int> FireBurglerID { get; set; }
        public Nullable<System.DateTime> ConstructionDate { get; set; }
        public Nullable<System.DateTime> RemodelDate { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<System.DateTime> DateRemoved { get; set; }
    }
}