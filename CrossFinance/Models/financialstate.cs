//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossFinance.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class financialstate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public financialstate()
        {
            this.agreement = new HashSet<agreement>();
        }
    
        public int Id { get; set; }
        public string OutstandingLiabilites { get; set; }
        public Nullable<decimal> Interests { get; set; }
        public Nullable<decimal> PenaltyInterests { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public Nullable<decimal> CourtFees { get; set; }
        public Nullable<decimal> RepresentationCourtFees { get; set; }
        public Nullable<decimal> VindicationCosts { get; set; }
        public Nullable<decimal> RepresentationVindicationCosts { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agreement> agreement { get; set; }
    }
}