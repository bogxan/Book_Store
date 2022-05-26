using BookStoreApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(AccountDto account);
        void DeleteAccount(int id);
        void UpdateAccount(AccountDto account);
        bool GetAccountByLoginPassword(AccountDto account);
    }
}
