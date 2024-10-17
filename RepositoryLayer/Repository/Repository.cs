using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEnity
    {
        #region property;

        readonly DemoDbContext ctx;

        DbSet<T> entities;
        #endregion
        #region constructor
        public Repository(DemoDbContext ctx)
        {
            this.ctx = ctx;
            entities = ctx.Set<T>();
        }
        #endregion

        public void Delete(T entity) {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            ctx.SaveChanges();
        }
        public T Get (int id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll() { 
            return entities.AsEnumerable();
        }

        public void Insert(T entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            ctx.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Enity");
            }
            entities.Add(entity);
        }
        public void Update(T entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            ctx.SaveChanges();
        }
        public void SaveChanges()
        {
            ctx.SaveChanges();
        }
    }
}
