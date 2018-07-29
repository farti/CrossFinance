﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<agreement> agreement { get; set; }
        public virtual DbSet<financialstate> financialstate { get; set; }
        public virtual DbSet<person> person { get; set; }
    
        
    
        public virtual int sp_InsertData(string streetName, string streetNumber, string flatNumber, string postCode, string postOfficeCity, string correspondenceStreetName, string correspondenceStreetnumber, string correspondenceFlatNumber, string correspondencePostCode, string correspondencePostOfficeCity, string firstName, string secondName, string surname, string nationalIdentificationNumber, Nullable<int> addressId, string phoneNumber, string phoneNumber2, Nullable<decimal> outstandingLiabilites, Nullable<decimal> interests, Nullable<decimal> penaltyInterests, Nullable<decimal> fees, Nullable<decimal> courtFees, Nullable<decimal> representationCourtFees, Nullable<decimal> vindicationCosts, Nullable<decimal> representationVindicationCosts, string number, Nullable<int> personID, Nullable<int> financialStateId)
        {
            var streetNameParameter = streetName != null ?
                new ObjectParameter("StreetName", streetName) :
                new ObjectParameter("StreetName", typeof(string));
    
            var streetNumberParameter = streetNumber != null ?
                new ObjectParameter("StreetNumber", streetNumber) :
                new ObjectParameter("StreetNumber", typeof(string));
    
            var flatNumberParameter = flatNumber != null ?
                new ObjectParameter("FlatNumber", flatNumber) :
                new ObjectParameter("FlatNumber", typeof(string));
    
            var postCodeParameter = postCode != null ?
                new ObjectParameter("PostCode", postCode) :
                new ObjectParameter("PostCode", typeof(string));
    
            var postOfficeCityParameter = postOfficeCity != null ?
                new ObjectParameter("PostOfficeCity", postOfficeCity) :
                new ObjectParameter("PostOfficeCity", typeof(string));
    
            var correspondenceStreetNameParameter = correspondenceStreetName != null ?
                new ObjectParameter("CorrespondenceStreetName", correspondenceStreetName) :
                new ObjectParameter("CorrespondenceStreetName", typeof(string));
    
            var correspondenceStreetnumberParameter = correspondenceStreetnumber != null ?
                new ObjectParameter("CorrespondenceStreetnumber", correspondenceStreetnumber) :
                new ObjectParameter("CorrespondenceStreetnumber", typeof(string));
    
            var correspondenceFlatNumberParameter = correspondenceFlatNumber != null ?
                new ObjectParameter("CorrespondenceFlatNumber", correspondenceFlatNumber) :
                new ObjectParameter("CorrespondenceFlatNumber", typeof(string));
    
            var correspondencePostCodeParameter = correspondencePostCode != null ?
                new ObjectParameter("CorrespondencePostCode", correspondencePostCode) :
                new ObjectParameter("CorrespondencePostCode", typeof(string));
    
            var correspondencePostOfficeCityParameter = correspondencePostOfficeCity != null ?
                new ObjectParameter("CorrespondencePostOfficeCity", correspondencePostOfficeCity) :
                new ObjectParameter("CorrespondencePostOfficeCity", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var secondNameParameter = secondName != null ?
                new ObjectParameter("SecondName", secondName) :
                new ObjectParameter("SecondName", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("Surname", surname) :
                new ObjectParameter("Surname", typeof(string));
    
            var nationalIdentificationNumberParameter = nationalIdentificationNumber != null ?
                new ObjectParameter("NationalIdentificationNumber", nationalIdentificationNumber) :
                new ObjectParameter("NationalIdentificationNumber", typeof(string));
    
            var addressIdParameter = addressId.HasValue ?
                new ObjectParameter("AddressId", addressId) :
                new ObjectParameter("AddressId", typeof(int));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var phoneNumber2Parameter = phoneNumber2 != null ?
                new ObjectParameter("PhoneNumber2", phoneNumber2) :
                new ObjectParameter("PhoneNumber2", typeof(string));
    
            var outstandingLiabilitesParameter = outstandingLiabilites.HasValue ?
                new ObjectParameter("OutstandingLiabilites", outstandingLiabilites) :
                new ObjectParameter("OutstandingLiabilites", typeof(decimal));
    
            var interestsParameter = interests.HasValue ?
                new ObjectParameter("Interests", interests) :
                new ObjectParameter("Interests", typeof(decimal));
    
            var penaltyInterestsParameter = penaltyInterests.HasValue ?
                new ObjectParameter("PenaltyInterests", penaltyInterests) :
                new ObjectParameter("PenaltyInterests", typeof(decimal));
    
            var feesParameter = fees.HasValue ?
                new ObjectParameter("Fees", fees) :
                new ObjectParameter("Fees", typeof(decimal));
    
            var courtFeesParameter = courtFees.HasValue ?
                new ObjectParameter("CourtFees", courtFees) :
                new ObjectParameter("CourtFees", typeof(decimal));
    
            var representationCourtFeesParameter = representationCourtFees.HasValue ?
                new ObjectParameter("RepresentationCourtFees", representationCourtFees) :
                new ObjectParameter("RepresentationCourtFees", typeof(decimal));
    
            var vindicationCostsParameter = vindicationCosts.HasValue ?
                new ObjectParameter("VindicationCosts", vindicationCosts) :
                new ObjectParameter("VindicationCosts", typeof(decimal));
    
            var representationVindicationCostsParameter = representationVindicationCosts.HasValue ?
                new ObjectParameter("RepresentationVindicationCosts", representationVindicationCosts) :
                new ObjectParameter("RepresentationVindicationCosts", typeof(decimal));
    
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            var financialStateIdParameter = financialStateId.HasValue ?
                new ObjectParameter("FinancialStateId", financialStateId) :
                new ObjectParameter("FinancialStateId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertData", streetNameParameter, streetNumberParameter, flatNumberParameter, postCodeParameter, postOfficeCityParameter, correspondenceStreetNameParameter, correspondenceStreetnumberParameter, correspondenceFlatNumberParameter, correspondencePostCodeParameter, correspondencePostOfficeCityParameter, firstNameParameter, secondNameParameter, surnameParameter, nationalIdentificationNumberParameter, addressIdParameter, phoneNumberParameter, phoneNumber2Parameter, outstandingLiabilitesParameter, interestsParameter, penaltyInterestsParameter, feesParameter, courtFeesParameter, representationCourtFeesParameter, vindicationCostsParameter, representationVindicationCostsParameter, numberParameter, personIDParameter, financialStateIdParameter);
        }
    
        
    }
}
