using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string IdentityNo { get; set; }
        public string LicenseSerialCode { get; set; }
        public string LicenseSerialNumber { get; set; }

        public virtual List<Bid> CustomerBids { get; set; }
    }
}
