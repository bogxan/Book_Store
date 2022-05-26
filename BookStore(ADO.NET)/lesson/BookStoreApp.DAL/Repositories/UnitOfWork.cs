using BookStoreApp.DAL.EF;
using BookStoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreContext db;
        private AccountsRepository _AccountsRepository;
        private BooksRepository _BooksRepository;
        private OrdersRepository _OrdersRepository;
        public AccountsRepository AccountsRepository => 
            _AccountsRepository??(_AccountsRepository=new AccountsRepository(db));

        public BooksRepository BooksRepository => 
            _BooksRepository??(_BooksRepository=new BooksRepository(db));

        public OrdersRepository OrdersRepository => 
            _OrdersRepository??(_OrdersRepository=new OrdersRepository(db));
        public UnitOfWork(string connectionstring)
        {
            db = new StoreContext(connectionstring);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
