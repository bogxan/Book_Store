using BookStoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
