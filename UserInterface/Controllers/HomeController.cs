using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListByIdentity()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckData(string Tc, string Plate)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            Customer customer = new Customer();
            List<Bid> bids = new List<Bid>();

            customer = customerBusiness.GetByIdentityAndPlate(Plate, Tc);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBids(string tc)
        {
            List<Bid> bids = new List<Bid>();
            BidBusiness bidBusiness = new BidBusiness();


            bids = bidBusiness.GetByIdentity(tc);

            return PartialView("~/Views/Home/BidListPartialview.cshtml", bids);

        }

        public ActionResult SaveRequestAndGetBids(string tc, string plate, string serialCode, string serialNo)
        {
            List<Bid> bids = new List<Bid>();
            BidBusiness bidBusiness = new BidBusiness();

            CustomerBusiness customerBusiness = new CustomerBusiness();
            Customer customer = new Customer();
            customer.IdentityNo = tc;
            customer.Plate = plate;
            customer.LicenseSerialCode = serialCode;
            customer.LicenseSerialNumber = serialNo;

            var isV = customerBusiness.GetByIdentityAndPlate(plate, tc);

            if (isV == null)
            {
                customerBusiness.Add(customer);

            }

            ServiceBusiness sb = new ServiceBusiness();
            sb.GetBidsFromACompany(tc, plate, serialCode, serialNo, customer);
            sb.GetBidsFromBCompany(tc, plate, serialCode, serialNo, customer);


            bids = bidBusiness.GetByIdentity(tc);

            return PartialView("~/Views/Home/BidListPartialview.cshtml", bids);

        }

    }
}