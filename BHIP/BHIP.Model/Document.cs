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
    
    public partial class Document
    {
        public int DocumentId { get; set; }
        public long RenewalId { get; set; }
        public long DocTypeId { get; set; }
        public System.DateTime LoadDate { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public byte[] Document1 { get; set; }
        public string Media { get; set; }
        public Nullable<bool> Action { get; set; }
    }
}
