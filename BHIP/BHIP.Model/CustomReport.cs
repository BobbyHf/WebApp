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
    
    public partial class CustomReport
    {
        public int CustomReportID { get; set; }
        public string ReportName { get; set; }
        public string ReportQuery { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CustomReportTypeID { get; set; }
    }
}