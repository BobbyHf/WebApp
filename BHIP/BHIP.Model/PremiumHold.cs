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
    
    public partial class PremiumHold
    {
        public int PremiumHoldID { get; set; }
        public int MemberCoverageID { get; set; }
        public int PolicyYearID { get; set; }
        public decimal Property { get; set; }
        public decimal Auto { get; set; }
        public decimal D_O { get; set; }
        public decimal Crime { get; set; }
        public decimal Fiduciary { get; set; }
        public decimal EmployedLawyers { get; set; }
        public decimal PL_GL { get; set; }
        public decimal Umbrella { get; set; }
        public decimal PrimaryCare { get; set; }
        public decimal Pollution { get; set; }
        public decimal Kidnap { get; set; }
        public decimal Cyber { get; set; }
        public string EditType { get; set; }
    }
}
