using System.Data.Entity;
using System.Transactions;
using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly HCalcEntities _db;

        public UnitOfWork()
        {
            _db = new HCalcEntities();
        }

        public void Dispose()
        {
           
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }
    }
}