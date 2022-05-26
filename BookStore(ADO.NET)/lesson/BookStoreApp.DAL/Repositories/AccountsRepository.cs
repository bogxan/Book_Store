using BookStoreApp.DAL.EF;
using BookStoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookStoreApp.DAL.Repositories
{
    public class AccountsRepository : BaseRepository<Account>
    {
        public AccountsRepository(StoreContext context) : base(context) { }
        public bool GetAccountByLoginPassword(Account account)
        {
            return db.Accounts.Any(acc => acc.Login.Equals(account.Login) && acc.Password.Equals(account.Password));
        }
        public override void Update(Account entity)
        {
            var updateAccount = Get(entity.Id);
            updateAccount.Login = entity.Login;
            updateAccount.Password = entity.Password;
        }
    }
}
