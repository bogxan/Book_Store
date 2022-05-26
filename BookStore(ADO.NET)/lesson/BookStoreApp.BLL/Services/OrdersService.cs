using BookStoreApp.BLL.DTO;
using BookStoreApp.BLL.Interfaces;
using BookStoreApp.DAL.Entities;
using BookStoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.Services
{
    public class OrdersService : IOrderService
    {
        private IUnitOfWork uow;
        private AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public OrdersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void AddOrder(OrderDto order)
        {
            var result = objectManager.Mapper.Map<Order>(order);
            uow.OrdersRepository.Create(result);
            uow.Save();
        }

        public void DeleteOrder(int id)
        {
            var result = uow.OrdersRepository.Get(id);
            uow.OrdersRepository.Delete(result.Id);
            uow.Save();
        }

        public void UpdateOrder(OrderDto order)
        {
            var result = objectManager.Mapper.Map<Order>(order);
            uow.OrdersRepository.Update(result);
            uow.Save();
        }
    }
}
