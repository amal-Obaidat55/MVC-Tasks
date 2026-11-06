using AGCSMS.Data;
using AGCSMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AGCSMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcademyDBContext Context;
        public HomeController(AcademyDBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<GraduationCertificate> certificates = Context.GraduationCertificates.ToList();
            List<Hospitality> hospitalities = Context.Hospitalities.ToList();
            List<GraduationGift> gifts = Context.GraduationGifts.ToList();

            ViewBag.Certificates = certificates;
            ViewBag.Hospitalities = hospitalities;
            ViewBag.Gifts = gifts;
            return View();
        }
        [HttpPost]
        public IActionResult ChooseOrder(string certificateSupplier, string hospitalitySupplier, string giftSupplier)
        {
            List<GraduationCertificate> certificates = Context.GraduationCertificates.ToList();
            List<Hospitality> hospitalities = Context.Hospitalities.ToList();
            List<GraduationGift> gifts = Context.GraduationGifts.ToList();


            double totalCPrice = 0;
            List<GraduationCertificate> certificate = new List<GraduationCertificate>();
            if(certificateSupplier == "suppA")
            {
                totalCPrice = Convert.ToDouble(certificates[0].UnitPrice) * Convert.ToDouble(certificates[0].Quantity);
                certificate.Add(certificates[0]);
            }
            else if(certificateSupplier == "suppB")
            {
                totalCPrice = Convert.ToDouble(certificates[1].UnitPrice) * Convert.ToDouble(certificates[1].Quantity);
                certificate.Add(certificates[1]);

            }
            else if (certificateSupplier == "suppC")
            {
                totalCPrice = Convert.ToDouble(certificates[2].UnitPrice) * Convert.ToDouble(certificates[2].Quantity);
                certificate.Add(certificates[2]);

            }
            else
            {
                return Content("Select certificate");
            }

            double totalHPrice = 0;
            List<Hospitality> hospitilaty = new List<Hospitality>();
            if (hospitalitySupplier == "suppD")
            {
                totalHPrice = Convert.ToDouble(hospitalities[0].UnitPrice) * Convert.ToDouble(hospitalities[0].Quantity);
                hospitilaty.Add(hospitalities[0]);
            }
            else if (hospitalitySupplier == "suppE")
            {
                totalHPrice = Convert.ToDouble(hospitalities[1].UnitPrice) * Convert.ToDouble(hospitalities[1].Quantity);
                hospitilaty.Add(hospitalities[1]);
            }
            else if (hospitalitySupplier == "suppF")
            {
                totalHPrice = Convert.ToDouble(hospitalities[2].UnitPrice) * Convert.ToDouble(hospitalities[2].Quantity);
                hospitilaty.Add(hospitalities[2]);
            }
            else
            {
                return Content("Select Hospitality");
            }

            double totalGPrice = 0;
            List<GraduationGift> gift = new List<GraduationGift>();
            if (giftSupplier == "suppG")
            {
                totalGPrice = Convert.ToDouble(gifts[0].UnitPrice) * Convert.ToDouble(gifts[0].Quantity);
                gift.Add(gifts[0]);
            }
            else if (giftSupplier == "suppH")
            {
                totalGPrice = Convert.ToDouble(gifts[1].UnitPrice) * Convert.ToDouble(gifts[1].Quantity);
                gift.Add(gifts[1]);
            }
            else if (giftSupplier == "suppI")
            {
                totalGPrice = Convert.ToDouble(gifts[2].UnitPrice) * Convert.ToDouble(gifts[2].Quantity);
                gift.Add(gifts[2]);

            }
            else
            {
                return Content("Select Gift");
            }


            double Total = totalGPrice + totalHPrice + totalCPrice;
            double discount = 0;
            if (Total >= 500)
            {
                discount = Total * 0.15;
            }
            else if(Total >= 300)
            {
                discount = Total * 0.10;
            }

            double finalTotal = Total - discount;

            HttpContext.Session.SetString("gift",JsonConvert.SerializeObject(gift) );
            HttpContext.Session.SetString("certificate",JsonConvert.SerializeObject(certificate) );
            HttpContext.Session.SetString("hospitality",JsonConvert.SerializeObject(hospitilaty) );
            HttpContext.Session.SetString("TotalGPrice", Convert.ToString(totalGPrice)); 
            HttpContext.Session.SetString("TotalHPrice", Convert.ToString(totalHPrice)); 
            HttpContext.Session.SetString("TotalCPrice", Convert.ToString(totalCPrice));
            HttpContext.Session.SetString("FinalPrice", Convert.ToString(finalTotal));
            HttpContext.Session.SetString("Discount", Convert.ToString(discount));
            return RedirectToAction("Review");
        }
        public IActionResult Review()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
