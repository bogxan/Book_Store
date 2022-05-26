using BookStoreApp.BLL.DTO;
using BookStoreApp.BLL.Interfaces;
using BookStoreApp.DAL.Entities;
using BookStoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.Services
{
    public class AccountsService : IAccountService
    {
        private IUnitOfWork uow;
        private AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public AccountsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void AddAccount(AccountDto account)
        {
            var result = objectManager.Mapper.Map<Account>(account);
            uow.AccountsRepository.Create(result);
            uow.Save();
        }

        public void DeleteAccount(int id)
        {
            var result = uow.AccountsRepository.Get(id);
            uow.AccountsRepository.Delete(result.Id);
            uow.Save();
        }

        public bool GetAccountByLoginPassword(AccountDto account)
        {
            return uow.AccountsRepository.GetAccountByLoginPassword(objectManager.Mapper.Map<Account>(account));
        }

        public void UpdateAccount(AccountDto account)
        {
            var result = objectManager.Mapper.Map<Account>(account);
            uow.AccountsRepository.Update(result);
            uow.Save();
        }
    }
}
