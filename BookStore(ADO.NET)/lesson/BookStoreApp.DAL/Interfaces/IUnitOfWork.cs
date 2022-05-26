using BookStoreApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public AccountsRepository AccountsRepository { get; }
        public BooksRepository BooksRepository { get; }
        public OrdersRepository OrdersRepository { get; }
        void Save();
    }
}
