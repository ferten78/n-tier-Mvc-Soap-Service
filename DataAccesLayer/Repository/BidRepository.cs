using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repository
{
    public class BidRepository : BaseRepository<Bid>
    {
        public BidRepository(SqlContext context) : base(context)
        {

        }
    }
}
