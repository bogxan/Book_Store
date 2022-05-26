﻿using AutoMapper;
using BookStoreApp.BLL.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.AutoMapper
{
    public class ObjectMapper
    {
        private IMapper mapper;
        private static ObjectMapper _instance;
        public static ObjectMapper Instance => _instance ?? (_instance = new ObjectMapper());
        public IMapper Mapper => mapper;
        private ObjectMapper()
        {
            var mapCnfg = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile(new MapoingProfile());
            });
            mapper = mapCnfg.CreateMapper();
        }
    }
}
