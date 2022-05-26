using BookStoreApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderDto order);
        void DeleteOrder(int id);
        void UpdateOrder(OrderDto order);
    }
}
