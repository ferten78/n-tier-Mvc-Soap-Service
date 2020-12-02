using Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceBusiness
    {
        public void GetBidsFromACompany(string identityNo, string plate, string serialCode, string serialNo, Customer customer)
        {
            List<Bid> bids = new List<Bid>();
            BidBusiness bidBusiness = new BidBusiness();


            //ACompany.ACompanyServiceSoapClient client = new ACompany.ACompanyServiceSoapClient();
            ACompany.ACompanyService client = new ACompany.ACompanyService();
            var result = client.GetBid(identityNo, plate, serialCode, serialNo); 

             
            Bid newBid = new Bid();
            newBid.CompanyName = result.CompanyName;
            newBid.Customer = customer;
            newBid.Description = result.Description;
            newBid.Logo = result.Logo;
            newBid.Price = result.Price;

            bidBusiness.Add(newBid);


        }
        public void GetBidsFromBCompany(string identityNo, string plate, string serialCode, string serialNo, Customer customer)
        {

            BidBusiness bidBusiness = new BidBusiness();


            Uri baseUrl = new Uri("http://localhost:62034/api/Bid");
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest("GetBid", Method.GET);


            request.AddParameter("identityNo", identityNo);
            request.AddParameter("plate", plate);
            request.AddParameter("serialCode", serialCode);
            request.AddParameter("serialNo", serialNo);

            IRestResponse<Bid> result = client.Execute<Bid>(request);

            Bid newBid = new Bid();

            if (result.IsSuccessful)
            {

                newBid = JsonConvert.DeserializeObject<Bid>(result.Content);
            }

            newBid.Customer = customer;
             

            bidBusiness.Add(newBid);

        }
    }
}
