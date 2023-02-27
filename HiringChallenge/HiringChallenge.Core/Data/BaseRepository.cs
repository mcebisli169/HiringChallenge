using HiringChallenge.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace HiringChallenge.Core.Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        ChallengeContext _db;
        DbSet<T> _table;
        public BaseRepository(ChallengeContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }
        public void Add(T item)
        {
            _table.Add(item);
        }

        public void Delete(int id)
        {
            T item = GetById(id);
            item.RowStatus = RowStatus.Passive;
            item.ModifiedDate = DateTime.Now;
            _table.Update(item);
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _table.AsNoTracking().FirstOrDefault(s=>s.Id==id);
        }

        public void Update(T item)
        {
            item.RowStatus = RowStatus.Active;
            item.ModifiedDate = DateTime.Now;
            _table.Update(item);
        }
    }
}
