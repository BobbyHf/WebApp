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
    
    public partial class DriverInfoSchedule
    {
        public int DriverInfoScheduleID { get; set; }
        public int MemberCoverageID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> StateID { get; set; }
        public string LicenseNumber { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<System.DateTime> DateRemoved { get; set; }
        public string Comments { get; set; }
    }
}
