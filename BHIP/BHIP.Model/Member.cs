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
    
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
        public string Phone { get; set; }
        public string PhoneExtension { get; set; }
        public string WebSite { get; set; }
        public Nullable<int> EntityTypeID { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public Nullable<System.DateTime> TerminatedDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string AutoCard { get; set; }
    }
}
