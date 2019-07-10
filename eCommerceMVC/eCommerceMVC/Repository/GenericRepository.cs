using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using eCommerceMVC.Models;
using System.Linq.Expressions;
using eCommerceMVC.Repository;

namespace eCommerceMVC.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
    {
        private JooleEntities _dbcontext;
        private DbSet<TEntity> dbset;
        public GenericRepository(JooleEntities dbcontext) {
            this._dbcontext = dbcontext;
            this.dbset = _dbcontext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters) {
            return dbset.SqlQuery(query, parameters).ToList();
        }
        public IQueryable<TEntity> GetAll() {
            return dbset.AsNoTracking();
        }
        public TEntity GetById(object id) {
            return dbset.Find(id);
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }
            if (filter != null) query = query.Where(filter);
            if (orderBy != null) return orderBy(query).ToList();
            else return query.ToList();
        }
        public void Insert(TEntity entity) {
            dbset.Add(entity);
        }
        public void Delete(object id) {
            TEntity entityToDelete = dbset.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(TEntity entityToDelete) {
            if (_dbcontext.Entry(entityToDelete).State == EntityState.Detached) dbset.Attach(entityToDelete);
            dbset.Remove(entityToDelete);
        }
        public void Update(TEntity entityToUpdate) {
            dbset.Attach(entityToUpdate);
            _dbcontext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}