using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Book Book { get; set; }
        public int CountBooks { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int BookId { get; set; }
    }
}
