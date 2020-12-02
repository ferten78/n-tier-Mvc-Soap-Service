using BCompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCompanyApi.Controllers
{
    public class BidController : ApiController
    { 
         
        public Bid GetBid(string identityNo, string plate, string serialCode, string serialNo)
        {
            Bid bid = new Bid();
            bid.CompanyName = "BCompany";
            bid.Description = "Açıklama Metni";
            bid.Logo = "Logo-Base64";

            Random rnd = new Random();
            decimal p = rnd.Next(900, 1300);
            bid.Price = p;

            return bid;
        }
    }
}
