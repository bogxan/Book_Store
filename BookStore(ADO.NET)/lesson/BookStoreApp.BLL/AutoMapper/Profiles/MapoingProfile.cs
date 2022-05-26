using AutoMapper;
using BookStoreApp.BLL.DTO;
using BookStoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.AutoMapper.Profiles
{
    public class MapoingProfile: Profile
    {
        public MapoingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
