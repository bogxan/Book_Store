using BookStoreApp.DAL.EF;
using BookStoreApp.DAL.Entities;
using BookStoreApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreApp.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected StoreContext db;
        DbSet<T> Table => db.Set<T>();
        public BaseRepository(StoreContext context)
        {
            db = context;
        }

        public virtual void Create(T entity)
        {
            Table.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            Table.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return Table.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public virtual List<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual List<T> GetAll(Func<T, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }


        public abstract void Update(T entity);
    }
}
