using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHIP.Model
{
    public class PremiumsViewModel
    {
        public int PremiumID { get; set; }
        public int MemberCoverageID { get; set; }
        public int PolicyYearID { get; set; }

        [Display(Name = "Property:")]
        public decimal Property { get; set; }
        [Display(Name = "Auto:")]
        public decimal Auto { get; set; }
        [Display(Name = "D&O:")]
        public decimal D_O { get; set; }
        [Display(Name = "Crime:")]
        public decimal Crime { get; set; }
        [Display(Name = "Fiduciary:")]
        public decimal Fiduciary { get; set; }
        [Display(Name = "Employeed Lawyers:")]
        public decimal EmployeedLawyers { get; set; }
        [Display(Name = "PL/GL:")]
        public decimal PL_GL { get; set; }
        [Display(Name = "Umbrella:")]
        public decimal Umbrella { get; set; }
        [Display(Name = "Primary Care:")]
        public decimal PrimaryCare { get; set; }
        [Display(Name = "Pollution:")]
        public decimal Pollution { get; set; }
        [Display(Name = "Kidnap:")]
        public decimal Kidnap { get; set; }
        [Display(Name = "Cyber:")]
        public decimal Cyber { get; set; }
        public bool COI { get; set; }
        public IEnumerable<PremiumsViewModel> GetPremiums(int memberCoverageID)
        {
            var query = (from premiums in ContextPerRequest.CurrentData.Premiums
                         where premiums.MemberCoverageID == memberCoverageID
                         select new PremiumsViewModel
                         {
                             Auto = premiums.Auto,
                             Crime = premiums.Crime,
                             Cyber = premiums.Cyber,
                             D_O = premiums.D_O,
                             EmployeedLawyers = premiums.EmployedLawyers,
                             Fiduciary = premiums.Fiduciary,
                             Kidnap = premiums.Kidnap,
                             MemberCoverageID = premiums.MemberCoverageID,
                             PL_GL = premiums.PL_GL,
                             PolicyYearID = premiums.PolicyYearID,
                             Pollution = premiums.Pollution,
                             PremiumID = premiums.PremiumID,
                             PrimaryCare = premiums.PrimaryCare,
                             Property = premiums.Property,
                             Umbrella = premiums.Umbrella
                         });

            return query;
        }

    }
}
