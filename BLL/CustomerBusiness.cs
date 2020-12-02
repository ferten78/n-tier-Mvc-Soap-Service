using DataAccesLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBusiness : IBusiness<Customer>
    {
        UnitOfWork _uof;
        bool _result;
        public CustomerBusiness()
        {
            _uof = new UnitOfWork();
        }

        public void Add(Customer item)
        {
            if (item != null)
            {
                _uof.CustomerRepository.Add(item);
                _result = _uof.ApplyChanges();

                if (_result != true)
                {
                    throw new Exception("Kayıt Yapılamadı.");
                }
            }
        }

        public void Delete(Customer item)
        {
            if (item != null)
            {
                _uof.CustomerRepository.Remove(item);
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

        public List<Customer> GetAll()
        {
            return _uof.CustomerRepository.GetAll();
        }

        public Customer GetById(int ID)
        {
            return _uof.CustomerRepository.GetByID(ID);
        }

        public void Update(Customer item)
        {
            _uof.CustomerRepository.Update(item);
            _result = _uof.ApplyChanges();

            if (_result != true)
            {
                throw new Exception("Güncelleme Yapılamadı.");
            }
        }

        public Customer GetByIdentityAndPlate(string Plate, string IdentityNumber)
        {
            Customer c = new Customer();
            c = _uof.CustomerRepository.GetAll()
                .Where(x => x.IdentityNo == IdentityNumber && x.Plate == Plate).FirstOrDefault();
             
            return c;
        }
    }
}
