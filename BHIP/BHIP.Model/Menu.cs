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
    
    public partial class Menu
    {
        public int MenuID { get; set; }
        public int ParentID { get; set; }
        public string Title { get; set; }
        public int LeftNode { get; set; }
        public int RightNode { get; set; }
        public string Link { get; set; }
        public int Level { get; set; }
    }
}
