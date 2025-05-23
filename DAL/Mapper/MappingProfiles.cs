using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace DAL.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductsEntity, ProductsDTO>();
            CreateMap<OrdersEntity, OrdersDTO>();
            CreateMap<CustomersEntity, CustomersDTO>();
            CreateMap<EmployeesEntity, EmployeesDTO>();

            CreateMap<ProductsEntity, ProductsDTO>().ReverseMap();
            CreateMap<OrdersEntity, OrdersDTO>().ReverseMap();
            CreateMap<CustomersEntity, CustomersDTO>().ReverseMap();
            CreateMap<EmployeesEntity, EmployeesDTO>().ReverseMap();
        }
    }
}
