using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCompanyApi.Models
{
    public class Bid
    {
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}