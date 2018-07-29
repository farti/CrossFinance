using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossFinance.Models;
using LinqToExcel;

namespace CrossFinance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadExcel( address objAddressDetails, person objPersonDetails ,financialstate objFinancialstateDetails,agreement objAgreementDetails, HttpPostedFileBase FileUpload)
        {
            string data = "";
            string dataNotValidPesel = "";
            if (FileUpload != null)
            {
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType ==
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;

                    if (filename.EndsWith(".xlsx"))
                    {
                        string targetpath = Server.MapPath("~/DetailFormatInExcel/");
                        FileUpload.SaveAs(targetpath + filename);
                        string pathToExcelFile = targetpath + filename;

                        string sheetName = "Arkusz1";

                        var excelFile = new ExcelQueryFactory(pathToExcelFile);
                        // Mapping excel column to mysql
                        excelFile.AddMapping<address>(x=>x.StreetName, "MAIN_STREET_NAME");
                        excelFile.AddMapping<address>(x=>x.StreetNumber, "MAIN_STREET_NUMBER");
                        excelFile.AddMapping<address>(x=>x.FlatNumber, "MAIN_STREET_FLAT_NUMBER");
                        excelFile.AddMapping<address>(x=>x.PostCode, "MAIN_POST_CODE");
                        excelFile.AddMapping<address>(x=>x.PostOfficeCity, "MAIN_POST_OFFICE_CITY");
                        excelFile.AddMapping<address>(x=>x.CorrespondenceStreetName, "CORRESPONDENCE_STREET_NAME");
                        excelFile.AddMapping<address>(x=>x.CorrespondenceStreetnumber, "CORRESPONDENCE_STREET_NUMBER");
                        excelFile.AddMapping<address>(x=>x.CorrespondenceFlatNumber, "CORRESPONDENCE_STREET_FLAT_NUMBER");
                        excelFile.AddMapping<address>(x=>x.CorrespondencePostCode, "CORRESPONDENCE_POST_CODE");
                        excelFile.AddMapping<address>(x=>x.CorrespondencePostOfficeCity, "CORRESPONDENCE_POST_OFFICE_CITY");

                        excelFile.AddMapping<person>(x=>x.FirstName, "imie");
                        excelFile.AddMapping<person>(x=>x.Surname, "nazwisko");
                        excelFile.AddMapping<person>(x=>x.NationalIdentificationNumber, "PESEL");
                        excelFile.AddMapping<person>(x=>x.PhoneNumber, "Telefon 1"); 
                        excelFile.AddMapping<person>(x=>x.PhoneNumber2, "Telefon2");

                        excelFile.AddMapping<financialstate>(x=>x.OutstandingLiabilites, "Kapital");
                        excelFile.AddMapping<financialstate>(x=>x.Interests, "odsetki");
                        excelFile.AddMapping<financialstate>(x=>x.PenaltyInterests, "odsetki Karne");
                        excelFile.AddMapping<financialstate>(x=>x.Fees, "opłaty");
                        excelFile.AddMapping<financialstate>(x=>x.CourtFees, "koszty sadowe");
                        excelFile.AddMapping<financialstate>(x=>x.RepresentationCourtFees, "koszty zastepstwa sadowego");
                        excelFile.AddMapping<financialstate>(x=>x.VindicationCosts, "koszty egzekucji");
                        excelFile.AddMapping<financialstate>(x=>x.RepresentationVindicationCosts, "koszty zastepstwa egzekucyjnego");

                        excelFile.AddMapping<agreement>(x=>x.Number, "nr_umowy");

                        var dataDetails = from a in excelFile.Worksheet<data>(sheetName) select a;

                        foreach (var a in dataDetails)
                        {
                            if (a.NationalIdentificationNumber != null)
                            {
                                //PESEL validator
                                if (!PeselIsValid(a.NationalIdentificationNumber))
                                {
                                    dataNotValidPesel += a.NationalIdentificationNumber + Environment.NewLine;
                                    ViewBag.PeselMessage = dataNotValidPesel;

                                }


                                var myOutstandingLiabilites = Convert.ToDecimal(a.OutstandingLiabilites);
                                var myInterests = Convert.ToDecimal(a.Interests);
                                var myPenaltyInterests = Convert.ToDecimal(a.PenaltyInterests);
                                var myFees = Convert.ToDecimal(a.Fees);
                                var myCourtFees = Convert.ToDecimal(a.CourtFees);
                                var myRepresentationCourtFees = Convert.ToDecimal(a.RepresentationCourtFees);
                                var myVindicationCosts = Convert.ToDecimal(a.VindicationCosts);
                                var myRepresentationVindicationCosts =
                                    Convert.ToDecimal(a.RepresentationVindicationCosts);

                                var insert = PostExcelData(a.StreetName, a.StreetNumber, a.FlatNumber, a.PostCode,
                                    a.PostOfficeCity, a.CorrespondenceStreetName, a.CorrespondenceStreetnumber,
                                    a.CorrespondenceFlatNumber, a.CorrespondencePostCode,
                                    a.CorrespondencePostOfficeCity,
                                    a.FirstName, a.SecondName, a.Surname, a.NationalIdentificationNumber, a.AddressId,
                                    a.PhoneNumber, a.PhoneNumber2,
                                    myOutstandingLiabilites, myInterests, myPenaltyInterests, myFees, myCourtFees,
                                    myRepresentationCourtFees, myVindicationCosts, myRepresentationVindicationCosts,
                                    a.Number, a.PersonId, a.FinancialStateId);
                            }
                        }

                        data = "Successful upload records!";
                        ViewBag.Message = data;

                    }

                    else
                    {
                        data = "This file is not valid format";
                        ViewBag.Message = data;
                    }
                    return View("Index");
                }

                else
                {

                    data = "Only Excel file format is allowed";

                    ViewBag.Message = data;
                    return View("Index");

                }

            }
            else
            {

                if (FileUpload == null)
                {
                    data = "Please choose Excel file";
                }

                ViewBag.Message = data;
                return View("Index");

            }
        }

        public int PostExcelData(
            string StreetName,string StreetNumber, string FlatNumber, string PostCode, string PostOfficeCity, string CorrespondenceStreetName, string CorrespondenceStreetnumber, string CorrespondenceFlatNumber, string CorrespondencePostCode, string CorrespondencePostOfficeCity,
            string FirstName, string SecondName, string Surname, string NationalIdentificationNumber, int AddressId, string PhoneNumber, string PhoneNumber2,
            decimal OutstandingLiabilites, decimal Interests, decimal PenaltyInterests, decimal Fees, decimal CourtFees, decimal RepresentationCourtFees, decimal VindicationCosts, decimal RepresentationVindicationCosts,
            string Number, int PersonId, int FinancialStateId
            )
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            var InsertExcelData = _context.sp_InsertData(
                StreetName, StreetNumber, FlatNumber, PostCode, PostOfficeCity, CorrespondenceStreetName, CorrespondenceStreetnumber, CorrespondenceFlatNumber, CorrespondencePostCode, CorrespondencePostOfficeCity,

                FirstName, SecondName, Surname, NationalIdentificationNumber, AddressId, PhoneNumber, PhoneNumber2,
                OutstandingLiabilites, Interests, PenaltyInterests, Fees, CourtFees, RepresentationCourtFees,
                VindicationCosts, RepresentationVindicationCosts,
                Number, PersonId, FinancialStateId
            );

            return InsertExcelData;
        }

        public bool PeselIsValid(string pesel)
        {
            bool validator = true;
            if (pesel.Length != 11)
            {
                validator = false;
            }
            else
            {
                int[] weight = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
                int k = 0;

                for (int i = 0; i < pesel.Length; i++)
                {
                    int temp;
                    if (!Int32.TryParse(pesel[i].ToString(), out temp))
                    {
                        validator = false;
                    }

                    if (i+1 == pesel.Length)
                    {
                        if ((10 - k % 10) % 10 != temp)
                        {
                            validator = false;
                        }
                    }
                    else
                    {
                        k += temp * weight[i];
                    }
                }
            }

            return validator;
        }

    }

}