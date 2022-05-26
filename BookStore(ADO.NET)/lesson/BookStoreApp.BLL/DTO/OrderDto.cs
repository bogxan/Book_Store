using BookStoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int CountBooks { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int BookId { get; set; }
    }
}
