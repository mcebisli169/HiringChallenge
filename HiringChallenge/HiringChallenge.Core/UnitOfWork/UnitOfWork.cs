using HiringChallenge.Core.Data;
using HiringChallenge.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _challengeContext;
        public UnitOfWork(ChallengeContext challengeContext)
        {
            _challengeContext = challengeContext;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _challengeContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_challengeContext.Database.CurrentTransaction != null && _challengeContext.Database.CurrentTransaction.TransactionId != null)
                _challengeContext.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _challengeContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_challengeContext);
        }

        public void RollbackTransaction()
        {
            if (_challengeContext.Database.CurrentTransaction != null && _challengeContext.Database.CurrentTransaction.TransactionId != null)
                _challengeContext.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _challengeContext.SaveChanges();
        }
    }
}
