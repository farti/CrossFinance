using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossFinance.Models
{
    public class data
    {
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
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }

        public Nullable<decimal> OutstandingLiabilites { get; set; }
        public Nullable<decimal> Interests { get; set; }
        public Nullable<decimal> PenaltyInterests { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public Nullable<decimal> CourtFees { get; set; }
        public Nullable<decimal> RepresentationCourtFees { get; set; }
        public Nullable<decimal> VindicationCosts { get; set; }
        public Nullable<decimal> RepresentationVindicationCosts { get; set; }

        public string Number { get; set; }
        public int PersonId { get; set; }
        public int FinancialStateId { get; set; }
            
        }
}