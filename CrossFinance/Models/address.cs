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
    
    public partial class address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public address()
        {
            this.person = new HashSet<person>();
        }
    
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PostCode { get; set; }
        public string PostOfficeCity { get; set; }
        public string CorrespondenceStreetName { get; set; }
        public string CorrespondenceStreetnumber { get; set; }
        public string CorrespondenceFlatNumber { get; set; }
        public string CorrespondencePostCode { get; set; }
        public string CorrespondencePostOfficeCity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<person> person { get; set; }
    }
}