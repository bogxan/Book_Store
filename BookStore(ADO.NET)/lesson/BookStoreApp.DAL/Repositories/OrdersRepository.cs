using BookStoreApp.DAL.EF;
using BookStoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(StoreContext context) : base(context) { }
        public override void Update(Order entity)
        {
            var updateOrder = Get(entity.Id);
            updateOrder.BookId = entity.BookId;
            updateOrder.CountBooks = entity.CountBooks;
            updateOrder.OrderDate = entity.OrderDate;
            updateOrder.Price = entity.Price;
        }
    }
}
