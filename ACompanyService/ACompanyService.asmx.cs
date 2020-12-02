using ACompanyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ACompanyService
{
    /// <summary>
    /// Summary description for ACompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ACompanyService : System.Web.Services.WebService
    {

        [WebMethod]
        public Bid GetBid(string identityNo, string plate, string serialCode, string serialNo)
        {
            Bid bid = new Bid();
            bid.CompanyName = "ACompany";
            bid.Description = "Açıklama Metni";
            bid.Logo = "Logo-Base64";

            Random rnd = new Random();
            decimal p = rnd.Next(900, 1300); 
            bid.Price = p;

            return bid;
        }
    }
}
