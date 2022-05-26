using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Entities
{
    public class Account: BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
