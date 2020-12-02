using DataAccesLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class UnitOfWork
    {
        public SqlContext _sqlContext;
        public UnitOfWork()
        {
            _sqlContext = new SqlContext();
        }

        private BidRepository _BidRepository;

        public BidRepository BidRepository
        {
            get
            {
                if (_BidRepository == null)
                {
                    _BidRepository = new BidRepository(_sqlContext);
                }
                return _BidRepository;
            }
        }


        private CustomerRepository _CustomerRepository;

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (_CustomerRepository == null)
                {
                    _CustomerRepository = new CustomerRepository(_sqlContext);
                }
                return _CustomerRepository;
            }
        }




        public bool ApplyChanges()
        {
            DbContextTransaction _transaction;
            bool isSuccess = false;
            _transaction = _sqlContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                _sqlContext.SaveChanges();
                _transaction.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                isSuccess = false;
            }
            finally
            {
                _transaction.Dispose();
            }
            return isSuccess;
        }

    }
}
