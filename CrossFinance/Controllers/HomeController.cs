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
        public ActionResult UploadExcel( Person objPersDetail , HttpPostedFileBase FileUpload)
        {
            string data = "";
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
                        var persDetails = from a in excelFile.Worksheet<Person>(sheetName) select a;
                        foreach (var a in persDetails)
                        {
                            int resullt = PostExcelData(a.FirstName, a.SecondName, a.Surname, a.NationalIdentificationNumber, a.AddressId, a.PhoneNumber, a.PhoneNumber2);
                            if (resullt <= 0)
                            {
                                data = "Hello User, Found some duplicate values! Only unique person has inserted and duplicate values(s) are not inserted";
                                ViewBag.Message = data;
                                continue;

                            }
                            else
                            {
                                data = "Successful upload records";
                                ViewBag.Message = data;
                            }
                        }

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

        public int PostExcelData(string FirstName, string SecondName, string Surname,
            string NationalIdentificationNumber, int AddressId, string PhoneNumber, string PhoneNumber2)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            var InsertExcelData = _context.sp_InsertPerson(FirstName, SecondName, Surname, NationalIdentificationNumber,
                AddressId, PhoneNumber, PhoneNumber2);
            return InsertExcelData;
        }

    }

}