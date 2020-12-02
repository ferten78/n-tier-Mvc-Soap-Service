using DataAccesLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BidBusiness : IBusiness<Bid>
    {
        UnitOfWork _uof;
        bool _result;
        public BidBusiness()
        {
            _uof = new UnitOfWork();
        }

        public void Add(Bid item)
        {
            if (item != null)
            {
                _uof.BidRepository.Add(item);
                _result = _uof.ApplyChanges();

                if (_result != true)
                {
                    throw new Exception("Kayıt Yapılamadı.");
                }
            }
        }

        public void Delete(Bid item)
        {
            if (item != null)
            {
                _uof.BidRepository.Remove(item);
                _result = _uof.ApplyChanges();

                if (_result != true)
                {
                    throw new Exception("Silme işlemi gerçekleştirilemedi.");
                }
            }
            else
            {
                throw new Exception("Silme gerçekleştirilemedi. Kayıt Bulunamadı.");
            }
        }

        public List<Bid> GetAll()
        {
            return _uof.BidRepository.GetAll();
        }

        public Bid GetById(int ID)
        { 
            return _uof.BidRepository.GetByID(ID);
        }
        public List<Bid> GetByIdentity(string IdentityNo)
        {
            List<Bid> List = new List<Bid>();

            List = _uof.BidRepository.GetAll()
                .Where(x => x.Customer.IdentityNo == IdentityNo).ToList();

            return List;
        }
        public void Update(Bid item)
        {
            _uof.BidRepository.Update(item);
            _result = _uof.ApplyChanges();

            if (_result != true)
            {
                throw new Exception("Güncelleme Yapılamadı.");
            }
        }
    }
}
